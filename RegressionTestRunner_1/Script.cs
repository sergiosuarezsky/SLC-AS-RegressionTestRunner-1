/*
****************************************************************************
*  Copyright (c) 2022,  Skyline Communications NV  All Rights Reserved.    *
****************************************************************************

By using this script, you expressly agree with the usage terms and
conditions set out below.
This script and all related materials are protected by copyrights and
other intellectual property rights that exclusively belong
to Skyline Communications.

A user license granted for this script is strictly for personal use only.
This script may not be used in any way by anyone without the prior
written consent of Skyline Communications. Any sublicensing of this
script is forbidden.

Any modifications to this script by the user are only allowed for
personal use and within the intended purpose of the script,
and will remain the sole responsibility of the user.
Skyline Communications will not be responsible for any damages or
malfunctions whatsoever of the script resulting from a modification
or adaptation by the user.

The content of this script is confidential information.
The user hereby agrees to keep this confidential information strictly
secret and confidential and not to disclose or reveal it, in whole
or in part, directly or indirectly to any person, entity, organization
or administration without the prior written consent of
Skyline Communications.

Any inquiries can be addressed to:

	Skyline Communications NV
	Ambachtenstraat 33
	B-8870 Izegem
	Belgium
	Tel.	: +32 51 31 35 69
	Fax.	: +32 51 31 01 29
	E-mail	: info@skyline.be
	Web		: www.skyline.be
	Contact	: Ben Vandenberghe

****************************************************************************
Revision History:

DATE		VERSION		AUTHOR			COMMENTS

dd/mm/2022	1.0.0.1		XXX, Skyline	Initial version
****************************************************************************
*/

