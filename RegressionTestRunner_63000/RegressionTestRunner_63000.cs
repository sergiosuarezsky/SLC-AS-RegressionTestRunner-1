// --- auto-generated code --- do not modify ---

/*
{{StartPackageInfo}}
<PackageInfo xmlns="http://www.skyline.be/ClassLibrary">
	<BasePackage>
		<Identity>
			<Name>Class Library</Name>
			<Version>1.2.0.11</Version>
		</Identity>
	</BasePackage>
	<CustomPackages>
		<Package>
			<Identity>
				<Name>InteractiveAutomationToolkit</Name>
				<Version>1.0.6.5</Version>
			</Identity>
		</Package>
	</CustomPackages>
</PackageInfo>
{{EndPackageInfo}}
*/

namespace Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit
{
    /// <summary>
    ///     Event loop of the interactive Automation script.
    /// </summary>
    public class InteractiveController
    {
        private bool isManualModeRequested;
        private System.Action manualAction;
        private Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog nextDialog;
        /// <summary>
        ///     Initializes a new instance of the <see cref = "InteractiveController"/> class.
        ///     This object will manage the event loop of the interactive Automation script.
        /// </summary>
        /// <param name = "engine">Link with the SLAutomation process.</param>
        /// <exception cref = "ArgumentNullException">When engine is null.</exception>
        public InteractiveController(Skyline.DataMiner.Automation.IEngine engine)
        {
            if (engine == null)
            {
                throw new System.ArgumentNullException("engine");
            }

            Engine = engine;
        }

        /// <summary>
        ///     Gets the dialog that is shown to the user.
        /// </summary>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog CurrentDialog
        {
            get;
            private set;
        }

        /// <summary>
        ///     Gets the link to the SLManagedAutomation process.
        /// </summary>
        public Skyline.DataMiner.Automation.IEngine Engine
        {
            get;
            private set;
        }

        /// <summary>
        ///     Gets a value indicating whether the event loop is updated manually or automatically.
        /// </summary>
        public bool IsManualMode
        {
            get;
            private set;
        }

        /// <summary>
        ///     Gets a value indicating whether the event loop has been started.
        /// </summary>
        public bool IsRunning
        {
            get;
            private set;
        }

        /// <summary>
        ///     Starts the application event loop.
        ///     Updates the displayed dialog after each user interaction.
        ///     Only user interaction on widgets with the WantsOnChange property set to true will cause updates.
        ///     Use <see cref = "RequestManualMode"/> if you want to manually control when the dialog is updated.
        /// </summary>
        /// <param name = "startDialog">Dialog to be shown first.</param>
        public void Run(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog startDialog)
        {
            if (startDialog == null)
            {
                throw new System.ArgumentNullException("startDialog");
            }

            nextDialog = startDialog;
            if (IsRunning)
            {
                throw new System.InvalidOperationException("Already running");
            }

            IsRunning = true;
            while (true)
            {
                try
                {
                    if (isManualModeRequested)
                    {
                        RunManualAction();
                    }
                    else
                    {
                        CurrentDialog = nextDialog;
                        CurrentDialog.Show();
                    }
                }
                catch (System.Exception)
                {
                    IsRunning = false;
                    IsManualMode = false;
                    throw;
                }
            }
        }

        /// <summary>
        ///     Sets the dialog that will be shown after user interaction events are processed,
        ///     or when <see cref = "Update"/> is called in manual mode.
        /// </summary>
        /// <param name = "dialog">The next dialog to be shown.</param>
        /// <exception cref = "ArgumentNullException">When dialog is null.</exception>
        public void ShowDialog(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog dialog)
        {
            if (dialog == null)
            {
                throw new System.ArgumentNullException("dialog");
            }

            nextDialog = dialog;
        }

        private void RunManualAction()
        {
            isManualModeRequested = false;
            IsManualMode = true;
            manualAction();
            IsManualMode = false;
        }
    }

    internal static class UiResultsExtensions
    {
        public static bool GetChecked(this Skyline.DataMiner.Automation.UIResults uiResults, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.CheckBox checkBox)
        {
            return uiResults.GetChecked(checkBox.DestVar);
        }

        public static string GetString(this Skyline.DataMiner.Automation.UIResults uiResults, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget interactiveWidget)
        {
            return uiResults.GetString(interactiveWidget.DestVar);
        }

        public static bool WasButtonPressed(this Skyline.DataMiner.Automation.UIResults uiResults, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Button button)
        {
            return uiResults.WasButtonPressed(button.DestVar);
        }

        public static bool WasCollapseButtonPressed(this Skyline.DataMiner.Automation.UIResults uiResults, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.CollapseButton button)
        {
            return uiResults.WasButtonPressed(button.DestVar);
        }

        public static System.Collections.Generic.IEnumerable<System.String> GetExpandedItemKeys(this Skyline.DataMiner.Automation.UIResults uiResults, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TreeView treeView)
        {
            string[] expandedItems = uiResults.GetExpanded(treeView.DestVar);
            if (expandedItems == null)
                return new string[0];
            return System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(expandedItems, x => !System.String.IsNullOrWhiteSpace(x)));
        }