namespace RegressionTestRunner
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using RegressionTestRunner.AutomationScripts;
	using RegressionTestRunner.Dialogs;
	using RegressionTestRunner.Helpers;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit;
	using Skyline.DataMiner.Library.Automation;

	public class Script
	{
		private const string ScriptConfigurationParamName = "ScriptConfiguration";

		private InteractiveController app;
		private IEngine engine;
		private RegressionTestManager regressionTestManager;

		private ScriptSelectionDialog scriptSelectionDialog;
		private AgentSelectionDialog agentSelectionDialog;
		private ConfirmationDialog confirmationDialog;
		private MessageDialog noTestsSelectedDialog;
		private ProgressDialog progressDialog;
		private ReportDialog reportDialog;

		/// <summary>
		/// The Script entry point.
		/// Engine.ShowUI();
		/// </summary>
		/// <param name="engine">Link with SLScripting process.</param>
		public void Run(Engine engine)
		{
			try
			{
				engine.SetFlag(RunTimeFlags.NoKeyCaching);
				engine.Timeout = TimeSpan.FromHours(10);
				RunSafe(engine);
			}
			catch (ScriptAbortException)
			{
				throw;
			}
			catch (Exception e)
			{
				engine.Log(nameof(Script), nameof(Run), $"Something went wrong: {e}");
				ShowExceptionDialog(engine, e);
			}
		}

		private void RunSafe(IEngine engine)
		{
			this.engine = engine;

			string serializedConfig = engine.GetScriptParam(ScriptConfigurationParamName)?.Value;
			if (!ScriptConfiguration.TryDeserialize(serializedConfig, out ScriptConfiguration scriptConfiguration))
			{
				RunInteractive();
			}
			else
			{
				RunSilent(scriptConfiguration);
			}
		}

		private void RunSilent(ScriptConfiguration scriptConfiguration)
		{
			HashSet<string> scripts = new HashSet<string>();

			// Get scripts from folders
			foreach (string folder in scriptConfiguration.Folders)
			{
				var directory = AutomationScriptHelper.RetrieveScripts(engine, folder, false);
				foreach (string automationScript in directory.AllAutomationScripts.Select(x => x.Name)) scripts.Add(automationScript);
			}

			// Get standalone scripts
			foreach (string automationScript in scriptConfiguration.Scripts)
			{
				scripts.Add(automationScript);
			}

			engine.Log(nameof(Script), nameof(RunSilent), $"Scripts to run: {String.Join(", ", scripts)}");

			regressionTestManager = new RegressionTestManager(engine, scripts.ToArray());
			regressionTestManager.ProgressReported += (sender, args) => engine.GenerateInformation(args.Progress);
			regressionTestManager.ProgressReported += (sender, args) => engine.Log(args.Progress);
			regressionTestManager.Run();
		}

		private void RunInteractive()
		{
			app = new InteractiveController(engine);

			// Define dialogs here
			scriptSelectionDialog = new ScriptSelectionDialog(engine);
			scriptSelectionDialog.SelectAgentButton.Pressed += (s, e) => app.ShowDialog(agentSelectionDialog);
			scriptSelectionDialog.OkButton.Pressed += (s, e) => engine.ExitSuccess("No tests available");

			var agents = engine.GetDms().GetAgents().Where(x => x.State == Skyline.DataMiner.Library.Common.AgentState.Running);
			agentSelectionDialog = new AgentSelectionDialog(engine, agents);
			agentSelectionDialog.BackButton.Pressed += (s, e) => app.ShowDialog(scriptSelectionDialog);
			agentSelectionDialog.RunTestsButton.Pressed += (s, e) => VerifySelectedTests();

			confirmationDialog = new ConfirmationDialog(engine) { Title = "Run Tests" };
			confirmationDialog.NoButton.Pressed += (s, e) => app.ShowDialog(scriptSelectionDialog);
			confirmationDialog.YesButton.Pressed += (s, e) => RunRegressionTests();

			noTestsSelectedDialog = new MessageDialog(engine, "No regression tests selected");
			noTestsSelectedDialog.OkButton.Pressed += (s, e) => app.ShowDialog(scriptSelectionDialog);

			app.Run(scriptSelectionDialog);
		}

		private void RunRegressionTests()
		{
			progressDialog = new ProgressDialog(engine) { Title = "Run Tests" };
			progressDialog.OkButton.Pressed += (s, e) => ShowReportDialog();

			app.ShowDialog(progressDialog);

			regressionTestManager = new RegressionTestManager(engine, agentSelectionDialog.SelectedAgent, scriptSelectionDialog.SelectedScripts.Select(x => x.Name).ToArray());
			regressionTestManager.ProgressReported += (s, e) => progressDialog.AddProgressLine(e.Progress);

			regressionTestManager.Run();

			progressDialog.Finish();
			app.ShowDialog(progressDialog);
		}

		private void ShowReportDialog()
		{
			reportDialog = new ReportDialog(engine, regressionTestManager);
			reportDialog.PerformAdditionalTestsButton.Pressed += (s, e) => app.ShowDialog(scriptSelectionDialog);
			reportDialog.FinishButton.Pressed += (s, e) => engine.ExitSuccess("Finished");

			app.ShowDialog(reportDialog);
		}

		private void VerifySelectedTests()
		{
			if (!scriptSelectionDialog.SelectedScripts.Any())
			{
				app.ShowDialog(noTestsSelectedDialog);
				return;
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Are you sure you want to run the following tests on agent {agentSelectionDialog.SelectedAgent.GetDisplayName()}?");
			foreach (var script in scriptSelectionDialog.SelectedScripts)
			{
				sb.AppendLine($"\t- {script.Name}");
			}

			confirmationDialog.Message = sb.ToString();
			app.ShowDialog(confirmationDialog);
		}

		private void ShowExceptionDialog(Engine engine, Exception exception)
		{
			ExceptionDialog dialog = new ExceptionDialog(engine, exception);
			dialog.OkButton.Pressed += (sender, args) => engine.ExitFail("Something went wrong during the creation of the new event.");
			if (app.IsRunning) app.ShowDialog(dialog); else app.Run(dialog);
		}
	}
}