        public static System.Collections.Generic.IEnumerable<System.String> GetCheckedItemKeys(this Skyline.DataMiner.Automation.UIResults uiResults, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TreeView treeView)
        {
            string result = uiResults.GetString(treeView.DestVar);
            if (System.String.IsNullOrEmpty(result))
                return new string[0];
            return result.Split(new char[]{';'}, System.StringSplitOptions.RemoveEmptyEntries);
        }
    }

    /// <summary>
    ///     A button that can be pressed.
    /// </summary>
    public class Button : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget
    {
        private bool pressed;
        /// <summary>
        ///     Initializes a new instance of the <see cref = "Button"/> class.
        /// </summary>
        /// <param name = "text">Text displayed in the button.</param>
        public Button(string text)
        {
            Type = Skyline.DataMiner.Automation.UIBlockType.Button;
            Text = text;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref = "Button"/> class.
        /// </summary>
        public Button(): this(System.String.Empty)
        {
        }

        /// <summary>
        ///     Gets or sets the tooltip.
        /// </summary>
        /// <exception cref = "ArgumentNullException">When the value is <c>null</c>.</exception>
        public string Tooltip
        {
            get
            {
                return BlockDefinition.TooltipText;
            }

            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("value");
                }

                BlockDefinition.TooltipText = value;
            }
        }

        /// <summary>
        ///     Triggered when the button is pressed.
        ///     WantsOnChange will be set to true when this event is subscribed to.
        /// </summary>
        public event System.EventHandler<System.EventArgs> Pressed
        {
            add
            {
                OnPressed += value;
                WantsOnChange = true;
            }

            remove
            {
                OnPressed -= value;
                if (OnPressed == null || !System.Linq.Enumerable.Any(OnPressed.GetInvocationList()))
                {
                    WantsOnChange = false;
                }
            }
        }

        private event System.EventHandler<System.EventArgs> OnPressed;
        /// <summary>
        ///     Gets or sets the text displayed in the button.
        /// </summary>
        public string Text
        {
            get
            {
                return BlockDefinition.Text;
            }

            set
            {
                BlockDefinition.Text = value;
            }
        }

        internal override void LoadResult(Skyline.DataMiner.Automation.UIResults uiResults)
        {
            pressed = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.UiResultsExtensions.WasButtonPressed(uiResults, this);
        }

        /// <inheritdoc/>
        internal override void RaiseResultEvents()
        {
            if ((OnPressed != null) && pressed)
            {
                OnPressed(this, System.EventArgs.Empty);
            }

            pressed = false;
        }
    }

    /// <summary>
    ///     A checkbox that can be selected or cleared.
    /// </summary>
    public class CheckBox : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget
    {
        private bool changed;
        private bool isChecked;
        /// <summary>
        ///     Initializes a new instance of the <see cref = "CheckBox"/> class.
        /// </summary>
        /// <param name = "text">Text displayed next to the checkbox.</param>
        public CheckBox(string text)
        {
            Type = Skyline.DataMiner.Automation.UIBlockType.CheckBox;
            IsChecked = false;
            Text = text;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref = "CheckBox"/> class.
        /// </summary>
        public CheckBox(): this(System.String.Empty)
        {
        }

        /// <summary>
        ///     Triggered when the state of the checkbox changes.
        ///     WantsOnChange will be set to true when this event is subscribed to.
        /// </summary>
        public event System.EventHandler<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.CheckBox.CheckBoxChangedEventArgs> Changed
        {
            add
            {
                OnChanged += value;
                WantsOnChange = true;
            }

            remove
            {
                OnChanged -= value;
                bool noOnChangedEvents = OnChanged == null || !System.Linq.Enumerable.Any(OnChanged.GetInvocationList());
                bool noOnCheckedEvents = OnChecked == null || !System.Linq.Enumerable.Any(OnChecked.GetInvocationList());
                bool noOnUnCheckedEvents = OnUnChecked == null || !System.Linq.Enumerable.Any(OnUnChecked.GetInvocationList());
                if (noOnChangedEvents && noOnCheckedEvents && noOnUnCheckedEvents)
                {
                    WantsOnChange = false;
                }
            }
        }

        private event System.EventHandler<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.CheckBox.CheckBoxChangedEventArgs> OnChanged;
        private event System.EventHandler<System.EventArgs> OnChecked;
        private event System.EventHandler<System.EventArgs> OnUnChecked;
        /// <summary>
        ///     Gets or sets a value indicating whether the checkbox is selected.
        /// </summary>
        public bool IsChecked
        {
            get
            {
                return isChecked;
            }

            set
            {
                isChecked = value;
                BlockDefinition.InitialValue = value.ToString();
            }
        }

        /// <summary>
        ///     Gets or sets the displayed text next to the checkbox.
        /// </summary>
        public string Text
        {
            get
            {
                return BlockDefinition.Text;
            }

            set
            {
                BlockDefinition.Text = value;
            }
        }

        /// <summary>
        ///     Gets or sets the tooltip.
        /// </summary>
        /// <exception cref = "ArgumentNullException">When the value is <c>null</c>.</exception>
        public string Tooltip
        {
            get
            {
                return BlockDefinition.TooltipText;
            }

            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("value");
                }

                BlockDefinition.TooltipText = value;
            }
        }

        internal override void LoadResult(Skyline.DataMiner.Automation.UIResults uiResults)
        {
            bool result = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.UiResultsExtensions.GetChecked(uiResults, this);
            if (WantsOnChange)
            {
                changed = result != IsChecked;
            }

            IsChecked = result;
        }

        /// <inheritdoc/>
        internal override void RaiseResultEvents()
        {
            if (!changed)
            {
                return;
            }

            if (OnChanged != null)
            {
                OnChanged(this, new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.CheckBox.CheckBoxChangedEventArgs(IsChecked));
            }

            if ((OnChecked != null) && IsChecked)
            {
                OnChecked(this, System.EventArgs.Empty);
            }

            if ((OnUnChecked != null) && !IsChecked)
            {
                OnUnChecked(this, System.EventArgs.Empty);
            }

            changed = false;
        }

        /// <summary>
        ///     Provides data for the <see cref = "Changed"/> event.
        /// </summary>
        public class CheckBoxChangedEventArgs : System.EventArgs
        {
            internal CheckBoxChangedEventArgs(bool isChecked)
            {
                IsChecked = isChecked;
            }

            /// <summary>
            ///     Gets a value indicating whether the checkbox has been checked.
            /// </summary>
            public bool IsChecked
            {
                get;
                private set;
            }
        }
    }

    /// <summary>
    ///		A button that can be used to show/hide a collection of widgets.
    /// </summary>
    public class CollapseButton : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget
    {
        private const string COLLAPSE = "Collapse";
        private const string EXPAND = "Expand";
        private string collapseText;
        private string expandText;
        private bool pressed;
        private bool isCollapsed;
        /// <summary>
        /// Initializes a new instance of the CollapseButton class.
        /// </summary>
        /// <param name = "linkedWidgets">Widgets that are linked to this collapse button.</param>
        /// <param name = "isCollapsed">State of the collapse button.</param>
        public CollapseButton(System.Collections.Generic.IEnumerable<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget> linkedWidgets, bool isCollapsed)
        {
            Type = Skyline.DataMiner.Automation.UIBlockType.Button;
            LinkedWidgets = new System.Collections.Generic.List<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget>(linkedWidgets);
            CollapseText = COLLAPSE;
            ExpandText = EXPAND;
            IsCollapsed = isCollapsed;
            WantsOnChange = true;
        }

        /// <summary>
        /// Initializes a new instance of the CollapseButton class.
        /// </summary>
        /// <param name = "isCollapsed">State of the collapse button.</param>
        public CollapseButton(bool isCollapsed = false): this(new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget[0], isCollapsed)
        {
        }

        /// <summary>
        ///     Triggered when the button is pressed.
        ///     WantsOnChange will be set to true when this event is subscribed to.
        /// </summary>
        public event System.EventHandler<System.EventArgs> Pressed
        {
            add
            {
                OnPressed += value;
            }

            remove
            {
                OnPressed -= value;
            }
        }

        private event System.EventHandler<System.EventArgs> OnPressed;
        /// <summary>
        /// Indicates if the collapse button is collapsed or not.
        /// If the collapse button is collapsed, the IsVisible property of all linked widgets is set to false.
        /// If the collapse button is not collapsed, the IsVisible property of all linked widgets is set to true.
        /// </summary>
        public bool IsCollapsed
        {
            get
            {
                return isCollapsed;
            }

            set
            {
                isCollapsed = value;
                BlockDefinition.Text = value ? ExpandText : CollapseText;
                foreach (Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget in GetAffectedWidgets(this, value))
                {
                    widget.IsVisible = !value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the text to be displayed in the collapse button when the button is expanded.
        /// </summary>
        public string CollapseText
        {
            get
            {
                return collapseText;
            }

            set
            {
                if (System.String.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentException("The Collapse text cannot be empty.");
                collapseText = value;
                if (!IsCollapsed)
                    BlockDefinition.Text = collapseText;
            }
        }

        /// <summary>
        ///     Gets or sets the tooltip.
        /// </summary>
        /// <exception cref = "ArgumentNullException">When the value is <c>null</c>.</exception>
        public string Tooltip
        {
            get
            {
                return BlockDefinition.TooltipText;
            }

            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("value");
                }

                BlockDefinition.TooltipText = value;
            }
        }

        /// <summary>
        /// Gets or sets the text to be displayed in the collapse button when the button is collapsed.
        /// </summary>
        public string ExpandText
        {
            get
            {
                return expandText;
            }

            set
            {
                if (System.String.IsNullOrWhiteSpace(value))
                    throw new System.ArgumentException("The Expand text cannot be empty.");
                expandText = value;
                if (IsCollapsed)
                    BlockDefinition.Text = expandText;
            }
        }

        /// <summary>
        /// Collection of widgets that are affected by this collapse button.
        /// </summary>
        public System.Collections.Generic.List<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget> LinkedWidgets
        {
            get;
            private set;
        }

        /// <summary>
        /// This method is used to collapse the collapse button.
        /// </summary>
        public void Collapse()
        {
            IsCollapsed = true;
        }

        /// <summary>
        /// This method is used to expand the collapse button.
        /// </summary>
        public void Expand()
        {
            IsCollapsed = false;
        }

        internal override void LoadResult(Skyline.DataMiner.Automation.UIResults uiResults)
        {
            pressed = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.UiResultsExtensions.WasCollapseButtonPressed(uiResults, this);
        }

        internal override void RaiseResultEvents()
        {
            if (pressed)
            {
                IsCollapsed = !IsCollapsed;
                if (OnPressed != null)
                    OnPressed(this, System.EventArgs.Empty);
            }

            pressed = false;
        }

        /// <summary>
        /// Retrieves a list of Widgets that are affected when the state of the provided collapse button is changed.
        /// This method was introduced to support nested collapse buttons.
        /// </summary>
        /// <param name = "collapseButton">Collapse button that is checked.</param>
        /// <param name = "collapse">Indicates if the top collapse button is going to be collapsed or expanded.</param>
        /// <returns>List of affected widgets.</returns>
        private static System.Collections.Generic.List<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget> GetAffectedWidgets(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.CollapseButton collapseButton, bool collapse)
        {
            System.Collections.Generic.List<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget> affectedWidgets = new System.Collections.Generic.List<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget>();
            affectedWidgets.AddRange(collapseButton.LinkedWidgets);
            var nestedCollapseButtons = System.Linq.Enumerable.OfType<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.CollapseButton>(collapseButton.LinkedWidgets);
            foreach (Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.CollapseButton nestedCollapseButton in nestedCollapseButtons)
            {
                if (collapse)
                {
                    // Collapsing top collapse button
                    affectedWidgets.AddRange(GetAffectedWidgets(nestedCollapseButton, collapse));
                }
                else if (!nestedCollapseButton.IsCollapsed)
                {
                    // Expanding top collapse button
                    affectedWidgets.AddRange(GetAffectedWidgets(nestedCollapseButton, collapse));
                }
            }

            return affectedWidgets;
        }
    }

    /// <summary>
    /// A widget that requires user input.
    /// </summary>
    public abstract class InteractiveWidget : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget
    {
        /// <summary>
        /// Initializes a new instance of the InteractiveWidget class.
        /// </summary>
        protected InteractiveWidget()
        {
            BlockDefinition.DestVar = System.Guid.NewGuid().ToString();
            WantsOnChange = false;
        }

        /// <summary>
        ///     Gets the alias that will be used to retrieve the value entered or selected by the user from the UIResults object.
        /// </summary>
        /// <remarks>Use methods <see cref = "UiResultsExtensions"/> to retrieve the result instead.</remarks>
        internal string DestVar
        {
            get
            {
                return BlockDefinition.DestVar;
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the control is enabled in the UI.
        ///     Disabling causes the widgets to be grayed out and disables user interaction.
        /// </summary>
        /// <remarks>Available from DataMiner 9.5.3 onwards.</remarks>
        public bool IsEnabled
        {
            get
            {
                return BlockDefinition.IsEnabled;
            }

            set
            {
                BlockDefinition.IsEnabled = value;
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether an update of the current value of the dialog box item will trigger an
        ///     event.
        /// </summary>
        /// <remarks>Is <c>false</c> by default except for <see cref = "Button"/>.</remarks>
        public bool WantsOnChange
        {
            get
            {
                return BlockDefinition.WantsOnChange;
            }

            set
            {
                BlockDefinition.WantsOnChange = value;
            }
        }

        internal abstract void LoadResult(Skyline.DataMiner.Automation.UIResults uiResults);
        internal abstract void RaiseResultEvents();
    }

    /// <summary>
    ///     A label is used to display text.
    ///     Text can have different styles.
    /// </summary>
    public class Label : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget
    {
        private Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TextStyle style;
        /// <summary>
        ///     Initializes a new instance of the <see cref = "Label"/> class.
        /// </summary>
        /// <param name = "text">The text that is displayed by the label.</param>
        public Label(string text)
        {
            Type = Skyline.DataMiner.Automation.UIBlockType.StaticText;
            Style = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TextStyle.None;
            Text = text;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref = "Label"/> class.
        /// </summary>
        public Label(): this("Label")
        {
        }

        /// <summary>
        ///     Gets or sets the text style of the label.
        /// </summary>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TextStyle Style
        {
            get
            {
                return style;
            }

            set
            {
                style = value;
                BlockDefinition.Style = StyleToUiString(value);
            }
        }

        /// <summary>
        ///     Gets or sets the displayed text.
        /// </summary>
        public string Text
        {
            get
            {
                return BlockDefinition.Text;
            }

            set
            {
                BlockDefinition.Text = value;
            }
        }

        /// <summary>
        ///     Gets or sets the tooltip.
        /// </summary>
        /// <exception cref = "ArgumentNullException">When the value is <c>null</c>.</exception>
        public string Tooltip
        {
            get
            {
                return BlockDefinition.TooltipText;
            }

            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("value");
                }

                BlockDefinition.TooltipText = value;
            }
        }

        private static string StyleToUiString(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TextStyle textStyle)
        {
            switch (textStyle)
            {
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TextStyle.None:
                    return null;
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TextStyle.Title:
                    return "Title1";
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TextStyle.Bold:
                    return "Title2";
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TextStyle.Heading:
                    return "Title3";
                default:
                    throw new System.ArgumentOutOfRangeException("textStyle", textStyle, null);
            }
        }
    }

    /// <summary>
    /// A section is a special component that can be used to group widgets together.
    /// </summary>
    public class Section
    {
        private readonly System.Collections.Generic.Dictionary<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout> widgetLayouts = new System.Collections.Generic.Dictionary<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout>();
        private bool isEnabled = true;
        private bool isVisible = true;
        /// <summary>
        /// Number of columns that are currently defined by the widgets that have been added to this section.
        /// </summary>
        public int ColumnCount
        {
            get;
            private set;
        }

        /// <summary>
        /// Number of rows that are currently defined by the widgets that have been added to this section.
        /// </summary>
        public int RowCount
        {
            get;
            private set;
        }

        /// <summary>
        ///		Gets or sets a value indicating whether the widgets within the section are visible or not.
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return isVisible;
            }

            set
            {
                isVisible = value;
                foreach (Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget in Widgets)
                {
                    widget.IsVisible = isVisible;
                }
            }
        }

        /// <summary>
        ///		Gets or sets a value indicating whether the interactive widgets within the section are enabled or not.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set
            {
                isEnabled = value;
                foreach (Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget in Widgets)
                {
                    Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget interactiveWidget = widget as Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget;
                    if (interactiveWidget != null)
                    {
                        interactiveWidget.IsEnabled = isEnabled;
                    }
                }
            }
        }

        /// <summary>
        ///     Gets widgets that have been added to the section.
        /// </summary>
        public System.Collections.Generic.IEnumerable<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget> Widgets
        {
            get
            {
                return widgetLayouts.Keys;
            }
        }

        /// <summary>
        ///     Adds a widget to the section.
        /// </summary>
        /// <param name = "widget">Widget to add to the <see cref = "Section"/>.</param>
        /// <param name = "widgetLayout">Location of the widget in the grid layout.</param>
        /// <returns>The dialog.</returns>
        /// <exception cref = "ArgumentNullException">When the widget is null.</exception>
        /// <exception cref = "ArgumentException">When the widget has already been added to the <see cref = "Section"/>.</exception>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Section AddWidget(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout widgetLayout)
        {
            if (widget == null)
            {
                throw new System.ArgumentNullException("widget");
            }

            if (widgetLayouts.ContainsKey(widget))
            {
                throw new System.ArgumentException("Widget is already added to the section");
            }

            widgetLayouts.Add(widget, widgetLayout);
            UpdateRowAndColumnCount();
            return this;
        }

        /// <summary>
        ///     Adds a widget to the section.
        /// </summary>
        /// <param name = "widget">Widget to add to the section.</param>
        /// <param name = "row">Row location of the widget on the grid.</param>
        /// <param name = "column">Column location of the widget on the grid.</param>
        /// <param name = "horizontalAlignment">Horizontal alignment of the widget.</param>
        /// <param name = "verticalAlignment">Vertical alignment of the widget.</param>
        /// <returns>The updated section.</returns>
        /// <exception cref = "ArgumentNullException">When the widget is null.</exception>
        /// <exception cref = "ArgumentException">When the location is out of bounds of the grid.</exception>
        /// <exception cref = "ArgumentException">When the widget has already been added to the dialog.</exception>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Section AddWidget(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget, int row, int column, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment horizontalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment.Left, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment verticalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment.Center)
        {
            AddWidget(widget, new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.WidgetLayout(row, column, horizontalAlignment, verticalAlignment));
            return this;
        }

        /// <summary>
        ///     Adds a widget to the section.
        /// </summary>
        /// <param name = "widget">Widget to add to the section.</param>
        /// <param name = "fromRow">Row location of the widget on the grid.</param>
        /// <param name = "fromColumn">Column location of the widget on the grid.</param>
        /// <param name = "rowSpan">Number of rows the widget will use.</param>
        /// <param name = "colSpan">Number of columns the widget will use.</param>
        /// <param name = "horizontalAlignment">Horizontal alignment of the widget.</param>
        /// <param name = "verticalAlignment">Vertical alignment of the widget.</param>
        /// <returns>The updated section.</returns>
        /// <exception cref = "ArgumentNullException">When the widget is null.</exception>
        /// <exception cref = "ArgumentException">When the location is out of bounds of the grid.</exception>
        /// <exception cref = "ArgumentException">When the widget has already been added to the dialog.</exception>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Section AddWidget(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget, int fromRow, int fromColumn, int rowSpan, int colSpan, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment horizontalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment.Left, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment verticalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment.Center)
        {
            AddWidget(widget, new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.WidgetLayout(fromRow, fromColumn, rowSpan, colSpan, horizontalAlignment, verticalAlignment));
            return this;
        }

        /// <summary>
        ///     Gets the layout of the widget in the dialog.
        /// </summary>
        /// <param name = "widget">A widget that is part of the dialog.</param>
        /// <returns>The widget layout in the dialog.</returns>
        /// <exception cref = "NullReferenceException">When the widget is null.</exception>
        /// <exception cref = "ArgumentException">When the widget is not part of the dialog.</exception>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout GetWidgetLayout(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget)
        {
            CheckWidgetExits(widget);
            return widgetLayouts[widget];
        }

        /// <summary>
        /// Removes all widgets from the section.
        /// </summary>
        public void Clear()
        {
            widgetLayouts.Clear();
            RowCount = 0;
            ColumnCount = 0;
        }

        private void CheckWidgetExits(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget)
        {
            if (widget == null)
            {
                throw new System.ArgumentNullException("widget");
            }

            if (!widgetLayouts.ContainsKey(widget))
            {
                throw new System.ArgumentException("Widget is not part of this dialog");
            }
        }

        /// <summary>
        ///		Used to update the RowCount and ColumnCount properties based on the Widgets added to the section.
        /// </summary>
        private void UpdateRowAndColumnCount()
        {
            if (System.Linq.Enumerable.Any(widgetLayouts))
            {
                RowCount = System.Linq.Enumerable.Max(widgetLayouts.Values, w => w.Row + w.RowSpan);
                ColumnCount = System.Linq.Enumerable.Max(widgetLayouts.Values, w => w.Column + w.ColumnSpan);
            }
            else
            {
                RowCount = 0;
                ColumnCount = 0;
            }
        }
    }

    /// <summary>
    ///     Widget that is used to edit and display text.
    /// </summary>
    public class TextBox : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget
    {
        private bool changed;
        private string previous;
        /// <summary>
        ///     Initializes a new instance of the <see cref = "TextBox"/> class.
        /// </summary>
        /// <param name = "text">The text displayed in the text box.</param>
        public TextBox(string text)
        {
            Type = Skyline.DataMiner.Automation.UIBlockType.TextBox;
            Text = text;
            PlaceHolder = System.String.Empty;
            ValidationText = "Invalid Input";
            ValidationState = Skyline.DataMiner.Automation.UIValidationState.NotValidated;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref = "TextBox"/> class.
        /// </summary>
        public TextBox(): this(System.String.Empty)
        {
        }

        private event System.EventHandler<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TextBox.TextBoxChangedEventArgs> OnChanged;
        /// <summary>
        ///     Gets or sets a value indicating whether users are able to enter multiple lines of text.
        /// </summary>
        public bool IsMultiline
        {
            get
            {
                return BlockDefinition.IsMultiline;
            }

            set
            {
                BlockDefinition.IsMultiline = value;
            }
        }

        /// <summary>
        ///     Gets or sets the text displayed in the text box.
        /// </summary>
        public string Text
        {
            get
            {
                return BlockDefinition.InitialValue;
            }

            set
            {
                BlockDefinition.InitialValue = value;
            }
        }

        /// <summary>
        ///     Gets or sets the tooltip.
        /// </summary>
        /// <exception cref = "ArgumentNullException">When the value is <c>null</c>.</exception>
        public string Tooltip
        {
            get
            {
                return BlockDefinition.TooltipText;
            }

            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("value");
                }

                BlockDefinition.TooltipText = value;
            }
        }

        /// <summary>
        ///		Gets or sets the text that should be displayed as a placeholder.
        /// </summary>
        /// <remarks>Available from DataMiner Feature Release 10.0.5 and Main Release 10.1.0 onwards.</remarks>
        public string PlaceHolder
        {
            get
            {
                return BlockDefinition.PlaceholderText;
            }

            set
            {
                BlockDefinition.PlaceholderText = value;
            }
        }

        /// <summary>
        ///		Gets or sets the state indicating if a given input field was validated or not and if the validation was valid.
        ///		This should be used by the client to add a visual marker on the input field.
        /// </summary>
        /// <remarks>Available from DataMiner Feature Release 10.0.5 and Main Release 10.1.0 onwards.</remarks>
        public Skyline.DataMiner.Automation.UIValidationState ValidationState
        {
            get
            {
                return BlockDefinition.ValidationState;
            }

            set
            {
                BlockDefinition.ValidationState = value;
            }
        }

        /// <summary>
        ///		Gets or sets the text that is shown if the validation state is invalid.
        ///		This should be used by the client to add a visual marker on the input field.
        /// </summary>
        /// <remarks>Available from DataMiner Feature Release 10.0.5 and Main Release 10.1.0 onwards.</remarks>
        public string ValidationText
        {
            get
            {
                return BlockDefinition.ValidationText;
            }

            set
            {
                BlockDefinition.ValidationText = value;
            }
        }

        internal override void LoadResult(Skyline.DataMiner.Automation.UIResults uiResults)
        {
            string value = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.UiResultsExtensions.GetString(uiResults, this);
            if (WantsOnChange)
            {
                changed = value != Text;
                previous = Text;
            }

            Text = value;
        }

        /// <inheritdoc/>
        internal override void RaiseResultEvents()
        {
            if (changed && OnChanged != null)
            {
                OnChanged(this, new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TextBox.TextBoxChangedEventArgs(Text, previous));
            }

            changed = false;
        }

        /// <summary>
        ///     Provides data for the <see cref = "Changed"/> event.
        /// </summary>
        public class TextBoxChangedEventArgs : System.EventArgs
        {
            internal TextBoxChangedEventArgs(string value, string previous)
            {
                Value = value;
                Previous = previous;
            }

            /// <summary>
            ///     Gets the text before the change.
            /// </summary>
            public string Previous
            {
                get;
                private set;
            }

            /// <summary>
            ///     Gets the changed text.
            /// </summary>
            public string Value
            {
                get;
                private set;
            }
        }
    }

    /// <summary>
    ///  A tree view structure.
    /// </summary>
    public class TreeView : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget
    {
        private System.Collections.Generic.Dictionary<System.String, System.Boolean> checkedItemCache;
        private System.Collections.Generic.Dictionary<System.String, System.Boolean> collapsedItemCache; // TODO: should only contain Items with LazyLoading set to true
        private System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> lookupTable;
        private bool itemsChanged = false;
        private System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> changedItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
        private bool itemsChecked = false;
        private System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> checkedItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
        private bool itemsUnchecked = false;
        private System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> uncheckedItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
        private bool itemsExpanded = false;
        private System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> expandedItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
        private bool itemsCollapsed = false;
        private System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> collapsedItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
        /// <summary>
        ///		Initializes a new instance of the <see cref = "TreeView"/> class.
        /// </summary>
        /// <param name = "treeViewItems"></param>
        public TreeView(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> treeViewItems)
        {
            Type = Skyline.DataMiner.Automation.UIBlockType.TreeView;
            Items = treeViewItems;
        }

        private event System.EventHandler<System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>> OnChanged;
        private event System.EventHandler<System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>> OnChecked;
        private event System.EventHandler<System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>> OnUnchecked;
        private event System.EventHandler<System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>> OnExpanded;
        private event System.EventHandler<System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>> OnCollapsed;
        /// <summary>
        /// Returns the top-level items in the tree view.
        /// The TreeViewItem.ChildItems property can be used to navigate further down the tree.
        /// </summary>
        public System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> Items
        {
            get
            {
                return BlockDefinition.TreeViewItems;
            }

            set
            {
                if (value == null)
                    throw new System.ArgumentNullException("value");
                BlockDefinition.TreeViewItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>(value);
                UpdateItemCache();
            }
        }

        /// <summary>
        /// Returns all items in the tree view that are selected.
        /// </summary>
        public System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> CheckedItems
        {
            get
            {
                return GetCheckedItems();
            }
        }

        /// <summary>
        /// Returns all leaves (= items without children) in the tree view that are selected.
        /// </summary>
        public System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> CheckedLeaves
        {
            get
            {
                return System.Linq.Enumerable.Where(GetCheckedItems(), x => !System.Linq.Enumerable.Any(x.ChildItems));
            }
        }

        /// <summary>
        /// Returns all nodes (= items with children) in the tree view that are selected.
        /// </summary>
        public System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> CheckedNodes
        {
            get
            {
                return System.Linq.Enumerable.Where(GetCheckedItems(), x => System.Linq.Enumerable.Any(x.ChildItems));
            }
        }

        /// <summary>
        /// This method is used to update the cached TreeViewItems and lookup table.
        /// </summary>
        internal void UpdateItemCache()
        {
            checkedItemCache = new System.Collections.Generic.Dictionary<System.String, System.Boolean>();
            collapsedItemCache = new System.Collections.Generic.Dictionary<System.String, System.Boolean>();
            lookupTable = new System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
            foreach (var item in GetAllItems())
            {
                try
                {
                    checkedItemCache.Add(item.KeyValue, item.IsChecked);
                    if (item.SupportsLazyLoading)
                        collapsedItemCache.Add(item.KeyValue, item.IsCollapsed);
                    lookupTable.Add(item.KeyValue, item);
                }
                catch (System.Exception e)
                {
                    throw new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TreeViewDuplicateItemsException(item.KeyValue, e);
                }
            }
        }

        /// <summary>
        /// Returns all items in the TreeView that are checked.
        /// </summary>
        /// <returns>All checked TreeViewItems in the TreeView.</returns>
        private System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> GetCheckedItems()
        {
            return System.Linq.Enumerable.Where(lookupTable.Values, x => x.ItemType == Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem.TreeViewItemType.CheckBox && x.IsChecked);
        }

        /// <summary>
        /// Iterates over all items in the tree and returns them in a flat collection.
        /// </summary>
        /// <returns>A flat collection containing all items in the tree view.</returns>
        public System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> GetAllItems()
        {
            System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> allItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
            foreach (var item in Items)
            {
                allItems.Add(item);
                allItems.AddRange(GetAllItems(item.ChildItems));
            }

            return allItems;
        }

        /// <summary>
        /// This method is used to recursively go through all the items in the TreeView.
        /// </summary>
        /// <param name = "children">List of TreeViewItems to be visited.</param>
        /// <returns>Flat collection containing every item in the provided children collection and all underlying items.</returns>
        private System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> GetAllItems(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> children)
        {
            System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem> allItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
            foreach (var item in children)
            {
                allItems.Add(item);
                allItems.AddRange(GetAllItems(item.ChildItems));
            }

            return allItems;
        }

        /// <summary>
        ///     Gets or sets the tooltip.
        /// </summary>
        /// <exception cref = "ArgumentNullException">When the value is <c>null</c>.</exception>
        public string Tooltip
        {
            get
            {
                return BlockDefinition.TooltipText;
            }

            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("value");
                }

                BlockDefinition.TooltipText = value;
            }
        }

        internal override void LoadResult(Skyline.DataMiner.Automation.UIResults uiResults)
        {
            var checkedItemKeys = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.UiResultsExtensions.GetCheckedItemKeys(uiResults, this); // this includes all checked items
            var expandedItemKeys = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.UiResultsExtensions.GetExpandedItemKeys(uiResults, this); // this includes all expanded items with LazyLoading set to true
            // Check for changes
            // Expanded Items
            System.Collections.Generic.List<System.String> newlyExpandedItems = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(collapsedItemCache, x => System.Linq.Enumerable.Contains(expandedItemKeys, x.Key) && x.Value), x => x.Key));
            if (System.Linq.Enumerable.Any(newlyExpandedItems) && OnExpanded != null)
            {
                itemsExpanded = true;
                expandedItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
                foreach (string newlyExpandedItemKey in newlyExpandedItems)
                {
                    expandedItems.Add(lookupTable[newlyExpandedItemKey]);
                }
            }

            // Collapsed Items
            System.Collections.Generic.List<System.String> newlyCollapsedItems = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(collapsedItemCache, x => !System.Linq.Enumerable.Contains(expandedItemKeys, x.Key) && !x.Value), x => x.Key));
            if (System.Linq.Enumerable.Any(newlyCollapsedItems) && OnCollapsed != null)
            {
                itemsCollapsed = true;
                collapsedItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
                foreach (string newyCollapsedItemKey in newlyCollapsedItems)
                {
                    collapsedItems.Add(lookupTable[newyCollapsedItemKey]);
                }
            }

            // Checked Items
            System.Collections.Generic.List<System.String> newlyCheckedItemKeys = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(checkedItemCache, x => System.Linq.Enumerable.Contains(checkedItemKeys, x.Key) && !x.Value), x => x.Key));
            if (System.Linq.Enumerable.Any(newlyCheckedItemKeys) && OnChecked != null)
            {
                itemsChecked = true;
                checkedItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
                foreach (string newlyCheckedItemKey in newlyCheckedItemKeys)
                {
                    checkedItems.Add(lookupTable[newlyCheckedItemKey]);
                }
            }

            // Unchecked Items
            System.Collections.Generic.List<System.String> newlyUncheckedItemKeys = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(checkedItemCache, x => !System.Linq.Enumerable.Contains(checkedItemKeys, x.Key) && x.Value), x => x.Key));
            if (System.Linq.Enumerable.Any(newlyUncheckedItemKeys) && OnUnchecked != null)
            {
                itemsUnchecked = true;
                uncheckedItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
                foreach (string newlyUncheckedItemKey in newlyUncheckedItemKeys)
                {
                    uncheckedItems.Add(lookupTable[newlyUncheckedItemKey]);
                }
            }

            // Changed Items
            System.Collections.Generic.List<System.String> changedItemKeys = new System.Collections.Generic.List<System.String>();
            changedItemKeys.AddRange(newlyCheckedItemKeys);
            changedItemKeys.AddRange(newlyUncheckedItemKeys);
            if (System.Linq.Enumerable.Any(changedItemKeys) && OnChanged != null)
            {
                itemsChanged = true;
                changedItems = new System.Collections.Generic.List<Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem>();
                foreach (string changedItemKey in changedItemKeys)
                {
                    changedItems.Add(lookupTable[changedItemKey]);
                }
            }

            // Persist states
            foreach (Skyline.DataMiner.Net.AutomationUI.Objects.TreeViewItem item in lookupTable.Values)
            {
                item.IsChecked = System.Linq.Enumerable.Contains(checkedItemKeys, item.KeyValue);
                item.IsCollapsed = !System.Linq.Enumerable.Contains(expandedItemKeys, item.KeyValue);
            }

            UpdateItemCache();
        }

        /// <inheritdoc/>
        internal override void RaiseResultEvents()
        {
            // Expanded items
            if (itemsExpanded && OnExpanded != null)
                OnExpanded(this, expandedItems);
            // Collapsed items
            if (itemsCollapsed && OnCollapsed != null)
                OnCollapsed(this, collapsedItems);
            // Checked items
            if (itemsChecked && OnChecked != null)
                OnChecked(this, checkedItems);
            // Unchecked items
            if (itemsUnchecked && OnUnchecked != null)
                OnUnchecked(this, uncheckedItems);
            // Changed items
            if (itemsChanged && OnChanged != null)
                OnChanged(this, changedItems);
            itemsExpanded = false;
            itemsCollapsed = false;
            itemsChecked = false;
            itemsUnchecked = false;
            itemsChanged = false;
            UpdateItemCache();
        }
    }

    /// <summary>
    ///		A whitespace.
    /// </summary>
    public class WhiteSpace : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget
    {
        /// <summary>
        /// Initializes a new instance of the <see cref = "WhiteSpace"/> class.
        /// </summary>
        public WhiteSpace()
        {
            Type = Skyline.DataMiner.Automation.UIBlockType.StaticText;
            BlockDefinition.Style = null;
            BlockDefinition.Text = System.String.Empty;
        }
    }

    /// <summary>
    ///     Base class for widgets.
    /// </summary>
    public class Widget
    {
        private Skyline.DataMiner.Automation.UIBlockDefinition blockDefinition = new Skyline.DataMiner.Automation.UIBlockDefinition();
        /// <summary>
        /// Initializes a new instance of the Widget class.
        /// </summary>
        protected Widget()
        {
            Type = Skyline.DataMiner.Automation.UIBlockType.Undefined;
            IsVisible = true;
            SetHeightAuto();
            SetWidthAuto();
        }

        /// <summary>
        ///     Gets or sets the fixed height (in pixels) of the widget.
        /// </summary>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int Height
        {
            get
            {
                return BlockDefinition.Height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                BlockDefinition.Height = value;
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the widget is visible in the dialog.
        /// </summary>
        public bool IsVisible
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets the maximum height (in pixels) of the widget.
        /// </summary>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int MaxHeight
        {
            get
            {
                return BlockDefinition.MaxHeight;
            }

            set
            {
                if (value <= -2)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                BlockDefinition.MaxHeight = value;
            }
        }

        /// <summary>
        ///     Gets or sets the maximum width (in pixels) of the widget.
        /// </summary>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int MaxWidth
        {
            get
            {
                return BlockDefinition.MaxWidth;
            }

            set
            {
                if (value <= -2)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                BlockDefinition.MaxWidth = value;
            }
        }

        /// <summary>
        ///     Gets or sets the minimum height (in pixels) of the widget.
        /// </summary>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int MinHeight
        {
            get
            {
                return BlockDefinition.MinHeight;
            }

            set
            {
                if (value <= -2)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                BlockDefinition.MinHeight = value;
            }
        }

        /// <summary>
        ///     Gets or sets the minimum width (in pixels) of the widget.
        /// </summary>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int MinWidth
        {
            get
            {
                return BlockDefinition.MinWidth;
            }

            set
            {
                if (value <= -2)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                BlockDefinition.MinWidth = value;
            }
        }

        /// <summary>
        ///     Gets or sets the UIBlockType of the widget.
        /// </summary>
        public Skyline.DataMiner.Automation.UIBlockType Type
        {
            get
            {
                return BlockDefinition.Type;
            }

            protected set
            {
                BlockDefinition.Type = value;
            }
        }

        /// <summary>
        ///     Gets or sets the fixed width (in pixels) of the widget.
        /// </summary>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int Width
        {
            get
            {
                return BlockDefinition.Width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                BlockDefinition.Width = value;
            }
        }

        /// <summary>
        /// Margin of the widget.
        /// </summary>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Margin Margin
        {
            get
            {
                return new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Margin(BlockDefinition.Margin);
            }

            set
            {
                BlockDefinition.Margin = value.ToString();
            }
        }

        internal Skyline.DataMiner.Automation.UIBlockDefinition BlockDefinition
        {
            get
            {
                return blockDefinition;
            }
        }

        /// <summary>
        ///     Set the height of the widget based on its content.
        /// </summary>
        public void SetHeightAuto()
        {
            BlockDefinition.Height = -1;
            BlockDefinition.MaxHeight = -1;
            BlockDefinition.MinHeight = -1;
        }

        /// <summary>
        ///     Set the width of the widget based on its content.
        /// </summary>
        public void SetWidthAuto()
        {
            BlockDefinition.Width = -1;
            BlockDefinition.MaxWidth = -1;
            BlockDefinition.MinWidth = -1;
        }
    }

    /// <summary>
    ///     A dialog represents a single window that can be shown.
    ///     You can show widgets in the window by adding them to the dialog.
    ///     The dialog uses a grid to determine the layout of its widgets.
    /// </summary>
    public abstract class Dialog
    {
        private const string Auto = "auto";
        private readonly System.Collections.Generic.Dictionary<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout> widgetLayouts = new System.Collections.Generic.Dictionary<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout>();
        private readonly System.Collections.Generic.Dictionary<System.Int32, System.String> columnDefinitions = new System.Collections.Generic.Dictionary<System.Int32, System.String>();
        private readonly System.Collections.Generic.Dictionary<System.Int32, System.String> rowDefinitions = new System.Collections.Generic.Dictionary<System.Int32, System.String>();
        private int height;
        private int maxHeight;
        private int maxWidth;
        private int minHeight;
        private int minWidth;
        private int width;
        private bool isEnabled = true;
        /// <summary>
        /// Initializes a new instance of the <see cref = "Dialog"/> class.
        /// </summary>
        /// <param name = "engine"></param>
        protected Dialog(Skyline.DataMiner.Automation.IEngine engine)
        {
            if (engine == null)
            {
                throw new System.ArgumentNullException("engine");
            }

            Engine = engine;
            width = -1;
            height = -1;
            MaxHeight = System.Int32.MaxValue;
            MinHeight = 1;
            MaxWidth = System.Int32.MaxValue;
            MinWidth = 1;
            RowCount = 0;
            ColumnCount = 0;
            Title = "Dialog";
            AllowOverlappingWidgets = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether overlapping widgets are allowed or not.
        /// Can be used in case you want to add multiple widgets to the same cell in the dialog.
        /// You can use the Margin property on the widgets to place them apart.
        /// </summary>
        public bool AllowOverlappingWidgets
        {
            get;
            set;
        }

        /// <summary>
        ///     Triggered when the back button of the dialog is pressed.
        /// </summary>
        public event System.EventHandler<System.EventArgs> Back;
        /// <summary>
        ///     Triggered when the forward button of the dialog is pressed.
        /// </summary>
        public event System.EventHandler<System.EventArgs> Forward;
        /// <summary>
        ///     Triggered when there is any user interaction.
        /// </summary>
        public event System.EventHandler<System.EventArgs> Interacted;
        /// <summary>
        ///     Gets the number of columns of the grid layout.
        /// </summary>
        public int ColumnCount
        {
            get;
            private set;
        }

        /// <summary>
        ///     Gets the link to the SLAutomation process.
        /// </summary>
        public Skyline.DataMiner.Automation.IEngine Engine
        {
            get;
            private set;
        }

        /// <summary>
        ///     Gets or sets the fixed height (in pixels) of the dialog.
        /// </summary>
        /// <remarks>
        ///     The user will still be able to resize the window,
        ///     but scrollbars will appear immediately.
        ///     <see cref = "MinHeight"/> should be used instead as it has a more desired effect.
        /// </remarks>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                height = value;
            }
        }

        /// <summary>
        ///     Gets or sets the maximum height (in pixels) of the dialog.
        /// </summary>
        /// <remarks>
        ///     The user will still be able to resize the window past this limit.
        /// </remarks>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int MaxHeight
        {
            get
            {
                return maxHeight;
            }

            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                maxHeight = value;
            }
        }

        /// <summary>
        ///     Gets or sets the maximum width (in pixels) of the dialog.
        /// </summary>
        /// <remarks>
        ///     The user will still be able to resize the window past this limit.
        /// </remarks>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int MaxWidth
        {
            get
            {
                return maxWidth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                maxWidth = value;
            }
        }

        /// <summary>
        ///     Gets or sets the minimum height (in pixels) of the dialog.
        /// </summary>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int MinHeight
        {
            get
            {
                return minHeight;
            }

            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                minHeight = value;
            }
        }

        /// <summary>
        ///     Gets or sets the minimum width (in pixels) of the dialog.
        /// </summary>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int MinWidth
        {
            get
            {
                return minWidth;
            }

            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                minWidth = value;
            }
        }

        /// <summary>
        ///     Gets the number of rows in the grid layout.
        /// </summary>
        public int RowCount
        {
            get;
            private set;
        }

        /// <summary>
        ///		Gets or sets a value indicating whether the interactive widgets within the dialog are enabled or not.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }

            set
            {
                isEnabled = value;
                foreach (Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget in Widgets)
                {
                    Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget interactiveWidget = widget as Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget;
                    if (interactiveWidget != null && !(interactiveWidget is Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.CollapseButton))
                    {
                        interactiveWidget.IsEnabled = isEnabled;
                    }
                }
            }
        }

        /// <summary>
        ///     Gets or sets the title at the top of the window.
        /// </summary>
        /// <remarks>Available from DataMiner 9.6.6 onwards.</remarks>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets widgets that are added to the dialog.
        /// </summary>
        public System.Collections.Generic.IEnumerable<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget> Widgets
        {
            get
            {
                return widgetLayouts.Keys;
            }
        }

        /// <summary>
        ///     Gets or sets the fixed width (in pixels) of the dialog.
        /// </summary>
        /// <remarks>
        ///     The user will still be able to resize the window,
        ///     but scrollbars will appear immediately.
        ///     <see cref = "MinWidth"/> should be used instead as it has a more desired effect.
        /// </remarks>
        /// <exception cref = "ArgumentOutOfRangeException">When the value is smaller than 1.</exception>
        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                width = value;
            }
        }

        /// <summary>
        ///     Adds a widget to the dialog.
        /// </summary>
        /// <param name = "widget">Widget to add to the dialog.</param>
        /// <param name = "widgetLayout">Location of the widget on the grid layout.</param>
        /// <returns>The dialog.</returns>
        /// <exception cref = "ArgumentNullException">When the widget is null.</exception>
        /// <exception cref = "ArgumentException">When the widget has already been added to the dialog.</exception>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog AddWidget(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout widgetLayout)
        {
            if (widget == null)
            {
                throw new System.ArgumentNullException("widget");
            }

            if (widgetLayouts.ContainsKey(widget))
            {
                throw new System.ArgumentException("Widget is already added to the dialog");
            }

            widgetLayouts.Add(widget, widgetLayout);
            System.Collections.Generic.SortedSet<System.Int32> rowsInUse;
            System.Collections.Generic.SortedSet<System.Int32> columnsInUse;
            this.FillRowsAndColumnsInUse(out rowsInUse, out columnsInUse);
            return this;
        }

        /// <summary>
        ///     Adds a widget to the dialog.
        /// </summary>
        /// <param name = "widget">Widget to add to the dialog.</param>
        /// <param name = "row">Row location of widget on the grid.</param>
        /// <param name = "column">Column location of the widget on the grid.</param>
        /// <param name = "horizontalAlignment">Horizontal alignment of the widget.</param>
        /// <param name = "verticalAlignment">Vertical alignment of the widget.</param>
        /// <returns>The dialog.</returns>
        /// <exception cref = "ArgumentNullException">When the widget is null.</exception>
        /// <exception cref = "ArgumentException">When the widget has already been added to the dialog.</exception>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog AddWidget(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget, int row, int column, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment horizontalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment.Left, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment verticalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment.Center)
        {
            AddWidget(widget, new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.WidgetLayout(row, column, horizontalAlignment, verticalAlignment));
            return this;
        }

        /// <summary>
        ///     Adds a widget to the dialog.
        /// </summary>
        /// <param name = "widget">Widget to add to the dialog.</param>
        /// <param name = "fromRow">Row location of widget on the grid.</param>
        /// <param name = "fromColumn">Column location of the widget on the grid.</param>
        /// <param name = "rowSpan">Number of rows the widget will use.</param>
        /// <param name = "colSpan">Number of columns the widget will use.</param>
        /// <param name = "horizontalAlignment">Horizontal alignment of the widget.</param>
        /// <param name = "verticalAlignment">Vertical alignment of the widget.</param>
        /// <returns>The dialog.</returns>
        /// <exception cref = "ArgumentNullException">When the widget is null.</exception>
        /// <exception cref = "ArgumentException">When the widget has already been added to the dialog.</exception>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog AddWidget(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget, int fromRow, int fromColumn, int rowSpan, int colSpan, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment horizontalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment.Left, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment verticalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment.Center)
        {
            AddWidget(widget, new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.WidgetLayout(fromRow, fromColumn, rowSpan, colSpan, horizontalAlignment, verticalAlignment));
            return this;
        }

        /// <summary>
        /// Adds the widgets from the section to the dialog.
        /// </summary>
        /// <param name = "section">Section to be added to the dialog.</param>
        /// <param name = "layout">Left top position of the section within the dialog.</param>
        /// <returns>Updated dialog.</returns>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog AddSection(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Section section, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.SectionLayout layout)
        {
            foreach (Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget in section.Widgets)
            {
                Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout widgetLayout = section.GetWidgetLayout(widget);
                AddWidget(widget, new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.WidgetLayout(widgetLayout.Row + layout.Row, widgetLayout.Column + layout.Column, widgetLayout.RowSpan, widgetLayout.ColumnSpan, widgetLayout.HorizontalAlignment, widgetLayout.VerticalAlignment));
            }

            return this;
        }

        /// <summary>
        /// Adds the widgets from the section to the dialog.
        /// </summary>
        /// <param name = "section">Section to be added to the dialog.</param>
        /// <param name = "fromRow">Row in the dialog where the section should be added.</param>
        /// <param name = "fromColumn">Column in the dialog where the section should be added.</param>
        /// <returns>Updated dialog.</returns>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog AddSection(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Section section, int fromRow, int fromColumn)
        {
            return AddSection(section, new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.SectionLayout(fromRow, fromColumn));
        }

        /// <summary>
        ///     Applies a fixed width (in pixels) to a column.
        /// </summary>
        /// <param name = "column">The index of the column on the grid.</param>
        /// <param name = "columnWidth">The width of the column.</param>
        /// <exception cref = "ArgumentOutOfRangeException">When the column index does not exist.</exception>
        /// <exception cref = "ArgumentOutOfRangeException">When the column width is smaller than 0.</exception>
        public void SetColumnWidth(int column, int columnWidth)
        {
            if (column < 0)
                throw new System.ArgumentOutOfRangeException("column");
            if (columnWidth < 0)
                throw new System.ArgumentOutOfRangeException("columnWidth");
            if (columnDefinitions.ContainsKey(column))
                columnDefinitions[column] = columnWidth.ToString();
            else
                columnDefinitions.Add(column, columnWidth.ToString());
        }

        /// <summary>
        ///     Shows the dialog window.
        ///     Also loads changes and triggers events when <paramref name = "requireResponse"/> is <c>true</c>.
        /// </summary>
        /// <param name = "requireResponse">If the dialog expects user interaction.</param>
        /// <remarks>Should only be used when you create your own event loop.</remarks>
        public void Show(bool requireResponse = true)
        {
            Skyline.DataMiner.Automation.UIBuilder uib = Build();
            uib.RequireResponse = requireResponse;
            Skyline.DataMiner.Automation.UIResults uir = Engine.ShowUI(uib);
            if (requireResponse)
            {
                LoadChanges(uir);
                RaiseResultEvents(uir);
            }
        }

        /// <summary>
        /// Removes all widgets from the dialog.
        /// </summary>
        public void Clear()
        {
            widgetLayouts.Clear();
            RowCount = 0;
            ColumnCount = 0;
        }

        private static string AlignmentToUiString(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment horizontalAlignment)
        {
            switch (horizontalAlignment)
            {
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment.Center:
                    return "Center";
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment.Left:
                    return "Left";
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment.Right:
                    return "Right";
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment.Stretch:
                    return "Stretch";
                default:
                    throw new System.ComponentModel.InvalidEnumArgumentException("horizontalAlignment", (int)horizontalAlignment, typeof(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment));
            }
        }

        private static string AlignmentToUiString(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment verticalAlignment)
        {
            switch (verticalAlignment)
            {
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment.Center:
                    return "Center";
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment.Top:
                    return "Top";
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment.Bottom:
                    return "Bottom";
                case Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment.Stretch:
                    return "Stretch";
                default:
                    throw new System.ComponentModel.InvalidEnumArgumentException("verticalAlignment", (int)verticalAlignment, typeof(Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment));
            }
        }

        /// <summary>
        /// Checks if any visible widgets in the Dialog overlap.
        /// </summary>
        /// <exception cref = "OverlappingWidgetsException">Thrown when two visible widgets overlap with each other.</exception>
        private void CheckIfVisibleWidgetsOverlap()
        {
            if (AllowOverlappingWidgets)
                return;
            foreach (Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget widget in widgetLayouts.Keys)
            {
                if (!widget.IsVisible)
                    continue;
                Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout widgetLayout = widgetLayouts[widget];
                for (int column = widgetLayout.Column; column < widgetLayout.Column + widgetLayout.ColumnSpan; column++)
                {
                    for (int row = widgetLayout.Row; row < widgetLayout.Row + widgetLayout.RowSpan; row++)
                    {
                        foreach (Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget otherWidget in widgetLayouts.Keys)
                        {
                            if (!otherWidget.IsVisible || widget.Equals(otherWidget))
                                continue;
                            Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout otherWidgetLayout = widgetLayouts[otherWidget];
                            if (column >= otherWidgetLayout.Column && column < otherWidgetLayout.Column + otherWidgetLayout.ColumnSpan && row >= otherWidgetLayout.Row && row < otherWidgetLayout.Row + otherWidgetLayout.RowSpan)
                            {
                                throw new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.OverlappingWidgetsException(System.String.Format("The widget overlaps with another widget in the Dialog on Row {0}, Column {1}, RowSpan {2}, ColumnSpan {3}", widgetLayout.Row, widgetLayout.Column, widgetLayout.RowSpan, widgetLayout.ColumnSpan));
                            }
                        }
                    }
                }
            }
        }

        private string GetRowDefinitions(System.Collections.Generic.SortedSet<System.Int32> rowsInUse)
        {
            string[] definitions = new string[rowsInUse.Count];
            int currentIndex = 0;
            foreach (int rowInUse in rowsInUse)
            {
                string value;
                if (rowDefinitions.TryGetValue(rowInUse, out value))
                {
                    definitions[currentIndex] = value;
                }
                else
                {
                    definitions[currentIndex] = Auto;
                }

                currentIndex++;
            }

            return System.String.Join(";", definitions);
        }

        private string GetColumnDefinitions(System.Collections.Generic.SortedSet<System.Int32> columnsInUse)
        {
            string[] definitions = new string[columnsInUse.Count];
            int currentIndex = 0;
            foreach (int columnInUse in columnsInUse)
            {
                string value;
                if (columnDefinitions.TryGetValue(columnInUse, out value))
                {
                    definitions[currentIndex] = value;
                }
                else
                {
                    definitions[currentIndex] = Auto;
                }

                currentIndex++;
            }

            return System.String.Join(";", definitions);
        }

        private Skyline.DataMiner.Automation.UIBuilder Build()
        {
            // Check rows and columns in use
            System.Collections.Generic.SortedSet<System.Int32> rowsInUse;
            System.Collections.Generic.SortedSet<System.Int32> columnsInUse;
            this.FillRowsAndColumnsInUse(out rowsInUse, out columnsInUse);
            // Check if visible widgets overlap and throw exception if this is the case
            CheckIfVisibleWidgetsOverlap();
            // Initialize UI Builder
            var uiBuilder = new Skyline.DataMiner.Automation.UIBuilder{Height = Height, MinHeight = MinHeight, Width = Width, MinWidth = MinWidth, RowDefs = GetRowDefinitions(rowsInUse), ColumnDefs = GetColumnDefinitions(columnsInUse), Title = Title};
            System.Collections.Generic.KeyValuePair<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout> defaultKeyValuePair = default(System.Collections.Generic.KeyValuePair<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout>);
            int rowIndex = 0;
            int columnIndex = 0;
            foreach (int rowInUse in rowsInUse)
            {
                columnIndex = 0;
                foreach (int columnInUse in columnsInUse)
                {
                    foreach (System.Collections.Generic.KeyValuePair<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout> keyValuePair in System.Linq.Enumerable.Where(widgetLayouts, x => x.Key.IsVisible && x.Key.Type != Skyline.DataMiner.Automation.UIBlockType.Undefined && x.Value.Row.Equals(rowInUse) && x.Value.Column.Equals(columnInUse)))
                    {
                        if (keyValuePair.Equals(defaultKeyValuePair))
                            continue;
                        // Can be removed once we retrieve all collapsed states from the UI
                        Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TreeView treeView = keyValuePair.Key as Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.TreeView;
                        if (treeView != null)
                            treeView.UpdateItemCache();
                        Skyline.DataMiner.Automation.UIBlockDefinition widgetBlockDefinition = keyValuePair.Key.BlockDefinition;
                        Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout widgetLayout = keyValuePair.Value;
                        widgetBlockDefinition.Column = columnIndex;
                        widgetBlockDefinition.ColumnSpan = widgetLayout.ColumnSpan;
                        widgetBlockDefinition.Row = rowIndex;
                        widgetBlockDefinition.RowSpan = widgetLayout.RowSpan;
                        widgetBlockDefinition.HorizontalAlignment = AlignmentToUiString(widgetLayout.HorizontalAlignment);
                        widgetBlockDefinition.VerticalAlignment = AlignmentToUiString(widgetLayout.VerticalAlignment);
                        widgetBlockDefinition.Margin = widgetLayout.Margin.ToString();
                        uiBuilder.AppendBlock(widgetBlockDefinition);
                    }

                    columnIndex++;
                }

                rowIndex++;
            }

            return uiBuilder;
        }

        /// <summary>
        /// Used to retrieve the rows and columns that are being used and updates the RowCount and ColumnCount properties based on the Widgets added to the dialog.
        /// </summary>
        /// <param name = "rowsInUse">Collection containing the rows that are defined by the Widgets in the Dialog.</param>
        /// <param name = "columnsInUse">Collection containing the columns that are defined by the Widgets in the Dialog.</param>
        private void FillRowsAndColumnsInUse(out System.Collections.Generic.SortedSet<System.Int32> rowsInUse, out System.Collections.Generic.SortedSet<System.Int32> columnsInUse)
        {
            rowsInUse = new System.Collections.Generic.SortedSet<System.Int32>();
            columnsInUse = new System.Collections.Generic.SortedSet<System.Int32>();
            foreach (System.Collections.Generic.KeyValuePair<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Widget, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout> keyValuePair in this.widgetLayouts)
            {
                if (keyValuePair.Key.IsVisible && keyValuePair.Key.Type != Skyline.DataMiner.Automation.UIBlockType.Undefined)
                {
                    for (int i = keyValuePair.Value.Row; i < keyValuePair.Value.Row + keyValuePair.Value.RowSpan; i++)
                    {
                        rowsInUse.Add(i);
                    }

                    for (int i = keyValuePair.Value.Column; i < keyValuePair.Value.Column + keyValuePair.Value.ColumnSpan; i++)
                    {
                        columnsInUse.Add(i);
                    }
                }
            }

            this.RowCount = rowsInUse.Count;
            this.ColumnCount = columnsInUse.Count;
        }

        private void LoadChanges(Skyline.DataMiner.Automation.UIResults uir)
        {
            foreach (Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget interactiveWidget in System.Linq.Enumerable.OfType<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget>(Widgets))
            {
                if (interactiveWidget.IsVisible)
                {
                    interactiveWidget.LoadResult(uir);
                }
            }
        }

        private void RaiseResultEvents(Skyline.DataMiner.Automation.UIResults uir)
        {
            if (Interacted != null)
            {
                Interacted(this, System.EventArgs.Empty);
            }

            if (uir.WasBack() && (Back != null))
            {
                Back(this, System.EventArgs.Empty);
                return;
            }

            if (uir.WasForward() && (Forward != null))
            {
                Forward(this, System.EventArgs.Empty);
                return;
            }

            // ToList is necessary to prevent InvalidOperationException when adding or removing widgets from a event handler.
            System.Collections.Generic.List<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget> intractableWidgets = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Where(System.Linq.Enumerable.OfType<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget>(Widgets), widget => widget.WantsOnChange));
            foreach (Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget intractable in intractableWidgets)
            {
                intractable.RaiseResultEvents();
            }
        }
    }

    /// <summary>
    ///		Dialog used to display an exception.
    /// </summary>
    public class ExceptionDialog : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog
    {
        private readonly Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Label exceptionLabel = new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Label();
        private System.Exception exception;
        /// <summary>
        /// Initializes a new instance of the ExceptionDialog class.
        /// </summary>
        /// <param name = "engine">Link with DataMiner.</param>
        public ExceptionDialog(Skyline.DataMiner.Automation.IEngine engine): base(engine)
        {
            Title = "Exception Occurred";
            OkButton = new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Button("OK");
            AddWidget(exceptionLabel, 0, 0);
            AddWidget(OkButton, 1, 0);
        }

        /// <summary>
        /// Initializes a new instance of the ExceptionDialog class with a specific exception to be displayed.
        /// </summary>
        /// <param name = "engine">Link with DataMiner.</param>
        /// <param name = "exception">Exception to be displayed by the exception dialog.</param>
        public ExceptionDialog(Skyline.DataMiner.Automation.IEngine engine, System.Exception exception): this(engine)
        {
            Exception = exception;
        }

        /// <summary>
        /// Exception to be displayed by the exception dialog.
        /// </summary>
        public System.Exception Exception
        {
            get
            {
                return exception;
            }

            set
            {
                exception = value;
                exceptionLabel.Text = exception.ToString();
            }
        }

        /// <summary>
        /// Button that is displayed below the exception.
        /// </summary>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Button OkButton
        {
            get;
            private set;
        }
    }

    /// <summary>
    ///		Dialog used to display a message.
    /// </summary>
    public class MessageDialog : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog
    {
        private readonly Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Label messageLabel = new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Label();
        /// <summary>
        /// Initializes a new instance of the <see cref = "MessageDialog"/> class without a message.
        /// </summary>
        /// <param name = "engine">Link with DataMiner.</param>
        public MessageDialog(Skyline.DataMiner.Automation.IEngine engine): base(engine)
        {
            OkButton = new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Button("OK")
            {Width = 150};
            AddWidget(messageLabel, 0, 0);
            AddWidget(OkButton, 1, 0);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "MessageDialog"/> class with a specific message.
        /// </summary>
        /// <param name = "engine">Link with DataMiner.</param>
        /// <param name = "message">Message to be displayed in the dialog.</param>
        public MessageDialog(Skyline.DataMiner.Automation.IEngine engine, System.String message): this(engine)
        {
            Message = message;
        }

        /// <summary>
        /// Message to be displayed in the dialog.
        /// </summary>
        public string Message
        {
            get
            {
                return messageLabel.Text;
            }

            set
            {
                messageLabel.Text = value;
            }
        }

        /// <summary>
        /// Button that is displayed below the message.
        /// </summary>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Button OkButton
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// When progress is displayed, this dialog has to be shown without requiring user interaction.
    /// When you are done displaying progress, call the Finish method and show the dialog with user interaction required.
    /// </summary>
    public class ProgressDialog : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Dialog
    {
        private readonly System.Text.StringBuilder progress = new System.Text.StringBuilder();
        private readonly Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Label progressLabel = new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Label();
        /// <summary>
        /// Used to instantiate a new instance of the <see cref = "ProgressDialog"/> class.
        /// </summary>
        /// <param name = "engine">Link with DataMiner.</param>
        public ProgressDialog(Skyline.DataMiner.Automation.IEngine engine): base(engine)
        {
            OkButton = new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Button("OK")
            {IsEnabled = true, Width = 150};
        }

        /// <summary>
        /// Button that is displayed after the Finish method is called.
        /// </summary>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Button OkButton
        {
            get;
            private set;
        }

        /// <summary>
        /// Adds the provided text on a new line to the current progress.
        /// </summary>
        /// <param name = "text">Indication of the progress made. This will be placed on a separate line.</param>
        public void AddProgressLine(string text)
        {
            progress.AppendLine(text);
            Engine.ShowProgress(progress.ToString());
        }

        /// <summary>
        /// Call this method when you are done updating the progress through this dialog.
        /// This will cause the OK button to appear.
        /// Display this form with user interactivity required after this method is called.
        /// </summary>
        public void Finish() // TODO: ShowConfirmation
        {
            progressLabel.Text = progress.ToString();
            if (!System.Linq.Enumerable.Contains(Widgets, progressLabel))
                AddWidget(progressLabel, 0, 0);
            if (!System.Linq.Enumerable.Contains(Widgets, OkButton))
                AddWidget(OkButton, 1, 0);
        }
    }

    /// <summary>
    /// This exception is used to indicate that two widgets have overlapping positions on the same dialog.
    /// </summary>
    [System.Serializable]
    public class OverlappingWidgetsException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref = "OverlappingWidgetsException"/> class.
        /// </summary>
        public OverlappingWidgetsException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "OverlappingWidgetsException"/> class with a specified error message.
        /// </summary>
        /// <param name = "message">The message that describes the error.</param>
        public OverlappingWidgetsException(string message): base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "OverlappingWidgetsException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name = "message">The error message that explains the reason for the exception.</param>
        /// <param name = "inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public OverlappingWidgetsException(string message, System.Exception inner): base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the OverlappingWidgetException class with the serialized data.
        /// </summary>
        /// <param name = "info">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name = "context">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected OverlappingWidgetsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
        {
        }
    }

    /// <summary>
    /// This exception is used to indicate that a tree view contains multiple items with the same key.
    /// </summary>
    [System.Serializable]
    public class TreeViewDuplicateItemsException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref = "TreeViewDuplicateItemsException"/> class.
        /// </summary>
        public TreeViewDuplicateItemsException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TreeViewDuplicateItemsException"/> class with a specified error message.
        /// </summary>
        /// <param name = "key">The key of the duplicate tree view items.</param>
        public TreeViewDuplicateItemsException(string key): base(System.String.Format("An item with key {0} is already present in the TreeView", key))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TreeViewDuplicateItemsException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name = "key">The key of the duplicate tree view items.</param>
        /// <param name = "inner">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public TreeViewDuplicateItemsException(string key, System.Exception inner): base(System.String.Format("An item with key {0} is already present in the TreeView", key), inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "TreeViewDuplicateItemsException"/> class with the serialized data.
        /// </summary>
        /// <param name = "info">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name = "context">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected TreeViewDuplicateItemsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
        {
        }
    }

    /// <summary>
    /// Specifies the horizontal alignment of a widget added to a dialog or section.
    /// </summary>
    public enum HorizontalAlignment
    {
        /// <summary>
        /// Specifies that the widget will be centered across its assigned cell(s).
        /// </summary>
        Center,
        /// <summary>
        /// Specifies that the widget will be aligned to the left across its assigned cell(s).
        /// </summary>
        Left,
        /// <summary>
        /// Specifies that the widget will be aligned to the right across its assigned cell(s).
        /// </summary>
        Right,
        /// <summary>
        /// Specifies that the widget will be stretched horizontally across its assigned cell(s).
        /// </summary>
        Stretch
    }

    /// <summary>
    /// Used to define the position of an item in a grid layout.
    /// </summary>
    public interface ILayout
    {
        /// <summary>
        ///     Gets the column location of the widget on the grid.
        /// </summary>
        /// <remarks>The top-left position is (0, 0) by default.</remarks>
        int Column
        {
            get;
        }

        /// <summary>
        ///     Gets the row location of the widget on the grid.
        /// </summary>
        /// <remarks>The top-left position is (0, 0) by default.</remarks>
        int Row
        {
            get;
        }
    }

    /// <summary>
    /// Used to define the position of a widget in a grid layout.
    /// </summary>
    public interface IWidgetLayout : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.ILayout
    {
        /// <summary>
        ///     Gets how many columns the widget spans on the grid.
        /// </summary>
        int ColumnSpan
        {
            get;
        }

        /// <summary>
        ///     Gets or sets the horizontal alignment of the widget.
        /// </summary>
        Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment HorizontalAlignment
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets the margin around the widget.
        /// </summary>
        /// <exception cref = "ArgumentNullException">When the value is null.</exception>
        Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Margin Margin
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets how many rows the widget spans on the grid.
        /// </summary>
        int RowSpan
        {
            get;
        }

        /// <summary>
        ///     Gets or sets the vertical alignment of the widget.
        /// </summary>
        Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment VerticalAlignment
        {
            get;
            set;
        }
    }

    /// <summary>
    /// Defines the whitespace that is displayed around a widget.
    /// </summary>
    public class Margin
    {
        private int bottom;
        private int left;
        private int right;
        private int top;
        /// <summary>
        /// Initializes a new instance of the Margin class.
        /// </summary>
        /// <param name = "left">Amount of margin on the left-hand side of the widget in pixels.</param>
        /// <param name = "top">Amount of margin at the top of the widget in pixels.</param>
        /// <param name = "right">Amount of margin on the right-hand side of the widget in pixels.</param>
        /// <param name = "bottom">Amount of margin at the bottom of the widget in pixels.</param>
        public Margin(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        /// <summary>
        /// Initializes a new instance of the Margin class.
        /// A margin is by default 3 pixels wide.
        /// </summary>
        public Margin(): this(3, 3, 3, 3)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Margin class based on a string.
        /// This string should have the following syntax: left;top;right;bottom
        /// </summary>
        /// <exception cref = "ArgumentException">If the string does not match the predefined syntax, or if any of the margins is not a number.</exception>
        /// <param name = "margin">Margin in string format.</param>
        public Margin(string margin)
        {
            if (System.String.IsNullOrWhiteSpace(margin))
            {
                left = 0;
                top = 0;
                right = 0;
                bottom = 0;
                return;
            }

            string[] splitMargin = margin.Split(';');
            if (splitMargin.Length != 4)
                throw new System.ArgumentException("Margin should have the following format: left;top;right;bottom");
            if (!System.Int32.TryParse(splitMargin[0], out left))
                throw new System.ArgumentException("Left margin is not a number");
            if (!System.Int32.TryParse(splitMargin[1], out top))
                throw new System.ArgumentException("Top margin is not a number");
            if (!System.Int32.TryParse(splitMargin[2], out right))
                throw new System.ArgumentException("Right margin is not a number");
            if (!System.Int32.TryParse(splitMargin[3], out bottom))
                throw new System.ArgumentException("Bottom margin is not a number");
        }

        /// <summary>
        /// Amount of margin in pixels at the bottom of the widget.
        /// </summary>
        public int Bottom
        {
            get
            {
                return bottom;
            }

            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                bottom = value;
            }
        }

        /// <summary>
        /// Amount of margin in pixels at the left-hand side of the widget.
        /// </summary>
        public int Left
        {
            get
            {
                return left;
            }

            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                left = value;
            }
        }

        /// <summary>
        /// Amount of margin in pixels at the right-hand side of the widget.
        /// </summary>
        public int Right
        {
            get
            {
                return right;
            }

            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                right = value;
            }
        }

        /// <summary>
        /// Amount of margin in pixels at the top of the widget.
        /// </summary>
        public int Top
        {
            get
            {
                return top;
            }

            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                top = value;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return System.String.Join(";", new object[]{left, top, right, bottom});
        }
    }

    /// <summary>
    /// Used to define the position of a section in another section or dialog.
    /// </summary>
    public class SectionLayout : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.ILayout
    {
        private int column;
        private int row;
        /// <summary>
        /// Initializes a new instance of the <see cref = "SectionLayout"/> class.
        /// </summary>
        /// <param name = "row">Row index of the cell that the top-left cell of the section will be mapped to.</param>
        /// <param name = "column">Column index of the cell that the top-left cell of the section will be mapped to.</param>
        public SectionLayout(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        /// <summary>
        ///     Gets or sets the column location of the section on the dialog grid.
        /// </summary>
        /// <remarks>The top-left position is (0, 0) by default.</remarks>
        public int Column
        {
            get
            {
                return column;
            }

            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                column = value;
            }
        }

        /// <summary>
        ///     Gets or sets the row location of the section on the dialog grid.
        /// </summary>
        /// <remarks>The top-left position is (0, 0) by default.</remarks>
        public int Row
        {
            get
            {
                return row;
            }

            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                row = value;
            }
        }
    }

    /// <summary>
    /// Style of the displayed text.
    /// </summary>
    public enum TextStyle
    {
        /// <summary>
        /// Default value, no explicit styling.
        /// </summary>
        None = 0,
        /// <summary>
        /// Text should be styled as a title.
        /// </summary>
        Title = 1,
        /// <summary>
        /// Text should be styled in bold.
        /// </summary>
        Bold = 2,
        /// <summary>
        /// Text should be styled as a heading.
        /// </summary>
        Heading = 3
    }

    /// <summary>
    /// Specifies the vertical alignment of a widget added to a dialog or section.
    /// </summary>
    public enum VerticalAlignment
    {
        /// <summary>
        /// Specifies that the widget will be centered vertically across its assigned cell(s).
        /// </summary>
        Center,
        /// <summary>
        /// Specifies that the widget will be aligned to the top of its assigned cell(s).
        /// </summary>
        Top,
        /// <summary>
        /// Specifies that the widget will be aligned to the bottom of its assigned cell(s).
        /// </summary>
        Bottom,
        /// <summary>
        /// Specifies that the widget will be stretched vertically across its assigned cell(s).
        /// </summary>
        Stretch
    }

    /// <inheritdoc/>
    public class WidgetLayout : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.IWidgetLayout
    {
        private int column;
        private int columnSpan;
        private Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Margin margin;
        private int row;
        private int rowSpan;
        /// <summary>
        /// Initializes a new instance of the <see cref = "WidgetLayout"/> class.
        /// </summary>
        /// <param name = "fromRow">Row index of top-left cell.</param>
        /// <param name = "fromColumn">Column index of the top-left cell.</param>
        /// <param name = "rowSpan">Number of vertical cells the widget spans across.</param>
        /// <param name = "columnSpan">Number of horizontal cells the widget spans across.</param>
        /// <param name = "horizontalAlignment">Horizontal alignment of the widget.</param>
        /// <param name = "verticalAlignment">Vertical alignment of the widget.</param>
        public WidgetLayout(int fromRow, int fromColumn, int rowSpan, int columnSpan, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment horizontalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment.Left, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment verticalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment.Top)
        {
            Row = fromRow;
            Column = fromColumn;
            RowSpan = rowSpan;
            ColumnSpan = columnSpan;
            HorizontalAlignment = horizontalAlignment;
            VerticalAlignment = verticalAlignment;
            Margin = new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Margin();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "WidgetLayout"/> class.
        /// </summary>
        /// <param name = "row">Row index of the cell where the widget is placed.</param>
        /// <param name = "column">Column index of the cell where the widget is placed.</param>
        /// <param name = "horizontalAlignment">Horizontal alignment of the widget.</param>
        /// <param name = "verticalAlignment">Vertical alignment of the widget.</param>
        public WidgetLayout(int row, int column, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment horizontalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment.Left, Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment verticalAlignment = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment.Top): this(row, column, 1, 1, horizontalAlignment, verticalAlignment)
        {
        }

        /// <summary>
        ///     Gets or sets the column location of the widget on the grid.
        /// </summary>
        public int Column
        {
            get
            {
                return column;
            }

            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                column = value;
            }
        }

        /// <summary>
        ///     Gets or sets how many columns the widget spans on the grid.
        /// </summary>
        public int ColumnSpan
        {
            get
            {
                return columnSpan;
            }

            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                columnSpan = value;
            }
        }

        /// <inheritdoc/>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.HorizontalAlignment HorizontalAlignment
        {
            get;
            set;
        }

        /// <inheritdoc/>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.Margin Margin
        {
            get
            {
                return margin;
            }

            set
            {
                if (value == null)
                {
                    throw new System.ArgumentNullException("value");
                }

                margin = value;
            }
        }

        /// <summary>
        ///     Gets or sets the row location of the widget on the grid.
        /// </summary>
        public int Row
        {
            get
            {
                return row;
            }

            set
            {
                if (value < 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                row = value;
            }
        }

        /// <summary>
        ///     Gets or sets how many rows the widget spans on the grid.
        /// </summary>
        public int RowSpan
        {
            get
            {
                return rowSpan;
            }

            set
            {
                if (value <= 0)
                {
                    throw new System.ArgumentOutOfRangeException("value");
                }

                rowSpan = value;
            }
        }

        /// <inheritdoc/>
        public Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.VerticalAlignment VerticalAlignment
        {
            get;
            set;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.WidgetLayout other = obj as Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.WidgetLayout;
            if (other == null)
                return false;
            bool rowMatch = Row.Equals(other.Row);
            bool columnMatch = Column.Equals(other.Column);
            bool rowSpanMatch = RowSpan.Equals(other.RowSpan);
            bool columnSpanMatch = ColumnSpan.Equals(other.ColumnSpan);
            bool horizontalAlignmentMatch = HorizontalAlignment.Equals(other.HorizontalAlignment);
            bool verticalAlignmentMatch = VerticalAlignment.Equals(other.VerticalAlignment);
            bool rowParamsMatch = rowMatch && rowSpanMatch;
            bool columnParamsMatch = columnMatch && columnSpanMatch;
            bool alignmentParamsMatch = horizontalAlignmentMatch && verticalAlignmentMatch;
            return rowParamsMatch && columnParamsMatch && alignmentParamsMatch;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Row ^ Column ^ RowSpan ^ ColumnSpan ^ (int)HorizontalAlignment ^ (int)VerticalAlignment;
        }
    }
}