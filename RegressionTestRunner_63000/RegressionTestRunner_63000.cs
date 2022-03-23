// --- auto-generated code --- do not modify ---

/*
{{StartPackageInfo}}
<PackageInfo xmlns="http://www.skyline.be/ClassLibrary">
	<BasePackage>
		<Identity>
			<Name>Class Library</Name>
			<Version>1.2.0.12</Version>
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

namespace Skyline.DataMiner
{
    namespace Library
    {
        namespace Automation
        {
            /// <summary>
            /// Defines extension methods on the <see cref = "IEngine"/> interface.
            /// </summary>
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("SLManagedAutomation.dll")]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("SLNetTypes.dll")]
            public static class IEngineExtensions
            {
#pragma warning disable S1104 // Fields should not have public accessibility

#pragma warning disable S2223 // Non-constant static fields should not be visible

                /// <summary>
                /// Allows an override of the behavior of GetDms to return a Fake or Mock of <see cref = "IDms"/>.
                /// Important: When this is used, unit tests should never be run in parallel.
                /// </summary>
                public static System.Func<Skyline.DataMiner.Automation.IEngine, Skyline.DataMiner.Library.Common.IDms> OverrideGetDms = engine =>
                {
                    return new Skyline.DataMiner.Library.Common.Dms(new Skyline.DataMiner.Library.Common.ConnectionCommunication(Skyline.DataMiner.Automation.Engine.SLNetRaw));
                }

                ;
#pragma warning restore S2223 // Non-constant static fields should not be visible

#pragma warning restore S1104 // Fields should not have public accessibility

                /// <summary>
                /// Retrieves an object implementing the <see cref = "IDms"/> interface.
                /// </summary>
                /// <param name = "engine">The <see cref = "IEngine"/> implementation.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "engine"/> is <see langword = "null"/>.</exception>
                /// <returns>The <see cref = "IDms"/> object.</returns>
                public static Skyline.DataMiner.Library.Common.IDms GetDms(this Skyline.DataMiner.Automation.IEngine engine)
                {
                    if (engine == null)
                    {
                        throw new System.ArgumentNullException("engine");
                    }

                    return OverrideGetDms(engine);
                }
            }
        }

        namespace Common
        {
            namespace Attributes
            {
                /// <summary>
                /// This attribute indicates a DLL is required.
                /// </summary>
                [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
                public sealed class DllImportAttribute : System.Attribute
                {
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DllImportAttribute"/> class.
                    /// </summary>
                    /// <param name = "dllImport">The name of the DLL to be imported.</param>
                    public DllImportAttribute(string dllImport)
                    {
                        DllImport = dllImport;
                    }

                    /// <summary>
                    /// Gets the name of the DLL to be imported.
                    /// </summary>
                    public string DllImport
                    {
                        get;
                        private set;
                    }
                }
            }

            /// <summary>
            /// Represents a system-wide element ID.
            /// </summary>
            /// <remarks>This is a combination of a DataMiner Agent ID (the ID of the Agent on which the element was created) and an element ID.</remarks>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("Newtonsoft.Json.dll")]
            public struct DmsElementId : System.IEquatable<Skyline.DataMiner.Library.Common.DmsElementId>, System.IComparable, System.IComparable<Skyline.DataMiner.Library.Common.DmsElementId>
            {
                /// <summary>
                /// The DataMiner Agent ID.
                /// </summary>
                private int agentId;
                /// <summary>
                /// The element ID.
                /// </summary>
                private int elementId;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsElementId"/> structure using the specified string.
                /// </summary>
                /// <param name = "id">String representing the system-wide element ID.</param>
                /// <remarks>The provided string must be formatted as follows: "DataMiner Agent ID/element ID (e.g. 400/201)".</remarks>
                /// <exception cref = "ArgumentNullException"><paramref name = "id"/> is <see langword = "null"/> .</exception>
                /// <exception cref = "ArgumentException"><paramref name = "id"/> is the empty string ("") or white space.</exception>
                /// <exception cref = "ArgumentException">The ID does not match the mandatory format.</exception>
                /// <exception cref = "ArgumentException">The DataMiner Agent ID is not an integer.</exception>
                /// <exception cref = "ArgumentException">The element ID is not an integer.</exception>
                /// <exception cref = "ArgumentException">Invalid DataMiner Agent ID.</exception>
                /// <exception cref = "ArgumentException">Invalid element ID.</exception>
                public DmsElementId(string id)
                {
                    if (id == null)
                    {
                        throw new System.ArgumentNullException("id");
                    }

                    if (System.String.IsNullOrWhiteSpace(id))
                    {
                        throw new System.ArgumentException("The provided ID must not be empty.", "id");
                    }

                    string[] idParts = id.Split('/');
                    if (idParts.Length != 2)
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid ID. Value: {0}. The string must be formatted as follows: \"agent ID/element ID\".", id);
                        throw new System.ArgumentException(message, "id");
                    }

                    if (!System.Int32.TryParse(idParts[0], System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out agentId))
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid DataMiner agent ID. \"{0}\" is not an integer value", id);
                        throw new System.ArgumentException(message, "id");
                    }

                    if (!System.Int32.TryParse(idParts[1], System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out elementId))
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid Element ID. \"{0}\" is not an integer value", id);
                        throw new System.ArgumentException(message, "id");
                    }

                    if (!IsValidAgentId())
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid agent ID. Value: {0}.", agentId);
                        throw new System.ArgumentException(message, "id");
                    }

                    if (!IsValidElementId())
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid element ID. Value: {0}.", elementId);
                        throw new System.ArgumentException(message, "id");
                    }
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsElementId"/> structure using the specified element ID and DataMiner Agent ID.
                /// </summary>
                /// <param name = "agentId">The DataMiner Agent ID.</param>
                /// <param name = "elementId">The element ID.</param>
                /// <remarks>The hosting DataMiner Agent ID value will be set to the same value as the specified DataMiner Agent ID.</remarks>
                /// <exception cref = "ArgumentException"><paramref name = "agentId"/> is invalid.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "elementId"/> is invalid.</exception>
                public DmsElementId(int agentId, int elementId)
                {
                    if ((elementId == -1 && agentId != -1) || agentId < -1)
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid agent ID. Value: {0}.", agentId);
                        throw new System.ArgumentException(message, "agentId");
                    }

                    if ((agentId == -1 && elementId != -1) || elementId < -1)
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid element ID. Value: {0}.", elementId);
                        throw new System.ArgumentException(message, "elementId");
                    }

                    this.elementId = elementId;
                    this.agentId = agentId;
                }

                /// <summary>
                /// Gets the DataMiner Agent ID.
                /// </summary>
                /// <remarks>The DataMiner Agent ID is the ID of the DataMiner Agent this element has been created on.</remarks>
                public int AgentId
                {
                    get
                    {
                        return agentId;
                    }

                    private set
                    {
                        // setter for serialization.
                        agentId = value;
                    }
                }

                /// <summary>
                /// Gets the element ID.
                /// </summary>
                public int ElementId
                {
                    get
                    {
                        return elementId;
                    }

                    private set
                    {
                        // setter for serialization.
                        elementId = value;
                    }
                }

                /// <summary>
                /// Gets the DataMiner Agent ID/element ID string representation.
                /// </summary>
                [Newtonsoft.Json.JsonIgnore]
                public string Value
                {
                    get
                    {
                        return agentId + "/" + elementId;
                    }
                }

                /// <summary>
                /// Compares the current instance with another object of the same type and returns an integer that indicates whether the
                /// current instance precedes, follows, or occurs in the same position in the sort order as the other object.
                /// </summary>
                /// <param name = "other">An object to compare with this instance.</param>
                /// <returns>A value that indicates the relative order of the objects being compared.
                /// The return value has these meanings: Less than zero means this instance precedes <paramref name = "other"/> in the sort order.
                /// Zero means this instance occurs in the same position in the sort order as <paramref name = "other"/>.
                /// Greater than zero means this instance follows <paramref name = "other"/> in the sort order.</returns>
                /// <remarks>The order of the comparison is as follows: DataMiner Agent ID, element ID.</remarks>
                public int CompareTo(Skyline.DataMiner.Library.Common.DmsElementId other)
                {
                    int result = agentId.CompareTo(other.AgentId);
                    if (result == 0)
                    {
                        result = elementId.CompareTo(other.ElementId);
                    }

                    return result;
                }

                /// <summary>
                /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
                /// </summary>
                /// <param name = "obj">An object to compare with this instance.</param>
                /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Less than zero means this instance precedes <paramref name = "obj"/> in the sort order. Zero means this instance occurs in the same position in the sort order as <paramref name = "obj"/>. Greater than zero means this instance follows <paramref name = "obj"/> in the sort order.</returns>
                /// <remarks>The order of the comparison is as follows: DataMiner Agent ID, element ID.</remarks>
                /// <exception cref = "ArgumentException">The obj is not of type <see cref = "DmsElementId"/></exception>
                public int CompareTo(object obj)
                {
                    if (obj == null)
                    {
                        return 1;
                    }

                    if (!(obj is Skyline.DataMiner.Library.Common.DmsElementId))
                    {
                        throw new System.ArgumentException("The provided object must be of type DmsElementId.", "obj");
                    }

                    return CompareTo((Skyline.DataMiner.Library.Common.DmsElementId)obj);
                }

                /// <summary>
                /// Compares the object to another object.
                /// </summary>
                /// <param name = "obj">The object to compare against.</param>
                /// <returns><c>true</c> if the elements are equal; otherwise, <c>false</c>.</returns>
                public override bool Equals(object obj)
                {
                    if (!(obj is Skyline.DataMiner.Library.Common.DmsElementId))
                    {
                        return false;
                    }

                    return Equals((Skyline.DataMiner.Library.Common.DmsElementId)obj);
                }

                /// <summary>
                /// Indicates whether the current object is equal to another object of the same type.
                /// </summary>
                /// <param name = "other">An object to compare with this object.</param>
                /// <returns><c>true</c> if the elements are equal; otherwise, <c>false</c>.</returns>
                public bool Equals(Skyline.DataMiner.Library.Common.DmsElementId other)
                {
                    if (elementId == other.elementId && agentId == other.agentId)
                    {
                        return true;
                    }

                    return false;
                }

                /// <summary>
                /// Returns the hash code.
                /// </summary>
                /// <returns>The hash code.</returns>
                public override int GetHashCode()
                {
                    return elementId ^ agentId;
                }

                /// <summary>
                /// Returns a string that represents the current object.
                /// </summary>
                /// <returns>A string that represents the current object.</returns>
                public override string ToString()
                {
                    return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "agent ID: {0}, element ID: {1}", agentId, elementId);
                }

                /// <summary>
                /// Returns a value determining whether the agent ID is valid.
                /// </summary>
                /// <returns><c>true</c> if the agent ID is valid; otherwise, <c>false</c>.</returns>
                private bool IsValidAgentId()
                {
                    bool isValid = true;
                    if ((elementId == -1 && agentId != -1) || agentId < -1)
                    {
                        isValid = false;
                    }

                    return isValid;
                }

                /// <summary>
                /// Returns a value determining whether the element ID is valid.
                /// </summary>
                /// <returns><c>true</c> if the element ID is valid; otherwise, <c>false</c>.</returns>
                private bool IsValidElementId()
                {
                    bool isValid = true;
                    if ((agentId == -1 && elementId != -1) || elementId < -1)
                    {
                        isValid = false;
                    }

                    return isValid;
                }
            }

            /// <summary>
            /// Represents a system-wide element ID.
            /// </summary>
            /// <remarks>This is a combination of a DataMiner Agent ID (the ID of the Agent on which the element was created) and an element ID.</remarks>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("Newtonsoft.Json.dll")]
            public struct DmsServiceId : System.IEquatable<Skyline.DataMiner.Library.Common.DmsServiceId>, System.IComparable, System.IComparable<Skyline.DataMiner.Library.Common.DmsServiceId>
            {
                /// <summary>
                /// The DataMiner Agent ID.
                /// </summary>
                private int agentId;
                /// <summary>
                /// The service ID.
                /// </summary>
                private int serviceId;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsServiceId"/> structure using the specified string.
                /// </summary>
                /// <param name = "id">String representing the system-wide service ID.</param>
                /// <remarks>The provided string must be formatted as follows: "DataMiner Agent ID/service ID (e.g. 400/201)".</remarks>
                /// <exception cref = "ArgumentNullException"><paramref name = "id"/> is <see langword = "null"/> .</exception>
                /// <exception cref = "ArgumentException"><paramref name = "id"/> is the empty string ("") or white space.</exception>
                /// <exception cref = "ArgumentException">The ID does not match the mandatory format.</exception>
                /// <exception cref = "ArgumentException">The DataMiner Agent ID is not an integer.</exception>
                /// <exception cref = "ArgumentException">The service ID is not an integer.</exception>
                /// <exception cref = "ArgumentException">Invalid DataMiner Agent ID.</exception>
                /// <exception cref = "ArgumentException">Invalid service ID.</exception>
                public DmsServiceId(string id)
                {
                    if (id == null)
                    {
                        throw new System.ArgumentNullException("id");
                    }

                    if (System.String.IsNullOrWhiteSpace(id))
                    {
                        throw new System.ArgumentException("The provided ID must not be empty.", "id");
                    }

                    string[] identifierParts = id.Split('/');
                    if (identifierParts.Length != 2)
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid ID. Value: {0}. The string must be formatted as follows: \"agent ID/service ID\".", id);
                        throw new System.ArgumentException(message, "id");
                    }

                    if (!System.Int32.TryParse(identifierParts[0], System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out agentId))
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid DataMiner agent ID. \"{0}\" is not an integer value", id);
                        throw new System.ArgumentException(message, "id");
                    }

                    if (!System.Int32.TryParse(identifierParts[1], System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out serviceId))
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid Service ID. \"{0}\" is not an integer value", id);
                        throw new System.ArgumentException(message, "id");
                    }

                    if (!IsValidAgentId())
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid agent ID. Value: {0}.", agentId);
                        throw new System.ArgumentException(message, "id");
                    }

                    if (!IsValidServiceId())
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid element ID. Value: {0}.", serviceId);
                        throw new System.ArgumentException(message, "id");
                    }
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsServiceId"/> structure using the specified service ID and DataMiner Agent ID.
                /// </summary>
                /// <param name = "agentId">The DataMiner Agent ID.</param>
                /// <param name = "serviceId">The service ID.</param>
                /// <remarks>The hosting DataMiner Agent ID value will be set to the same value as the specified DataMiner Agent ID.</remarks>
                /// <exception cref = "ArgumentException"><paramref name = "agentId"/> is invalid.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "serviceId"/> is invalid.</exception>
                public DmsServiceId(int agentId, int serviceId)
                {
                    this.serviceId = serviceId;
                    this.agentId = agentId;
                    if (!IsValidAgentId())
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid agent ID. Value: {0}.", agentId);
                        throw new System.ArgumentException(message, "agentId");
                    }

                    if (!IsValidServiceId())
                    {
                        string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid element ID. Value: {0}.", serviceId);
                        throw new System.ArgumentException(message, "serviceId");
                    }
                }

                /// <summary>
                /// Gets the DataMiner Agent ID.
                /// </summary>
                /// <remarks>The DataMiner Agent ID is the ID of the DataMiner Agent this service has been created on.</remarks>
                public int AgentId
                {
                    get
                    {
                        return agentId;
                    }

                    private set
                    {
                        // setter for serialization.
                        agentId = value;
                    }
                }

                /// <summary>
                /// Gets the service ID.
                /// </summary>
                public int ServiceId
                {
                    get
                    {
                        return serviceId;
                    }

                    private set
                    {
                        // setter for serialization.
                        serviceId = value;
                    }
                }

                /// <summary>
                /// Gets the DataMiner Agent ID/service ID string representation.
                /// </summary>
                [Newtonsoft.Json.JsonIgnore]
                public string Value
                {
                    get
                    {
                        return agentId + "/" + serviceId;
                    }
                }

                /// <summary>
                /// Compares the current instance with another object of the same type and returns an integer that indicates whether the
                /// current instance precedes, follows, or occurs in the same position in the sort order as the other object.
                /// </summary>
                /// <param name = "other">An object to compare with this instance.</param>
                /// <returns>A value that indicates the relative order of the objects being compared.
                /// The return value has these meanings: Less than zero means this instance precedes <paramref name = "other"/> in the sort order.
                /// Zero means this instance occurs in the same position in the sort order as <paramref name = "other"/>.
                /// Greater than zero means this instance follows <paramref name = "other"/> in the sort order.</returns>
                /// <remarks>The order of the comparison is as follows: DataMiner Agent ID, service ID.</remarks>
                public int CompareTo(Skyline.DataMiner.Library.Common.DmsServiceId other)
                {
                    int result = agentId.CompareTo(other.AgentId);
                    if (result == 0)
                    {
                        result = serviceId.CompareTo(other.ServiceId);
                    }

                    return result;
                }

                /// <summary>
                /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
                /// </summary>
                /// <param name = "obj">An object to compare with this instance.</param>
                /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Less than zero means this instance precedes <paramref name = "obj"/> in the sort order. Zero means this instance occurs in the same position in the sort order as <paramref name = "obj"/>. Greater than zero means this instance follows <paramref name = "obj"/> in the sort order.</returns>
                /// <remarks>The order of the comparison is as follows: DataMiner Agent ID, service ID.</remarks>
                /// <exception cref = "ArgumentException">The obj is not of type <see cref = "DmsServiceId"/></exception>
                public int CompareTo(object obj)
                {
                    if (obj == null)
                    {
                        return 1;
                    }

                    if (!(obj is Skyline.DataMiner.Library.Common.DmsServiceId))
                    {
                        throw new System.ArgumentException("The provided object must be of type DmsServiceId.", "obj");
                    }

                    return CompareTo((Skyline.DataMiner.Library.Common.DmsServiceId)obj);
                }

                /// <summary>
                /// Compares the object to another object.
                /// </summary>
                /// <param name = "obj">The object to compare against.</param>
                /// <returns><c>true</c> if the elements are equal; otherwise, <c>false</c>.</returns>
                public override bool Equals(object obj)
                {
                    if (!(obj is Skyline.DataMiner.Library.Common.DmsServiceId))
                    {
                        return false;
                    }

                    return Equals((Skyline.DataMiner.Library.Common.DmsServiceId)obj);
                }

                /// <summary>
                /// Indicates whether the current object is equal to another object of the same type.
                /// </summary>
                /// <param name = "other">An object to compare with this object.</param>
                /// <returns><c>true</c> if the services are equal; otherwise, <c>false</c>.</returns>
                public bool Equals(Skyline.DataMiner.Library.Common.DmsServiceId other)
                {
                    if (serviceId == other.serviceId && agentId == other.agentId)
                    {
                        return true;
                    }

                    return false;
                }

                /// <summary>
                /// Returns the hash code.
                /// </summary>
                /// <returns>The hash code.</returns>
                public override int GetHashCode()
                {
                    return serviceId ^ agentId;
                }

                /// <summary>
                /// Returns a string that represents the current object.
                /// </summary>
                /// <returns>A string that represents the current object.</returns>
                public override string ToString()
                {
                    return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "agent ID: {0}, service ID: {1}", agentId, serviceId);
                }

                /// <summary>
                /// Returns a value determining whether the agent ID is valid.
                /// </summary>
                /// <returns><c>true</c> if the agent ID is valid; otherwise, <c>false</c>.</returns>
                private bool IsValidAgentId()
                {
                    bool isValid = true;
                    if ((serviceId == -1 && agentId != -1) || agentId < -1)
                    {
                        isValid = false;
                    }

                    return isValid;
                }

                /// <summary>
                /// Returns a value determining whether the element ID is valid.
                /// </summary>
                /// <returns><c>true</c> if the element ID is valid; otherwise, <c>false</c>.</returns>
                private bool IsValidServiceId()
                {
                    bool isValid = true;
                    if ((agentId == -1 && serviceId != -1) || serviceId < -1)
                    {
                        isValid = false;
                    }

                    return isValid;
                }
            }

            /// <summary>
            /// Represents a DataMiner System.
            /// </summary>
            internal class Dms : Skyline.DataMiner.Library.Common.IDms
            {
                /// <summary>
                /// Dictionary for all of the element properties found on the DataMiner System.
                /// </summary>
                private readonly System.Collections.Generic.IDictionary<System.String, Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition> elementProperties = new System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition>();
                /// <summary>
                /// Dictionary for all of the service properties found on the DataMiner System.
                /// </summary>
                private readonly System.Collections.Generic.IDictionary<System.String, Skyline.DataMiner.Library.Common.Properties.IDmsServicePropertyDefinition> serviceProperties = new System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Library.Common.Properties.IDmsServicePropertyDefinition>();
                /// <summary>
                /// Dictionary for all of the view properties found on the DataMiner System.
                /// </summary>
                private readonly System.Collections.Generic.IDictionary<System.String, Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition> viewProperties = new System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition>();
                /// <summary>
                /// Specifies is the DataMiner System object has been loaded.
                /// </summary>
                private bool isLoaded;
                /// <summary>
                /// Cached element information message.
                /// </summary>
                private Skyline.DataMiner.Net.Messages.ElementInfoEventMessage cachedElementInfoMessage;
                /// <summary>
                /// The object used for DMS communication.
                /// </summary>
                private Skyline.DataMiner.Library.Common.ICommunication communication;
                /// <summary>
                /// Initializes a new instance of the <see cref = "Dms"/> class.
                /// </summary>
                /// <param name = "communication">An object implementing the ICommunication interface.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "communication"/> is <see langword = "null"/>.</exception>
                internal Dms(Skyline.DataMiner.Library.Common.ICommunication communication)
                {
                    if (communication == null)
                    {
                        throw new System.ArgumentNullException("communication");
                    }

                    this.communication = communication;
                }

                /// <summary>
                /// Gets the communication interface.
                /// </summary>
                /// <value>The communication interface.</value>
                public Skyline.DataMiner.Library.Common.ICommunication Communication
                {
                    get
                    {
                        return communication;
                    }
                }

                /// <summary>
                /// Gets the element property definitions available in the DataMiner System.
                /// </summary>
                /// <value>The element property definitions available in the DataMiner System.</value>
                public Skyline.DataMiner.Library.Common.IPropertyDefinitionCollection<Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition> ElementPropertyDefinitions
                {
                    get
                    {
                        if (!isLoaded)
                        {
                            LoadDmsProperties();
                        }

                        return new Skyline.DataMiner.Library.Common.PropertyDefinitionCollection<Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition>(elementProperties);
                    }
                }

                /// <summary>
                /// Gets the view property definitions available in the DataMiner System.
                /// </summary>
                /// <value>The view property definitions available in the DataMiner System.</value>
                public Skyline.DataMiner.Library.Common.IPropertyDefinitionCollection<Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition> ViewPropertyDefinitions
                {
                    get
                    {
                        if (!isLoaded)
                        {
                            LoadDmsProperties();
                        }

                        return new Skyline.DataMiner.Library.Common.PropertyDefinitionCollection<Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition>(viewProperties);
                    }
                }

                /// <summary>
                ///     Gets the service property definitions available in the DataMiner System.
                /// </summary>
                /// <value>The service property definitions available in the DataMiner System.</value>
                public Skyline.DataMiner.Library.Common.IPropertyDefinitionCollection<Skyline.DataMiner.Library.Common.Properties.IDmsServicePropertyDefinition> ServicePropertyDefinitions
                {
                    get
                    {
                        if (!this.isLoaded)
                        {
                            this.LoadDmsProperties();
                        }

                        return new Skyline.DataMiner.Library.Common.PropertyDefinitionCollection<Skyline.DataMiner.Library.Common.Properties.IDmsServicePropertyDefinition>(this.serviceProperties);
                    }
                }

                /// <summary>
                /// Determines whether an element with the specified name exists in the DataMiner System.
                /// </summary>
                /// <param name = "elementName">The name of the element.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "elementName"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "elementName"/> is the empty string ("") or white space.</exception>
                /// <returns><c>true</c> if the element exists; otherwise, <c>false</c>.</returns>
                public bool ElementExists(string elementName)
                {
                    if (elementName == null)
                    {
                        throw new System.ArgumentNullException("elementName");
                    }

                    if (System.String.IsNullOrWhiteSpace(elementName))
                    {
                        throw new System.ArgumentException("The element name is the empty string (\"\") or white space.", "elementName");
                    }

                    try
                    {
                        Skyline.DataMiner.Net.Messages.GetElementByNameMessage message = new Skyline.DataMiner.Net.Messages.GetElementByNameMessage(elementName);
                        Skyline.DataMiner.Net.Messages.ElementInfoEventMessage response = (Skyline.DataMiner.Net.Messages.ElementInfoEventMessage)communication.SendSingleResponseMessage(message);
                        // Cache the response of SLNet.
                        // Could be useful when this call is used within a "GetElement" this makes sure that we do not double call SLNet.
                        if (response != null)
                        {
                            cachedElementInfoMessage = response;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Skyline.DataMiner.Net.Exceptions.DataMinerException e)
                    {
                        if (e.ErrorCode == -2146233088)
                        {
                            // 0x80131500, Element "[element name]" is unavailable.
                            return false;
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                /// <summary>
                /// Gets the DataMiner Agents found on the DataMiner System.
                /// </summary>
                /// <returns>The DataMiner Agents in the DataMiner System.</returns>
                public System.Collections.Generic.ICollection<Skyline.DataMiner.Library.Common.IDma> GetAgents()
                {
                    System.Collections.Generic.List<Skyline.DataMiner.Library.Common.IDma> dataMinerAgents = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.IDma>();
                    Skyline.DataMiner.Net.Messages.GetInfoMessage message = new Skyline.DataMiner.Net.Messages.GetInfoMessage{Type = Skyline.DataMiner.Net.Messages.InfoType.DataMinerInfo};
                    Skyline.DataMiner.Net.Messages.DMSMessage[] responses = communication.SendMessage(message);
                    foreach (Skyline.DataMiner.Net.Messages.DMSMessage response in responses)
                    {
                        Skyline.DataMiner.Net.Messages.GetDataMinerInfoResponseMessage info = (Skyline.DataMiner.Net.Messages.GetDataMinerInfoResponseMessage)response;
                        if (info.ID > 0)
                        {
                            dataMinerAgents.Add(new Skyline.DataMiner.Library.Common.Dma(this, info.ID));
                        }
                    }

                    return dataMinerAgents;
                }

                /// <summary>
                /// Retrieves the element with the specified element name.
                /// </summary>
                /// <param name = "elementName">The name of the element.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "elementName"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "elementName"/> is the empty string ("") or white space.</exception>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner System.</exception>
                /// <returns>The element with the specified name.</returns>
                public Skyline.DataMiner.Library.Common.IDmsElement GetElement(string elementName)
                {
                    if (elementName == null)
                    {
                        throw new System.ArgumentNullException("elementName");
                    }

                    if (System.String.IsNullOrWhiteSpace(elementName))
                    {
                        throw new System.ArgumentException("The element name is the empty string (\"\") or white space.", "elementName");
                    }

                    if (!ElementExists(elementName))
                    {
                        throw new Skyline.DataMiner.Library.Common.ElementNotFoundException(elementName);
                    }

                    return new Skyline.DataMiner.Library.Common.DmsElement(this, cachedElementInfoMessage);
                }

                /// <summary>
                /// Returns a string that represents the current object.
                /// </summary>
                /// <returns>A string that represents the current object.</returns>
                public override string ToString()
                {
                    return "DataMiner System";
                }

                /// <summary>
                /// Loads all the properties found on the DataMiner system.
                /// </summary>
                internal void LoadDmsProperties()
                {
                    isLoaded = true;
                    Skyline.DataMiner.Net.Messages.GetInfoMessage message = new Skyline.DataMiner.Net.Messages.GetInfoMessage{Type = Skyline.DataMiner.Net.Messages.InfoType.PropertyConfiguration};
                    Skyline.DataMiner.Net.Messages.GetPropertyConfigurationResponse response = (Skyline.DataMiner.Net.Messages.GetPropertyConfigurationResponse)communication.SendSingleResponseMessage(message);
                    foreach (Skyline.DataMiner.Net.Messages.PropertyConfig property in response.Properties)
                    {
                        switch (property.Type)
                        {
                            case "Element":
                                elementProperties[property.Name] = new Skyline.DataMiner.Library.Common.Properties.DmsElementPropertyDefinition(this, property);
                                break;
                            case "View":
                                viewProperties[property.Name] = new Skyline.DataMiner.Library.Common.Properties.DmsViewPropertyDefinition(this, property);
                                break;
                            case "Service":
                                serviceProperties[property.Name] = new Skyline.DataMiner.Library.Common.Properties.DmsServicePropertyDefinition(this, property);
                                break;
                            default:
                                continue;
                        }
                    }
                }
            }

            /// <summary>
            /// Helper class to convert from enumeration value to string or vice versa.
            /// </summary>
            internal static class EnumMapper
            {
                /// <summary>
                /// The connection type map.
                /// </summary>
                private static readonly System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Library.Common.ConnectionType> ConnectionTypeMapping = new System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Library.Common.ConnectionType>{{"SNMP", Skyline.DataMiner.Library.Common.ConnectionType.SnmpV1}, {"SNMPV1", Skyline.DataMiner.Library.Common.ConnectionType.SnmpV1}, {"SNMPV2", Skyline.DataMiner.Library.Common.ConnectionType.SnmpV2}, {"SNMPV3", Skyline.DataMiner.Library.Common.ConnectionType.SnmpV3}, {"SERIAL", Skyline.DataMiner.Library.Common.ConnectionType.Serial}, {"SERIAL SINGLE", Skyline.DataMiner.Library.Common.ConnectionType.SerialSingle}, {"SMART-SERIAL", Skyline.DataMiner.Library.Common.ConnectionType.SmartSerial}, {"SMART-SERIAL SINGLE", Skyline.DataMiner.Library.Common.ConnectionType.SmartSerialSingle}, {"HTTP", Skyline.DataMiner.Library.Common.ConnectionType.Http}, {"GPIB", Skyline.DataMiner.Library.Common.ConnectionType.Gpib}, {"VIRTUAL", Skyline.DataMiner.Library.Common.ConnectionType.Virtual}, {"OPC", Skyline.DataMiner.Library.Common.ConnectionType.Opc}, {"SLA", Skyline.DataMiner.Library.Common.ConnectionType.Sla}, {"WEBSOCKET", Skyline.DataMiner.Library.Common.ConnectionType.WebSocket}};
                /// <summary>
                /// Converts a string denoting a connection type to the corresponding value of the <see cref = "ConnectionType"/> enumeration.
                /// </summary>
                /// <param name = "type">The connection type.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "type"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "type"/> is the empty string ("") or white space</exception>
                /// <exception cref = "KeyNotFoundException"></exception>
                /// <returns>The corresponding <see cref = "ConnectionType"/> value.</returns>
                internal static Skyline.DataMiner.Library.Common.ConnectionType ConvertStringToConnectionType(string type)
                {
                    if (type == null)
                    {
                        throw new System.ArgumentNullException("type");
                    }

                    if (System.String.IsNullOrWhiteSpace(type))
                    {
                        throw new System.ArgumentException("The type must not be empty.", "type");
                    }

                    string valueLower = type.ToUpperInvariant();
                    Skyline.DataMiner.Library.Common.ConnectionType result;
                    if (!ConnectionTypeMapping.TryGetValue(valueLower, out result))
                    {
                        throw new System.Collections.Generic.KeyNotFoundException(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "The key {0} could not be found.", valueLower));
                    }

                    return result;
                }
            }

            /// <summary>
            /// Class containing helper methods.
            /// </summary>
            internal static class HelperClass
            {
                /// <summary>
                /// Checks the element state and throws an exception if no operation is possible due to the current element state.
                /// </summary>
                /// <param name = "element">The element on which to check the state.</param>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner system.</exception>
                /// <exception cref = "ElementStoppedException">The element is stopped.</exception>
                internal static void CheckElementState(Skyline.DataMiner.Library.Common.IDmsElement element)
                {
                    if (element.State == Skyline.DataMiner.Library.Common.ElementState.Deleted)
                    {
                        throw new Skyline.DataMiner.Library.Common.ElementNotFoundException(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Failed to perform an operation on the element: {0} because it has been deleted.", element.Name));
                    }

                    if (element.State == Skyline.DataMiner.Library.Common.ElementState.Stopped)
                    {
                        throw new Skyline.DataMiner.Library.Common.ElementStoppedException(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Failed to perform an operation on the element: {0} because it has been stopped.", element.Name));
                    }
                }

                /// <summary>
                /// Determines if a connection is using a dedicated connection or not (e.g serial single, smart serial single).
                /// </summary>
                /// <param name = "info">ElementPortInfo</param>
                /// <returns>Whether a connection is marked as single or not.</returns>
                internal static bool IsDedicatedConnection(Skyline.DataMiner.Net.Messages.ElementPortInfo info)
                {
                    bool isDedicatedConnection = false;
                    switch (info.ProtocolType)
                    {
                        case Skyline.DataMiner.Net.Messages.ProtocolType.SerialSingle:
                        case Skyline.DataMiner.Net.Messages.ProtocolType.SmartSerialRawSingle:
                        case Skyline.DataMiner.Net.Messages.ProtocolType.SmartSerialSingle:
                            isDedicatedConnection = true;
                            break;
                        default:
                            isDedicatedConnection = false;
                            break;
                    }

                    return isDedicatedConnection;
                }
            }

            /// <summary>
            ///     DataMiner System interface.
            /// </summary>
            public interface IDms
            {
                /// <summary>
                ///     Gets the communication interface.
                /// </summary>
                /// <value>The communication interface.</value>
                Skyline.DataMiner.Library.Common.ICommunication Communication
                {
                    get;
                }

                /// <summary>
                ///     Gets the element property definitions available in the DataMiner System.
                /// </summary>
                /// <value>The element property definitions available in the DataMiner System.</value>
                Skyline.DataMiner.Library.Common.IPropertyDefinitionCollection<Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition> ElementPropertyDefinitions
                {
                    get;
                }

                /// <summary>
                ///     Gets the service property definitions available in the DataMiner System.
                /// </summary>
                /// <value>The service property definitions available in the DataMiner System.</value>
                Skyline.DataMiner.Library.Common.IPropertyDefinitionCollection<Skyline.DataMiner.Library.Common.Properties.IDmsServicePropertyDefinition> ServicePropertyDefinitions
                {
                    get;
                }

                /// <summary>
                ///     Gets the view property definitions available in the DataMiner System.
                /// </summary>
                /// <value>The view property definitions available in the DataMiner System.</value>
                Skyline.DataMiner.Library.Common.IPropertyDefinitionCollection<Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition> ViewPropertyDefinitions
                {
                    get;
                }

                /// <summary>
                ///     Determines whether an element with the specified name exists in the DataMiner System.
                /// </summary>
                /// <param name = "elementName">The name of the element.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "elementName"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "elementName"/> is the empty string ("") or white space.</exception>
                /// <returns><c>true</c> if the element exists; otherwise, <c>false</c>.</returns>
                bool ElementExists(string elementName);
                /// <summary>
                ///     Gets the DataMiner Agents found in the DataMiner System.
                /// </summary>
                /// <returns>The DataMiner Agents in the DataMiner System.</returns>
                System.Collections.Generic.ICollection<Skyline.DataMiner.Library.Common.IDma> GetAgents();
                /// <summary>
                ///     Retrieves the element with the specified element name.
                /// </summary>
                /// <param name = "elementName">The name of the element.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "elementName"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "elementName"/> is the empty string ("") or white space.</exception>
                /// <exception cref = "ElementNotFoundException">No element with the specified name exists in the DataMiner system.</exception>
                /// <returns>The element with the specified name.</returns>
                Skyline.DataMiner.Library.Common.IDmsElement GetElement(string elementName);
            }

            /// <summary>
            /// Contains methods for input validation.
            /// </summary>
            internal static class InputValidator
            {
                /// <summary>
                /// Validates the name of an element, service, redundancy group, template or folder.
                /// </summary>
                /// <param name = "name">The element name.</param>
                /// <param name = "parameterName">The name of the parameter that is passing the name.</param>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation is empty or white space.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation exceeds 200 characters.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation contains a forbidden character.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation contains more than one '%' character.</exception>
                /// <returns><c>true</c> if the name is valid; otherwise, <c>false</c>.</returns>
                /// <remarks>Forbidden characters: '\', '/', ':', '*', '?', '"', '&lt;', '&gt;', '|', '°', ';'.</remarks>
                public static string ValidateName(string name, string parameterName)
                {
                    if (name == null)
                    {
                        throw new System.ArgumentNullException("name");
                    }

                    if (parameterName == null)
                    {
                        throw new System.ArgumentNullException("parameterName");
                    }

                    if (System.String.IsNullOrWhiteSpace(name))
                    {
                        throw new System.ArgumentException("The name must not be null or white space.", parameterName);
                    }

                    string trimmedName = name.Trim();
                    if (trimmedName.Length > 200)
                    {
                        throw new System.ArgumentException("The name must not exceed 200 characters.", parameterName);
                    }

                    // White space is trimmed.
                    if (trimmedName[0].Equals('.'))
                    {
                        throw new System.ArgumentException("The name must not start with a dot ('.').", parameterName);
                    }

                    if (trimmedName[trimmedName.Length - 1].Equals('.'))
                    {
                        throw new System.ArgumentException("The name must not end with a dot ('.').", parameterName);
                    }

                    if (!System.Text.RegularExpressions.Regex.IsMatch(trimmedName, @"^[^/\\:;\*\?<>\|°""]+$"))
                    {
                        throw new System.ArgumentException("The name contains a forbidden character.", parameterName);
                    }

                    if (System.Linq.Enumerable.Count(trimmedName, x => x == '%') > 1)
                    {
                        throw new System.ArgumentException("The name must not contain more than one '%' characters.", parameterName);
                    }

                    return trimmedName;
                }

                /// <summary>
                /// Validates the specified name for a view.
                /// </summary>
                /// <param name = "name">The view name.</param>
                /// <param name = "parameterName">The name of the parameter to which the view name is passed.</param>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "name"/> is invalid.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation exceeds 200 characters.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation contains a forbidden character.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation contains more than one '%' character.</exception>
                /// <returns>The validated view name.</returns>
                public static string ValidateViewName(string name, string parameterName)
                {
                    if (name == null)
                    {
                        throw new System.ArgumentNullException(parameterName);
                    }

                    if (System.String.IsNullOrWhiteSpace(name))
                    {
                        throw new System.ArgumentException("The name must not be null or white space.", parameterName);
                    }

                    string trimmedName = name.Trim();
                    if (trimmedName.Length > 0)
                    {
                        if (trimmedName.Length > 200)
                        {
                            throw new System.ArgumentException("The name must not exceed 200 characters.", parameterName);
                        }

                        ValidateViewNameForbiddenCharacters(trimmedName, parameterName);
                    }

                    return trimmedName;
                }

                /// <summary>
                /// Determines whether the specified template is compatible with the specified protocol.
                /// </summary>
                /// <param name = "template">The template.</param>
                /// <param name = "protocol">The protocol.</param>
                /// <returns><c>true</c> if the template is compatible with the protocol; otherwise, <c>false</c>.</returns>
                public static bool IsCompatibleTemplate(Skyline.DataMiner.Library.Common.Templates.IDmsTemplate template, Skyline.DataMiner.Library.Common.IDmsProtocol protocol)
                {
                    bool isCompatible = true;
                    if (template != null && (!template.Protocol.Name.Equals(protocol.Name, System.StringComparison.OrdinalIgnoreCase) || !template.Protocol.Version.Equals(protocol.Version, System.StringComparison.OrdinalIgnoreCase)))
                    {
                        isCompatible = false;
                    }

                    return isCompatible;
                }

                /// <summary>
                /// Validates the specified name for a view for forbidden characters.
                /// </summary>
                /// <param name = "viewName">The view name.</param>
                /// <param name = "parameterName">The name of the parameter to which the view name is passed.</param>
                /// <exception cref = "ArgumentException"><paramref name = "viewName"/> is invalid.</exception>
                private static void ValidateViewNameForbiddenCharacters(string viewName, string parameterName)
                {
                    if (viewName[0].Equals('.'))
                    {
                        throw new System.ArgumentException("The name must not start with a dot ('.').", parameterName);
                    }

                    if (viewName[viewName.Length - 1].Equals('.'))
                    {
                        throw new System.ArgumentException("The name must not end with a dot ('.').", parameterName);
                    }

                    if (System.Linq.Enumerable.Contains(viewName, '|'))
                    {
                        throw new System.ArgumentException("The name contains a forbidden character. (Forbidden characters: '|')", parameterName);
                    }

                    if (System.Linq.Enumerable.Count(viewName, x => x == '%') > 1)
                    {
                        throw new System.ArgumentException("The name must not contain more than one '%' characters.", parameterName);
                    }
                }
            }

            /// <summary>
            /// Updateable interface.
            /// </summary>
            public interface IUpdateable
            {
            }

            /// <summary>
            /// Represents a DataMiner Agent.
            /// </summary>
            internal class Dma : Skyline.DataMiner.Library.Common.DmsObject, Skyline.DataMiner.Library.Common.IDma
            {
                /// <summary>
                /// The object used for DMS communication.
                /// </summary>
                private new readonly Skyline.DataMiner.Library.Common.IDms dms;
                /// <summary>
                /// The DataMiner Agent ID.
                /// </summary>
                private readonly int id;
                private string hostName;
                private string name;
                private Skyline.DataMiner.Library.Common.IDmsScheduler scheduler;
                private Skyline.DataMiner.Library.Common.AgentState state;
                private bool stateRetrieved;
                private string versionInfo;
                /// <summary>
                /// Initializes a new instance of the <see cref = "Dma"/> class.
                /// </summary>
                /// <param name = "dms">The DataMiner System.</param>
                /// <param name = "id">The ID of the DataMiner Agent.</param>
                /// <exception cref = "ArgumentNullException">The <see cref = "IDms"/> reference is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The DataMiner Agent ID is negative.</exception>
                internal Dma(Skyline.DataMiner.Library.Common.IDms dms, int id): base(dms)
                {
                    if (id < 1)
                    {
                        throw new System.ArgumentException(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid DataMiner agent ID: {0}", id), "id");
                    }

                    this.dms = dms;
                    this.id = id;
                }

                internal Dma(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.GetDataMinerInfoResponseMessage infoMessage): base(dms)
                {
                    if (infoMessage == null)
                    {
                        throw new System.ArgumentNullException("infoMessage");
                    }

                    Parse(infoMessage);
                }

                /// <summary>
                /// Gets the name of the host that is hosting this DataMiner Agent.
                /// </summary>
                /// <value>The name of the host.</value>
                /// <exception cref = "AgentNotFoundException">The Agent was not found in the DataMiner System.</exception>
                public string HostName
                {
                    get
                    {
                        LoadOnDemand();
                        return hostName;
                    }
                }

                /// <summary>
                /// Gets the ID of this DataMiner Agent.
                /// </summary>
                /// <value>The ID of this DataMiner Agent.</value>
                public int Id
                {
                    get
                    {
                        return id;
                    }
                }

                /// <summary>
                /// Gets the name of this DataMiner Agent.
                /// </summary>
                /// <value>The name of this DataMiner Agent.</value>
                /// <exception cref = "AgentNotFoundException">The Agent was not found in the DataMiner System.</exception>
                public string Name
                {
                    get
                    {
                        LoadOnDemand();
                        return name;
                    }
                }

                /// <summary>
                /// Gets the Scheduler component of the DataMiner System.
                /// </summary>
                public Skyline.DataMiner.Library.Common.IDmsScheduler Scheduler
                {
                    get
                    {
                        LoadOnDemand();
                        return scheduler;
                    }
                }

                /// <summary>
                /// Gets the state of this DataMiner Agent.
                /// </summary>
                /// <value>The state of this DataMiner Agent.</value>
                /// <exception cref = "AgentNotFoundException">The Agent was not found in the DataMiner System.</exception>
                public Skyline.DataMiner.Library.Common.AgentState State
                {
                    get
                    {
                        if (!stateRetrieved)
                        {
                            try
                            {
                                Skyline.DataMiner.Net.Messages.GetDataMinerStateMessage message = new Skyline.DataMiner.Net.Messages.GetDataMinerStateMessage(id);
                                var response = dms.Communication.SendSingleResponseMessage(message) as Skyline.DataMiner.Net.Messages.GetDataMinerStateResponseMessage;
                                if (response != null)
                                {
                                    stateRetrieved = true;
                                    state = (Skyline.DataMiner.Library.Common.AgentState)response.State;
                                }
                            }
                            catch (Skyline.DataMiner.Net.Exceptions.DataMinerCommunicationException e)
                            {
                                if (e.ErrorCode == -2147220787)
                                {
                                    // 0x800402CD No connection.
                                    throw new Skyline.DataMiner.Library.Common.AgentNotFoundException(id);
                                }
                            }
                        }

                        return state;
                    }
                }

                /// <summary>
                /// Gets the version information of the DataMiner Agent.
                /// </summary>
                public string VersionInfo
                {
                    get
                    {
                        LoadOnDemand();
                        return versionInfo;
                    }
                }

                /// <summary>
                /// Returns a string that represents the current object.
                /// </summary>
                /// <returns>A string that represents the current object.</returns>
                public override string ToString()
                {
                    return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "DataMiner agent ID: {0}", id);
                }

                internal override void Load()
                {
                    try
                    {
                        Skyline.DataMiner.Net.Messages.GetDataMinerByIDMessage message = new Skyline.DataMiner.Net.Messages.GetDataMinerByIDMessage(id);
                        Skyline.DataMiner.Net.Messages.GetDataMinerInfoResponseMessage infoResponseMessage = Dms.Communication.SendSingleResponseMessage(message) as Skyline.DataMiner.Net.Messages.GetDataMinerInfoResponseMessage;
                        if (infoResponseMessage != null)
                        {
                            Parse(infoResponseMessage);
                        }
                        else
                        {
                            throw new Skyline.DataMiner.Library.Common.AgentNotFoundException(id);
                        }

                        Skyline.DataMiner.Net.Messages.GetAgentBuildInfo buildInfoMessage = new Skyline.DataMiner.Net.Messages.GetAgentBuildInfo(id);
                        Skyline.DataMiner.Net.Messages.BuildInfoResponse buildInfoResponse = (Skyline.DataMiner.Net.Messages.BuildInfoResponse)Dms.Communication.SendSingleResponseMessage(buildInfoMessage);
                        if (buildInfoResponse != null)
                        {
                            Parse(buildInfoResponse);
                        }

                        Skyline.DataMiner.Net.Messages.RSAPublicKeyRequest rsapkr;
                        rsapkr = new Skyline.DataMiner.Net.Messages.RSAPublicKeyRequest(id)
                        {HostingDataMinerID = id};
                        Skyline.DataMiner.Net.Messages.RSAPublicKeyResponse resp = Dms.Communication.SendSingleResponseMessage(rsapkr) as Skyline.DataMiner.Net.Messages.RSAPublicKeyResponse;
                        Skyline.DataMiner.Library.Common.RSA.PublicKey = new System.Security.Cryptography.RSAParameters{Modulus = resp.Modulus, Exponent = resp.Exponent};
                        scheduler = new Skyline.DataMiner.Library.Common.DmsScheduler(this);
                        IsLoaded = true;
                    }
                    catch (Skyline.DataMiner.Net.Exceptions.DataMinerException e)
                    {
                        if (e.ErrorCode == -2146233088)
                        {
                            // 0x80131500, No agent available with ID.
                            throw new Skyline.DataMiner.Library.Common.AgentNotFoundException(id);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                private void Parse(Skyline.DataMiner.Net.Messages.GetDataMinerInfoResponseMessage infoMessage)
                {
                    name = infoMessage.AgentName;
                    hostName = infoMessage.ComputerName;
                }

                /// <summary>
                /// Parses the version information of the DataMiner Agent.
                /// </summary>
                /// <param name = "response">The response message.</param>
                private void Parse(Skyline.DataMiner.Net.Messages.BuildInfoResponse response)
                {
                    if (response == null || response.Agents == null || response.Agents.Length == 0)
                    {
                        throw new System.ArgumentException("Agent build information cannot be null or empty");
                    }

                    string rawVersion = response.Agents[0].RawVersion;
                    this.versionInfo = rawVersion;
                }
            }

            /// <summary>
            /// DataMiner Agent interface.
            /// </summary>
            public interface IDma
            {
                /// <summary>
                /// Gets the DataMiner System this Agent is part of.
                /// </summary>
                /// <value>The DataMiner system this Agent is part of.</value>
                Skyline.DataMiner.Library.Common.IDms Dms
                {
                    get;
                }

                /// <summary>
                /// Gets the name of the host of this DataMiner Agent.
                /// </summary>
                /// <value>The name of the host of this DataMiner Agent.</value>
                /// <exception cref = "AgentNotFoundException">The Agent was not found in the DataMiner System.</exception>
                string HostName
                {
                    get;
                }

                /// <summary>
                /// Gets the ID of this DataMiner Agent.
                /// </summary>
                /// <value>The ID of this DataMiner Agent.</value>
                int Id
                {
                    get;
                }

                /// <summary>
                /// Gets the name of this DataMiner Agent.
                /// </summary>
                /// <value>The name of this DataMiner Agent.</value>
                /// <exception cref = "AgentNotFoundException">The Agent was not found in the DataMiner System.</exception>
                string Name
                {
                    get;
                }

                /// <summary>
                /// Gets the Scheduler component of the DataMiner System.
                /// </summary>
                Skyline.DataMiner.Library.Common.IDmsScheduler Scheduler
                {
                    get;
                }

                /// <summary>
                /// Gets the state of this DataMiner Agent.
                /// </summary>
                /// <value>The state of this DataMiner Agent.</value>
                /// <exception cref = "AgentNotFoundException">The Agent was not found in the DataMiner System.</exception>
                Skyline.DataMiner.Library.Common.AgentState State
                {
                    get;
                }

                /// <summary>
                /// Gets the version info of this DataMiner Agent.
                /// </summary>
                string VersionInfo
                {
                    get;
                }
            }

            /// <summary>
            /// Represents a communication interface implementation using the <see cref = "IConnection"/> interface.
            /// </summary>
            internal class ConnectionCommunication : Skyline.DataMiner.Library.Common.ICommunication
            {
                /// <summary>
                /// The SLNet connection.
                /// </summary>
                private readonly Skyline.DataMiner.Net.IConnection connection;
                /// <summary>
                /// Initializes a new instance of the <see cref = "ConnectionCommunication"/> class using an instance of the <see cref = "IConnection"/> class.
                /// </summary>
                /// <param name = "connection">The connection.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "connection"/> is <see langword = "null"/>.</exception>
                public ConnectionCommunication(Skyline.DataMiner.Net.IConnection connection)
                {
                    if (connection == null)
                    {
                        throw new System.ArgumentNullException("connection");
                    }

                    this.connection = connection;
                }

                /// <summary>
                /// Sends a message to the SLNet process.
                /// </summary>
                /// <param name = "message">The message to be sent.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "message"/> is <see langword = "null"/>.</exception>
                /// <returns>The message responses.</returns>
                public Skyline.DataMiner.Net.Messages.DMSMessage[] SendMessage(Skyline.DataMiner.Net.Messages.DMSMessage message)
                {
                    if (message == null)
                    {
                        throw new System.ArgumentNullException("message");
                    }

                    return connection.HandleMessage(message);
                }

                /// <summary>
                /// Sends a message to the SLNet process.
                /// </summary>
                /// <param name = "message">The message to be sent.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "message"/> is <see langword = "null"/>.</exception>
                /// <returns>The message response.</returns>
                public Skyline.DataMiner.Net.Messages.DMSMessage SendSingleResponseMessage(Skyline.DataMiner.Net.Messages.DMSMessage message)
                {
                    if (message == null)
                    {
                        throw new System.ArgumentNullException("message");
                    }

                    return connection.HandleSingleResponseMessage(message);
                }
            }

            /// <summary>
            /// Defines methods to send messages to a DataMiner System.
            /// </summary>
            public interface ICommunication
            {
                /// <summary>
                /// Sends a message to the SLNet process that can have multiple responses.
                /// </summary>
                /// <param name = "message">The message to be sent.</param>
                /// <exception cref = "ArgumentNullException">The message cannot be null.</exception>
                /// <returns>The message responses.</returns>
                Skyline.DataMiner.Net.Messages.DMSMessage[] SendMessage(Skyline.DataMiner.Net.Messages.DMSMessage message);
                /// <summary>
                /// Sends a message to the SLNet process that returns a single response.
                /// </summary>
                /// <param name = "message">The message to be sent.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "message"/> is <see langword = "null"/>.</exception>
                /// <returns>The message response.</returns>
                Skyline.DataMiner.Net.Messages.DMSMessage SendSingleResponseMessage(Skyline.DataMiner.Net.Messages.DMSMessage message);
            }

            /// <summary>
            /// Defines methods to support the comparison of DataMiner views for equality.
            /// </summary>
            public class DmsViewEqualityComparer : System.Collections.Generic.EqualityComparer<Skyline.DataMiner.Library.Common.IDmsView>
            {
                /// <summary>
                /// Determines whether the specified view objects are equal.
                /// </summary>
                /// <param name = "x">The first object to compare.</param>
                /// <param name = "y">The second object to compare.</param>
                /// <returns><c>true</c> if the specified views have the same ID; otherwise, <c>false</c>.</returns>
                public override bool Equals(Skyline.DataMiner.Library.Common.IDmsView x, Skyline.DataMiner.Library.Common.IDmsView y)
                {
                    if (x == null && y == null)
                    {
                        return true;
                    }

                    if (x == null || y == null)
                    {
                        return false;
                    }

                    return x.Id == y.Id;
                }

                /// <summary>
                /// Returns a hash code for the specified object.
                /// </summary>
                /// <param name = "obj">The object for which to get a hash code.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "obj"/> is <see langword = "null"/>.</exception>
                /// <returns>A hash code for the specified object.</returns>
                public override int GetHashCode(Skyline.DataMiner.Library.Common.IDmsView obj)
                {
                    if (obj == null)
                    {
                        throw new System.ArgumentNullException("obj");
                    }

                    return obj.Id.GetHashCode();
                }
            }

            /// <summary>
            /// A collection of IElementConnection objects.
            /// </summary>
            public class ElementConnectionCollection : Skyline.DataMiner.Library.Common.IElementConnectionCollection
            {
                private readonly Skyline.DataMiner.Library.Common.IElementConnection[] connections;
                private readonly bool canBeValidated;
                private readonly System.Collections.Generic.IList<Skyline.DataMiner.Library.Common.IDmsConnectionInfo> protocolConnectionInfo;
                /// <summary>
                /// initiates a new instance.
                /// </summary>
                /// <param name = "protocolConnectionInfo"></param>
                internal ElementConnectionCollection(System.Collections.Generic.IList<Skyline.DataMiner.Library.Common.IDmsConnectionInfo> protocolConnectionInfo)
                {
                    int amountOfConnections = protocolConnectionInfo.Count;
                    this.connections = new Skyline.DataMiner.Library.Common.IElementConnection[amountOfConnections];
                    this.protocolConnectionInfo = protocolConnectionInfo;
                    canBeValidated = true;
                }

                /// <summary>
                /// Initiates a new instance.
                /// </summary>
                /// <param name = "message"></param>
                internal ElementConnectionCollection(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage message)
                {
                    int amountOfConnections = 1;
                    if (message != null && message.ExtraPorts != null)
                    {
                        amountOfConnections += message.ExtraPorts.Length;
                    }

                    this.connections = new Skyline.DataMiner.Library.Common.IElementConnection[amountOfConnections];
                    canBeValidated = false;
                }

                /// <summary>
                /// Gets the total amount of elements in the collection.
                /// </summary>
                public int Length
                {
                    get
                    {
                        return connections.Length;
                    }
                }

                /// <summary>
                /// Returns the collection as a IElementConnection array.
                /// </summary>
                public System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IElementConnection> Enumerator
                {
                    get
                    {
                        return connections;
                    }
                }

                /// <summary>
                /// Returns an enumerator that iterates through the collection.
                /// </summary>
                /// <returns>An enumerator that can be used to iterate through the collection.</returns>
                public System.Collections.Generic.IEnumerator<Skyline.DataMiner.Library.Common.IElementConnection> GetEnumerator()
                {
                    return ((System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IElementConnection>)connections).GetEnumerator();
                }

                /// <summary>
                /// Returns an enumerator that iterates through a collection.
                /// </summary>
                /// <returns>An <see cref = "IEnumerator"/> object that can be used to iterate through the collection.</returns>
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return this.GetEnumerator();
                }

                /// <summary>
                /// Gets or sets an entry in the collection.
                /// </summary>
                /// <param name = "index"></param>
                /// <returns></returns>
                public Skyline.DataMiner.Library.Common.IElementConnection this[int index]
                {
                    get
                    {
                        return connections[index];
                    }

                    set
                    {
                        bool valid = ValidateConnectionTypeAtPos(index, value);
                        if (valid)
                        {
                            connections[index] = value;
                        }
                        else
                        {
                            throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Invalid connection type provided at index " + index);
                        }
                    }
                }

                /// <summary>
                /// Validates the provided <see cref = "IElementConnection"/> against the provided Protocol.
                /// </summary>
                /// <param name = "index">The index position of the connection to validate.</param>
                /// <param name = "conn">The IElementConnection connection.</param>
                /// <exception cref = "ArgumentOutOfRangeException"><paramref name = "index"/> is out of range.</exception>
                /// <returns></returns>
                private bool ValidateConnectionTypeAtPos(int index, Skyline.DataMiner.Library.Common.IElementConnection conn)
                {
                    if (!canBeValidated)
                    {
                        return true;
                    }

                    if (index < 0 || ((index + 1) > protocolConnectionInfo.Count))
                    {
                        throw new System.ArgumentOutOfRangeException("index", "Index needs to be between 0 and the amount of connections in the protocol minus 1.");
                    }

                    return ValidateConnectionInfo(conn, protocolConnectionInfo[index]);
                }

                /// <summary>
                /// Validates a single connection.
                /// </summary>
                /// <param name = "conn"><see cref = "IElementConnection"/> object.</param>
                /// <param name = "connectionInfo"><see cref = "IDmsConnectionInfo"/> object.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "conn"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentNullException"><paramref name = "connectionInfo"/> is <see langword = "null"/>.</exception>
                /// <returns></returns>
                private static bool ValidateConnectionInfo(Skyline.DataMiner.Library.Common.IElementConnection conn, Skyline.DataMiner.Library.Common.IDmsConnectionInfo connectionInfo)
                {
                    if (conn == null)
                    {
                        throw new Skyline.DataMiner.Library.Common.IncorrectDataException("conn: Invalid data , ElementConfiguration does not contain connection info");
                    }

                    if (connectionInfo == null)
                    {
                        throw new Skyline.DataMiner.Library.Common.IncorrectDataException("connectionInfo: Invalid data , Protocol does not contain connection info");
                    }

                    switch (connectionInfo.Type)
                    {
                        case Skyline.DataMiner.Library.Common.ConnectionType.SnmpV1:
                            return ValidateAsSnmpV1(conn);
                        case Skyline.DataMiner.Library.Common.ConnectionType.SnmpV2:
                            return ValidateAsSnmpV2(conn);
                        case Skyline.DataMiner.Library.Common.ConnectionType.SnmpV3:
                            return ValidateAsSnmpV3(conn);
                        case Skyline.DataMiner.Library.Common.ConnectionType.Virtual:
                            return conn is Skyline.DataMiner.Library.Common.IVirtualConnection;
                        case Skyline.DataMiner.Library.Common.ConnectionType.Http:
                            return conn is Skyline.DataMiner.Library.Common.IHttpConnection;
                        default:
                            return false;
                    }
                }

                /// <summary>
                /// Validate a connection for SNMPv1
                /// </summary>
                /// <param name = "conn">object of type <see cref = "IElementConnection"/> to validate.</param>
                /// <returns></returns>
                private static bool ValidateAsSnmpV1(Skyline.DataMiner.Library.Common.IElementConnection conn)
                {
                    return conn is Skyline.DataMiner.Library.Common.ISnmpV1Connection || conn is Skyline.DataMiner.Library.Common.ISnmpV2Connection || conn is Skyline.DataMiner.Library.Common.ISnmpV3Connection;
                }

                /// <summary>
                /// Validate a connection for SNMPv2
                /// </summary>
                /// <param name = "conn">object of type <see cref = "IElementConnection"/> to validate.</param>
                /// <returns></returns>
                private static bool ValidateAsSnmpV2(Skyline.DataMiner.Library.Common.IElementConnection conn)
                {
                    return conn is Skyline.DataMiner.Library.Common.ISnmpV2Connection || conn is Skyline.DataMiner.Library.Common.ISnmpV3Connection;
                }

                /// <summary>
                /// Validate a connection for SNMPv3
                /// </summary>
                /// <param name = "conn">object of type <see cref = "IElementConnection"/> to validate.</param>
                /// <returns></returns>
                private static bool ValidateAsSnmpV3(Skyline.DataMiner.Library.Common.IElementConnection conn)
                {
                    return conn is Skyline.DataMiner.Library.Common.ISnmpV3Connection || conn is Skyline.DataMiner.Library.Common.ISnmpV2Connection;
                }
            }

            /// <summary>
            /// A collection of IElementConnection objects.
            /// </summary>
            public interface IElementConnectionCollection : System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IElementConnection>
            {
                /// <summary>
                /// Gets or sets an entry in the collection.
                /// </summary>
                Skyline.DataMiner.Library.Common.IElementConnection this[int index]
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets the total amount of elements in the collection.
                /// </summary>
                int Length
                {
                    get;
                }

                /// <summary>
                /// Returns the collection as a IElementConnection array.
                /// </summary>
                System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IElementConnection> Enumerator
                {
                    get;
                }
            }

            /// <summary>
            /// Represents information about a connection.
            /// </summary>
            internal class DmsConnectionInfo : Skyline.DataMiner.Library.Common.IDmsConnectionInfo
            {
                /// <summary>
                /// The name of the connection.
                /// </summary>
                private readonly string name;
                /// <summary>
                /// The connection type.
                /// </summary>
                private readonly Skyline.DataMiner.Library.Common.ConnectionType type;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsConnectionInfo"/> class.
                /// </summary>
                /// <param name = "name">The connection name.</param>
                /// <param name = "type">The connection type.</param>
                internal DmsConnectionInfo(string name, Skyline.DataMiner.Library.Common.ConnectionType type)
                {
                    this.name = name;
                    this.type = type;
                }

                /// <summary>
                /// Gets the connection name.
                /// </summary>
                /// <value>The connection name.</value>
                public string Name
                {
                    get
                    {
                        return name;
                    }
                }

                /// <summary>
                /// Gets the connection type.
                /// </summary>
                /// <value>The connection type.</value>
                public Skyline.DataMiner.Library.Common.ConnectionType Type
                {
                    get
                    {
                        return type;
                    }
                }

                /// <summary>
                /// Returns a string that represents the current object.
                /// </summary>
                /// <returns>A string that represents the current object.</returns>
                public override string ToString()
                {
                    return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Connection with Name:{0} and Type:{1}.", name, type);
                }
            }

            /// <summary>
            /// DataMiner element connection information interface.
            /// </summary>
            public interface IDmsConnectionInfo
            {
                /// <summary>
                /// Gets the connection name.
                /// </summary>
                /// <value>The connection name.</value>
                string Name
                {
                    get;
                }

                /// <summary>
                /// Gets the connection type.
                /// </summary>
                /// <value>The connection type.</value>
                Skyline.DataMiner.Library.Common.ConnectionType Type
                {
                    get;
                }
            }

            /// <summary>
            /// Specifies the state of the Agent.
            /// </summary>
            public enum AgentState
            {
                /// <summary>
                /// Specifies the not running state.
                /// </summary>
                NotRunning = 0,
                /// <summary>
                /// Specifies the running state.
                /// </summary>
                Running = 1,
                /// <summary>
                /// Specifies the starting state.
                /// </summary>
                Starting = 2,
                /// <summary>
                /// Specifies the unknown state.
                /// </summary>
                Unknown = 3,
                /// <summary>
                /// Specifies the switching state.
                /// </summary>
                Switching = 4
            }

            /// <summary>
            /// Specifies the connection type.
            /// </summary>
            public enum ConnectionType
            {
                /// <summary>
                /// Undefined connection type.
                /// </summary>
                Undefined = 0,
                /// <summary>
                /// SNMPv1 connection.
                /// </summary>
                SnmpV1 = 1,
                /// <summary>
                /// Serial connection.
                /// </summary>
                Serial = 2,
                /// <summary>
                /// Smart-serial connection.
                /// </summary>
                SmartSerial = 3,
                /// <summary>
                /// Virtual connection.
                /// </summary>
                Virtual = 4,
                /// <summary>
                /// GBIP (General Purpose Interface Bus) connection.
                /// </summary>
                Gpib = 5,
                /// <summary>
                /// OPC (OLE for Process Control) connection.
                /// </summary>
                Opc = 6,
                /// <summary>
                /// SLA (Service Level Agreement).
                /// </summary>
                Sla = 7,
                /// <summary>
                /// SNMPv2 connection.
                /// </summary>
                SnmpV2 = 8,
                /// <summary>
                /// SNMPv3 connection.
                /// </summary>
                SnmpV3 = 9,
                /// <summary>
                /// HTTP connection.
                /// </summary>
                Http = 10,
                /// <summary>
                /// Service.
                /// </summary>
                Service = 11,
                /// <summary>
                /// Serial single connection.
                /// </summary>
                SerialSingle = 12,
                /// <summary>
                /// Smart-serial single connection.
                /// </summary>
                SmartSerialSingle = 13,
                /// <summary>
                /// Web Socket connection.
                /// </summary>
                WebSocket = 14
            }

            /// <summary>
            /// The alarm level of an element, parameter or alarm.
            /// </summary>
            public enum AlarmLevel
            {
                /// <summary>
                /// No alarm
                /// </summary>
                Undefined = 0,
                /// <summary>
                /// Normal
                /// </summary>
                Normal = 1,
                /// <summary>
                /// Warning
                /// </summary>
                Warning = 2,
                /// <summary>
                /// Minor
                /// </summary>
                Minor = 3,
                /// <summary>
                /// Major
                /// </summary>
                Major = 4,
                /// <summary>
                /// Critical
                /// </summary>
                Critical = 5,
                /// <summary>
                /// Information
                /// </summary>
                Information = 6,
                /// <summary>
                /// Timeout
                /// </summary>
                Timeout = 7,
                /// <summary>
                /// Initial
                /// </summary>
                Initial = 8,
                /// <summary>
                /// Masked
                /// </summary>
                Masked = 9,
                /// <summary>
                /// Error
                /// </summary>
                Error = 10,
                /// <summary>
                /// Notice
                /// </summary>
                Notice = 11,
                /// <summary>
                /// Suggestion
                /// </summary>
                Suggestion = 12
            }

            /// <summary>
            /// Specifies the state of the element.
            /// </summary>
            public enum ElementState
            {
                /// <summary>
                /// Specifies the undefined element state.
                /// </summary>
                Undefined = 0,
                /// <summary>
                /// Specifies the active element state.
                /// </summary>
                Active = 1,
                /// <summary>
                /// Specifies the hidden element state.
                /// </summary>
                Hidden = 2,
                /// <summary>
                /// Specifies the paused element state.
                /// </summary>
                Paused = 3,
                /// <summary>
                /// Specifies the stopped element state.
                /// </summary>
                Stopped = 4,
                /// <summary>
                /// Specifies the deleted element state.
                /// </summary>
                Deleted = 6,
                /// <summary>
                /// Specifies the error element state.
                /// </summary>
                Error = 10,
                /// <summary>
                /// Specifies the restart element state.
                /// </summary>
                Restart = 11,
                /// <summary>
                /// Specifies the masked element state.
                /// </summary>
                Masked = 12
            }

            /// <summary>
            /// Specifies the type of the filtering.
            /// </summary>
            public enum FilterType
            {
                /// <summary>
                /// Filtering done on display key.
                /// </summary>
                Display = 0,
                /// <summary>
                /// Filtering done on primary key.
                /// </summary>
                PrimaryKey = 1
            }

            /// <summary>
            /// Specifies the protocol type.
            /// </summary>
            public enum ProtocolType
            {
                /// <summary>
                /// Undefined protocol type.
                /// </summary>
                Undefined = 0,
                /// <summary>
                /// The SNMP protocol type.
                /// </summary>
                Snmp = 1,
                /// <summary>
                /// The SNMPv1 protocol type.
                /// </summary>
                SnmpV1 = 1,
                /// <summary>
                /// The serial protocol type.
                /// </summary>
                Serial = 2,
                /// <summary>
                /// The smart serial protocol type.
                /// </summary>
                SmartSerial = 3,
                /// <summary>
                /// The virtual protocol type.
                /// </summary>
                Virtual = 4,
                /// <summary>
                /// The General Purpose Interface Bus (GPIB) protocol type.
                /// </summary>
                Gpib = 5,
                /// <summary>
                /// The OLE Process Controller (OPC) protocol type.
                /// </summary>
                Opc = 6,
                /// <summary>
                /// The Service Level Agreement (SLA) protocol type.
                /// </summary>
                Sla = 7,
                /// <summary>
                /// The SNMPv2 protocol type.
                /// </summary>
                SnmpV2 = 8,
                /// <summary>
                /// The SNMPv3 protocol type.
                /// </summary>
                SnmpV3 = 9,
                /// <summary>
                /// The HTTP protocol type.
                /// </summary>
                Http = 10,
                /// <summary>
                /// The service protocol type.
                /// </summary>
                Service = 11,
                /// <summary>
                /// The serial single protocol type.
                /// </summary>
                SerialSingle = 12,
                /// <summary>
                /// The smart serial single protocol type.
                /// </summary>
                SmartSerialSingle = 13,
                /// <summary>
                /// The smart serial raw protocol type.
                /// </summary>
                SmartSerialRaw = 14,
                /// <summary>
                /// The smart serial raw single protocol type.
                /// </summary>
                SmartSerialRawSingle = 15,
                /// <summary>
                /// The websocket protocol type.
                /// </summary>
                WebSocket = 16
            }

            /// <summary>
            /// The exception that is thrown when an action is performed on a DataMiner Agent that was not found.
            /// </summary>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("System.Runtime.Serialization.dll")]
            public class AgentNotFoundException : Skyline.DataMiner.Library.Common.DmsException
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "AgentNotFoundException"/> class.
                /// </summary>
                public AgentNotFoundException()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "AgentNotFoundException"/> class with a specified DataMiner Agent ID.
                /// </summary>
                /// <param name = "id">The ID of the DataMiner Agent that was not found.</param>
                public AgentNotFoundException(int id): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "The agent with ID '{0}' was not found.", id))
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "AgentNotFoundException"/> class with a specified error message.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                public AgentNotFoundException(string message): base(message)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "AgentNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public AgentNotFoundException(string message, System.Exception innerException): base(message, innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "AgentNotFoundException"/> class with serialized data.
                /// </summary>
                /// <param name = "info">The serialization info.</param>
                /// <param name = "context">The streaming context.</param>
                /// <exception cref = "ArgumentNullException">The <paramref name = "info"/> parameter is <see langword = "null"/>.</exception>
                /// <exception cref = "SerializationException">The class name is <see langword = "null"/> or HResult is zero (0).</exception>
                /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
                protected AgentNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
                {
                }
            }

            /// <summary>
            /// The exception that is thrown when a requested alarm template was not found.
            /// </summary>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("System.Runtime.Serialization.dll")]
            public class AlarmTemplateNotFoundException : Skyline.DataMiner.Library.Common.TemplateNotFoundException
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "AlarmTemplateNotFoundException"/> class.
                /// </summary>
                public AlarmTemplateNotFoundException()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "AlarmTemplateNotFoundException"/> class.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                public AlarmTemplateNotFoundException(string message): base(message)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "AlarmTemplateNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public AlarmTemplateNotFoundException(string message, System.Exception innerException): base(message, innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "AlarmTemplateNotFoundException"/> class.
                /// </summary>
                /// <param name = "templateName">The name of the template.</param>
                /// <param name = "protocol">The protocol this template relates to.</param>
                public AlarmTemplateNotFoundException(string templateName, Skyline.DataMiner.Library.Common.IDmsProtocol protocol): base(templateName, protocol)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "AlarmTemplateNotFoundException"/> class.
                /// </summary>
                /// <param name = "templateName">The name of the template.</param>
                /// <param name = "protocolName">The name of the protocol.</param>
                /// <param name = "protocolVersion">The version of the protocol.</param>
                public AlarmTemplateNotFoundException(string templateName, string protocolName, string protocolVersion): base(templateName, protocolName, protocolVersion)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "AlarmTemplateNotFoundException"/> class with serialized data.
                /// </summary>
                /// <param name = "info">The serialization info.</param>
                /// <param name = "context">The streaming context.</param>
                /// <exception cref = "ArgumentNullException">The <paramref name = "info"/> parameter is <see langword = "null"/>.</exception>
                /// <exception cref = "SerializationException">The class name is <see langword = "null"/> or HResult is zero (0).</exception>
                /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
                protected AlarmTemplateNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
                {
                }
            }

            /// <summary>
            /// The exception that is thrown when an exception occurs in a DataMiner System.
            /// </summary>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("System.Runtime.Serialization.dll")]
            public class DmsException : System.Exception
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsException"/> class.
                /// </summary>
                public DmsException()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsException"/> class.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                public DmsException(string message): base(message)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public DmsException(string message, System.Exception innerException): base(message, innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsException"/> class with serialized data.
                /// </summary>
                /// <param name = "info">The serialization info.</param>
                /// <param name = "context">The streaming context.</param>
                /// <exception cref = "ArgumentNullException">The <paramref name = "info"/> parameter is <see langword = "null"/>.</exception>
                /// <exception cref = "SerializationException">The class name is <see langword = "null"/> or HResult is zero (0).</exception>
                /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
                protected DmsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
                {
                }
            }

            /// <summary>
            /// The exception that is thrown when performing actions on an element that was not found.
            /// </summary>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("System.Runtime.Serialization.dll")]
            public class ElementNotFoundException : Skyline.DataMiner.Library.Common.DmsException
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementNotFoundException"/> class.
                /// </summary>
                public ElementNotFoundException()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementNotFoundException"/> class.
                /// </summary>
                /// <param name = "dmsElementId">The DataMiner Agent ID/element ID of the element that was not found.</param>
                public ElementNotFoundException(Skyline.DataMiner.Library.Common.DmsElementId dmsElementId): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Element with DMA ID '{0}' and element ID '{1}' was not found.", dmsElementId.AgentId, dmsElementId.ElementId))
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementNotFoundException"/> class.
                /// </summary>
                /// <param name = "dmaId">The ID of the DataMiner Agent that was not found.</param>
                /// <param name = "elementId">The ID of the element that was not found.</param>
                public ElementNotFoundException(int dmaId, int elementId): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Element with DMA ID '{0}' and element ID '{1}' was not found.", dmaId, elementId))
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementNotFoundException"/> class.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                public ElementNotFoundException(string message): base(message)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public ElementNotFoundException(string message, System.Exception innerException): base(message, innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "dmsElementId">The DataMiner Agent ID/element ID of the element that was not found.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public ElementNotFoundException(Skyline.DataMiner.Library.Common.DmsElementId dmsElementId, System.Exception innerException): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Element with DMA ID '{0}' and element ID '{1}' was not found.", dmsElementId.AgentId, dmsElementId.ElementId), innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementNotFoundException"/> class with serialized data.
                /// </summary>
                /// <param name = "info">The serialization info.</param>
                /// <param name = "context">The streaming context.</param>
                /// <exception cref = "ArgumentNullException">The <paramref name = "info"/> parameter is <see langword = "null"/>.</exception>
                /// <exception cref = "SerializationException">The class name is <see langword = "null"/> or HResult is zero (0).</exception>
                /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
                protected ElementNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
                {
                }
            }

            /// <summary>
            /// The exception that is thrown when an operation is performed on a stopped element.
            /// </summary>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("System.Runtime.Serialization.dll")]
            public class ElementStoppedException : Skyline.DataMiner.Library.Common.DmsException
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementStoppedException"/> class.
                /// </summary>
                public ElementStoppedException()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementStoppedException"/> class.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                public ElementStoppedException(string message): base(message)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementStoppedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "dmsElementId">The ID of the element.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public ElementStoppedException(Skyline.DataMiner.Library.Common.DmsElementId dmsElementId, System.Exception innerException): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "The element with ID '{0}' is stopped.", dmsElementId.Value), innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementStoppedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public ElementStoppedException(string message, System.Exception innerException): base(message, innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementStoppedException"/> class with serialized data.
                /// </summary>
                /// <param name = "info">The serialization info.</param>
                /// <param name = "context">The streaming context.</param>
                /// <exception cref = "ArgumentNullException">The <paramref name = "info"/> parameter is <see langword = "null"/>.</exception>
                /// <exception cref = "SerializationException">The class name is <see langword = "null"/> or HResult is zero (0).</exception>
                /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
                protected ElementStoppedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
                {
                }
            }

            /// <summary>
            /// The exception that is thrown when invalid data was provided.
            /// </summary>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("System.Runtime.Serialization.dll")]
            public class IncorrectDataException : Skyline.DataMiner.Library.Common.DmsException
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "IncorrectDataException"/> class.
                /// </summary>
                public IncorrectDataException()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "IncorrectDataException"/> class.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                public IncorrectDataException(string message): base(message)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "IncorrectDataException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public IncorrectDataException(string message, System.Exception innerException): base(message, innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "IncorrectDataException"/> class with serialized data.
                /// </summary>
                /// <param name = "info">The serialization info.</param>
                /// <param name = "context">The streaming context.</param>
                /// <exception cref = "ArgumentNullException">The <paramref name = "info"/> parameter is <see langword = "null"/>.</exception>
                /// <exception cref = "SerializationException">The class name is <see langword = "null"/> or HResult is zero (0).</exception>
                /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
                protected IncorrectDataException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
                {
                }
            }

            /// <summary>
            /// The exception that is thrown when an action is performed on a DataMiner element parameter that was not found.
            /// </summary>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("System.Runtime.Serialization.dll")]
            public class ParameterNotFoundException : Skyline.DataMiner.Library.Common.DmsException
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "ParameterNotFoundException"/> class.
                /// </summary>
                public ParameterNotFoundException()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ParameterNotFoundException"/> class with a specified DataMiner element parameter ID.
                /// </summary>
                /// <param name = "id">The ID of the DataMiner Agent that was not found.</param>
                /// <param name = "dmsElementId">The DataMiner Agent ID/element ID of the element the parameter belongs to.</param>
                public ParameterNotFoundException(int id, Skyline.DataMiner.Library.Common.DmsElementId dmsElementId): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "The parameter with ID '{0}' was not found on the element with agent ID '{1}' and element ID '{2}'.", id, dmsElementId.AgentId, dmsElementId.ElementId))
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ParameterNotFoundException"/> class with a specified error message.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                public ParameterNotFoundException(string message): base(message)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ParameterNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public ParameterNotFoundException(string message, System.Exception innerException): base(message, innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ParameterNotFoundException"/> class with a specified DataMiner element parameter ID.
                /// </summary>
                /// <param name = "id">The ID of the DataMiner agent that was not found.</param>
                /// <param name = "dmsElementId">The DataMiner agent ID/element ID of the element the parameter belongs to.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public ParameterNotFoundException(int id, Skyline.DataMiner.Library.Common.DmsElementId dmsElementId, System.Exception innerException): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "The parameter with ID '{0}' was not found on the element with agent ID '{1}' and element ID '{2}'.", id, dmsElementId.AgentId, dmsElementId.ElementId), innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ParameterNotFoundException"/> class with serialized data.
                /// </summary>
                /// <param name = "info">The serialization info.</param>
                /// <param name = "context">The streaming context.</param>
                /// <exception cref = "ArgumentNullException">The <paramref name = "info"/> parameter is <see langword = "null"/>.</exception>
                /// <exception cref = "SerializationException">The class name is <see langword = "null"/> or HResult is zero (0).</exception>
                /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
                protected ParameterNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
                {
                }
            }

            /// <summary>
            /// The exception that is thrown when a requested protocol was not found.
            /// </summary>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("System.Runtime.Serialization.dll")]
            public class ProtocolNotFoundException : Skyline.DataMiner.Library.Common.DmsException
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "ProtocolNotFoundException"/> class.
                /// </summary>
                public ProtocolNotFoundException()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ProtocolNotFoundException"/> class.
                /// </summary>
                /// <param name = "protocolName">The name of the protocol.</param>
                /// <param name = "protocolVersion">The version of the protocol.</param>
                public ProtocolNotFoundException(string protocolName, string protocolVersion): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Protocol with name '{0}' and version '{1}' was not found.", protocolName, protocolVersion))
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ProtocolNotFoundException"/> class.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                public ProtocolNotFoundException(string message): base(message)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ProtocolNotFoundException"/> class.
                /// </summary>
                /// <param name = "protocolName">The name of the protocol.</param>
                /// <param name = "protocolVersion">The version of the protocol.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public ProtocolNotFoundException(string protocolName, string protocolVersion, System.Exception innerException): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Protocol with name '{0}' and version '{1}' was not found.", protocolName, protocolVersion), innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ProtocolNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public ProtocolNotFoundException(string message, System.Exception innerException): base(message, innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ProtocolNotFoundException"/> class with serialized data.
                /// </summary>
                /// <param name = "info">The serialization info.</param>
                /// <param name = "context">The streaming context.</param>
                /// <exception cref = "ArgumentNullException">The <paramref name = "info"/> parameter is <see langword = "null"/>.</exception>
                /// <exception cref = "SerializationException">The class name is <see langword = "null"/> or HResult is zero (0).</exception>
                /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
                protected ProtocolNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
                {
                }
            }

            /// <summary>
            /// The exception that is thrown when a requested template was not found.
            /// </summary>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("System.Runtime.Serialization.dll")]
            public class TemplateNotFoundException : Skyline.DataMiner.Library.Common.DmsException
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "TemplateNotFoundException"/> class.
                /// </summary>
                public TemplateNotFoundException()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "TemplateNotFoundException"/> class.
                /// </summary>
                /// <param name = "templateName">The name of the template.</param>
                /// <param name = "protocol">The protocol this template relates to.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "protocol"/> is <see langword = "null"/>.</exception>
                public TemplateNotFoundException(string templateName, Skyline.DataMiner.Library.Common.IDmsProtocol protocol): base(BuildMessageString(templateName, protocol))
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "TemplateNotFoundException"/> class.
                /// </summary>
                /// <param name = "templateName">The name of the template.</param>
                /// <param name = "protocolName">The name of the protocol.</param>
                /// <param name = "protocolVersion">The version of the protocol.</param>
                public TemplateNotFoundException(string templateName, string protocolName, string protocolVersion): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Template \"{0}\" for protocol \"{1}\" version \"{2}\" was not found.", templateName, protocolName, protocolVersion))
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "TemplateNotFoundException"/> class.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                public TemplateNotFoundException(string message): base(message)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "TemplateNotFoundException"/> class.
                /// </summary>
                /// <param name = "templateName">The name of the template.</param>
                /// <param name = "protocolName">The name of the protocol.</param>
                /// <param name = "protocolVersion">The version of the protocol.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public TemplateNotFoundException(string templateName, string protocolName, string protocolVersion, System.Exception innerException): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Template \"{0}\" for protocol \"{1}\" version \"{2}\" was not found.", templateName, protocolName, protocolVersion), innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "TemplateNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public TemplateNotFoundException(string message, System.Exception innerException): base(message, innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "TemplateNotFoundException"/> class with serialized data.
                /// </summary>
                /// <param name = "info">The serialization info.</param>
                /// <param name = "context">The streaming context.</param>
                /// <exception cref = "ArgumentNullException">The <paramref name = "info"/> parameter is <see langword = "null"/>.</exception>
                /// <exception cref = "SerializationException">The class name is <see langword = "null"/> or HResult is zero (0).</exception>
                /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
                protected TemplateNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
                {
                }

                private static string BuildMessageString(string templateName, Skyline.DataMiner.Library.Common.IDmsProtocol protocol)
                {
                    if (protocol == null)
                    {
                        throw new System.ArgumentNullException("protocol");
                    }

                    return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Template \"{0}\" for protocol \"{1}\" version \"{2}\" was not found.", templateName, protocol.Name, protocol.Version);
                }
            }

            /// <summary>
            /// The exception that is thrown when performing actions on a view that was not found.
            /// </summary>
            [System.Serializable]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("System.Runtime.Serialization.dll")]
            public class ViewNotFoundException : Skyline.DataMiner.Library.Common.DmsException
            {
                /// <summary>
                /// Initializes a new instance of the <see cref = "ViewNotFoundException"/> class.
                /// </summary>
                public ViewNotFoundException()
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ViewNotFoundException"/> class.
                /// </summary>
                /// <param name = "viewId">The ID of the view that was not found.</param>
                public ViewNotFoundException(int viewId): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "View with ID '{0}' was not found.", viewId))
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ViewNotFoundException"/> class.
                /// </summary>
                /// <param name = "viewId">The ID of the view that was not found.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public ViewNotFoundException(int viewId, System.Exception innerException): base(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "View with ID '{0}' was not found.", viewId), innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ViewNotFoundException"/> class.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                public ViewNotFoundException(string message): base(message)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ViewNotFoundException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
                /// </summary>
                /// <param name = "message">The error message that explains the reason for the exception.</param>
                /// <param name = "innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
                public ViewNotFoundException(string message, System.Exception innerException): base(message, innerException)
                {
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "ViewNotFoundException"/> class with serialized data.
                /// </summary>
                /// <param name = "info">The serialization info.</param>
                /// <param name = "context">The streaming context.</param>
                /// <exception cref = "ArgumentNullException">The <paramref name = "info"/> parameter is <see langword = "null"/>.</exception>
                /// <exception cref = "SerializationException">The class name is <see langword = "null"/> or HResult is zero (0).</exception>
                /// <remarks>This constructor is called during deserialization to reconstitute the exception object transmitted over a stream.</remarks>
                protected ViewNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context): base(info, context)
                {
                }
            }

            /// <summary>
            /// Represents the parent for every type of object that can be present on a DataMiner system.
            /// </summary>
            internal abstract class DmsObject
            {
                /// <summary>
                /// The DataMiner system the object belongs to.
                /// </summary>
                protected readonly Skyline.DataMiner.Library.Common.IDms dms;
                /// <summary>
                /// List containing all of the properties that were changed.
                /// </summary>
                private readonly System.Collections.Generic.List<System.String> changedPropertyList = new System.Collections.Generic.List<System.String>();
                /// <summary>
                /// Flag stating whether the DataMiner system object has been loaded.
                /// </summary>
                private bool isLoaded;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsObject"/> class.
                /// </summary>
                /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                protected DmsObject(Skyline.DataMiner.Library.Common.IDms dms)
                {
                    if (dms == null)
                    {
                        throw new System.ArgumentNullException("dms");
                    }

                    this.dms = dms;
                }

                /// <summary>
                /// Gets the DataMiner system this object belongs to.
                /// </summary>
                public Skyline.DataMiner.Library.Common.IDms Dms
                {
                    get
                    {
                        return dms;
                    }
                }

                /// <summary>
                /// Gets the list containing all of the names of the properties that are changed.
                /// </summary>
                internal System.Collections.Generic.List<System.String> ChangedPropertyList
                {
                    get
                    {
                        return changedPropertyList;
                    }
                }

                /// <summary>
                /// Gets the communication object.
                /// </summary>
                internal Skyline.DataMiner.Library.Common.ICommunication Communication
                {
                    get
                    {
                        return dms.Communication;
                    }
                }

                /// <summary>
                /// Gets or sets a value indicating whether or not the DMS object has been loaded.
                /// </summary>
                internal bool IsLoaded
                {
                    get
                    {
                        return isLoaded;
                    }

                    set
                    {
                        isLoaded = value;
                    }
                }

                /// <summary>
                /// Loads DMS object data in case the object exists and is not already loaded.
                /// </summary>
                internal void LoadOnDemand()
                {
                    if (!IsLoaded)
                    {
                        Load();
                    }
                }

                /// <summary>
                /// Loads the object.
                /// </summary>
                internal abstract void Load();
            }

            /// <summary>
            /// DataMiner object interface.
            /// </summary>
            public interface IDmsObject
            {
            }

            /// <summary>
            /// Represents a DataMiner element.
            /// </summary>
            internal class DmsElement : Skyline.DataMiner.Library.Common.DmsObject, Skyline.DataMiner.Library.Common.IDmsElement
            {
                /// <summary>
                ///     Contains the properties for the element.
                /// </summary>
                private readonly System.Collections.Generic.IDictionary<System.String, Skyline.DataMiner.Library.Common.Properties.DmsElementProperty> properties = new System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Library.Common.Properties.DmsElementProperty>();
                /// <summary>
                ///     This list will be used to keep track of which views were assigned / removed during the life time of the element.
                /// </summary>
                private readonly System.Collections.Generic.List<System.Int32> registeredViewIds = new System.Collections.Generic.List<System.Int32>();
                /// <summary>
                ///     A set of all updated properties.
                /// </summary>
                private readonly System.Collections.Generic.HashSet<System.String> updatedProperties = new System.Collections.Generic.HashSet<System.String>();
                /// <summary>
                ///     Array of views where the element is contained in.
                /// </summary>
                private readonly System.Collections.Generic.ISet<Skyline.DataMiner.Library.Common.IDmsView> views = new Skyline.DataMiner.Library.Common.DmsViewSet();
                /// <summary>
                ///     The advanced settings.
                /// </summary>
                private Skyline.DataMiner.Library.Common.AdvancedSettings advancedSettings;
                /// <summary>
                ///     The device settings.
                /// </summary>
                private Skyline.DataMiner.Library.Common.DeviceSettings deviceSettings;
                /// <summary>
                ///     The DVE settings.
                /// </summary>
                private Skyline.DataMiner.Library.Common.DveSettings dveSettings;
                /// <summary>
                ///     Collection of connections available on the element.
                /// </summary>
                private Skyline.DataMiner.Library.Common.IElementConnectionCollection elementCommunicationConnections;
                // Keep this message in case we need to parse the element properties when the user wants to use these.
                private Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo;
                /// <summary>
                ///     The failover settings.
                /// </summary>
                private Skyline.DataMiner.Library.Common.FailoverSettings failoverSettings;
                /// <summary>
                ///     The general settings.
                /// </summary>
                private Skyline.DataMiner.Library.Common.GeneralSettings generalSettings;
                /// <summary>
                ///     Specifies whether the properties of the elementInfo object have been parsed into dedicated objects.
                /// </summary>
                private bool propertiesLoaded;
                /// <summary>
                ///     The redundancy settings.
                /// </summary>
                private Skyline.DataMiner.Library.Common.RedundancySettings redundancySettings;
                /// <summary>
                ///     The replication settings.
                /// </summary>
                private Skyline.DataMiner.Library.Common.ReplicationSettings replicationSettings;
                /// <summary>
                ///     The element components.
                /// </summary>
                private System.Collections.Generic.IList<Skyline.DataMiner.Library.Common.ElementSettings> settings;
                /// <summary>
                ///     Specifies whether the views have been loaded.
                /// </summary>
                private bool viewsLoaded;
                /// <summary>
                ///     Initializes a new instance of the <see cref = "DmsElement"/> class.
                /// </summary>
                /// <param name = "dms">Object implementing <see cref = "IDms"/> interface.</param>
                /// <param name = "dmsElementId">The system-wide element ID.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                internal DmsElement(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Library.Common.DmsElementId dmsElementId): base(dms)
                {
                    this.Initialize();
                    this.generalSettings.DmsElementId = dmsElementId;
                }

                /// <summary>
                ///     Initializes a new instance of the <see cref = "DmsElement"/> class.
                /// </summary>
                /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                /// <param name = "elementInfo">The element information.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentNullException"><paramref name = "elementInfo"/> is <see langword = "null"/>.</exception>
                internal DmsElement(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo): base(dms)
                {
                    if (elementInfo == null)
                    {
                        throw new System.ArgumentNullException("elementInfo");
                    }

                    this.Initialize(elementInfo);
                    this.Parse(elementInfo);
                }

                /// <summary>
                ///     Gets the advanced settings of this element.
                /// </summary>
                /// <value>The advanced settings of this element.</value>
                public Skyline.DataMiner.Library.Common.IAdvancedSettings AdvancedSettings
                {
                    get
                    {
                        return this.advancedSettings;
                    }
                }

                /// <summary>
                ///     Gets the DataMiner Agent ID.
                /// </summary>
                /// <value>The DataMiner Agent ID.</value>
                public int AgentId
                {
                    get
                    {
                        return this.generalSettings.DmsElementId.AgentId;
                    }
                }

                /// <summary>
                ///     Gets or sets the alarm template assigned to this element.
                /// </summary>
                /// <value>The alarm template assigned to this element.</value>
                /// <exception cref = "ArgumentException">
                ///     The specified alarm template is not compatible with the protocol this element
                ///     executes.
                /// </exception>
                public Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate AlarmTemplate
                {
                    get
                    {
                        return this.generalSettings.AlarmTemplate;
                    }

                    set
                    {
                        if (!Skyline.DataMiner.Library.Common.InputValidator.IsCompatibleTemplate(value, this.Protocol))
                        {
                            throw new System.ArgumentException("The specified alarm template is not compatible with the protocol this element executes.", "value");
                        }

                        this.generalSettings.AlarmTemplate = value;
                    }
                }

                /// <summary>
                ///     Gets or sets the available connections on the element.
                /// </summary>
                public Skyline.DataMiner.Library.Common.IElementConnectionCollection Connections
                {
                    get
                    {
                        return this.elementCommunicationConnections;
                    }

                    set
                    {
                        this.elementCommunicationConnections = value;
                    }
                }

                /// <summary>
                ///     Gets or sets the element description.
                /// </summary>
                /// <value>The element description.</value>
                public string Description
                {
                    get
                    {
                        return this.GeneralSettings.Description;
                    }

                    set
                    {
                        this.GeneralSettings.Description = value;
                    }
                }

                /// <summary>
                ///     Gets the system-wide element ID of the element.
                /// </summary>
                /// <value>The system-wide element ID of the element.</value>
                public Skyline.DataMiner.Library.Common.DmsElementId DmsElementId
                {
                    get
                    {
                        return this.generalSettings.DmsElementId;
                    }
                }

                /// <summary>
                ///     Gets the DVE settings of this element.
                /// </summary>
                /// <value>The DVE settings of this element.</value>
                public Skyline.DataMiner.Library.Common.IDveSettings DveSettings
                {
                    get
                    {
                        return this.dveSettings;
                    }
                }

                /// <summary>
                ///     Gets the failover settings of this element.
                /// </summary>
                /// <value>The failover settings of this element.</value>
                public Skyline.DataMiner.Library.Common.IFailoverSettings FailoverSettings
                {
                    get
                    {
                        return this.failoverSettings;
                    }
                }

                /// <summary>
                ///     Gets the DataMiner Agent that hosts this element.
                /// </summary>
                /// <value>The DataMiner Agent that hosts this element.</value>
                public Skyline.DataMiner.Library.Common.IDma Host
                {
                    get
                    {
                        return this.generalSettings.Host;
                    }
                }

                /// <summary>
                ///     Gets the element ID.
                /// </summary>
                /// <value>The element ID.</value>
                public int Id
                {
                    get
                    {
                        return this.generalSettings.DmsElementId.ElementId;
                    }
                }

                /// <summary>
                ///     Gets or sets the element name.
                /// </summary>
                /// <value>The element name.</value>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation is empty or white space.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation exceeds 200 characters.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation contains a forbidden character.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation contains more than one '%' character.</exception>
                /// <exception cref = "NotSupportedException">A set operation is not supported on a DVE child or a derived element.</exception>
                /// <remarks>
                ///     <para>The following restrictions apply to element names:</para>
                ///     <list type = "bullet">
                ///         <item>
                ///             <para>Names may not start or end with the following characters: '.' (dot), ' ' (space).</para>
                ///         </item>
                ///         <item>
                ///             <para>
                ///                 Names may not contain the following characters: '\', '/', ':', '*', '?', '"', '&lt;', '&gt;', '|',
                ///                 '°', ';'.
                ///             </para>
                ///         </item>
                ///         <item>
                ///             <para>The following characters may not occur more than once within a name: '%' (percentage).</para>
                ///         </item>
                ///     </list>
                /// </remarks>
                public string Name
                {
                    get
                    {
                        return this.generalSettings.Name;
                    }

                    set
                    {
                        this.generalSettings.Name = Skyline.DataMiner.Library.Common.InputValidator.ValidateName(value, "value");
                    }
                }

                /// <summary>
                ///     Gets the properties of this element.
                /// </summary>
                /// <value>The element properties.</value>
                public Skyline.DataMiner.Library.Common.IPropertyCollection<Skyline.DataMiner.Library.Common.Properties.IDmsElementProperty, Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition> Properties
                {
                    get
                    {
                        this.LoadOnDemand();
                        // Parse properties using definitions from Dms.
                        if (!this.propertiesLoaded)
                        {
                            this.ParseElementProperties();
                        }

                        System.Collections.Generic.IDictionary<System.String, Skyline.DataMiner.Library.Common.Properties.IDmsElementProperty> copy = new System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Library.Common.Properties.IDmsElementProperty>(this.properties.Count);
                        foreach (var kvp in this.properties)
                        {
                            copy.Add(kvp.Key, kvp.Value);
                        }

                        return new Skyline.DataMiner.Library.Common.PropertyCollection<Skyline.DataMiner.Library.Common.Properties.IDmsElementProperty, Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition>(copy);
                    }
                }

                /// <summary>
                ///     Gets the protocol executed by this element.
                /// </summary>
                /// <value>The protocol executed by this element.</value>
                public Skyline.DataMiner.Library.Common.IDmsProtocol Protocol
                {
                    get
                    {
                        return this.generalSettings.Protocol;
                    }
                }

                /// <summary>
                ///     Gets the redundancy settings.
                /// </summary>
                /// <value>The redundancy settings.</value>
                public Skyline.DataMiner.Library.Common.IRedundancySettings RedundancySettings
                {
                    get
                    {
                        return this.redundancySettings;
                    }
                }

                /// <summary>
                ///     Gets the replication settings.
                /// </summary>
                /// <value>The replication settings.</value>
                public Skyline.DataMiner.Library.Common.IReplicationSettings ReplicationSettings
                {
                    get
                    {
                        return this.replicationSettings;
                    }
                }

                /// <summary>
                /// Gets the spectrum component of this element.
                /// </summary>
                public Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzer SpectrumAnalyzer
                {
                    get
                    {
                        return new Skyline.DataMiner.Library.Common.DmsSpectrumAnalyzer(this);
                    }
                }

                /// <summary>
                ///     Gets the element state.
                /// </summary>
                /// <value>The element state.</value>
                public Skyline.DataMiner.Library.Common.ElementState State
                {
                    get
                    {
                        return this.GeneralSettings.State;
                    }

                    internal set
                    {
                        this.GeneralSettings.State = value;
                    }
                }

                /// <summary>
                ///     Gets or sets the trend template that is assigned to this element.
                /// </summary>
                /// <value>The trend template that is assigned to this element.</value>
                /// <exception cref = "ArgumentException">
                ///     The specified trend template is not compatible with the protocol this element
                ///     executes.
                /// </exception>
                public Skyline.DataMiner.Library.Common.Templates.IDmsTrendTemplate TrendTemplate
                {
                    get
                    {
                        return this.generalSettings.TrendTemplate;
                    }

                    set
                    {
                        if (!Skyline.DataMiner.Library.Common.InputValidator.IsCompatibleTemplate(value, this.Protocol))
                        {
                            throw new System.ArgumentException("The specified trend template is not compatible with the protocol this element executes.", "value");
                        }

                        this.generalSettings.TrendTemplate = value;
                    }
                }

                /// <summary>
                ///     Gets the type of the element.
                /// </summary>
                /// <value>The element type.</value>
                public string Type
                {
                    get
                    {
                        return this.deviceSettings.Type;
                    }
                }

                /// <summary>
                ///     Gets the views the element is part of.
                /// </summary>
                /// <value>The views the element is part of.</value>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation is an empty collection.</exception>
                public System.Collections.Generic.ISet<Skyline.DataMiner.Library.Common.IDmsView> Views
                {
                    get
                    {
                        if (!this.viewsLoaded)
                        {
                            this.LoadViews();
                        }

                        return this.views;
                    }
                }

                /// <summary>
                ///     Gets the general settings of the element.
                /// </summary>
                internal Skyline.DataMiner.Library.Common.GeneralSettings GeneralSettings
                {
                    get
                    {
                        return this.generalSettings;
                    }
                }

                /// <summary>
                ///     Gets the specified table.
                /// </summary>
                /// <param name = "tableId">The table parameter ID.</param>
                /// <exception cref = "ArgumentException"><paramref name = "tableId"/> is invalid.</exception>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner System.</exception>
                /// <exception cref = "ElementStoppedException">The element is stopped.</exception>
                /// <returns>The table that corresponds with the specified ID.</returns>
                public Skyline.DataMiner.Library.Common.IDmsTable GetTable(int tableId)
                {
                    Skyline.DataMiner.Library.Common.HelperClass.CheckElementState(this);
                    if (tableId < 1)
                    {
                        throw new System.ArgumentException("Invalid table ID.", "tableId");
                    }

                    return new Skyline.DataMiner.Library.Common.DmsTable(this, tableId);
                }

                /// <summary>
                ///     Returns a string that represents the current object.
                /// </summary>
                /// <returns>A string that represents the current object.</returns>
                public override string ToString()
                {
                    var sb = new System.Text.StringBuilder();
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Name: {0}{1}", this.Name, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "agent ID/element ID: {0}{1}", this.DmsElementId.Value, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Description: {0}{1}", this.Description, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Protocol name: {0}{1}", this.Protocol.Name, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Protocol version: {0}{1}", this.Protocol.Version, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Hosting agent ID: {0}{1}", this.Host.Id, System.Environment.NewLine);
                    return sb.ToString();
                }

                /// <summary>
                ///     Loads all the data and properties found related to the element.
                /// </summary>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner system.</exception>
                internal override void Load()
                {
                    try
                    {
                        this.IsLoaded = true;
                        var message = new Skyline.DataMiner.Net.Messages.GetElementByIDMessage(this.generalSettings.DmsElementId.AgentId, this.generalSettings.DmsElementId.ElementId);
                        var response = (Skyline.DataMiner.Net.Messages.ElementInfoEventMessage)this.Communication.SendSingleResponseMessage(message);
                        this.elementCommunicationConnections = new Skyline.DataMiner.Library.Common.ElementConnectionCollection(response);
                        this.Parse(response);
                    }
                    catch (Skyline.DataMiner.Net.Exceptions.DataMinerException e)
                    {
                        if (e.ErrorCode == -2146233088)
                        {
                            // 0x80131500, Element "[element ID]" is unavailable.
                            throw new Skyline.DataMiner.Library.Common.ElementNotFoundException(this.DmsElementId, e);
                        }

                        throw;
                    }
                }

                /// <summary>
                ///     Loads all the views where this element is included.
                /// </summary>
                internal void LoadViews()
                {
                    var message = new Skyline.DataMiner.Net.Messages.GetViewsForElementMessage{DataMinerID = this.generalSettings.DmsElementId.AgentId, ElementID = this.generalSettings.DmsElementId.ElementId};
                    var response = (Skyline.DataMiner.Net.Messages.GetViewsForElementResponse)this.Communication.SendSingleResponseMessage(message);
                    this.views.Clear();
                    this.registeredViewIds.Clear();
                    foreach (Skyline.DataMiner.Net.Messages.DataMinerObjectInfo info in response.Views)
                    {
                        var view = new Skyline.DataMiner.Library.Common.DmsView(this.dms, info.ID, info.Name);
                        this.registeredViewIds.Add(info.ID);
                        this.views.Add(view);
                    }

                    this.viewsLoaded = true;
                }

                /// <summary>
                ///     Parses all of the element info.
                /// </summary>
                /// <param name = "elementInfo">The element info message.</param>
                internal void Parse(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    this.IsLoaded = true;
                    try
                    {
                        this.ParseElementInfo(elementInfo);
                    }
                    catch
                    {
                        this.IsLoaded = false;
                        throw;
                    }
                }

                /// <summary>
                ///     Update the updataProperties HashSet with a change event.
                /// </summary>
                /// <param name = "sender"></param>
                /// <param name = "e"></param>
                internal void PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
                {
                    this.updatedProperties.Add(e.PropertyName);
                }

                /// <summary>
                ///     Initializes the element.
                /// </summary>
                private void Initialize(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    this.elementInfo = elementInfo;
                    this.Initialize();
                    this.elementCommunicationConnections = new Skyline.DataMiner.Library.Common.ElementConnectionCollection(this.elementInfo);
                }

                /// <summary>
                ///     Initializes the element.
                /// </summary>
                private void Initialize()
                {
                    this.generalSettings = new Skyline.DataMiner.Library.Common.GeneralSettings(this);
                    this.deviceSettings = new Skyline.DataMiner.Library.Common.DeviceSettings(this);
                    this.replicationSettings = new Skyline.DataMiner.Library.Common.ReplicationSettings(this);
                    this.advancedSettings = new Skyline.DataMiner.Library.Common.AdvancedSettings(this);
                    this.failoverSettings = new Skyline.DataMiner.Library.Common.FailoverSettings(this);
                    this.redundancySettings = new Skyline.DataMiner.Library.Common.RedundancySettings(this);
                    this.dveSettings = new Skyline.DataMiner.Library.Common.DveSettings(this);
                    this.settings = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.ElementSettings>{this.generalSettings, this.deviceSettings, this.replicationSettings, this.advancedSettings, this.failoverSettings, this.redundancySettings, this.dveSettings};
                }

                /// <summary>
                ///     Parse an ElementPortInfo object in order to add IElementConnection objects to the ElementConnectionCollection.
                /// </summary>
                /// <param name = "info">The ElementPortInfo object.</param>
                private void ParseConnection(Skyline.DataMiner.Net.Messages.ElementPortInfo info)
                {
                    switch (info.ProtocolType)
                    {
                        case Skyline.DataMiner.Net.Messages.ProtocolType.Virtual:
                            var myVirtualConnection = new Skyline.DataMiner.Library.Common.VirtualConnection(info);
                            this.elementCommunicationConnections[info.PortID] = myVirtualConnection;
                            break;
                        case Skyline.DataMiner.Net.Messages.ProtocolType.SnmpV1:
                            var mySnmpV1Connection = new Skyline.DataMiner.Library.Common.SnmpV1Connection(info);
                            this.elementCommunicationConnections[info.PortID] = mySnmpV1Connection;
                            break;
                        case Skyline.DataMiner.Net.Messages.ProtocolType.SnmpV2:
                            var mySnmpv2Connection = new Skyline.DataMiner.Library.Common.SnmpV2Connection(info);
                            this.elementCommunicationConnections[info.PortID] = mySnmpv2Connection;
                            break;
                        case Skyline.DataMiner.Net.Messages.ProtocolType.SnmpV3:
                            var mySnmpV3Connection = new Skyline.DataMiner.Library.Common.SnmpV3Connection(info);
                            this.elementCommunicationConnections[info.PortID] = mySnmpV3Connection;
                            break;
                        case Skyline.DataMiner.Net.Messages.ProtocolType.Http:
                            var myHttpConnection = new Skyline.DataMiner.Library.Common.HttpConnection(info);
                            this.elementCommunicationConnections[info.PortID] = myHttpConnection;
                            break;
                        default:
                            var myConnection = new Skyline.DataMiner.Library.Common.RealConnection(info);
                            this.elementCommunicationConnections[info.PortID] = myConnection;
                            break;
                    }
                }

                /// <summary>
                ///     Parse an ElementInfoEventMessage object.
                /// </summary>
                /// <param name = "elementInfo"></param>
                private void ParseConnections(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    // Keep this object in case properties are accessed.
                    this.elementInfo = elementInfo;
                    this.ParseConnection(elementInfo.MainPort);
                    if (elementInfo.ExtraPorts != null)
                    {
                        foreach (Skyline.DataMiner.Net.Messages.ElementPortInfo info in elementInfo.ExtraPorts)
                        {
                            this.ParseConnection(info);
                        }
                    }
                }

                /// <summary>
                ///     Parses the element info.
                /// </summary>
                /// <param name = "elementInfo">The element info.</param>
                private void ParseElementInfo(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    // Keep this object in case properties are accessed.
                    this.elementInfo = elementInfo;
                    foreach (Skyline.DataMiner.Library.Common.ElementSettings component in this.settings)
                    {
                        component.Load(elementInfo);
                    }

                    this.ParseConnections(elementInfo);
                }

                /// <summary>
                ///     Parses the element properties.
                /// </summary>
                private void ParseElementProperties()
                {
                    this.properties.Clear();
                    foreach (Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition definition in this.Dms.ElementPropertyDefinitions)
                    {
                        Skyline.DataMiner.Net.Messages.PropertyInfo info = null;
                        if (this.elementInfo.Properties != null)
                        {
                            info = System.Linq.Enumerable.FirstOrDefault(this.elementInfo.Properties, p => p.Name.Equals(definition.Name, System.StringComparison.OrdinalIgnoreCase));
                            var duplicates = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(System.Linq.Enumerable.GroupBy(this.elementInfo.Properties, p => p.Name), g => System.Linq.Enumerable.Count(g) > 1), g => g.Key));
                            if (System.Linq.Enumerable.Any(duplicates))
                            {
                                string message = "Duplicate element properties detected. Element \"" + this.elementInfo.Name + "\" (" + this.elementInfo.DataMinerID + "/" + this.elementInfo.ElementID + "), duplicate properties: " + string.Join(", ", duplicates) + ".";
                                Skyline.DataMiner.Library.Common.Logger.Log(message);
                            }
                        }

                        string propertyValue = info != null ? info.Value : System.String.Empty;
                        if (definition.IsReadOnly)
                        {
                            this.properties.Add(definition.Name, new Skyline.DataMiner.Library.Common.Properties.DmsElementProperty(this, definition, propertyValue));
                        }
                        else
                        {
                            var property = new Skyline.DataMiner.Library.Common.Properties.DmsWritableElementProperty(this, definition, propertyValue);
                            this.properties.Add(definition.Name, property);
                            property.PropertyChanged += this.PropertyChanged;
                        }
                    }

                    this.propertiesLoaded = true;
                }
            }

            /// <summary>
            /// Represents a set of <see cref = "IDmsView"/> items.
            /// </summary>
            [System.Serializable]
            public sealed class DmsViewSet : System.Collections.Generic.ISet<Skyline.DataMiner.Library.Common.IDmsView>
            {
                /// <summary>
                /// The views in the set.
                /// </summary>
                private readonly System.Collections.Generic.HashSet<Skyline.DataMiner.Library.Common.IDmsView> views = new System.Collections.Generic.HashSet<Skyline.DataMiner.Library.Common.IDmsView>(new Skyline.DataMiner.Library.Common.DmsViewEqualityComparer());
                /// <summary>
                /// Gets the number of views that are contained in a set.
                /// </summary>
                /// <value>The number of views that are contained in the set.</value>
                public int Count
                {
                    get
                    {
                        return views.Count;
                    }
                }

                /// <summary>
                /// Gets a value indicating whether a collection is read-only.
                /// </summary>
                /// <value><c>true</c> if the collection is read-only; otherwise, <c>false</c>.</value>
                bool System.Collections.Generic.ICollection<Skyline.DataMiner.Library.Common.IDmsView>.IsReadOnly
                {
                    get
                    {
                        return ((System.Collections.Generic.ICollection<Skyline.DataMiner.Library.Common.IDmsView>)views).IsReadOnly;
                    }
                }

                /// <summary>
                /// Adds the specified item to a set.
                /// </summary>
                /// <param name = "item">The item to add to the set.</param>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <returns><c>true</c> if the item is added to the set; <c>false</c> if the item is already present.</returns>
                public bool Add(Skyline.DataMiner.Library.Common.IDmsView item)
                {
                    if (item == null)
                    {
                        throw new System.ArgumentNullException("item");
                    }

                    return views.Add(item);
                }

                /// <summary>
                /// Adds the specified item to a set.
                /// </summary>
                /// <param name = "item">The item to add to the set.</param>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                void System.Collections.Generic.ICollection<Skyline.DataMiner.Library.Common.IDmsView>.Add(Skyline.DataMiner.Library.Common.IDmsView item)
                {
                    if (item == null)
                    {
                        throw new System.ArgumentNullException("item");
                    }

                    views.Add(item);
                }

                /// <summary>
                /// Removes all items from the collection.
                /// </summary>
                /// <remarks>
                /// <para>This method is an O(n) operation, where <c>n</c> is Count.</para>
                /// </remarks>
                public void Clear()
                {
                    views.Clear();
                }

                /// <summary>
                /// Determines whether the collection contains the specified item.
                /// </summary>
                /// <param name = "item">The item to locate in the set.</param>
                /// <returns><c>true</c> if the collection contains the specified item; otherwise, <c>false</c>.</returns>
                /// <remarks>This method is an O(1) operation.</remarks>
                public bool Contains(Skyline.DataMiner.Library.Common.IDmsView item)
                {
                    return views.Contains(item);
                }

                /// <summary>
                /// Copies the items of a ICollection&lt;IDmsView&gt; object to an array, starting at the specified array index.
                /// </summary>
                /// <param name = "array">The one-dimensional array that is the destination of the items copied from the object. The array must have zero-based indexing.</param>
                /// <param name = "arrayIndex">The zero-based index in array at which copying begins.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "array"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentOutOfRangeException"><paramref name = "arrayIndex"/> is less than 0.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "arrayIndex"/> is greater than the length of the destination <paramref name = "array"/>.</exception>
                public void CopyTo(Skyline.DataMiner.Library.Common.IDmsView[] array, int arrayIndex)
                {
                    views.CopyTo(array, arrayIndex);
                }

                /// <summary>
                /// Returns an enumerator that iterates through the collection object.
                /// </summary>
                /// <returns>A enumerator object for the object.</returns>
                public System.Collections.Generic.IEnumerator<Skyline.DataMiner.Library.Common.IDmsView> GetEnumerator()
                {
                    return views.GetEnumerator();
                }

                /// <summary>
                /// Removes the specified item from the collection.
                /// </summary>
                /// <param name = "item">The item to remove.</param>
                /// <returns><c>true</c> if the item is successfully found and removed; otherwise, <c>false</c>. This method returns <c>false</c> if the item is not found in the collection.</returns>
                public bool Remove(Skyline.DataMiner.Library.Common.IDmsView item)
                {
                    return views.Remove(item);
                }

                /// <summary>
                /// Returns an enumerator that iterates through a collection.
                /// </summary>
                /// <returns>An <see cref = "IEnumerator&lt;T&gt;"/> object that can be used to iterate through the collection.</returns>
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return ((System.Collections.IEnumerable)views).GetEnumerator();
                }

                /// <summary>
                /// Modifies the current set to contain all items that are present in itself, the specified collection, or both.
                /// </summary>
                /// <param name = "other">The collection to compare to the current set.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "other"/> is <see langword = "null"/>.</exception>
                public void UnionWith(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IDmsView> other)
                {
                    views.UnionWith(other);
                }

                /// <summary>
                /// Modifies the current set to contain only items that are present in that object and in the specified collection.
                /// </summary>
                /// <param name = "other">The collection to compare to the current set.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "other"/> is <see langword = "null"/>.</exception>
                public void IntersectWith(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IDmsView> other)
                {
                    views.IntersectWith(other);
                }

                /// <summary>
                /// Removes all items in the specified collection from the current set.
                /// </summary>
                /// <param name = "other">The collection of items to remove from the set.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "other"/> is <see langword = "null"/>.</exception>
                /// <remarks>
                /// <para>The ExceptWith method is the equivalent of mathematical set subtraction.</para>
                /// <para>This method is an O(<c>n</c>) operation, where <c>n</c> is the number of elements in the <c>other</c> parameter.</para>
                /// </remarks>
                public void ExceptWith(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IDmsView> other)
                {
                    views.ExceptWith(other);
                }

                /// <summary>
                /// Modifies the current set to contain only items that are present either in this object or in the specified collection, but not both.
                /// </summary>
                /// <param name = "other">The collection to compare to the current object.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "other"/> is <see langword = "null"/>.</exception>
                /// <remarks>
                /// If the other parameter is a collection with the same equality comparer as the current object, this method is an O(n) operation.
                ///  Otherwise, this method is an O(n + m) operation, where n is the number of items in <paramref name = "other"/> and m is Count.
                /// </remarks>
                public void SymmetricExceptWith(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IDmsView> other)
                {
                    views.SymmetricExceptWith(other);
                }

                /// <summary>
                /// Determines whether this set is a subset of the specified collection.
                /// </summary>
                /// <param name = "other">The collection to compare to the current object.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "other"/> is <see langword = "null"/>.</exception>
                /// <returns><c>true</c> if this object is a subset of other; otherwise, <c>false</c>.</returns>
                /// <remarks>
                /// <para>An empty set is a subset of any other collection, including an empty set.
                /// Therefore, this method returns true if the collection represented by the current object is empty, even if the other parameter is an empty set.</para>
                /// <para>This method always returns false if Count is greater than the number of items in <paramref name = "other"/>.</para>
                /// <para>If the collection represented by other is a collection with the same equality comparer as the current object, this method is an O(n) operation.
                /// Otherwise, this method is an O(n + m) operation, where n is Count and m is the number of items in <paramref name = "other"/>.</para>
                /// </remarks>
                public bool IsSubsetOf(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IDmsView> other)
                {
                    return views.IsSubsetOf(other);
                }

                /// <summary>
                /// Determines whether this object is a superset of the specified collection.
                /// </summary>
                /// <param name = "other">The collection to compare to the current object.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "other"/> is <see langword = "null"/>.</exception>
                /// <returns><c>true</c> if the object is a superset of other; otherwise, <c>false</c>.</returns>
                /// <remarks>
                /// <para>All collections, including the empty set, are supersets of the empty set.
                /// Therefore, this method returns true if the collection represented by the other parameter is empty, even if the current object is empty.</para>
                /// <para>This method always returns false if Count is less than the number of items in <paramref name = "other"/>.</para>
                /// <para>If the collection represented by other is a collection with the same equality comparer as the current object, this method is an O(n) operation.
                ///  Otherwise, this method is an O(n + m) operation, where n is the number of items in <paramref name = "other"/> and m is Count.</para>
                /// </remarks>
                public bool IsSupersetOf(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IDmsView> other)
                {
                    return views.IsSupersetOf(other);
                }

                /// <summary>
                /// Determines whether the object is a proper superset of the specified collection.
                /// </summary>
                /// <param name = "other">The collection to compare to the current object.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "other"/> is <see langword = "null"/>.</exception>
                /// <returns><c>true</c> if this object is a proper superset of other; otherwise, <c>false</c>.</returns>
                /// <remarks>
                /// <para>An empty set is a proper superset of any other collection.
                /// Therefore, this method returns true if the collection represented by the other parameter is empty unless the current collection is also empty.</para>
                /// <para>This method always returns <c>false</c> if Count is less than or equal to the number of elements in other.</para>
                /// <para>If the collection represented by other is a collection with the same equality comparer as the current object, this method is an O(n) operation.
                ///  Otherwise, this method is an O(n + m) operation, where n is the number of elements in other and m is Count.</para>
                /// </remarks>
                public bool IsProperSupersetOf(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IDmsView> other)
                {
                    return views.IsProperSupersetOf(other);
                }

                /// <summary>
                /// Determines whether this object is a proper subset of the specified collection.
                /// </summary>
                /// <param name = "other">The collection to compare to the current object.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "other"/> is <see langword = "null"/>.</exception>
                /// <returns><c>true</c> if this object is a proper subset of other; otherwise, <c>false</c>.</returns>
                /// <remarks>
                /// <para>An empty set is a proper subset of any other collection.
                /// Therefore, this method returns <c>true</c> if the collection represented by the current object is empty unless the other parameter is also an empty set.</para>
                /// <para>This method always returns <c>false</c> if Count is greater than or equal to the number of items in other.</para>
                /// <para>If the collection represented by other is a collection with the same equality comparer as the current object, then this method is an O(n) operation.
                ///  Otherwise, this method is an O(n + m) operation, where n is Count and m is the number of items in <paramref name = "other"/>.</para>
                /// </remarks>
                public bool IsProperSubsetOf(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IDmsView> other)
                {
                    return views.IsProperSubsetOf(other);
                }

                /// <summary>
                /// Determines whether the current object and a specified collection share common items.
                /// </summary>
                /// <param name = "other">The collection to compare to the current object.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "other"/> is <see langword = "null"/>.</exception>
                /// <returns><c>true</c> if this object and other share at least one common element; otherwise, <c>false</c>.</returns>
                /// <remarks>
                /// This method is an O(<c>n</c>) operation, where <c>n</c> is the number of items in <paramref name = "other"/>.
                /// </remarks>
                public bool Overlaps(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IDmsView> other)
                {
                    return views.Overlaps(other);
                }

                /// <summary>
                /// Determines whether this object and the specified collection contain the same items.
                /// </summary>
                /// <param name = "other">The collection to compare to the current object.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "other"/> is <see langword = "null"/>.</exception>
                /// <returns>true if this set is equal to <paramref name = "other"/>; otherwise, false.</returns>
                /// <remarks>
                /// <para>The SetEquals method ignores duplicate entries and the order of items in the <paramref name = "other"/> parameter.</para>
                /// <para>If the collection represented by other is a collection with the same equality comparer as the current object, this method is an O(n) operation.
                /// Otherwise, this method is an O(n + m) operation, where n is the number of items in <paramref name = "other"/> and m is Count.</para>
                /// </remarks>
                public bool SetEquals(System.Collections.Generic.IEnumerable<Skyline.DataMiner.Library.Common.IDmsView> other)
                {
                    return views.SetEquals(other);
                }
            }

            /// <summary>
            /// DataMiner element interface.
            /// </summary>
            public interface IDmsElement : Skyline.DataMiner.Library.Common.IDmsObject, Skyline.DataMiner.Library.Common.IUpdateable
            {
                /// <summary>
                /// Gets the advanced settings of this element.
                /// </summary>
                /// <value>The advanced settings of this element.</value>
                Skyline.DataMiner.Library.Common.IAdvancedSettings AdvancedSettings
                {
                    get;
                }

                /// <summary>
                /// Gets the DataMiner Agent ID.
                /// </summary>
                /// <value>The DataMiner Agent ID.</value>
                int AgentId
                {
                    get;
                }

                /// <summary>
                /// Gets or sets the alarm template assigned to this element.
                /// </summary>
                /// <value>The alarm template assigned to this element.</value>
                /// <exception cref = "ArgumentException">The specified alarm template is not compatible with the protocol this element executes.</exception>
                Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate AlarmTemplate
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or Sets the collection of IElementConnection objects.
                /// </summary>
                Skyline.DataMiner.Library.Common.IElementConnectionCollection Connections
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the element description.
                /// </summary>
                /// <value>The element description.</value>
                string Description
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets the system-wide element ID of the element.
                /// </summary>
                /// <value>The system-wide element ID of the element.</value>
                Skyline.DataMiner.Library.Common.DmsElementId DmsElementId
                {
                    get;
                }

                /// <summary>
                /// Gets the DVE settings of this element.
                /// </summary>
                /// <value>The DVE settings of this element.</value>
                Skyline.DataMiner.Library.Common.IDveSettings DveSettings
                {
                    get;
                }

                /// <summary>
                /// Gets the DataMiner Agent that hosts this element.
                /// </summary>
                /// <value>The DataMiner Agent that hosts this element.</value>
                Skyline.DataMiner.Library.Common.IDma Host
                {
                    get;
                }

                ///// <summary>
                ///// Gets the failover settings of this element.
                ///// </summary>
                ///// <value>The failover settings of this element.</value>
                //IFailoverSettings FailoverSettings { get; }
                /// <summary>
                /// Gets the element ID.
                /// </summary>
                /// <value>The element ID.</value>
                int Id
                {
                    get;
                }

                /// <summary>
                /// Gets or sets the element name.
                /// </summary>
                /// <value>The element name.</value>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation is empty or white space.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation exceeds 200 characters.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation contains a forbidden character.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation contains more than one '%' character.</exception>
                /// <exception cref = "NotSupportedException">A set operation is not supported on a DVE child or a derived element.</exception>
                /// <remarks>
                /// <para>The following restrictions apply to element names:</para>
                /// <list type = "bullet">
                ///		<item><para>Names may not start or end with the following characters: '.' (dot), ' ' (space).</para></item>
                ///		<item><para>Names may not contain the following characters: '\', '/', ':', '*', '?', '"', '&lt;', '&gt;', '|', '°', ';'.</para></item>
                ///		<item><para>The following characters may not occur more than once within a name: '%' (percentage).</para></item>
                /// </list>
                /// </remarks>
                string Name
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets the properties of this element.
                /// </summary>
                /// <value>The element properties.</value>
                Skyline.DataMiner.Library.Common.IPropertyCollection<Skyline.DataMiner.Library.Common.Properties.IDmsElementProperty, Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition> Properties
                {
                    get;
                }

                /// <summary>
                /// Gets the protocol executed by this element.
                /// </summary>
                /// <value>The protocol executed by this element.</value>
                Skyline.DataMiner.Library.Common.IDmsProtocol Protocol
                {
                    get;
                }

                /// <summary>
                /// Gets the redundancy settings.
                /// </summary>
                /// <value>The redundancy settings.</value>
                Skyline.DataMiner.Library.Common.IRedundancySettings RedundancySettings
                {
                    get;
                }

                /// <summary>
                /// Gets the replication settings.
                /// </summary>
                /// <value>The replication settings.</value>
                Skyline.DataMiner.Library.Common.IReplicationSettings ReplicationSettings
                {
                    get;
                }

                /// <summary>
                /// Gets the spectrum analyzer component of this element.
                /// </summary>
                /// <value>The spectrum analyzer component.</value>
                /// <remarks>This is only applicable for spectrum analyzer elements.</remarks>
                Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzer SpectrumAnalyzer
                {
                    get;
                }

                /// <summary>
                /// Gets the element state.
                /// </summary>
                /// <value>The element state.</value>
                Skyline.DataMiner.Library.Common.ElementState State
                {
                    get;
                }

                /// <summary>
                /// Gets or sets the trend template that is assigned to this element.
                /// </summary>
                /// <value>The trend template that is assigned to this element.</value>
                /// <exception cref = "ArgumentException">The specified trend template is not compatible with the protocol this element executes.</exception>
                Skyline.DataMiner.Library.Common.Templates.IDmsTrendTemplate TrendTemplate
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets the type of the element.
                /// </summary>
                /// <value>The element type.</value>
                string Type
                {
                    get;
                }

                /// <summary>
                /// Gets the views the element is part of.
                /// </summary>
                /// <value>The views the element is part of.</value>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation is an empty collection.</exception>
                System.Collections.Generic.ISet<Skyline.DataMiner.Library.Common.IDmsView> Views
                {
                    get;
                }

                /// <summary>
                /// Gets the specified table.
                /// </summary>
                /// <param name = "tableId">The table parameter ID.</param>
                /// <exception cref = "ArgumentException"><paramref name = "tableId"/> is invalid.</exception>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner System.</exception>
                /// <exception cref = "ElementStoppedException">The element is not active.</exception>
                /// <returns>The table that corresponds with the specified ID.</returns>
                Skyline.DataMiner.Library.Common.IDmsTable GetTable(int tableId);
            }

            /// <summary>
            /// Base class for all connection related objects.
            /// </summary>
            public abstract class ConnectionSettings
            {
                /// <summary>
                /// Enum used to track changes on properties of classes implementing this abstract class.
                /// </summary>
                protected enum ConnectionSetting
                {
                    /// <summary>
                    /// GetCommunityString
                    /// </summary>
                    GetCommunityString = 0,
                    /// <summary>
                    /// SetCommunityString
                    /// </summary>
                    SetCommunityString = 1,
                    /// <summary>
                    /// DeviceAddress
                    /// </summary>
                    DeviceAddress = 2,
                    /// <summary>
                    /// Timeout
                    /// </summary>
                    Timeout = 3,
                    /// <summary>
                    /// Retries
                    /// </summary>
                    Retries = 4,
                    /// <summary>
                    /// ElementTimeout
                    /// </summary>
                    ElementTimeout = 5,
                    /// <summary>
                    /// PortConnection (e.g.Udp , Tcp)
                    /// </summary>
                    PortConnection = 6,
                    /// <summary>
                    /// SecurityConfiguration
                    /// </summary>
                    SecurityConfig = 7,
                    /// <summary>
                    /// SNMPv3 Encryption Algorithm
                    /// </summary>
                    EncryptionAlgorithm = 8,
                    /// <summary>
                    /// SNMPv3 AuthenticationProtocol
                    /// </summary>
                    AuthenticationProtocol = 9,
                    /// <summary>
                    /// SNMPv3 EncryptionKey
                    /// </summary>
                    EncryptionKey = 10,
                    /// <summary>
                    /// SNMPv3 AuthenticationKey
                    /// </summary>
                    AuthenticationKey = 11,
                    /// <summary>
                    /// SNMPv3 Username
                    /// </summary>
                    Username = 12,
                    /// <summary>
                    /// SNMPv3 Security Level and Protocol
                    /// </summary>
                    SecurityLevelAndProtocol = 13,
                    /// <summary>
                    /// Local port
                    /// </summary>
                    LocalPort = 14,
                    /// <summary>
                    /// Remote port
                    /// </summary>
                    RemotePort = 15,
                    /// <summary>
                    /// Is SSL/TLS enabled
                    /// </summary>
                    IsSslTlsEnabled = 16,
                    /// <summary>
                    /// Remote host
                    /// </summary>
                    RemoteHost = 17,
                    /// <summary>
                    /// Network interface card
                    /// </summary>
                    NetworkInterfaceCard = 18,
                    /// <summary>
                    /// Bus address
                    /// </summary>
                    BusAddress = 19,
                    /// <summary>
                    /// Is BypassProxy enabled.
                    /// </summary>
                    IsByPassProxyEnabled
                }

                /// <summary>
                /// The list of changed properties.
                /// </summary>
                private readonly System.Collections.Generic.List<Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting> changedPropertyList = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting>();
                /// <summary>
                /// Gets the list of updated properties.
                /// </summary>
                protected System.Collections.Generic.List<Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting> ChangedPropertyList
                {
                    get
                    {
                        return changedPropertyList;
                    }
                }
            }

            /// <summary>
            /// Class representing an HTTP Connection.
            /// </summary>
            public class HttpConnection : Skyline.DataMiner.Library.Common.ConnectionSettings, Skyline.DataMiner.Library.Common.IHttpConnection
            {
                private string busAddress;
                private readonly int id;
                private System.TimeSpan? elementTimeout;
                private bool isBypassProxyEnabled;
                private int retries;
                private Skyline.DataMiner.Library.Common.ITcp tcpConfiguration;
                private System.TimeSpan timeout;
                private const string BypassProxyValue = "bypassProxy";
                /// <summary>
                /// Initializes a new instance of the <see cref = "HttpConnection"/> class with default settings for Timeout (1500), Retries (3), Element Timeout (30),
                /// </summary>
                /// <param name = "tcpConfiguration">The TCP Connection.</param>
                /// <param name = "isByPassProxyEnabled">Allows you to enable the ByPassProxy setting. Default true.</param>
                /// <remarks>In case HTTPS needs to be used. TCP port needs to be 443 or the PollingIP needs to start with https:// . e.g. https://192.168.0.1</remarks>
                public HttpConnection(Skyline.DataMiner.Library.Common.ITcp tcpConfiguration, bool isByPassProxyEnabled = true)
                {
                    if (tcpConfiguration == null)
                        throw new System.ArgumentNullException("tcpConfiguration");
                    this.tcpConfiguration = tcpConfiguration;
                    this.busAddress = isByPassProxyEnabled ? BypassProxyValue : System.String.Empty;
                    this.IsBypassProxyEnabled = isByPassProxyEnabled;
                    this.id = -1;
                    this.timeout = new System.TimeSpan(0, 0, 0, 0, 1500);
                    this.retries = 3;
                    this.elementTimeout = new System.TimeSpan(0, 0, 0, 30);
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "HttpConnection"/> class using the specified <see cref = "ElementPortInfo"/>.
                /// </summary>
                /// <param name = "info">Instance of <see cref = "ElementPortInfo"/> to parse the contents of.</param>
                internal HttpConnection(Skyline.DataMiner.Net.Messages.ElementPortInfo info)
                {
                    this.busAddress = info.BusAddress;
                    this.isBypassProxyEnabled = info.ByPassProxy;
                    this.retries = info.Retries;
                    this.timeout = new System.TimeSpan(0, 0, 0, 0, info.TimeoutTime);
                    this.id = info.PortID;
                    this.elementTimeout = new System.TimeSpan(0, 0, 0, 0, info.ElementTimeoutTime);
                    this.tcpConfiguration = new Skyline.DataMiner.Library.Common.Tcp(info);
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "HttpConnection"/> class.
                /// </summary>
                public HttpConnection()
                {
                }

                /// <summary>
                /// Gets the bus address.
                /// </summary>
                /// <value>The buss address.</value>
                public string BusAddress
                {
                    get
                    {
                        return this.busAddress;
                    }
                }

                /// <summary>
                /// Gets or sets the element timeout.
                /// </summary>
                /// <value>The element timeout.</value>
                /// <remarks>When <see langword = "null"/>, this connection will not be taken into account for the element to go into timeout.</remarks>
                public System.TimeSpan? ElementTimeout
                {
                    get
                    {
                        return this.elementTimeout;
                    }

                    set
                    {
                        if (this.elementTimeout != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.ElementTimeout);
                            this.elementTimeout = value;
                        }
                    }
                }

                /// <summary>
                /// Gets the connection ID.
                /// </summary>
                /// <value>The connection ID.</value>
                public int Id
                {
                    get
                    {
                        return this.id;
                    }
                }

                /// <summary>
                /// Gets a value indicating whether to bypass the proxy.
                /// </summary>
                /// <value><c>true</c> if the proxy needs to be bypassed; otherwise, <c>false</c>.</value>
                public bool IsBypassProxyEnabled
                {
                    get
                    {
                        return this.isBypassProxyEnabled;
                    }

                    set
                    {
                        if (this.isBypassProxyEnabled != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.IsByPassProxyEnabled);
                            this.isBypassProxyEnabled = value;
                            this.busAddress = this.isBypassProxyEnabled ? BypassProxyValue : System.String.Empty;
                        }
                    }
                }

                /// <summary>
                /// Gets or set the number of retries.
                /// </summary>
                /// <value>The number of retries.</value>
                public int Retries
                {
                    get
                    {
                        return this.retries;
                    }

                    set
                    {
                        if (this.retries != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.Retries);
                            this.retries = value;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets the TCP connection configuration.
                /// </summary>
                /// <value>The TCP connection configuration.</value>
                public Skyline.DataMiner.Library.Common.ITcp TcpConfiguration
                {
                    get
                    {
                        return this.tcpConfiguration;
                    }

                    set
                    {
                        if (this.tcpConfiguration != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.PortConnection);
                            this.tcpConfiguration = value;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets the timeout.
                /// </summary>
                /// <value>The timeout.</value>
                public System.TimeSpan Timeout
                {
                    get
                    {
                        return this.timeout;
                    }

                    set
                    {
                        if (this.timeout != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.Timeout);
                            this.timeout = value;
                        }
                    }
                }
            }

            /// <summary>
            /// Represents a connection of a DataMiner element.
            /// </summary>
            public interface IElementConnection
            {
                /// <summary>
                /// Gets the value indicating the connection number or sets which connection id should be used during creation.
                /// </summary>
                /// <value>The identifier of the connection.</value>
                int Id
                {
                    get;
                }
            }

            /// <summary>
            /// Represents an HTTP Connection
            /// </summary>
            public interface IHttpConnection : Skyline.DataMiner.Library.Common.IRealConnection
            {
                /// <summary>
                /// Gets or sets the TCP connection configuration.
                /// </summary>
                /// <value>The TCP connection configuration.</value>
                Skyline.DataMiner.Library.Common.ITcp TcpConfiguration
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets the bus address.
                /// </summary>
                /// <value>The buss address.</value>
                string BusAddress
                {
                    get;
                }

                /// <summary>
                /// Gets a value indicating whether to bypass the proxy.
                /// </summary>
                /// <value><c>true</c> if the proxy needs to be bypassed; otherwise, <c>false</c>.</value>
                bool IsBypassProxyEnabled
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// Defines a non-virtual interface.
            /// </summary>
            public interface IRealConnection : Skyline.DataMiner.Library.Common.IElementConnection
            {
                // The following properties are added to each connection although it only works for the main connection.
                // The reason for this is that it could be supported in the future, and it's also designed like this in the web api: http://localhost/API/v1/soap.asmx?op=CreateElement
                /// <summary>
                /// Gets or sets the timeout of a single command or request.
                /// </summary>
                /// <value>The timeout of a single command or request.</value>
                System.TimeSpan Timeout
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the number of retries.
                /// </summary>
                /// <value>The number of retries.</value>
                int Retries
                {
                    get;
                    set;
                }

                ///<summary>
                /// Gets or sets a value indicating after how long the element will go into timeout when it is not responding for.
                ///</summary>
                /// <value>The timespan to be set, when set to <see langword = "null"/>, the connection does not have an impact on the element timeout./></value>
                System.TimeSpan? ElementTimeout
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// Represents a serial connection.
            /// </summary>
            public interface ISerialConnection : Skyline.DataMiner.Library.Common.IRealConnection
            {
                // TODO: Model serial single.
                // bool IsDedicatedConnection { get; } or make subclass?
                /// <summary>
                /// Gets or sets the port connection.
                /// </summary>
                /// <value>The port connection.</value>
                Skyline.DataMiner.Library.Common.IPortConnection Connection
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the bus address.
                /// </summary>
                string BusAddress
                {
                    get;
                    set;
                }
            //bool IsSecure { get; set; }
            }

            /// <summary>
            /// Defines an SNMP connection.
            /// </summary>
            public interface ISnmpConnection : Skyline.DataMiner.Library.Common.IRealConnection
            {
                /// <summary>
                /// Gets or sets the underlying connection.
                /// </summary>
                /// <value>The underlying connection.</value>
                Skyline.DataMiner.Library.Common.IUdp UdpConfiguration
                {
                    get;
                    set;
                }

                // Credentials can currently be used with SNMP connections only.
                // When credentials are provided, then no community strings (snmpv1/snmpv2) or user name,level,authentication protocol,authentication key,encryption protocol, encryption key can be provided.
                // See http://devcore3/documentation/server/RC/html/e7dbdb35-9528-5b65-8436-6b3242a8076f.htm
                // Currently only Get implemented in order to detect if credentials are used or not because then the other fields should be empty and not be settable.
                /// <summary>
                /// Gets the library credentials Guid. When empty guid, the credentials are not used from the library.
                /// </summary>
                System.Guid LibraryCredentials
                {
                    get;
                }

                /// <summary>
                /// Gets or sets the device address.
                /// </summary>
                /// <value>The device address.</value>
                string DeviceAddress
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// Defines an SNMPv1 Connection
            /// </summary>
            public interface ISnmpV1Connection : Skyline.DataMiner.Library.Common.ISnmpConnection
            {
                /// <summary>
                /// Gets or sets the get community string.
                /// </summary>
                /// <value>The get community string.</value>
                string GetCommunityString
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the set community string.
                /// </summary>
                /// <value>The set community string.</value>
                string SetCommunityString
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// Defines an SNMPv2 Connection.
            /// </summary>
            public interface ISnmpV2Connection : Skyline.DataMiner.Library.Common.ISnmpConnection
            {
                /// <summary>
                /// Gets or sets the get community string.
                /// </summary>
                /// <value>The get community string.</value>
                string GetCommunityString
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the set community string.
                /// </summary>
                /// <value>The set community string.</value>
                string SetCommunityString
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// Defines an SNMPv3 Connection.
            /// </summary>
            public interface ISnmpV3Connection : Skyline.DataMiner.Library.Common.ISnmpConnection
            {
                /// <summary>
                /// Gets or sets the SNMPv3 security configuration.
                /// </summary>
                Skyline.DataMiner.Library.Common.ISnmpV3SecurityConfig SecurityConfig
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// Interface for SnmpV3 Security configurations.
            /// </summary>
            public interface ISnmpV3SecurityConfig
            {
                /// <summary>
                /// Gets or sets the EncryptionAlgorithm.
                /// </summary>
                Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm EncryptionAlgorithm
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the AuthenticationProtocol.
                /// </summary>
                Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm AuthenticationAlgorithm
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the EncryptionKey.
                /// </summary>
                string EncryptionKey
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the AuthenticationKey.
                /// </summary>
                string AuthenticationKey
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the username.
                /// </summary>
                string Username
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the SecurityLevelAndProtocol.
                /// </summary>
                Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol SecurityLevelAndProtocol
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// Defines a Virtual Connection
            /// </summary>
            public interface IVirtualConnection : Skyline.DataMiner.Library.Common.IElementConnection
            {
            }

            /// <summary>
            /// Class representing any non-virtual connection.
            /// </summary>
            public class RealConnection : Skyline.DataMiner.Library.Common.ConnectionSettings, Skyline.DataMiner.Library.Common.IRealConnection
            {
                private readonly int id;
                private System.TimeSpan timeout;
                private int retries;
                private System.TimeSpan? elementTimeout;
                /// <summary>
                /// Initiates a new RealConnection class.
                /// </summary>
                /// <param name = "info"></param>
                internal RealConnection(Skyline.DataMiner.Net.Messages.ElementPortInfo info)
                {
                    this.id = info.PortID;
                    this.retries = info.Retries;
                    this.timeout = new System.TimeSpan(0, 0, 0, 0, info.TimeoutTime);
                }

                /// <summary>
                /// Default empty constructor.
                /// </summary>
                public RealConnection()
                {
                }

                /// <summary>
                /// Gets the zero based id of the connection.
                /// </summary>
                public int Id
                {
                    get
                    {
                        return this.id;
                    }
                }

                /// <summary>
                /// Get or Set the timeout value.
                /// </summary>
                public System.TimeSpan Timeout
                {
                    get
                    {
                        return timeout;
                    }

                    set
                    {
                        if (value.TotalMilliseconds >= 10 && value.TotalMilliseconds <= 120000)
                        {
                            timeout = value;
                        }
                        else
                        {
                            throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Timeout value should be between 10 and 120 s.");
                        }
                    }
                }

                /// <summary>
                /// Get or Set the amount of retries.
                /// </summary>
                public int Retries
                {
                    get
                    {
                        return retries;
                    }

                    set
                    {
                        if (value >= 0 && value <= 10)
                        {
                            retries = value;
                        }
                        else
                        {
                            throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Retries value should be between 0 and 10.");
                        }
                    }
                }

                /// <summary>
                /// Get or Set the timespan before the element will go into timeout after not responding.
                /// </summary>
                /// <value>When null, the connection will not be taken into account for the element to go into timeout.</value>
                public System.TimeSpan? ElementTimeout
                {
                    get
                    {
                        return elementTimeout;
                    }

                    set
                    {
                        if (value == null || (value.Value.TotalSeconds >= 1 && value.Value.TotalSeconds <= 120))
                        {
                            elementTimeout = value;
                        }
                        else
                        {
                            throw new Skyline.DataMiner.Library.Common.IncorrectDataException("ElementTimeout value should be between 1 and 120 sec.");
                        }
                    }
                }
            }

            /// <summary>
            /// Class used to Encrypt data in DataMiner.
            /// </summary>
            internal class RSA
            {
                private static System.Security.Cryptography.RSAParameters publicKey;
                /// <summary>
                /// Get or Sets the Public Key.
                /// </summary>
                internal static System.Security.Cryptography.RSAParameters PublicKey
                {
                    get
                    {
                        return publicKey;
                    }

                    set
                    {
                        publicKey = value;
                    }
                }
            }

            /// <summary>
            /// Class representing a Serial Connection.
            /// </summary>
            public class SerialConnection : Skyline.DataMiner.Library.Common.ISerialConnection
            {
                /// <summary>
                ///	Initiates a new instance with default settings for Timeout (1500), Retries (3), Element Timeout (30),
                ///	</summary>
                /// <param name = "tcpConnection">The TCP Connection.</param>
                public SerialConnection(Skyline.DataMiner.Library.Common.ITcp tcpConnection)
                {
                    if (tcpConnection == null)
                        throw new System.ArgumentNullException("tcpConnection");
                    Connection = tcpConnection;
                    BusAddress = System.String.Empty;
                    Id = -1;
                    Timeout = new System.TimeSpan(0, 0, 0, 0, 1500);
                    Retries = 3;
                    ElementTimeout = new System.TimeSpan(0, 0, 0, 30);
                }

                /// <summary>
                ///	Initiates a new instance with default settings for Timeout (1500), Retries (3), Element Timeout (30),
                ///	</summary>
                /// <param name = "udpConnection">The UDP Connection.</param>
                public SerialConnection(Skyline.DataMiner.Library.Common.IUdp udpConnection)
                {
                    if (udpConnection == null)
                        throw new System.ArgumentNullException("udpConnection");
                    Connection = udpConnection;
                    BusAddress = System.String.Empty;
                    Id = -1;
                    Timeout = new System.TimeSpan(0, 0, 0, 0, 1500);
                    Retries = 3;
                    ElementTimeout = new System.TimeSpan(0, 0, 0, 30);
                }

                /// <summary>
                /// Default empty constructor
                /// </summary>
                public SerialConnection()
                {
                }

                /// <summary>
                /// Get or Sets the connection settings.
                /// </summary>
                public Skyline.DataMiner.Library.Common.IPortConnection Connection
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the bus address.
                /// </summary>
                public string BusAddress
                {
                    get;
                    set;
                }

                /// <summary>
                /// Get or Set the timeout value.
                /// </summary>
                public System.TimeSpan Timeout
                {
                    get;
                    set;
                }

                /// <summary>
                /// Get or Set the amount of retries.
                /// </summary>
                public int Retries
                {
                    get;
                    set;
                }

                /// <summary>
                /// Get or Set the timespan before the element will go into timeout after not responding.
                /// </summary>
                /// <value>When null, the connection will not be taken into account for the element to go into timeout.</value>
                public System.TimeSpan? ElementTimeout
                {
                    get;
                    set;
                }

                /// <summary>
                /// Get or Sets the zero based id of the connection.
                /// </summary>
                public int Id
                {
                    get;
                    private set;
                }
            }

            /// <summary>
            ///     Class representing an SNMPv1 connection.
            /// </summary>
            public class SnmpV1Connection : Skyline.DataMiner.Library.Common.ConnectionSettings, Skyline.DataMiner.Library.Common.ISnmpV1Connection
            {
                private readonly int id;
                private readonly System.Guid libraryCredentials;
                private string deviceAddress;
                private System.TimeSpan? elementTimeout;
                private string getCommunityString;
                private int retries;
                private string setCommunityString;
                private System.TimeSpan timeout;
                private Skyline.DataMiner.Library.Common.IUdp udpIpConfiguration;
                /// <summary>
                ///     /// Initiates a new instance with default settings for Get Community String (public), Set Community String
                ///     (private), Device Address (empty),
                ///     Command Timeout (1500ms), Retries (3) and Element Timeout (30s).
                /// </summary>
                /// <param name = "udpConfiguration">The UDP configuration parameters.</param>
                public SnmpV1Connection(Skyline.DataMiner.Library.Common.IUdp udpConfiguration)
                {
                    if (udpConfiguration == null)
                    {
                        throw new System.ArgumentNullException("udpConfiguration");
                    }

                    this.id = -1;
                    this.udpIpConfiguration = udpConfiguration;
                    this.getCommunityString = "public";
                    this.setCommunityString = "private";
                    this.deviceAddress = System.String.Empty;
                    this.timeout = new System.TimeSpan(0, 0, 0, 0, 1500);
                    this.retries = 3;
                    this.elementTimeout = new System.TimeSpan(0, 0, 0, 30);
                }

                /// <summary>
                ///     Default empty constructor
                /// </summary>
                public SnmpV1Connection()
                {
                }

                /// <summary>
                ///     Initiates an new instance.
                /// </summary>
                internal SnmpV1Connection(Skyline.DataMiner.Net.Messages.ElementPortInfo info)
                {
                    this.deviceAddress = info.BusAddress;
                    this.retries = info.Retries;
                    this.timeout = new System.TimeSpan(0, 0, 0, 0, info.TimeoutTime);
                    this.libraryCredentials = info.LibraryCredential;
                    // this.elementTimeout = new TimeSpan(0, 0, info.ElementTimeoutTime / 1000);
                    if (this.libraryCredentials == System.Guid.Empty)
                    {
                        this.getCommunityString = info.GetCommunity;
                        this.setCommunityString = info.SetCommunity;
                    }
                    else
                    {
                        this.getCommunityString = System.String.Empty;
                        this.setCommunityString = System.String.Empty;
                    }

                    this.id = info.PortID;
                    this.elementTimeout = new System.TimeSpan(0, 0, 0, 0, info.ElementTimeoutTime);
                    this.udpIpConfiguration = new Skyline.DataMiner.Library.Common.Udp(info);
                }

                /// <summary>
                ///     Get or Set the device address.
                /// </summary>
                public string DeviceAddress
                {
                    get
                    {
                        return this.deviceAddress;
                    }

                    set
                    {
                        if (this.deviceAddress != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.DeviceAddress);
                            this.deviceAddress = value;
                        }
                    }
                }

                /// <summary>
                ///     Get or Set the timespan before the element will go into timeout after not responding.
                /// </summary>
                /// <value>When null, the connection will not be taken into account for the element to go into timeout.</value>
                public System.TimeSpan? ElementTimeout
                {
                    get
                    {
                        return this.elementTimeout;
                    }

                    set
                    {
                        if (this.elementTimeout != value)
                        {
                            if (value == null || (value.Value.TotalSeconds >= 1 && value.Value.TotalSeconds <= 120))
                            {
                                this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.ElementTimeout);
                                this.elementTimeout = value;
                            }
                            else
                            {
                                throw new Skyline.DataMiner.Library.Common.IncorrectDataException("ElementTimeout value should be between 1 and 120 sec.");
                            }
                        }
                    }
                }

                /// <summary>
                ///     Get or sets the Get community string.
                /// </summary>
                public string GetCommunityString
                {
                    get
                    {
                        return this.getCommunityString;
                    }

                    set
                    {
                        if (this.getCommunityString != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.GetCommunityString);
                            this.getCommunityString = value;
                        }
                    }
                }

                /// <summary>
                /// Gets the zero based id of the connection.
                /// </summary>
                public int Id
                {
                    get
                    {
                        return this.id;
                    }
                }

                /// <summary>
                ///     Get the libraryCredentials
                /// </summary>
                public System.Guid LibraryCredentials
                {
                    get
                    {
                        return this.libraryCredentials;
                    }
                }

                /// <summary>
                ///     Get or Set the amount of retries.
                /// </summary>
                public int Retries
                {
                    get
                    {
                        return this.retries;
                    }

                    set
                    {
                        if (this.retries != value)
                        {
                            if (value >= 0 && value <= 10)
                            {
                                this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.Retries);
                                this.retries = value;
                            }
                            else
                            {
                                throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Retries value should be between 0 and 10.");
                            }
                        }
                    }
                }

                /// <summary>
                ///     Get or set the Set Community String.
                /// </summary>
                public string SetCommunityString
                {
                    get
                    {
                        return this.setCommunityString;
                    }

                    set
                    {
                        if (this.setCommunityString != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.SetCommunityString);
                            this.setCommunityString = value;
                        }
                    }
                }

                /// <summary>
                ///     Get or Set the timeout value.
                /// </summary>
                public System.TimeSpan Timeout
                {
                    get
                    {
                        return this.timeout;
                    }

                    set
                    {
                        if (this.timeout != value)
                        {
                            if (value.TotalMilliseconds >= 10 && value.TotalMilliseconds <= 120000)
                            {
                                this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.Timeout);
                                this.timeout = value;
                            }
                            else
                            {
                                throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Timeout value should be between 10 and 120 sec.");
                            }
                        }
                    }
                }

                /// <summary>
                ///     Get or Set the UDP Connection settings
                /// </summary>
                public Skyline.DataMiner.Library.Common.IUdp UdpConfiguration
                {
                    get
                    {
                        return this.udpIpConfiguration;
                    }

                    set
                    {
                        if (this.udpIpConfiguration == null || !this.udpIpConfiguration.Equals(value))
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.PortConnection);
                            this.udpIpConfiguration = value;
                        }
                    }
                }
            }

            /// <summary>
            ///     Class representing an SnmpV2 Connection.
            /// </summary>
            public class SnmpV2Connection : Skyline.DataMiner.Library.Common.ConnectionSettings, Skyline.DataMiner.Library.Common.ISnmpV2Connection
            {
                private readonly int id;
                private readonly System.Guid libraryCredentials;
                private string deviceAddress;
                private System.TimeSpan? elementTimeout;
                private string getCommunityString;
                private int retries;
                private string setCommunityString;
                private System.TimeSpan timeout;
                private Skyline.DataMiner.Library.Common.IUdp udpIpConfiguration;
                /// <summary>
                ///     Initiates a new instance with default settings for Get Community String (public), Set Community String (private),
                ///     Device Address (empty),
                ///     Command Timeout (1500ms), Retries (3) and Element Timeout (30s).
                /// </summary>
                /// <param name = "udpConfiguration">The UDP Connection settings.</param>
                public SnmpV2Connection(Skyline.DataMiner.Library.Common.IUdp udpConfiguration)
                {
                    if (udpConfiguration == null)
                    {
                        throw new System.ArgumentNullException("udpConfiguration");
                    }

                    this.id = -1;
                    this.udpIpConfiguration = udpConfiguration;
                    // this.udpIpConfiguration = udpIpIpConfiguration;
                    this.deviceAddress = System.String.Empty;
                    this.getCommunityString = "public";
                    this.setCommunityString = "private";
                    this.timeout = new System.TimeSpan(0, 0, 0, 0, 1500);
                    this.retries = 3;
                    this.elementTimeout = new System.TimeSpan(0, 0, 0, 30);
                    this.libraryCredentials = System.Guid.Empty;
                }

                /// <summary>
                ///     Default empty constructor
                /// </summary>
                public SnmpV2Connection()
                {
                }

                /// <summary>
                ///     Initializes a new instance.
                /// </summary>
                internal SnmpV2Connection(Skyline.DataMiner.Net.Messages.ElementPortInfo info)
                {
                    this.deviceAddress = info.BusAddress;
                    this.retries = info.Retries;
                    this.timeout = new System.TimeSpan(0, 0, 0, 0, info.TimeoutTime);
                    this.getCommunityString = info.GetCommunity;
                    this.setCommunityString = info.SetCommunity;
                    this.libraryCredentials = info.LibraryCredential;
                    if (info.LibraryCredential == System.Guid.Empty)
                    {
                        this.getCommunityString = info.GetCommunity;
                        this.setCommunityString = info.SetCommunity;
                    }
                    else
                    {
                        this.getCommunityString = System.String.Empty;
                        this.setCommunityString = System.String.Empty;
                    }

                    this.id = info.PortID;
                    this.elementTimeout = new System.TimeSpan(0, 0, 0, 0, info.ElementTimeoutTime);
                    this.udpIpConfiguration = new Skyline.DataMiner.Library.Common.Udp(info);
                }

                /// <summary>
                ///     Get or Sets the device address.
                /// </summary>
                public string DeviceAddress
                {
                    get
                    {
                        return this.deviceAddress;
                    }

                    set
                    {
                        if (this.deviceAddress != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.DeviceAddress);
                            this.deviceAddress = value;
                        }
                    }
                }

                /// <summary>
                ///     Get or Set the timespan before the element will go into timeout after not responding.
                /// </summary>
                /// <value>When null, the connection will not be taken into account for the element to go into timeout.</value>
                public System.TimeSpan? ElementTimeout
                {
                    get
                    {
                        return this.elementTimeout;
                    }

                    set
                    {
                        if (this.elementTimeout != value)
                        {
                            if (value == null || (value.Value.TotalSeconds >= 1 && value.Value.TotalSeconds <= 120))
                            {
                                this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.ElementTimeout);
                                this.elementTimeout = value;
                            }
                            else
                            {
                                throw new Skyline.DataMiner.Library.Common.IncorrectDataException("ElementTimeout value should be between 1 and 120 sec.");
                            }
                        }
                    }
                }

                /// <summary>
                ///     Get or Sets the Get community string.
                /// </summary>
                public string GetCommunityString
                {
                    get
                    {
                        return this.getCommunityString;
                    }

                    set
                    {
                        if (this.getCommunityString != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.GetCommunityString);
                            this.getCommunityString = value;
                        }
                    }
                }

                /// <summary>
                ///     Gets the zero based id of the connection.
                /// </summary>
                public int Id
                {
                    get
                    {
                        return this.id;
                    }
                }

                /// <summary>
                ///     Gets the Library Credential settings.
                /// </summary>
                public System.Guid LibraryCredentials
                {
                    get
                    {
                        return this.libraryCredentials;
                    }
                }

                /// <summary>
                ///     Get or Set the amount of retries.
                /// </summary>
                public int Retries
                {
                    get
                    {
                        return this.retries;
                    }

                    set
                    {
                        if (this.retries != value)
                        {
                            if (value >= 0 && value <= 10)
                            {
                                this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.Retries);
                                this.retries = value;
                            }
                            else
                            {
                                throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Retries value should be between 0 and 10.");
                            }
                        }
                    }
                }

                /// <summary>
                ///     Get or Sets the Set community string.
                /// </summary>
                public string SetCommunityString
                {
                    get
                    {
                        return this.setCommunityString;
                    }

                    set
                    {
                        if (this.setCommunityString != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.SetCommunityString);
                            this.setCommunityString = value;
                        }
                    }
                }

                /// <summary>
                ///     Get or Set the timeout value.
                /// </summary>
                public System.TimeSpan Timeout
                {
                    get
                    {
                        return this.timeout;
                    }

                    set
                    {
                        if (this.timeout != value)
                        {
                            if (value.TotalMilliseconds >= 10 && value.TotalMilliseconds <= 120000)
                            {
                                this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.Timeout);
                                this.timeout = value;
                            }
                            else
                            {
                                throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Timeout value should be between 10 and 120 s.");
                            }
                        }
                    }
                }

                /// <summary>
                ///     Get or Sets the UDP connection settings.
                /// </summary>
                public Skyline.DataMiner.Library.Common.IUdp UdpConfiguration
                {
                    get
                    {
                        return this.udpIpConfiguration;
                    }

                    set
                    {
                        if (this.udpIpConfiguration == null || !this.udpIpConfiguration.Equals(value))
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.PortConnection);
                            this.udpIpConfiguration = value;
                        }
                    }
                }
            }

            /// <summary>
            ///     Class representing a SNMPv3 class.
            /// </summary>
            public class SnmpV3Connection : Skyline.DataMiner.Library.Common.ConnectionSettings, Skyline.DataMiner.Library.Common.ISnmpV3Connection
            {
                private readonly int id;
                private readonly System.Guid libraryCredentials;
                private string deviceAddress;
                private System.TimeSpan? elementTimeout;
                private int retries;
                private Skyline.DataMiner.Library.Common.ISnmpV3SecurityConfig securityConfig;
                private System.TimeSpan timeout;
                private Skyline.DataMiner.Library.Common.IUdp udpIpConfiguration;
                /// <summary>
                ///     Initializes a new instance.
                /// </summary>
                /// <param name = "udpConfiguration">The udp configuration settings.</param>
                /// <param name = "securityConfig">The SNMPv3 security configuration.</param>
                public SnmpV3Connection(Skyline.DataMiner.Library.Common.IUdp udpConfiguration, Skyline.DataMiner.Library.Common.SnmpV3SecurityConfig securityConfig)
                {
                    if (udpConfiguration == null)
                    {
                        throw new System.ArgumentNullException("udpConfiguration");
                    }

                    if (securityConfig == null)
                    {
                        throw new System.ArgumentNullException("securityConfig");
                    }

                    this.libraryCredentials = System.Guid.Empty;
                    this.id = -1;
                    this.udpIpConfiguration = udpConfiguration;
                    this.deviceAddress = System.String.Empty;
                    this.securityConfig = securityConfig;
                    this.timeout = new System.TimeSpan(0, 0, 0, 0, 1500);
                    this.retries = 3;
                    this.elementTimeout = new System.TimeSpan(0, 0, 0, 30);
                }

                /// <summary>
                ///     Default empty constructor
                /// </summary>
                public SnmpV3Connection()
                {
                }

                /// <summary>
                ///     Initializes a new instance.
                /// </summary>
                internal SnmpV3Connection(Skyline.DataMiner.Net.Messages.ElementPortInfo info)
                {
                    this.deviceAddress = info.BusAddress;
                    this.retries = info.Retries;
                    this.timeout = new System.TimeSpan(0, 0, 0, 0, info.TimeoutTime);
                    this.elementTimeout = new System.TimeSpan(0, 0, info.ElementTimeoutTime / 1000);
                    if (this.libraryCredentials == System.Guid.Empty)
                    {
                        var securityLevelAndProtocol = Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocolAdapter.FromSLNetStopBits(info.StopBits);
                        var encryptionAlgorithm = Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithmAdapter.FromSLNetFlowControl(info.FlowControl);
                        var authenticationProtocol = Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithmAdapter.FromSLNetParity(info.Parity);
                        string authenticationKey = info.GetCommunity;
                        string encryptionKey = info.SetCommunity;
                        string username = info.DataBits;
                        this.securityConfig = new Skyline.DataMiner.Library.Common.SnmpV3SecurityConfig(securityLevelAndProtocol, username, authenticationKey, encryptionKey, authenticationProtocol, encryptionAlgorithm);
                    }
                    else
                    {
                        this.SecurityConfig = new Skyline.DataMiner.Library.Common.SnmpV3SecurityConfig(Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol.DefinedInCredentialsLibrary, System.String.Empty, System.String.Empty, System.String.Empty, Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.DefinedInCredentialsLibrary, Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.DefinedInCredentialsLibrary);
                    }

                    this.id = info.PortID;
                    this.elementTimeout = new System.TimeSpan(0, 0, 0, 0, info.ElementTimeoutTime);
                    this.udpIpConfiguration = new Skyline.DataMiner.Library.Common.Udp(info);
                }

                /// <summary>
                ///     Gets or Sets the device address.
                /// </summary>
                public string DeviceAddress
                {
                    get
                    {
                        return this.deviceAddress;
                    }

                    set
                    {
                        if (this.deviceAddress != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.DeviceAddress);
                            this.deviceAddress = value;
                        }
                    }
                }

                /// <summary>
                ///     Get or Set the timespan before the element will go into timeout after not responding.
                /// </summary>
                /// <value>When null, the connection will not be taken into account for the element to go into timeout.</value>
                public System.TimeSpan? ElementTimeout
                {
                    get
                    {
                        return this.elementTimeout;
                    }

                    set
                    {
                        if (this.elementTimeout != value)
                        {
                            if (value == null || (value.Value.TotalSeconds >= 1 && value.Value.TotalSeconds <= 120))
                            {
                                this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.ElementTimeout);
                                this.elementTimeout = value;
                            }
                            else
                            {
                                throw new Skyline.DataMiner.Library.Common.IncorrectDataException("ElementTimeout value should be between 1 and 120 sec.");
                            }
                        }
                    }
                }

                /// <summary>
                /// Gets the zero based id of the connection.
                /// </summary>
                public int Id
                {
                    get
                    {
                        return this.id;
                    }
                // set
                // {
                // 	ChangedPropertyList.Add("Id");
                // 	id = value;
                // }
                }

                /// <summary>
                ///     Get the libraryCredentials.
                /// </summary>
                public System.Guid LibraryCredentials
                {
                    get
                    {
                        return this.libraryCredentials;
                    }
                }

                /// <summary>
                ///     Get or Set the amount of retries.
                /// </summary>
                public int Retries
                {
                    get
                    {
                        return this.retries;
                    }

                    set
                    {
                        if (this.retries != value)
                        {
                            if (value >= 0 && value <= 10)
                            {
                                this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.Retries);
                                this.retries = value;
                            }
                            else
                            {
                                throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Retries value should be between 0 and 10.");
                            }
                        }
                    }
                }

                /// <summary>
                ///     Gets or sets the SNMPv3 security configuration.
                /// </summary>
                public Skyline.DataMiner.Library.Common.ISnmpV3SecurityConfig SecurityConfig
                {
                    get
                    {
                        return this.securityConfig;
                    }

                    set
                    {
                        this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.SecurityConfig);
                        this.securityConfig = value;
                    }
                }

                /// <summary>
                ///     Get or Set the timeout value.
                /// </summary>
                public System.TimeSpan Timeout
                {
                    get
                    {
                        return this.timeout;
                    }

                    set
                    {
                        if (this.timeout != value)
                        {
                            if (value.TotalMilliseconds >= 10 && value.TotalMilliseconds <= 120000)
                            {
                                this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.Timeout);
                                this.timeout = value;
                            }
                            else
                            {
                                throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Timeout value should be between 10 and 120 sec.");
                            }
                        }
                    }
                }

                /// <summary>
                ///     Get or Set the UDP Connection settings
                /// </summary>
                public Skyline.DataMiner.Library.Common.IUdp UdpConfiguration
                {
                    get
                    {
                        return this.udpIpConfiguration;
                    }

                    set
                    {
                        if (this.udpIpConfiguration == null || !this.udpIpConfiguration.Equals(value))
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.PortConnection);
                            this.udpIpConfiguration = value;
                        }
                    }
                }
            }

            /// <summary>
            /// Allows adapting the enum to other library equivalents.
            /// </summary>
            internal static class SnmpV3EncryptionAlgorithmAdapter
            {
                /// <summary>
                /// Converts SLNet flowControl string into the enum.
                /// </summary>
                /// <param name = "flowControl">flowControl string received from SLNet.</param>
                /// <returns>The equivalent enum.</returns>
                public static Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm FromSLNetFlowControl(string flowControl)
                {
                    string noCaseFlowControl = flowControl.ToUpper();
                    switch (noCaseFlowControl)
                    {
                        case "DES":
                            return Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.Des;
                        case "AES128":
                            return Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.Aes128;
                        case "AES192":
                            return Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.Aes192;
                        case "AES256":
                            return Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.Aes256;
                        case "DEFINEDINCREDENTIALSLIBRARY":
                            return Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.DefinedInCredentialsLibrary;
                        case "NONE":
                        default:
                            return Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.None;
                    }
                }
            }

            /// <summary>
            ///     Represents the Security settings linked to SNMPv3.
            /// </summary>
            public class SnmpV3SecurityConfig : Skyline.DataMiner.Library.Common.ConnectionSettings, Skyline.DataMiner.Library.Common.ISnmpV3SecurityConfig
            {
                private Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm authenticationAlgorithm;
                private string authenticationKey;
                private Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm encryptionAlgorithm;
                private string encryptionKey;
                private Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol securityLevelAndProtocol;
                private string username;
                /// <summary>
                ///     Initializes a new instance using No Authentication and No Privacy.
                /// </summary>
                /// <param name = "username">The username.</param>
                /// <exception cref = "System.ArgumentNullException">When the username is null.</exception>
                public SnmpV3SecurityConfig(string username)
                {
                    if (username == null)
                    {
                        throw new System.ArgumentNullException("username");
                    }

                    this.securityLevelAndProtocol = Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol.NoAuthenticationNoPrivacy;
                    this.username = username;
                    this.authenticationKey = string.Empty;
                    this.encryptionKey = string.Empty;
                    this.authenticationAlgorithm = Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.None;
                    this.encryptionAlgorithm = Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.None;
                }

                /// <summary>
                ///     Initializes a new instance using Authentication No Privacy.
                /// </summary>
                /// <param name = "username">The username.</param>
                /// <param name = "authenticationKey">The Authentication key.</param>
                /// <param name = "authenticationAlgorithm">The Authentication Algorithm.</param>
                /// <exception cref = "System.ArgumentNullException">When username, authenticationKey is null.</exception>
                /// <exception cref = "IncorrectDataException">
                ///     When None or DefinedInCredentialsLibrary is selected as authentication
                ///     algorithm.
                /// </exception>
                public SnmpV3SecurityConfig(string username, string authenticationKey, Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm authenticationAlgorithm)
                {
                    if (username == null)
                    {
                        throw new System.ArgumentNullException("username");
                    }

                    if (authenticationKey == null)
                    {
                        throw new System.ArgumentNullException("authenticationKey");
                    }

                    if (authenticationAlgorithm == Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.None || authenticationAlgorithm == Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.DefinedInCredentialsLibrary)
                    {
                        throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Authentication Algorithm 'None' and 'DefinedInCredentialsLibrary' is Invalid when choosing 'Authentication No Privacy' as Security Level and Protocol.");
                    }

                    this.securityLevelAndProtocol = Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol.AuthenticationNoPrivacy;
                    this.username = username;
                    this.authenticationKey = authenticationKey;
                    this.encryptionKey = string.Empty;
                    this.authenticationAlgorithm = authenticationAlgorithm;
                    this.encryptionAlgorithm = Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.None;
                }

                /// <summary>
                ///     Initializes a new instance using Authentication and Privacy.
                /// </summary>
                /// <param name = "username">The username.</param>
                /// <param name = "authenticationKey">The authentication key.</param>
                /// <param name = "encryptionKey">The encryptionKey.</param>
                /// <param name = "authenticationProtocol">The authentication algorithm.</param>
                /// <param name = "encryptionAlgorithm">The encryption algorithm.</param>
                /// <exception cref = "System.ArgumentNullException">When username, authenticationKey or encryptionKey is null.</exception>
                /// <exception cref = "IncorrectDataException">
                ///     When None or DefinedInCredentialsLibrary is selected as authentication
                ///     algorithm or encryption algorithm.
                /// </exception>
                public SnmpV3SecurityConfig(string username, string authenticationKey, Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm authenticationProtocol, string encryptionKey, Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm encryptionAlgorithm)
                {
                    if (username == null)
                    {
                        throw new System.ArgumentNullException("username");
                    }

                    if (authenticationKey == null)
                    {
                        throw new System.ArgumentNullException("authenticationKey");
                    }

                    if (encryptionKey == null)
                    {
                        throw new System.ArgumentNullException("encryptionKey");
                    }

                    if (authenticationProtocol == Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.None || authenticationProtocol == Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.DefinedInCredentialsLibrary)
                    {
                        throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Authentication Algorithm 'None' and 'DefinedInCredentialsLibrary' is Invalid when choosing 'Authentication No Privacy' as Security Level and Protocol.");
                    }

                    if (encryptionAlgorithm == Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.None || encryptionAlgorithm == Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm.DefinedInCredentialsLibrary)
                    {
                        throw new Skyline.DataMiner.Library.Common.IncorrectDataException("Encryption Algorithm 'None' and 'DefinedInCredentialsLibrary' is Invalid when choosing 'Authentication and Privacy' as Security Level and Protocol.");
                    }

                    this.securityLevelAndProtocol = Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol.AuthenticationPrivacy;
                    this.username = username;
                    this.authenticationKey = authenticationKey;
                    this.encryptionKey = encryptionKey;
                    this.authenticationAlgorithm = authenticationProtocol;
                    this.encryptionAlgorithm = encryptionAlgorithm;
                }

                /// <summary>
                ///     Default empty constructor
                /// </summary>
                public SnmpV3SecurityConfig()
                {
                }

                /// <summary>
                ///     Initializes a new instance.
                /// </summary>
                /// <param name = "securityLevelAndProtocol">The security Level and Protocol.</param>
                /// <param name = "username">The username.</param>
                /// <param name = "authenticationKey">The authenticationKey</param>
                /// <param name = "encryptionKey">The encryptionKey</param>
                /// <param name = "authenticationAlgorithm">The authentication Algorithm.</param>
                /// <param name = "encryptionAlgorithm">The encryption Algorithm.</param>
                /// <exception cref = "System.ArgumentNullException">When username, authenticationKey or encryptionKey is null.</exception>
                internal SnmpV3SecurityConfig(Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol securityLevelAndProtocol, string username, string authenticationKey, string encryptionKey, Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm authenticationAlgorithm, Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm encryptionAlgorithm)
                {
                    if (username == null)
                    {
                        throw new System.ArgumentNullException("username");
                    }

                    if (authenticationKey == null)
                    {
                        throw new System.ArgumentNullException("authenticationKey");
                    }

                    if (encryptionKey == null)
                    {
                        throw new System.ArgumentNullException("encryptionKey");
                    }

                    this.securityLevelAndProtocol = securityLevelAndProtocol;
                    this.username = username;
                    this.authenticationKey = authenticationKey;
                    this.encryptionKey = encryptionKey;
                    this.authenticationAlgorithm = authenticationAlgorithm;
                    this.encryptionAlgorithm = encryptionAlgorithm;
                }

                /// <summary>
                ///     Gets or sets the AuthenticationProtocol.
                /// </summary>
                public Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm AuthenticationAlgorithm
                {
                    get
                    {
                        return this.authenticationAlgorithm;
                    }

                    set
                    {
                        if (this.authenticationAlgorithm != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.AuthenticationProtocol);
                            this.authenticationAlgorithm = value;
                        }
                    }
                }

                /// <summary>
                ///     Gets or sets the AuthenticationKey.
                /// </summary>
                public string AuthenticationKey
                {
                    get
                    {
                        return this.authenticationKey;
                    }

                    set
                    {
                        if (this.AuthenticationKey != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.AuthenticationKey);
                            this.authenticationKey = value;
                        }
                    }
                }

                /// <summary>
                ///     Gets or sets the EncryptionAlgorithm.
                /// </summary>
                public Skyline.DataMiner.Library.Common.SnmpV3EncryptionAlgorithm EncryptionAlgorithm
                {
                    get
                    {
                        return this.encryptionAlgorithm;
                    }

                    set
                    {
                        if (this.encryptionAlgorithm != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.EncryptionAlgorithm);
                            this.encryptionAlgorithm = value;
                        }
                    }
                }

                /// <summary>
                ///     Gets or sets the EncryptionKey.
                /// </summary>
                public string EncryptionKey
                {
                    get
                    {
                        return this.encryptionKey;
                    }

                    set
                    {
                        if (this.encryptionKey != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.EncryptionKey);
                            this.encryptionKey = value;
                        }
                    }
                }

                /// <summary>
                ///     Gets or sets the SecurityLevelAndProtocol.
                /// </summary>
                public Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol SecurityLevelAndProtocol
                {
                    get
                    {
                        return this.securityLevelAndProtocol;
                    }

                    set
                    {
                        if (this.securityLevelAndProtocol != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.SecurityLevelAndProtocol);
                            this.securityLevelAndProtocol = value;
                        }
                    }
                }

                /// <summary>
                ///     Gets or sets the username.
                /// </summary>
                public string Username
                {
                    get
                    {
                        return this.username;
                    }

                    set
                    {
                        if (this.username != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.Username);
                            this.username = value;
                        }
                    }
                }
            }

            /// <summary>
            /// Allows adapting the enum to other library equivalents.
            /// </summary>
            internal static class SnmpV3SecurityLevelAndProtocolAdapter
            {
                /// <summary>
                /// Converts SLNet stopBits string into the enum.
                /// </summary>
                /// <param name = "stopBits">stopBits string received from SLNet.</param>
                /// <returns>The equivalent enum.</returns>
                public static Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol FromSLNetStopBits(string stopBits)
                {
                    string noCaseStopBits = stopBits.ToUpper();
                    switch (noCaseStopBits)
                    {
                        case "AUTHPRIV":
                        case "AUTHENTICATIONPRIVACY":
                            return Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol.AuthenticationPrivacy;
                        case "AUTHNOPRIV":
                        case "AUTHENTICATIONNOPRIVACY":
                            return Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol.AuthenticationNoPrivacy;
                        case "NOAUTHNOPRIV":
                        case "NOAUTHENTICATIONNOPRIVACY":
                            return Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol.NoAuthenticationNoPrivacy;
                        case "DEFINEDINCREDENTIALSLIBRARY":
                            return Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol.DefinedInCredentialsLibrary;
                        default:
                            return Skyline.DataMiner.Library.Common.SnmpV3SecurityLevelAndProtocol.None;
                    }
                }
            }

            /// <summary>
            /// Class representing a Virtual connection. 
            /// </summary>
            public class VirtualConnection : Skyline.DataMiner.Library.Common.ConnectionSettings, Skyline.DataMiner.Library.Common.IVirtualConnection
            {
                private readonly int id;
                /// <summary>
                /// Initiates a new VirtualConnection class.
                /// </summary>
                /// <param name = "info"></param>
                internal VirtualConnection(Skyline.DataMiner.Net.Messages.ElementPortInfo info)
                {
                    this.id = info.PortID;
                }

                /// <summary>
                /// Initiates a new VirtualConnection class.
                /// </summary>
                public VirtualConnection()
                {
                    this.id = -1;
                }

                /// <summary>
                /// Gets the zero based id of the connection.
                /// </summary>
                public int Id
                {
                    get
                    {
                        return id;
                    }
                }
            }

            /// <summary>
            /// Specifies the SNMPv3 authentication protocol.
            /// </summary>
            public enum SnmpV3AuthenticationAlgorithm
            {
                /// <summary>
                /// Message Digest 5 (MD5).
                /// </summary>
                Md5 = 0,
                /// <summary>
                /// Secure Hash Algorithm (SHA).
                /// </summary>
                Sha1 = 1,
                /// <summary>
                /// Secure Hash Algorithm (SHA) 224.
                /// </summary>
                Sha224 = 2,
                /// <summary>
                /// Secure Hash Algorithm (SHA) 256.
                /// </summary>
                Sha256 = 3,
                /// <summary>
                /// Secure Hash Algorithm (SHA) 384.
                /// </summary>
                Sha384 = 4,
                /// <summary>
                /// Secure Hash Algorithm (SHA) 512.
                /// </summary>
                Sha512 = 5,
                /// <summary>
                /// Algorithm is defined in the Credential Library.
                /// </summary>
                DefinedInCredentialsLibrary = 6,
                /// <summary>
                /// No algorithm selected.
                /// </summary>
                None = 7
            }

            /// <summary>
            /// Allows adapting the enum to other library equivalents.
            /// </summary>
            public class SnmpV3AuthenticationAlgorithmAdapter
            {
                /// <summary>
                /// Converts SLNet parity string into the enum.
                /// </summary>
                /// <param name = "parity">Parity string received from SLNet.</param>
                /// <returns>The equivalent enum.</returns>
                public static Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm FromSLNetParity(string parity)
                {
                    string noCaseParity = parity.ToUpper();
                    switch (noCaseParity)
                    {
                        case "MD5":
                        case "HMAC-MD5":
                            return Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.Md5;
                        case "SHA":
                        case "SHA1":
                        case "HMAC-SHA":
                            return Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.Sha1;
                        case "SHA224":
                            return Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.Sha224;
                        case "SHA256":
                            return Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.Sha256;
                        case "SHA384":
                            return Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.Sha384;
                        case "SHA512":
                            return Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.Sha512;
                        case "DEFINEDINCREDENTIALSLIBRARY":
                            return Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.DefinedInCredentialsLibrary;
                        case "NONE":
                        default:
                            return Skyline.DataMiner.Library.Common.SnmpV3AuthenticationAlgorithm.None;
                    }
                }
            }

            /// <summary>
            /// Specifies the SNMPv3 encryption algorithm.
            /// </summary>
            public enum SnmpV3EncryptionAlgorithm
            {
                /// <summary>
                /// Data Encryption Standard (DES).
                /// </summary>
                Des = 0,
                /// <summary>
                /// Advanced Encryption Standard (AES) 128 bit.
                /// </summary>
                Aes128 = 1,
                /// <summary>
                /// Advanced Encryption Standard (AES) 192 bit.
                /// </summary>
                Aes192 = 2,
                /// <summary>
                /// Advanced Encryption Standard (AES) 256 bit.
                /// </summary>
                Aes256 = 3,
                /// <summary>
                /// Advanced Encryption Standard is defined in the Credential Library.
                /// </summary>
                DefinedInCredentialsLibrary = 4,
                /// <summary>
                /// No algorithm selected.
                /// </summary>
                None = 5
            }

            /// <summary>
            /// Specifies the SNMP v3 security level and protocol.
            /// </summary>
            public enum SnmpV3SecurityLevelAndProtocol
            {
                /// <summary>
                /// Authentication and privacy.
                /// </summary>
                AuthenticationPrivacy = 0,
                /// <summary>
                /// Authentication but no privacy.
                /// </summary>
                AuthenticationNoPrivacy = 1,
                /// <summary>
                /// No authentication and no privacy.
                /// </summary>
                NoAuthenticationNoPrivacy = 2,
                /// <summary>
                /// Security Level and Protocol is defined in the Credential library.
                /// </summary>
                DefinedInCredentialsLibrary = 3,
                /// <summary>
                /// No algorithm selected.
                /// </summary>
                None = 4
            }

            /// <summary>
            /// Represents a connection using the Internet Protocol (IP).
            /// </summary>
            public interface IIpBased : Skyline.DataMiner.Library.Common.IPortConnection
            {
                /// <summary>
                /// Gets or sets the host name or IP address of the host to connect to.
                /// </summary>
                /// <value>The host name or IP address of the host to connect to.</value>
                string RemoteHost
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the network interface card (NIC).
                /// </summary>
                /// <value>The network interface card (NIC). A value of 0 means the network interface card will be selected automatically.</value>
                int NetworkInterfaceCard
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// interface IPortConnection for which all connections will inherit from.
            /// </summary>
            public interface IPortConnection
            {
            }

            /// <summary>
            /// Represents a TCP/IP connection.
            /// </summary>
            public interface ITcp : Skyline.DataMiner.Library.Common.IIpBased
            {
                /// <summary>
                /// Gets or sets the local port number.
                /// </summary>
                /// <value>The local port number.</value>
                /// <remarks>Configuring the local port is only supported for <see cref = "ISerialConnection"/> connections.</remarks>
                int? LocalPort
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or set the remote port number.
                /// </summary>
                /// <value>The remote port number.</value>
                int? RemotePort
                {
                    get;
                    set;
                }

                /// <summary>
                /// Indicates if SSL/TLS is enabled on the connection.
                /// </summary>
                /// <remarks>Can only be set to true on connection for protocol type Serial and port type IP.</remarks>
                bool IsSslTlsEnabled
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets if a dedicated connection is used.
                /// </summary>
                /// <remarks>This is the "single" of <see cref = "ISerialConnection"/> and <see cref = "ISmartSerialConnection"/>. Cannot be configured.</remarks>
                bool IsDedicated
                {
                    get;
                }
            }

            /// <summary>
            /// Represents a UDP/IP connection.
            /// </summary>
            public interface IUdp : Skyline.DataMiner.Library.Common.IIpBased
            {
                /// <summary>
                /// Gets or sets the local port number.
                /// </summary>
                /// <value>The local port number.</value>
                /// <remarks>Configuring the local port is only supported for <see cref = "ISerialConnection"/> connections.</remarks>
                int? LocalPort
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or set the remote port number.
                /// </summary>
                /// <value>The remote port number.</value>
                int? RemotePort
                {
                    get;
                    set;
                }

                /// <summary>
                /// Indicates if SSL/TLS is enabled on the connection.
                /// </summary>
                bool IsSslTlsEnabled
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets if a dedicated connection is used.
                /// </summary>
                bool IsDedicated
                {
                    get;
                }
            }

            /// <summary>
            /// Class representing a TCP connection.
            /// </summary>
            public class Tcp : Skyline.DataMiner.Library.Common.ConnectionSettings, Skyline.DataMiner.Library.Common.ITcp
            {
                private string remoteHost;
                private int networkInterfaceCard;
                private int? localPort;
                private int? remotePort;
                private bool isSslTlsEnabled;
                private readonly bool isDedicated;
                internal Tcp(Skyline.DataMiner.Net.Messages.ElementPortInfo info)
                {
                    this.remoteHost = info.PollingIPAddress;
                    if (!info.PollingIPPort.Equals(System.String.Empty))
                        remotePort = System.Convert.ToInt32(info.PollingIPPort);
                    if (!info.LocalIPPort.Equals(System.String.Empty))
                        localPort = System.Convert.ToInt32(info.LocalIPPort);
                    this.isSslTlsEnabled = info.IsSslTlsEnabled;
                    this.isDedicated = Skyline.DataMiner.Library.Common.HelperClass.IsDedicatedConnection(info);
                    int networkInterfaceId = System.String.IsNullOrWhiteSpace(info.Number) ? 0 : System.Convert.ToInt32(info.Number);
                    this.networkInterfaceCard = networkInterfaceId;
                }

                /// <summary>
                /// Initializes a new instance, using default values for localPort (null=Auto) and NetworkInterfaceCard (0=Auto)
                /// </summary>
                /// <param name = "remoteHost">The IP or name of the remote host.</param>
                /// <param name = "remotePort">The port number of the remote host.</param>
                public Tcp(string remoteHost, int remotePort)
                {
                    this.localPort = null;
                    this.remotePort = remotePort;
                    this.remoteHost = remoteHost;
                    this.networkInterfaceCard = 0;
                    this.isDedicated = false;
                }

                /// <summary>
                /// Default empty constructor.
                /// </summary>
                public Tcp()
                {
                }

                /// <summary>
                /// Gets or sets the IP Address or name of the remote host.
                /// </summary>
                public string RemoteHost
                {
                    get
                    {
                        return this.remoteHost;
                    }

                    set
                    {
                        if (this.remoteHost != value)
                        {
                            ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.RemoteHost);
                            this.remoteHost = value;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets the network interface card number.
                /// </summary>
                public int NetworkInterfaceCard
                {
                    get
                    {
                        return this.networkInterfaceCard;
                    }

                    set
                    {
                        if (this.networkInterfaceCard != value)
                        {
                            ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.NetworkInterfaceCard);
                            networkInterfaceCard = value;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets the local port.
                /// </summary>
                public int? LocalPort
                {
                    get
                    {
                        return localPort;
                    }

                    set
                    {
                        if (this.localPort != value)
                        {
                            ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.LocalPort);
                            this.localPort = value;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets the remote port.
                /// </summary>
                public int? RemotePort
                {
                    get
                    {
                        return remotePort;
                    }

                    set
                    {
                        if (this.remotePort != value)
                        {
                            ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.RemotePort);
                            remotePort = value;
                        }
                    }
                }

                /// <summary>
                /// Indicates if SSL/TLS is enabled on the connection.
                /// </summary>
                /// <remarks>Can only be set to true on connection for protocol type Serial and port type IP.</remarks>
                public bool IsSslTlsEnabled
                {
                    get
                    {
                        return this.isSslTlsEnabled;
                    }

                    set
                    {
                        if (this.isSslTlsEnabled != value)
                        {
                            ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.IsSslTlsEnabled);
                            this.isSslTlsEnabled = value;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets if a dedicated connection is used.
                /// </summary>
                /// <remarks>This is the "single" of <see cref = "ISerialConnection"/> and <see cref = "ISmartSerialConnection"/>. Cannot be configured.</remarks>
                public bool IsDedicated
                {
                    get
                    {
                        return this.isDedicated;
                    }
                }
            }

            /// <summary>
            ///     Class representing an UDP connection.
            /// </summary>
            public sealed class Udp : Skyline.DataMiner.Library.Common.ConnectionSettings, Skyline.DataMiner.Library.Common.IUdp
            {
                /// <summary>
                ///		Compares two instances of this object by comparing the property fields.
                /// </summary>
                /// <param name = "other">The object to compare to.</param>
                /// <returns>Boolean indicating if object is equal or not.</returns>
                public bool Equals(Skyline.DataMiner.Library.Common.Udp other)
                {
                    return this.isDedicated == other.isDedicated && this.isSslTlsEnabled == other.isSslTlsEnabled && this.localPort == other.localPort && this.networkInterfaceCard == other.networkInterfaceCard && string.Equals(this.remoteHost, other.remoteHost, System.StringComparison.InvariantCulture) && this.remotePort == other.remotePort;
                }

                /// <summary>Determines whether the specified object is equal to the current object.</summary>
                /// <param name = "obj">The object to compare with the current object. </param>
                /// <returns>true if the specified object  is equal to the current object; otherwise, false.</returns>
                public override bool Equals(object obj)
                {
                    if (ReferenceEquals(null, obj))
                        return false;
                    if (ReferenceEquals(this, obj))
                        return true;
                    if (obj.GetType() != this.GetType())
                        return false;
                    return Equals((Skyline.DataMiner.Library.Common.Udp)obj);
                }

                /// <summary>Serves as the default hash function. </summary>
                /// <returns>A hash code for the current object.</returns>
                public override int GetHashCode()
                {
                    unchecked
                    {
                        int hashCode = this.isDedicated.GetHashCode();
                        hashCode = (hashCode * 397) ^ this.isSslTlsEnabled.GetHashCode();
                        hashCode = (hashCode * 397) ^ this.localPort.GetHashCode();
                        hashCode = (hashCode * 397) ^ this.networkInterfaceCard;
                        hashCode = (hashCode * 397) ^ (this.remoteHost != null ? System.StringComparer.InvariantCulture.GetHashCode(this.remoteHost) : 0);
                        hashCode = (hashCode * 397) ^ this.remotePort.GetHashCode();
                        return hashCode;
                    }
                }

                private readonly bool isDedicated;
                private bool isSslTlsEnabled;
                private int? localPort;
                private int networkInterfaceCard;
                private string remoteHost;
                private int? remotePort;
                /// <summary>
                ///     Initializes a new instance, using default values for localPort (null=Auto) SslTlsEnabled (false), IsDedicated
                ///     (false) and NetworkInterfaceCard (0=Auto)
                /// </summary>
                /// <param name = "remoteHost">The IP or name of the remote host.</param>
                /// <param name = "remotePort">The port number of the remote host.</param>
                public Udp(string remoteHost, int remotePort)
                {
                    this.localPort = null;
                    this.remotePort = remotePort;
                    this.isSslTlsEnabled = false;
                    this.isDedicated = false;
                    this.remoteHost = remoteHost;
                    this.networkInterfaceCard = 0;
                }

                /// <summary>
                ///     Default empty constructor
                /// </summary>
                public Udp()
                {
                }

                /// <summary>
                ///     Initializes a new instance using a <see cref = "ElementPortInfo"/> object.
                /// </summary>
                /// <param name = "info"></param>
                internal Udp(Skyline.DataMiner.Net.Messages.ElementPortInfo info)
                {
                    this.remoteHost = info.PollingIPAddress;
                    if (!info.PollingIPPort.Equals(System.String.Empty))
                        remotePort = System.Convert.ToInt32(info.PollingIPPort);
                    if (!info.LocalIPPort.Equals(System.String.Empty))
                        localPort = System.Convert.ToInt32(info.LocalIPPort);
                    this.isSslTlsEnabled = info.IsSslTlsEnabled;
                    this.isDedicated = Skyline.DataMiner.Library.Common.HelperClass.IsDedicatedConnection(info);
                    int networkInterfaceId = string.IsNullOrWhiteSpace(info.Number) ? 0 : System.Convert.ToInt32(info.Number);
                    this.networkInterfaceCard = networkInterfaceId;
                }

                /// <summary>
                ///     Gets or sets if a dedicated connection is used.
                /// </summary>
                public bool IsDedicated
                {
                    get
                    {
                        return this.isDedicated;
                    }
                }

                /// <summary>
                ///     Gets or sets if TLS is enabled on the connection.
                /// </summary>
                public bool IsSslTlsEnabled
                {
                    get
                    {
                        return this.isSslTlsEnabled;
                    }

                    set
                    {
                        if (this.isSslTlsEnabled != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.IsSslTlsEnabled);
                            this.isSslTlsEnabled = value;
                        }
                    }
                }

                /// <summary>
                ///     Gets or sets the local port.
                /// </summary>
                public int? LocalPort
                {
                    get
                    {
                        return this.localPort;
                    }

                    set
                    {
                        if (this.localPort != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.LocalPort);
                            this.localPort = value;
                        }
                    }
                }

                /// <summary>
                ///     Gets or sets the network interface card number.
                /// </summary>
                public int NetworkInterfaceCard
                {
                    get
                    {
                        return this.networkInterfaceCard;
                    }

                    set
                    {
                        if (this.networkInterfaceCard != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.NetworkInterfaceCard);
                            this.networkInterfaceCard = value;
                        }
                    }
                }

                /// <summary>
                ///     Gets or sets the IP Address or name of the remote host.
                /// </summary>
                public string RemoteHost
                {
                    get
                    {
                        return this.remoteHost;
                    }

                    set
                    {
                        if (this.remoteHost != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.RemoteHost);
                            this.remoteHost = value;
                        }
                    }
                }

                /// <summary>
                ///     Gets or sets the remote port.
                /// </summary>
                public int? RemotePort
                {
                    get
                    {
                        return this.remotePort;
                    }

                    set
                    {
                        if (this.remotePort != value)
                        {
                            this.ChangedPropertyList.Add(Skyline.DataMiner.Library.Common.ConnectionSettings.ConnectionSetting.RemotePort);
                            this.remotePort = value;
                        }
                    }
                }
            }

            /// <summary>
            /// Represents the advanced element information.
            /// </summary>
            internal class AdvancedSettings : Skyline.DataMiner.Library.Common.ElementSettings, Skyline.DataMiner.Library.Common.IAdvancedSettings
            {
                /// <summary>
                /// Value indicating whether the element is hidden.
                /// </summary>
                private bool isHidden;
                /// <summary>
                /// Value indicating whether the element is read-only.
                /// </summary>
                private bool isReadOnly;
                /// <summary>
                /// Indicates whether this is a simulated element.
                /// </summary>
                private bool isSimulation;
                /// <summary>
                /// The element timeout value.
                /// </summary>
                private System.TimeSpan timeout = new System.TimeSpan(0, 0, 30);
                /// <summary>
                /// Initializes a new instance of the <see cref = "AdvancedSettings"/> class.
                /// </summary>
                /// <param name = "dmsElement">The reference to the <see cref = "DmsElement"/> instance this object is part of.</param>
                internal AdvancedSettings(Skyline.DataMiner.Library.Common.DmsElement dmsElement): base(dmsElement)
                {
                }

                /// <summary>
                /// Gets or sets a value indicating whether the element is hidden.
                /// </summary>
                /// <value><c>true</c> if the element is hidden; otherwise, <c>false</c>.</value>
                /// <exception cref = "NotSupportedException">A set operation is not supported on a derived element.</exception>
                public bool IsHidden
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return isHidden;
                    }

                    set
                    {
                        DmsElement.LoadOnDemand();
                        if (DmsElement.RedundancySettings.IsDerived)
                        {
                            throw new System.NotSupportedException("This operation is not supported on a derived element.");
                        }

                        if (isHidden != value)
                        {
                            ChangedPropertyList.Add("IsHidden");
                            isHidden = value;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets a value indicating whether the element is read-only.
                /// </summary>
                /// <value><c>true</c> if the element is read-only; otherwise, <c>false</c>.</value>
                /// <exception cref = "NotSupportedException">A set operation is not supported on a DVE or derived element.</exception>
                public bool IsReadOnly
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return isReadOnly;
                    }

                    set
                    {
                        if (DmsElement.DveSettings.IsChild || DmsElement.RedundancySettings.IsDerived)
                        {
                            throw new System.NotSupportedException("This operation is not supported on a DVE child or derived element.");
                        }

                        DmsElement.LoadOnDemand();
                        if (isReadOnly != value)
                        {
                            ChangedPropertyList.Add("IsReadOnly");
                            isReadOnly = value;
                        }
                    }
                }

                /// <summary>
                /// Gets a value indicating whether the element is running a simulation.
                /// </summary>
                /// <value><c>true</c> if the element is running a simulation; otherwise, <c>false</c>.</value>
                public bool IsSimulation
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return isSimulation;
                    }
                }

                /// <summary>
                /// Gets or sets the element timeout value.
                /// </summary>
                /// <value>The timeout value.</value>
                /// <exception cref = "ArgumentOutOfRangeException">The value specified for a set operation is not in the range of [0,120] s.</exception>
                /// <exception cref = "NotSupportedException">A set operation is not supported on a DVE or derived element.</exception>
                /// <remarks>Fractional seconds are ignored. For example, setting the timeout to a value of 3.5s results in setting it to 3s.</remarks>
                public System.TimeSpan Timeout
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return timeout;
                    }

                    set
                    {
                        if (DmsElement.DveSettings.IsChild || DmsElement.RedundancySettings.IsDerived)
                        {
                            throw new System.NotSupportedException("Setting the timeout is not supported on a DVE child or derived element.");
                        }

                        DmsElement.LoadOnDemand();
                        int timeoutInSeconds = (int)value.TotalSeconds;
                        if (timeoutInSeconds < 0 || timeoutInSeconds > 120)
                        {
                            throw new System.ArgumentOutOfRangeException("value", "The timeout value must be in the range of [0,120] s.");
                        }

                        if ((int)timeout.TotalSeconds != (int)value.TotalSeconds)
                        {
                            ChangedPropertyList.Add("Timeout");
                            timeout = value;
                        }
                    }
                }

                /// <summary>
                /// Returns the string representation of the object.
                /// </summary>
                /// <returns>String representation of the object.</returns>
                public override string ToString()
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.AppendLine("ADVANCED SETTINGS:");
                    sb.AppendLine("==========================");
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Timeout: {0}{1}", Timeout, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Hidden: {0}{1}", IsHidden, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Simulation: {0}{1}", IsSimulation, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Read-only: {0}{1}", IsReadOnly, System.Environment.NewLine);
                    return sb.ToString();
                }

                /// <summary>
                /// Loads the information to the component.
                /// </summary>
                /// <param name = "elementInfo">The element information.</param>
                internal override void Load(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    timeout = new System.TimeSpan(0, 0, 0, 0, elementInfo.ElementTimeoutTime);
                    isHidden = elementInfo.Hidden;
                    isReadOnly = elementInfo.IsReadOnly;
                    isSimulation = elementInfo.IsSimulated;
                }
            }

            /// <summary>
            ///  Represents a class containing the device details of an element.
            /// </summary>
            internal class DeviceSettings : Skyline.DataMiner.Library.Common.ElementSettings
            {
                /// <summary>
                /// The type of the element.
                /// </summary>
                private string type = System.String.Empty;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DeviceSettings"/> class.
                /// </summary>
                /// <param name = "dmsElement">The reference to the DmsElement where this object will be used in.</param>
                internal DeviceSettings(Skyline.DataMiner.Library.Common.DmsElement dmsElement): base(dmsElement)
                {
                }

                /// <summary>
                /// Gets the element type.
                /// </summary>
                internal string Type
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return type;
                    }
                }

                /// <summary>
                /// Returns the string representation of the object.
                /// </summary>
                /// <returns>String representation of the object.</returns>
                public override string ToString()
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.AppendLine("DEVICE SETTINGS:");
                    sb.AppendLine("==========================");
                    sb.AppendLine("Type: " + type);
                    return sb.ToString();
                }

                /// <summary>
                /// Loads the information to the component.
                /// </summary>
                /// <param name = "elementInfo">The element information.</param>
                internal override void Load(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    type = elementInfo.Type ?? System.String.Empty;
                }
            }

            /// <summary>
            /// Represents DVE information of an element.
            /// </summary>
            internal class DveSettings : Skyline.DataMiner.Library.Common.ElementSettings, Skyline.DataMiner.Library.Common.IDveSettings
            {
                /// <summary>
                /// Value indicating whether DVE creation is enabled.
                /// </summary>
                private bool isDveCreationEnabled = true;
                /// <summary>
                /// Value indicating whether this element is a parent DVE.
                /// </summary>
                private bool isParent;
                /// <summary>
                /// The parent element.
                /// </summary>
                private Skyline.DataMiner.Library.Common.IDmsElement parent;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DveSettings"/> class.
                /// </summary>
                /// <param name = "dmsElement">The reference to the DmsElement where this object will be used in.</param>
                internal DveSettings(Skyline.DataMiner.Library.Common.DmsElement dmsElement): base(dmsElement)
                {
                }

                /// <summary>
                /// Gets a value indicating whether this element is a DVE child.
                /// </summary>
                /// <value><c>true</c> if this element is a DVE child element; otherwise, <c>false</c>.</value>
                public bool IsChild
                {
                    get
                    {
                        return parent != null;
                    }
                }

                /// <summary>
                /// Gets or sets a value indicating whether DVE creation is enabled for this element.
                /// </summary>
                /// <value><c>true</c> if the element DVE generation is enabled; otherwise, <c>false</c>.</value>
                /// <exception cref = "NotSupportedException">The set operation is not supported: The element is not a DVE parent element.</exception>
                public bool IsDveCreationEnabled
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return isDveCreationEnabled;
                    }

                    set
                    {
                        DmsElement.LoadOnDemand();
                        if (!DmsElement.DveSettings.IsParent)
                        {
                            throw new System.NotSupportedException("This operation is only supported on DVE parent elements.");
                        }

                        if (isDveCreationEnabled != value)
                        {
                            ChangedPropertyList.Add("IsDveCreationEnabled");
                            isDveCreationEnabled = value;
                        }
                    }
                }

                /// <summary>
                /// Gets a value indicating whether this element is a DVE parent.
                /// </summary>
                /// <value><c>true</c> if the element is a DVE parent element; otherwise, <c>false</c>.</value>
                public bool IsParent
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return isParent;
                    }
                }

                /// <summary>
                /// Gets the parent element.
                /// </summary>
                /// <value>The parent element.</value>
                public Skyline.DataMiner.Library.Common.IDmsElement Parent
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return parent;
                    }
                }

                /// <summary>
                /// Returns the string representation of the object.
                /// </summary>
                /// <returns>String representation of the object.</returns>
                public override string ToString()
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.AppendLine("DVE SETTINGS:");
                    sb.AppendLine("==========================");
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "DVE creation enabled: {0}{1}", IsDveCreationEnabled, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Is parent DVE: {0}{1}", IsParent, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Is child DVE: {0}{1}", IsChild, System.Environment.NewLine);
                    if (IsChild)
                    {
                        sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Parent DataMiner agent ID/element ID: {0}{1}", parent.DmsElementId.Value, System.Environment.NewLine);
                    }

                    return sb.ToString();
                }

                /// <summary>
                /// Loads the information to the component.
                /// </summary>
                /// <param name = "elementInfo">The element information.</param>
                internal override void Load(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    if (elementInfo.IsDynamicElement && elementInfo.DveParentDmaId != 0 && elementInfo.DveParentElementId != 0)
                    {
                        parent = new Skyline.DataMiner.Library.Common.DmsElement(DmsElement.Dms, new Skyline.DataMiner.Library.Common.DmsElementId(elementInfo.DveParentDmaId, elementInfo.DveParentElementId));
                    }

                    isParent = elementInfo.IsDveMainElement;
                    isDveCreationEnabled = elementInfo.CreateDVEs;
                }
            }

            /// <summary>
            /// Represents a class containing the failover settings for an element.
            /// </summary>
            internal class FailoverSettings : Skyline.DataMiner.Library.Common.ElementSettings, Skyline.DataMiner.Library.Common.IFailoverSettings
            {
                /// <summary>
                /// In failover configurations, this can be used to force an element to run only on one specific agent.
                /// </summary>
                private string forceAgent = System.String.Empty;
                /// <summary>
                /// Is true when the element is a failover element and is online on the backup agent instead of this agent; otherwise, false.
                /// </summary>
                private bool isOnlineOnBackupAgent;
                /// <summary>
                /// Is true when the element is a failover element that needs to keep running on the same DataMiner agent event after switching; otherwise, false.
                /// </summary>
                private bool keepOnline;
                /// <summary>
                /// Initializes a new instance of the <see cref = "FailoverSettings"/> class.
                /// </summary>
                /// <param name = "dmsElement">The reference to the DmsElement where this object will be used in.</param>
                internal FailoverSettings(Skyline.DataMiner.Library.Common.DmsElement dmsElement): base(dmsElement)
                {
                }

                /// <summary>
                /// Gets or sets a value indicating whether to force agent.
                /// Local IP address of the agent which will be running the element.
                /// </summary>
                /// <value>Value indicating whether to force agent.</value>
                public string ForceAgent
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return forceAgent;
                    }

                    set
                    {
                        DmsElement.LoadOnDemand();
                        var newValue = value == null ? System.String.Empty : value;
                        if (!forceAgent.Equals(newValue, System.StringComparison.Ordinal))
                        {
                            ChangedPropertyList.Add("ForceAgent");
                            forceAgent = newValue;
                        }
                    }
                }

                /// <summary>
                /// Gets a value indicating whether the element is a failover element and is online on the backup agent instead of this agent.
                /// </summary>
                /// <value><c>true</c> if the element is a failover element and is online on the backup agent instead of this agent; otherwise, <c>false</c>.</value>
                public bool IsOnlineOnBackupAgent
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return isOnlineOnBackupAgent;
                    }
                }

                /// <summary>
                /// Gets or sets a value indicating whether the element is a failover element that needs to keep running on the same DataMiner agent event after switching.
                /// keepOnline="true" indicates that the element needs to keep running even when the agent is offline.
                /// </summary>
                /// <value><c>true</c> if the element is a failover element that needs to keep running on the same DataMiner agent event after switching; otherwise, <c>false</c>.</value>
                public bool KeepOnline
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return keepOnline;
                    }

                    set
                    {
                        DmsElement.LoadOnDemand();
                        if (keepOnline != value)
                        {
                            ChangedPropertyList.Add("KeepOnline");
                            keepOnline = value;
                        }
                    }
                }

                /// <summary>
                /// Returns the string representation of the object.
                /// </summary>
                /// <returns>String representation of the object.</returns>
                public override string ToString()
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.AppendLine("FAILOVER SETTINGS:");
                    sb.AppendLine("==========================");
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Keep online: {0}{1}", KeepOnline, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Force agent: {0}{1}", ForceAgent, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Online on backup agent: {0}{1}", IsOnlineOnBackupAgent, System.Environment.NewLine);
                    return sb.ToString();
                }

                /// <summary>
                /// Loads the information to the component.
                /// </summary>
                /// <param name = "elementInfo">The element information.</param>
                internal override void Load(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    keepOnline = elementInfo.KeepOnline;
                    forceAgent = elementInfo.ForceAgent ?? System.String.Empty;
                    isOnlineOnBackupAgent = elementInfo.IsOnlineOnBackupAgent;
                }
            }

            /// <summary>
            /// Represents general element information.
            /// </summary>
            internal class GeneralSettings : Skyline.DataMiner.Library.Common.ElementSettings
            {
                /// <summary>
                /// The name of the alarm template.
                /// </summary>
                private string alarmTemplateName;
                /// <summary>
                /// The SLNet call that will retrieve the alarm template from the system if needed.
                /// </summary>
                private System.Lazy<Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate> alarmTemplateLoader;
                /// <summary>
                /// The alarm template assigned to this element.
                /// </summary>
                private Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate alarmTemplate;
                /// <summary>
                /// Element description.
                /// </summary>
                private string description = System.String.Empty;
                /// <summary>
                /// The hosting DataMiner agent.
                /// </summary>
                private Skyline.DataMiner.Library.Common.Dma host;
                /// <summary>
                /// The element state.
                /// </summary>
                private Skyline.DataMiner.Library.Common.ElementState state = Skyline.DataMiner.Library.Common.ElementState.Active;
                /// <summary>
                /// Instance of the protocol this element executes.
                /// </summary>
                private Skyline.DataMiner.Library.Common.DmsProtocol protocol;
                /// <summary>
                /// The trend template assigned to this element.
                /// </summary>
                private Skyline.DataMiner.Library.Common.Templates.IDmsTrendTemplate trendTemplate;
                /// <summary>
                /// The name of the element.
                /// </summary>
                private string name;
                /// <summary>
                /// Initializes a new instance of the <see cref = "GeneralSettings"/> class.
                /// </summary>
                /// <param name = "dmsElement">The reference to the DmsElement where this object will be used in.</param>
                internal GeneralSettings(Skyline.DataMiner.Library.Common.DmsElement dmsElement): base(dmsElement)
                {
                }

                /// <summary>
                /// Gets or sets the alarm template definition of the element.
                /// This can either be an alarm template or an alarm template group.
                /// </summary>
                internal Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate AlarmTemplate
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        if (!alarmTemplateLoader.IsValueCreated)
                        {
                            alarmTemplate = alarmTemplateLoader.Value;
                        }

                        return alarmTemplate;
                    }

                    set
                    {
                        DmsElement.LoadOnDemand();
                        string newAlarmTemplateName = value == null ? System.String.Empty : value.Name;
                        bool isCurrentEmpty = System.String.IsNullOrWhiteSpace(alarmTemplateName);
                        bool isNewEmpty = System.String.IsNullOrWhiteSpace(newAlarmTemplateName);
                        bool updateRequired = isCurrentEmpty ? !isNewEmpty : !alarmTemplateName.Equals(newAlarmTemplateName, System.StringComparison.OrdinalIgnoreCase);
                        if (updateRequired)
                        {
                            ChangedPropertyList.Add("AlarmTemplate");
                            alarmTemplateName = newAlarmTemplateName;
                            alarmTemplateLoader = new System.Lazy<Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate>(() => value);
                            alarmTemplate = alarmTemplateLoader.Value;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets the element description.
                /// </summary>
                internal string Description
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return description;
                    }

                    set
                    {
                        DmsElement.LoadOnDemand();
                        string newValue = value == null ? System.String.Empty : value;
                        if (!description.Equals(newValue, System.StringComparison.Ordinal))
                        {
                            ChangedPropertyList.Add("Description");
                            description = newValue;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets the system-wide element ID.
                /// </summary>
                internal Skyline.DataMiner.Library.Common.DmsElementId DmsElementId
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets the DataMiner agent that hosts the element.
                /// </summary>
                internal Skyline.DataMiner.Library.Common.Dma Host
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return host;
                    }
                }

                /// <summary>
                /// Gets or sets the state of the element.
                /// </summary>
                internal Skyline.DataMiner.Library.Common.ElementState State
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return state;
                    }

                    set
                    {
                        DmsElement.LoadOnDemand();
                        state = value;
                    }
                }

                /// <summary>
                /// Gets or sets the trend template assigned to this element.
                /// </summary>
                internal Skyline.DataMiner.Library.Common.Templates.IDmsTrendTemplate TrendTemplate
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return trendTemplate;
                    }

                    set
                    {
                        DmsElement.LoadOnDemand();
                        bool updateRequired = false;
                        if (trendTemplate == null)
                        {
                            if (value != null)
                            {
                                updateRequired = true;
                            }
                        }
                        else
                        {
                            if (value == null || !trendTemplate.Equals(value))
                            {
                                updateRequired = true;
                            }
                        }

                        if (updateRequired)
                        {
                            ChangedPropertyList.Add("TrendTemplate");
                            trendTemplate = value;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets the name of the element.
                /// </summary>
                /// <exception cref = "NotSupportedException">A set operation is not supported on a DVE child or a derived element.</exception>
                internal string Name
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return name;
                    }

                    set
                    {
                        DmsElement.LoadOnDemand();
                        if (DmsElement.DveSettings.IsChild || DmsElement.RedundancySettings.IsDerived)
                        {
                            throw new System.NotSupportedException("Setting the name of a DVE child or a derived element is not supported.");
                        }

                        if (!name.Equals(value, System.StringComparison.Ordinal))
                        {
                            ChangedPropertyList.Add("Name");
                            name = value.Trim();
                        }
                    }
                }

                /// <summary>
                /// Gets or sets the instance of the protocol.
                /// </summary>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation is empty.</exception>
                internal Skyline.DataMiner.Library.Common.DmsProtocol Protocol
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return protocol;
                    }

                    set
                    {
                        if (value == null)
                        {
                            throw new System.ArgumentNullException("value");
                        }

                        DmsElement.LoadOnDemand();
                        ChangedPropertyList.Add("Protocol");
                        protocol = value;
                    }
                }

                /// <summary>
                /// Returns the string representation of the object.
                /// </summary>
                /// <returns>String representation of the object.</returns>
                public override string ToString()
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.AppendLine("GENERAL SETTINGS:");
                    sb.AppendLine("==========================");
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Name: {0}{1}", DmsElement.Name, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Description: {0}{1}", Description, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Protocol name: {0}{1}", Protocol.Name, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Protocol version: {0}{1}", Protocol.Version, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "DMA ID: {0}{1}", DmsElementId.AgentId, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Element ID: {0}{1}", DmsElementId.ElementId, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Hosting DMA ID: {0}{1}", Host.Id, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Alarm template: {0}{1}", AlarmTemplate, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Trend template: {0}{1}", TrendTemplate, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "State: {0}{1}", State, System.Environment.NewLine);
                    return sb.ToString();
                }

                /// <summary>
                /// Loads the information to the component.
                /// </summary>
                /// <param name = "elementInfo">The element information.</param>
                internal override void Load(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    DmsElementId = new Skyline.DataMiner.Library.Common.DmsElementId(elementInfo.DataMinerID, elementInfo.ElementID);
                    description = elementInfo.Description ?? System.String.Empty;
                    protocol = new Skyline.DataMiner.Library.Common.DmsProtocol(DmsElement.Dms, elementInfo.Protocol, elementInfo.ProtocolVersion);
                    alarmTemplateName = elementInfo.ProtocolTemplate;
                    trendTemplate = System.String.IsNullOrWhiteSpace(elementInfo.Trending) ? null : new Skyline.DataMiner.Library.Common.Templates.DmsTrendTemplate(DmsElement.Dms, elementInfo.Trending, protocol);
                    state = (Skyline.DataMiner.Library.Common.ElementState)elementInfo.State;
                    name = elementInfo.Name ?? System.String.Empty;
                    host = new Skyline.DataMiner.Library.Common.Dma(DmsElement.Dms, elementInfo.HostingAgentID);
                    alarmTemplateLoader = new System.Lazy<Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate>(() => LoadAlarmTemplateDefinition());
                }

                /// <summary>
                /// Loads the alarm template definition.
                /// This method checks whether there is a group or a template assigned to the element.
                /// </summary>
                private Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate LoadAlarmTemplateDefinition()
                {
                    Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate innerAlarmTemplate = alarmTemplate; // do not use public property here as it will cause cyclic call
                    if (innerAlarmTemplate == null && !System.String.IsNullOrWhiteSpace(alarmTemplateName))
                    {
                        Skyline.DataMiner.Net.Messages.GetAlarmTemplateMessage message = new Skyline.DataMiner.Net.Messages.GetAlarmTemplateMessage{AsOneObject = true, Protocol = protocol.Name, Version = protocol.Version, Template = alarmTemplateName};
                        Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage response = (Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage)DmsElement.Dms.Communication.SendSingleResponseMessage(message);
                        if (response != null)
                        {
                            switch (response.Type)
                            {
                                case Skyline.DataMiner.Net.Messages.AlarmTemplateType.Template:
                                    innerAlarmTemplate = new Skyline.DataMiner.Library.Common.Templates.DmsStandaloneAlarmTemplate(DmsElement.Dms, response);
                                    break;
                                case Skyline.DataMiner.Net.Messages.AlarmTemplateType.Group:
                                    innerAlarmTemplate = new Skyline.DataMiner.Library.Common.Templates.DmsAlarmTemplateGroup(DmsElement.Dms, response);
                                    break;
                                default:
                                    throw new System.InvalidOperationException("Unexpected value: " + response.Type);
                            }
                        }
                    }

                    return innerAlarmTemplate;
                }
            }

            /// <summary>
            /// DataMiner element advanced settings interface.
            /// </summary>
            public interface IAdvancedSettings
            {
                /// <summary>
                /// Gets or sets a value indicating whether the element is hidden.
                /// </summary>
                /// <value><c>true</c> if the element is hidden; otherwise, <c>false</c>.</value>
                /// <exception cref = "NotSupportedException">A set operation is not supported on a derived element.</exception>
                bool IsHidden
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets a value indicating whether the element is read-only.
                /// </summary>
                /// <value><c>true</c> if the element is read-only; otherwise, <c>false</c>.</value>
                /// <exception cref = "NotSupportedException">A set operation is not supported on a DVE or derived element.</exception>
                bool IsReadOnly
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets a value indicating whether the element is running a simulation.
                /// </summary>
                /// <value><c>true</c> if the element is running a simulation; otherwise, <c>false</c>.</value>
                bool IsSimulation
                {
                    get;
                }

                /// <summary>
                /// Gets or sets the element timeout value.
                /// </summary>
                /// <value>The timeout value.</value>
                /// <exception cref = "NotSupportedException">A set operation is not supported on a DVE or derived element.</exception>
                /// <exception cref = "ArgumentOutOfRangeException">The value specified for a set operation is not in the range of [0,120] s.</exception>
                /// <remarks>Fractional seconds are ignored. For example, setting the timeout to a value of 3.5s results in setting it to 3s.</remarks>
                System.TimeSpan Timeout
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// DataMiner element DVE settings interface.
            /// </summary>
            public interface IDveSettings
            {
                /// <summary>
                /// Gets a value indicating whether this element is a DVE child.
                /// </summary>
                /// <value><c>true</c> if this element is a DVE child element; otherwise, <c>false</c>.</value>
                bool IsChild
                {
                    get;
                }

                /// <summary>
                /// Gets or sets a value indicating whether DVE creation is enabled for this element.
                /// </summary>
                /// <value><c>true</c> if the element DVE generation is enabled; otherwise, <c>false</c>.</value>
                /// <exception cref = "NotSupportedException">The element is not a DVE parent element.</exception>
                bool IsDveCreationEnabled
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets a value indicating whether this element is a DVE parent.
                /// </summary>
                /// <value><c>true</c> if the element is a DVE parent element; otherwise, <c>false</c>.</value>
                bool IsParent
                {
                    get;
                }

                /// <summary>
                /// Gets the parent element.
                /// </summary>
                /// <value>The parent element.</value>
                Skyline.DataMiner.Library.Common.IDmsElement Parent
                {
                    get;
                }
            }

            /// <summary>
            /// DataMiner element failover settings interface.
            /// </summary>
            internal interface IFailoverSettings
            {
                /// <summary>
                /// Gets or sets a value indicating whether to force agent.
                /// Local IP address of the agent which will be running the element.
                /// </summary>
                /// <value>Value indicating whether to force agent.</value>
                string ForceAgent
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets a value indicating whether the element is a failover element and is online on the backup agent instead of this agent.
                /// </summary>
                /// <value><c>true</c> if the element is a failover element and is online on the backup agent instead of this agent; otherwise, <c>false</c>.</value>
                bool IsOnlineOnBackupAgent
                {
                    get;
                }

                /// <summary>
                /// Gets or sets a value indicating whether the element is a failover element that needs to keep running on the same DataMiner agent event after switching.
                /// </summary>
                /// <value><c>true</c> if the element is a failover element that needs to keep running on the same DataMiner agent event after switching; otherwise, <c>false</c>.</value>
                bool KeepOnline
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// DataMiner element redundancy settings interface.
            /// </summary>
            public interface IRedundancySettings
            {
                /// <summary>
                /// Gets a value indicating whether the element is derived from another element.
                /// </summary>
                /// <value><c>true</c> if the element is derived from another element; otherwise, <c>false</c>.</value>
                bool IsDerived
                {
                    get;
                }
            }

            /// <summary>
            /// DataMiner element replication settings interface.
            /// </summary>
            public interface IReplicationSettings
            {
                /// <summary>
                /// Gets the domain the user belongs to.
                /// </summary>
                /// <value>The domain the user belongs to.</value>
                string Domain
                {
                    get;
                }

                ///// <summary>
                ///// Gets a value indicating whether it is allowed to perform the logic of a protocol on the replicated element instead of only showing the data received on the original element.
                ///// By Default, some functionality is not allowed on replicated elements (get, set, QAs, triggers etc.).
                ///// </summary>
                ///// <value><c>true</c> if it is allowed to perform the logic of a protocol on the replicated element; otherwise, <c>false</c>.</value>
                //bool ConnectsToExternalProbe { get; }
                /// <summary>
                /// Gets the IP address of the DataMiner Agent from which this element is replicated.
                /// </summary>
                /// <value>The IP address of the DataMiner Agent from which this element is replicated.</value>
                string IPAddressSourceAgent
                {
                    get;
                }

                /// <summary>
                /// Gets a value indicating whether this element is replicated.
                /// </summary>
                /// <value><c>true</c> if this element is replicated; otherwise, <c>false</c>.</value>
                bool IsReplicated
                {
                    get;
                }

                ///// <summary>
                ///// Gets the additional options defined when replicating the element.
                ///// </summary>
                ///// <value>The additional options defined when replicating the element.</value>
                //string Options { get; }
                /// <summary>
                /// Gets the password corresponding with the user name to log in on the source DataMiner Agent.
                /// </summary>
                /// <value>The password corresponding with the user name.</value>
                string Password
                {
                    get;
                }

                /// <summary>
                /// Gets the system-wide element ID of the source element.
                /// </summary>
                /// <value>The system-wide element ID of the source element.</value>
                Skyline.DataMiner.Library.Common.DmsElementId SourceDmsElementId
                {
                    get;
                }

                /// <summary>
                /// Gets the user name used to log in on the source DataMiner Agent.
                /// </summary>
                /// <value>The user name used to log in on the source DataMiner Agent.</value>
                string UserName
                {
                    get;
                }
            }

            /// <summary>
            /// Represents the redundancy settings for a element.
            /// </summary>
            internal class RedundancySettings : Skyline.DataMiner.Library.Common.ElementSettings, Skyline.DataMiner.Library.Common.IRedundancySettings
            {
                /// <summary>
                /// Value indicating whether or not this element is derived from another element.
                /// </summary>
                private bool isDerived;
                /// <summary>
                /// Initializes a new instance of the <see cref = "RedundancySettings"/> class.
                /// </summary>
                /// <param name = "dmsElement">The reference to the <see cref = "DmsElement"/> instance this object is part of.</param>
                internal RedundancySettings(Skyline.DataMiner.Library.Common.DmsElement dmsElement): base(dmsElement)
                {
                }

                /// <summary>
                /// Gets or sets a value indicating whether the element is derived from another element.
                /// </summary>
                /// <value><c>true</c> if the element is derived from another element; otherwise, <c>false</c>.</value>
                public bool IsDerived
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return isDerived;
                    }

                    internal set
                    {
                        isDerived = value;
                    }
                }

                /// <summary>
                /// Returns the string representation of the object.
                /// </summary>
                /// <returns>String representation of the object.</returns>
                public override string ToString()
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.AppendLine("REDUNDANCY SETTINGS:");
                    sb.AppendLine("==========================");
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Derived: {0}{1}", isDerived, System.Environment.NewLine);
                    return sb.ToString();
                }

                /// <summary>
                /// Loads the information to the component.
                /// </summary>
                /// <param name = "elementInfo">The element information.</param>
                internal override void Load(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    isDerived = elementInfo.IsDerivedElement;
                }
            }

            /// <summary>
            /// Represents the replication information of an element.
            /// </summary>
            internal class ReplicationSettings : Skyline.DataMiner.Library.Common.ElementSettings, Skyline.DataMiner.Library.Common.IReplicationSettings
            {
                /// <summary>
                /// The domain the specified user belongs to.
                /// </summary>
                private string domain = System.String.Empty;
                /// <summary>
                /// External DMP engine.
                /// </summary>
                private bool connectsToExternalDmp;
                /// <summary>
                /// IP address of the source DataMiner Agent.
                /// </summary>
                private string ipAddressSourceDma = System.String.Empty;
                /// <summary>
                /// Value indicating whether this element is replicated.
                /// </summary>
                private bool isReplicated;
                /// <summary>
                /// The options string.
                /// </summary>
                private string options = System.String.Empty;
                /// <summary>
                /// The password.
                /// </summary>
                private string password = System.String.Empty;
                /// <summary>
                /// The ID of the source element.
                /// </summary>
                private Skyline.DataMiner.Library.Common.DmsElementId sourceDmsElementId = new Skyline.DataMiner.Library.Common.DmsElementId(-1, -1);
                /// <summary>
                /// The user name.
                /// </summary>
                private string userName = System.String.Empty;
                /// <summary>
                /// Initializes a new instance of the <see cref = "ReplicationSettings"/> class.
                /// </summary>
                /// <param name = "dmsElement">The reference to the DmsElement where this object will be used in.</param>
                internal ReplicationSettings(Skyline.DataMiner.Library.Common.DmsElement dmsElement): base(dmsElement)
                {
                }

                /// <summary>
                /// Gets the domain the user belongs to.
                /// </summary>
                /// <value>The domain the user belongs to.</value>
                public string Domain
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return domain;
                    }

                    internal set
                    {
                        domain = value;
                    }
                }

                /// <summary>
                /// Gets a value indicating whether it is allowed to perform logic of a protocol on the replicated element instead of only showing the data received on the original element.
                /// By Default, some functionality is not allowed on replicated elements (get, set, QAs, triggers etc.).
                /// </summary>
                /// <value><c>true</c> if it is allowed to perform the logic of a protocol on the replicated element; otherwise, <c>false</c>.</value>
                public bool ConnectsToExternalProbe
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return connectsToExternalDmp;
                    }
                }

                /// <summary>
                /// Gets the IP address of the DataMiner Agent from which this element is replicated.
                /// </summary>
                /// <value>The IP address of the DataMiner Agent from which this element is replicated</value>
                public string IPAddressSourceAgent
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return ipAddressSourceDma;
                    }

                    internal set
                    {
                        ipAddressSourceDma = value;
                    }
                }

                /// <summary>
                /// Gets a value indicating whether this element is replicated.
                /// </summary>
                /// <value><c>true</c> if this element is replicated; otherwise, <c>false</c>.</value>
                public bool IsReplicated
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return isReplicated;
                    }

                    internal set
                    {
                        isReplicated = value;
                    }
                }

                /// <summary>
                /// Gets the additional options defined when replicating the element.
                /// </summary>
                /// <value>The additional options defined when replicating the element.</value>
                public string Options
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return options;
                    }

                    internal set
                    {
                        options = value;
                    }
                }

                /// <summary>
                /// Gets the password corresponding with the user name to log in on the source DataMiner Agent.
                /// </summary>
                /// <value>The password corresponding with the user name.</value>
                public string Password
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return password;
                    }

                    internal set
                    {
                        password = value;
                    }
                }

                /// <summary>
                /// Gets the system-wide element ID of the source element.
                /// </summary>
                /// <value>The system-wide element ID of the source element.</value>
                public Skyline.DataMiner.Library.Common.DmsElementId SourceDmsElementId
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return sourceDmsElementId;
                    }

                    internal set
                    {
                        sourceDmsElementId = value;
                    }
                }

                /// <summary>
                /// Gets the user name used to log in on the source DataMiner Agent.
                /// </summary>
                /// <value>The user name used to log in on the source DataMiner Agent.</value>
                public string UserName
                {
                    get
                    {
                        DmsElement.LoadOnDemand();
                        return userName;
                    }

                    internal set
                    {
                        userName = value;
                    }
                }

                /// <summary>
                /// Returns the string representation of the object.
                /// </summary>
                /// <returns>String representation of the object.</returns>
                public override string ToString()
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.AppendLine("REPLICATION SETTINGS:");
                    sb.AppendLine("==========================");
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Replicated: {0}{1}", isReplicated, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Source DMA ID: {0}{1}", sourceDmsElementId.AgentId, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Source element ID: {0}{1}", sourceDmsElementId.ElementId, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "IP address source DMA: {0}{1}", ipAddressSourceDma, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Domain: {0}{1}", domain, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "User name: {0}{1}", userName, System.Environment.NewLine);
                    sb.AppendFormat(System.Globalization.CultureInfo.InvariantCulture, "Password: {0}{1}", password, System.Environment.NewLine);
                    //sb.AppendFormat(CultureInfo.InvariantCulture, "Options: {0}{1}", options, Environment.NewLine);
                    //sb.AppendFormat(CultureInfo.InvariantCulture, "Replication DMP engine: {0}{1}", connectsToExternalDmp, Environment.NewLine);
                    return sb.ToString();
                }

                /// <summary>
                /// Loads the information to the component.
                /// </summary>
                /// <param name = "elementInfo">The element information.</param>
                internal override void Load(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo)
                {
                    isReplicated = elementInfo.ReplicationActive;
                    if (!isReplicated)
                    {
                        options = System.String.Empty;
                        ipAddressSourceDma = System.String.Empty;
                        password = System.String.Empty;
                        domain = System.String.Empty;
                        sourceDmsElementId = new Skyline.DataMiner.Library.Common.DmsElementId(-1, -1);
                        userName = System.String.Empty;
                        connectsToExternalDmp = false;
                    }

                    options = elementInfo.ReplicationOptions ?? System.String.Empty;
                    ipAddressSourceDma = elementInfo.ReplicationDmaIP ?? System.String.Empty;
                    password = elementInfo.ReplicationPwd ?? System.String.Empty;
                    domain = elementInfo.ReplicationDomain ?? System.String.Empty;
                    bool isEmpty = System.String.IsNullOrWhiteSpace(elementInfo.ReplicationRemoteElement) || elementInfo.ReplicationRemoteElement.Equals("/", System.StringComparison.Ordinal);
                    if (isEmpty)
                    {
                        sourceDmsElementId = new Skyline.DataMiner.Library.Common.DmsElementId(-1, -1);
                    }
                    else
                    {
                        try
                        {
                            sourceDmsElementId = new Skyline.DataMiner.Library.Common.DmsElementId(elementInfo.ReplicationRemoteElement);
                        }
                        catch (System.Exception ex)
                        {
                            string logMessage = "Failed parsing replication element info for element " + System.Convert.ToString(elementInfo.Name) + " (" + System.Convert.ToString(elementInfo.DataMinerID) + "/" + System.Convert.ToString(elementInfo.ElementID) + "). Replication remote element is: " + System.Convert.ToString(elementInfo.ReplicationRemoteElement) + System.Environment.NewLine + ex;
                            Skyline.DataMiner.Library.Common.Logger.Log(logMessage);
                            sourceDmsElementId = new Skyline.DataMiner.Library.Common.DmsElementId(-1, -1);
                        }
                    }

                    userName = elementInfo.ReplicationUser ?? System.String.Empty;
                    connectsToExternalDmp = elementInfo.ReplicationIsExternalDMP;
                }
            }

            /// <summary>
            /// Represents a base class for all of the components in a DmsElement object.
            /// </summary>
            internal abstract class ElementSettings
            {
                /// <summary>
                /// The list of changed properties.
                /// </summary>
                private readonly System.Collections.Generic.List<System.String> changedPropertyList = new System.Collections.Generic.List<System.String>();
                /// <summary>
                /// Instance of the DmsElement class where these classes will be used for.
                /// </summary>
                private readonly Skyline.DataMiner.Library.Common.DmsElement dmsElement;
                /// <summary>
                /// Initializes a new instance of the <see cref = "ElementSettings"/> class.
                /// </summary>
                /// <param name = "dmsElement">The reference to the <see cref = "DmsElement"/> instance this object is part of.</param>
                protected ElementSettings(Skyline.DataMiner.Library.Common.DmsElement dmsElement)
                {
                    this.dmsElement = dmsElement;
                }

                /// <summary>
                /// Gets the element this object belongs to.
                /// </summary>
                internal Skyline.DataMiner.Library.Common.DmsElement DmsElement
                {
                    get
                    {
                        return dmsElement;
                    }
                }

                /// <summary>
                /// Gets the list of updated properties.
                /// </summary>
                protected internal System.Collections.Generic.List<System.String> ChangedPropertyList
                {
                    get
                    {
                        return changedPropertyList;
                    }
                }

                /// <summary>
                /// Based on the array provided from the DmsNotify call, parse the data to the correct fields.
                /// </summary>
                /// <param name = "elementInfo">Object containing all the required information. Retrieved by DmsClass.</param>
                internal abstract void Load(Skyline.DataMiner.Net.Messages.ElementInfoEventMessage elementInfo);
            }

            /// <summary>
            /// Represents a DataMiner protocol.
            /// </summary>
            internal class DmsProtocol : Skyline.DataMiner.Library.Common.DmsObject, Skyline.DataMiner.Library.Common.IDmsProtocol
            {
                /// <summary>
                /// The constant value 'Production'.
                /// </summary>
                private const string Production = "Production";
                /// <summary>
                /// The protocol name.
                /// </summary>
                private string name;
                /// <summary>
                /// The protocol version.
                /// </summary>
                private string version;
                /// <summary>
                /// The type of the protocol.
                /// </summary>
                private Skyline.DataMiner.Library.Common.ProtocolType type;
                /// <summary>
                /// The protocol referenced version.
                /// </summary>
                private string referencedVersion;
                /// <summary>
                /// Whether the version is 'Production'.
                /// </summary>
                private bool isProduction;
                /// <summary>
                /// The connection info of the protocol.
                /// </summary>
                private System.Collections.Generic.IList<Skyline.DataMiner.Library.Common.IDmsConnectionInfo> connectionInfo = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.IDmsConnectionInfo>();
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsProtocol"/> class.
                /// </summary>
                /// <param name = "dms">The DataMiner System.</param>
                /// <param name = "name">The protocol name.</param>
                /// <param name = "version">The protocol version.</param>
                /// <param name = "type">The type of the protocol.</param>
                /// <param name = "referencedVersion">The protocol referenced version.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentNullException"><paramref name = "name"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentNullException"><paramref name = "version"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "name"/> is the empty string ("") or white space.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "version"/> is the empty string ("") or white space.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "version"/> is not 'Production' and <paramref name = "referencedVersion"/> is not the empty string ("") or white space.</exception>
                internal DmsProtocol(Skyline.DataMiner.Library.Common.IDms dms, string name, string version, Skyline.DataMiner.Library.Common.ProtocolType type = Skyline.DataMiner.Library.Common.ProtocolType.Undefined, string referencedVersion = ""): base(dms)
                {
                    if (name == null)
                    {
                        throw new System.ArgumentNullException("name");
                    }

                    if (version == null)
                    {
                        throw new System.ArgumentNullException("version");
                    }

                    if (System.String.IsNullOrWhiteSpace(name))
                    {
                        throw new System.ArgumentException("The name of the protocol is the empty string (\"\") or white space.", "name");
                    }

                    if (System.String.IsNullOrWhiteSpace(version))
                    {
                        throw new System.ArgumentException("The version of the protocol is the empty string (\"\") or white space.", "version");
                    }

                    this.name = name;
                    this.version = version;
                    this.type = type;
                    this.isProduction = CheckIsProduction(this.version);
                    if (!this.isProduction && !System.String.IsNullOrWhiteSpace(referencedVersion))
                    {
                        throw new System.ArgumentException("The version of the protocol is not referenced version of the protocol is not the empty string (\"\") or white space.", "referencedVersion");
                    }

                    this.referencedVersion = referencedVersion;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsProtocol"/> class.
                /// </summary>
                /// <param name = "dms">The DataMiner system.</param>
                /// <param name = "infoMessage">The information message received from SLNet.</param>
                /// <param name = "requestedProduction">The version requested to SLNet.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "infoMessage"/> is <see langword = "null"/>.</exception>
                internal DmsProtocol(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.GetProtocolInfoResponseMessage infoMessage, bool requestedProduction): base(dms)
                {
                    if (infoMessage == null)
                    {
                        throw new System.ArgumentNullException("infoMessage");
                    }

                    this.isProduction = requestedProduction;
                    Parse(infoMessage);
                }

                /// <summary>
                /// Gets the connection information.
                /// </summary>
                /// <value>The connection information.</value>
                public System.Collections.Generic.IList<Skyline.DataMiner.Library.Common.IDmsConnectionInfo> ConnectionInfo
                {
                    get
                    {
                        LoadOnDemand();
                        return new System.Collections.ObjectModel.ReadOnlyCollection<Skyline.DataMiner.Library.Common.IDmsConnectionInfo>(connectionInfo);
                    }
                }

                /// <summary>
                /// Gets the protocol name.
                /// </summary>
                /// <value>The protocol name.</value>
                public string Name
                {
                    get
                    {
                        return name;
                    }
                }

                /// <summary>
                /// Gets the protocol version.
                /// </summary>
                /// <value>The protocol version.</value>
                public string Version
                {
                    get
                    {
                        return version;
                    }
                }

                public Skyline.DataMiner.Library.Common.ProtocolType Type
                {
                    get
                    {
                        return type;
                    }
                }

                /// <summary>
                /// Gets the protocol referenced version.
                /// </summary>
                /// <value>The protocol referenced version.</value>
                public string ReferencedVersion
                {
                    get
                    {
                        if (System.String.IsNullOrEmpty(referencedVersion))
                        {
                            LoadOnDemand();
                        }

                        return referencedVersion == System.String.Empty ? null : referencedVersion;
                    }
                }

                /// <summary>
                /// Gets a value indicating whether the version is 'Production'.
                /// </summary>
                /// <value>Whether the version is 'Production'.</value>
                public bool IsProduction
                {
                    get
                    {
                        return isProduction;
                    }
                }

                /// <summary>
                /// Gets the alarm template with the specified name defined for this protocol.
                /// </summary>
                /// <param name = "templateName">The name of the alarm template.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "templateName"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "templateName"/> is the empty string ("") or white space.</exception>
                /// <exception cref = "AlarmTemplateNotFoundException">No alarm template with the specified name was found.</exception>
                /// <returns>The alarm template with the specified name defined for this protocol.</returns>
                public Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate GetAlarmTemplate(string templateName)
                {
                    Skyline.DataMiner.Net.Messages.GetAlarmTemplateMessage message = new Skyline.DataMiner.Net.Messages.GetAlarmTemplateMessage{AsOneObject = true, Protocol = this.Name, Version = this.Version, Template = templateName};
                    Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage alarmTemplateEventMessage = (Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage)dms.Communication.SendSingleResponseMessage(message);
                    if (alarmTemplateEventMessage == null)
                    {
                        throw new Skyline.DataMiner.Library.Common.AlarmTemplateNotFoundException(templateName, this);
                    }

                    if (alarmTemplateEventMessage.Type == Skyline.DataMiner.Net.Messages.AlarmTemplateType.Template)
                    {
                        return new Skyline.DataMiner.Library.Common.Templates.DmsStandaloneAlarmTemplate(dms, alarmTemplateEventMessage);
                    }
                    else if (alarmTemplateEventMessage.Type == Skyline.DataMiner.Net.Messages.AlarmTemplateType.Group)
                    {
                        return new Skyline.DataMiner.Library.Common.Templates.DmsAlarmTemplateGroup(dms, alarmTemplateEventMessage);
                    }
                    else
                    {
                        throw new System.NotSupportedException("Support for " + alarmTemplateEventMessage.Type + " has not yet been implemented.");
                    }
                }

                /// <summary>
                /// Returns a string that represents the current object.
                /// </summary>
                /// <returns>A string that represents the current object.</returns>
                public override string ToString()
                {
                    return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Protocol name: {0}, version: {1}", Name, Version);
                }

                /// <summary>
                /// Validate if <paramref name = "version"/> is 'Production'.
                /// </summary>
                /// <param name = "version">The version.</param>
                /// <returns>Whether <paramref name = "version"/> is 'Production'.</returns>
                internal static bool CheckIsProduction(string version)
                {
                    return System.String.Equals(version, Production, System.StringComparison.OrdinalIgnoreCase);
                }

                /// <summary>
                /// Loads the object.
                /// </summary>
                /// <exception cref = "ProtocolNotFoundException">No protocol with the specified name and version exists in the DataMiner system.</exception>
                internal override void Load()
                {
                    isProduction = CheckIsProduction(version);
                    Skyline.DataMiner.Net.Messages.GetProtocolMessage getProtocolMessage = new Skyline.DataMiner.Net.Messages.GetProtocolMessage{Protocol = name, Version = version};
                    Skyline.DataMiner.Net.Messages.GetProtocolInfoResponseMessage protocolInfo = (Skyline.DataMiner.Net.Messages.GetProtocolInfoResponseMessage)Communication.SendSingleResponseMessage(getProtocolMessage);
                    if (protocolInfo != null)
                    {
                        Parse(protocolInfo);
                    }
                    else
                    {
                        throw new Skyline.DataMiner.Library.Common.ProtocolNotFoundException(name, version);
                    }
                }

                /// <summary>
                /// Parses the <see cref = "GetProtocolInfoResponseMessage"/> message.
                /// </summary>
                /// <param name = "protocolInfo">The protocol information.</param>
                private void Parse(Skyline.DataMiner.Net.Messages.GetProtocolInfoResponseMessage protocolInfo)
                {
                    IsLoaded = true;
                    name = protocolInfo.Name;
                    type = (Skyline.DataMiner.Library.Common.ProtocolType)protocolInfo.ProtocolType;
                    if (isProduction)
                    {
                        version = Production;
                        referencedVersion = protocolInfo.Version;
                    }
                    else
                    {
                        version = protocolInfo.Version;
                        referencedVersion = System.String.Empty;
                    }

                    ParseConnectionInfo(protocolInfo);
                }

                /// <summary>
                /// Parses the <see cref = "GetProtocolInfoResponseMessage"/> message.
                /// </summary>
                /// <param name = "protocolInfo">The protocol information.</param>
                private void ParseConnectionInfo(Skyline.DataMiner.Net.Messages.GetProtocolInfoResponseMessage protocolInfo)
                {
                    System.Collections.Generic.List<Skyline.DataMiner.Library.Common.DmsConnectionInfo> info = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.DmsConnectionInfo>();
                    info.Add(new Skyline.DataMiner.Library.Common.DmsConnectionInfo(System.String.Empty, Skyline.DataMiner.Library.Common.EnumMapper.ConvertStringToConnectionType(protocolInfo.Type)));
                    if (protocolInfo.AdvancedTypes != null && protocolInfo.AdvancedTypes.Length > 0 && !System.String.IsNullOrWhiteSpace(protocolInfo.AdvancedTypes))
                    {
                        string[] split = protocolInfo.AdvancedTypes.Split(';');
                        foreach (string part in split)
                        {
                            if (part.Contains(":"))
                            {
                                string[] connectionSplit = part.Split(':');
                                Skyline.DataMiner.Library.Common.ConnectionType connectionType = Skyline.DataMiner.Library.Common.EnumMapper.ConvertStringToConnectionType(connectionSplit[0]);
                                string connectionName = connectionSplit[1];
                                info.Add(new Skyline.DataMiner.Library.Common.DmsConnectionInfo(connectionName, connectionType));
                            }
                            else
                            {
                                Skyline.DataMiner.Library.Common.ConnectionType connectionType = Skyline.DataMiner.Library.Common.EnumMapper.ConvertStringToConnectionType(part);
                                string connectionName = System.String.Empty;
                                info.Add(new Skyline.DataMiner.Library.Common.DmsConnectionInfo(connectionName, connectionType));
                            }
                        }
                    }

                    connectionInfo = info.ToArray();
                }
            }

            /// <summary>
            /// DataMiner protocol interface.
            /// </summary>
            public interface IDmsProtocol : Skyline.DataMiner.Library.Common.IDmsObject
            {
                /// <summary>
                /// Gets the connection information.
                /// </summary>
                /// <value>The connection information.</value>
                System.Collections.Generic.IList<Skyline.DataMiner.Library.Common.IDmsConnectionInfo> ConnectionInfo
                {
                    get;
                }

                /// <summary>
                /// Gets the protocol name.
                /// </summary>
                /// <value>The protocol name.</value>
                string Name
                {
                    get;
                }

                /// <summary>
                /// Gets the protocol version.
                /// </summary>
                /// <value>The protocol version.</value>
                string Version
                {
                    get;
                }

                /// <summary>
                /// Gets the version this production protocol is based on.
                /// </summary>
                /// <value>The referenced version. This is only applicable for production protocols.</value>
                string ReferencedVersion
                {
                    get;
                }

                /// <summary>
                /// Gets the type of the protocol.
                /// </summary>
                /// <value>The type of protocol.</value>
                Skyline.DataMiner.Library.Common.ProtocolType Type
                {
                    get;
                }

                /// <summary>
                /// Gets the alarm template with the specified name defined for this protocol.
                /// </summary>
                /// <param name = "templateName">The name of the alarm template.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "templateName"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "templateName"/> is the empty string ("") or white space.</exception>
                /// <exception cref = "AlarmTemplateNotFoundException">No alarm template with the specified name was found.</exception>
                /// <returns>The alarm template with the specified name defined for this protocol.</returns>
                Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate GetAlarmTemplate(string templateName);
            }

            /// <summary>
            /// Represents the DataMiner Scheduler component.
            /// </summary>
            internal class DmsScheduler : Skyline.DataMiner.Library.Common.IDmsScheduler
            {
                private readonly Skyline.DataMiner.Library.Common.IDma myDma;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsScheduler"/> class.
                /// </summary>
                /// <param name = "agent">The agent to which this scheduler component belongs to.</param>
                public DmsScheduler(Skyline.DataMiner.Library.Common.IDma agent)
                {
                    myDma = agent;
                }
            }

            /// <summary>
            /// Represents the DataMiner Scheduler component.
            /// </summary>
            public interface IDmsScheduler
            {
            }

            /// <summary>
            /// DataMiner service interface.
            /// </summary>
            public interface IDmsService : Skyline.DataMiner.Library.Common.IDmsObject, Skyline.DataMiner.Library.Common.IUpdateable
            {
                /// <summary>
                /// Gets the advanced settings of this service.
                /// </summary>
                /// <value>The advanced settings of this service.</value>
                Skyline.DataMiner.Library.Common.IAdvancedServiceSettings AdvancedSettings
                {
                    get;
                }

                /// <summary>
                /// Gets the parameter settings of this service.
                /// </summary>
                /// <value>The parameter settings of this service.</value>
                Skyline.DataMiner.Library.Common.IServiceParamsSettings ParameterSettings
                {
                    get;
                }

                /// <summary>
                /// Gets the replication settings.
                /// </summary>
                /// <value>The replication settings.</value>
                Skyline.DataMiner.Library.Common.IReplicationServiceSettings ReplicationSettings
                {
                    get;
                }

                /// <summary>
                /// Gets the DataMiner Agent ID.
                /// </summary>
                /// <value>The DataMiner Agent ID.</value>
                int AgentId
                {
                    get;
                }

                /// <summary>
                /// Gets or sets the service description.
                /// </summary>
                /// <value>The service description.</value>
                string Description
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets the system-wide service ID of the service.
                /// </summary>
                /// <value>The system-wide service ID of the service.</value>
                Skyline.DataMiner.Library.Common.DmsServiceId DmsServiceId
                {
                    get;
                }

                /// <summary>
                /// Gets the DataMiner Agent that hosts this service.
                /// </summary>
                /// <value>The DataMiner Agent that hosts this service.</value>
                Skyline.DataMiner.Library.Common.IDma Host
                {
                    get;
                }

                /// <summary>
                /// Gets the service ID.
                /// </summary>
                /// <value>The service ID.</value>
                int Id
                {
                    get;
                }

                /// <summary>
                /// Gets or sets the service name.
                /// </summary>
                /// <value>The service name.</value>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation is empty or white space.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation exceeds 200 characters.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation contains a forbidden character.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation contains more than one '%' character.</exception>
                /// <remarks>
                /// <para>The following restrictions apply to service names:</para>
                /// <list type = "bullet">
                ///		<item><para>Names may not start or end with the following characters: '.' (dot), ' ' (space).</para></item>
                ///		<item><para>Names may not contain the following characters: '\', '/', ':', '*', '?', '"', '&lt;', '&gt;', '|', '°', ';'.</para></item>
                ///		<item><para>The following characters may not occur more than once within a name: '%' (percentage).</para></item>
                /// </list>
                /// </remarks>
                string Name
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets the properties of this service.
                /// </summary>
                /// <value>The service properties.</value>
                Skyline.DataMiner.Library.Common.IPropertyCollection<Skyline.DataMiner.Library.Common.Properties.IDmsServiceProperty, Skyline.DataMiner.Library.Common.Properties.IDmsServicePropertyDefinition> Properties
                {
                    get;
                }

                /// <summary>
                /// Gets the views the service is part of.
                /// </summary>
                /// <value>The views the service is part of.</value>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation is an empty collection.</exception>
                System.Collections.Generic.ISet<Skyline.DataMiner.Library.Common.IDmsView> Views
                {
                    get;
                }
            }

            /// <summary>
            /// DataMiner service advanced settings interface.
            /// </summary>
            public interface IAdvancedServiceSettings
            {
                /// <summary>
                /// Gets a value indicating whether the service is a service template.
                /// </summary>
                /// <value><c>true</c> if the service is a service template; otherwise, <c>false</c>.</value>
                bool IsTemplate
                {
                    get;
                }

                /// <summary>
                /// Gets the service template from which the service is generated in case the service is generated through a service template.
                /// </summary>
                Skyline.DataMiner.Library.Common.DmsServiceId? ParentTemplate
                {
                    get;
                }

                /// <summary>
                /// Gets the element that is linked to this service in case of an enhanced service.
                /// </summary>
                Skyline.DataMiner.Library.Common.DmsElementId? ServiceElement
                {
                    get;
                }

                /// <summary>
                /// Gets or sets the alarm template of the service element (enhanced service).
                /// </summary>
                Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate ServiceElementAlarmTemplate
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the trend template of the service element (enhanced service).
                /// </summary>
                Skyline.DataMiner.Library.Common.Templates.IDmsTrendTemplate ServiceElementTrendTemplate
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the protocol applied to the service element (enhanced service).
                /// </summary>
                Skyline.DataMiner.Library.Common.IDmsProtocol ServiceElementProtocol
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets a value indicating whether timeouts are being included in the service.
                /// </summary>
                bool IgnoreTimeouts
                {
                    get;
                    set;
                }
            }

            /// <summary>
            /// DataMiner service replication settings interface.
            /// </summary>
            public interface IReplicationServiceSettings
            {
                /// <summary>
                /// Gets the domain the user belongs to.
                /// </summary>
                /// <value>The domain the user belongs to.</value>
                string Domain
                {
                    get;
                }

                /// <summary>
                /// Gets the IP address of the DataMiner Agent from which this service is replicated.
                /// </summary>
                /// <value>The IP address of the DataMiner Agent from which this service is replicated.</value>
                string IPAddressSourceAgent
                {
                    get;
                }

                /// <summary>
                /// Gets a value indicating whether this service is replicated.
                /// </summary>
                /// <value><c>true</c> if this service is replicated; otherwise, <c>false</c>.</value>
                bool IsReplicated
                {
                    get;
                }

                ///// <summary>
                ///// Gets the additional options defined when replicating the service.
                ///// </summary>
                ///// <value>The additional options defined when replicating the service.</value>
                //string Options { get; }
                /// <summary>
                /// Gets the password corresponding with the user name to log in on the source DataMiner Agent.
                /// </summary>
                /// <value>The password corresponding with the user name.</value>
                string Password
                {
                    get;
                }

                /// <summary>
                /// Gets the system-wide service ID of the source service.
                /// </summary>
                /// <value>The system-wide service ID of the source service.</value>
                Skyline.DataMiner.Library.Common.DmsServiceId? SourceDmsServiceId
                {
                    get;
                }

                /// <summary>
                /// Gets the user name used to log in on the source DataMiner Agent.
                /// </summary>
                /// <value>The user name used to log in on the source DataMiner Agent.</value>
                string UserName
                {
                    get;
                }
            }

            /// <summary>
            /// DataMiner service advanced settings interface.
            /// </summary>
            public interface IServiceParamsSettings
            {
                /// <summary>
                /// Gets the included parameters.
                /// </summary>
                Skyline.DataMiner.Library.Common.ServiceParamSettings[] IncludedParameters
                {
                    get;
                }
            }

            /// <summary>
            /// Represents a base class for all of the components in a DmsService object.
            /// </summary>
            public class ServiceParamFilterSettings
            {
                private readonly Skyline.DataMiner.Net.Messages.ServiceParamFilter serviceParamFilter;
                internal ServiceParamFilterSettings(Skyline.DataMiner.Net.Messages.ServiceParamFilter serviceParamFilter)
                {
                    this.serviceParamFilter = serviceParamFilter;
                }

                /// <summary>
                /// Gets the filter for the parameter.
                /// </summary>
                public string Filter
                {
                    get
                    {
                        return serviceParamFilter.Filter;
                    }
                }

                /// <summary>
                /// Gets the filter value for the parameter.
                /// </summary>
                public string FilterValue
                {
                    get
                    {
                        return serviceParamFilter.FilterValue;
                    }
                }

                /// <summary>
                /// Gets the filter type for the parameter.
                /// </summary>
                public Skyline.DataMiner.Library.Common.FilterType FilterType
                {
                    get
                    {
                        return (Skyline.DataMiner.Library.Common.FilterType)serviceParamFilter.FilterType;
                    }
                }

                /// <summary>
                /// Gets a value indicating whether the parameter is included.
                /// </summary>
                public bool IsIncluded
                {
                    get
                    {
                        return serviceParamFilter.IsIncluded;
                    }
                }

                /// <summary>
                /// Gets the matrix port for the parameter.
                /// </summary>
                public int MatrixPort
                {
                    get
                    {
                        return serviceParamFilter.MatrixPort;
                    }
                }

                /// <summary>
                /// Gets the ID of the parameter.
                /// </summary>
                public int ParameterID
                {
                    get
                    {
                        return serviceParamFilter.ParameterID;
                    }
                }

                internal static Skyline.DataMiner.Library.Common.ServiceParamFilterSettings[] GetParamFilters(Skyline.DataMiner.Net.Messages.ServiceInfoParams serviceParams)
                {
                    System.Collections.Generic.List<Skyline.DataMiner.Library.Common.ServiceParamFilterSettings> lParamFilters = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.ServiceParamFilterSettings>();
                    foreach (Skyline.DataMiner.Net.Messages.ServiceParamFilter paramFilter in serviceParams.ParameterFilters)
                    {
                        lParamFilters.Add(new Skyline.DataMiner.Library.Common.ServiceParamFilterSettings(paramFilter));
                    }

                    return lParamFilters.ToArray();
                }
            }

            /// <summary>
            /// Represents a base class for all of the components in a DmsService object.
            /// </summary>
            public class ServiceParamSettings
            {
                private readonly Skyline.DataMiner.Net.Messages.ServiceInfoParams includedElement;
                private Skyline.DataMiner.Library.Common.ServiceParamFilterSettings[] serviceParamFilters;
                private bool isLoaded;
                internal ServiceParamSettings(Skyline.DataMiner.Net.Messages.ServiceInfoParams infoParams)
                {
                    includedElement = infoParams;
                }

                /// <summary>
                /// Gets the Alias of the element.
                /// </summary>
                public string Alias
                {
                    get
                    {
                        return includedElement.Alias;
                    }
                }

                /// <summary>
                /// Gets the DataMiner ID of the element.
                /// </summary>
                public int DataMinerID
                {
                    get
                    {
                        return includedElement.DataMinerID;
                    }
                }

                /// <summary>
                /// Gets the element ID of the element.
                /// </summary>
                public int ElementID
                {
                    get
                    {
                        return includedElement.ElementID;
                    }
                }

                /// <summary>
                /// Gets the group ID to which the element belongs.
                /// </summary>
                public int GroupID
                {
                    get
                    {
                        return includedElement.GroupID;
                    }
                }

                /// <summary>
                /// Gets the included capped alarm level of the element.
                /// </summary>
                public Skyline.DataMiner.Library.Common.AlarmLevel IncludedCapped
                {
                    get
                    {
                        return (Skyline.DataMiner.Library.Common.AlarmLevel)System.Enum.Parse(typeof(Skyline.DataMiner.Library.Common.AlarmLevel), includedElement.IncludedCapped, true);
                    }
                }

                /// <summary>
                /// Gets the index of the element.
                /// </summary>
                public int Index
                {
                    get
                    {
                        return includedElement.Index;
                    }
                }

                /// <summary>
                /// Gets a value indicating whether the element is excluded.
                /// </summary>
                public bool IsExcluded
                {
                    get
                    {
                        return includedElement.IsExcluded;
                    }
                }

                /// <summary>
                /// Gets a value indicating whether the element is a service.
                /// </summary>
                public bool IsService
                {
                    get
                    {
                        return includedElement.IsService;
                    }
                }

                /// <summary>
                /// Gets the not used capped alarm level of the element.
                /// </summary>
                public Skyline.DataMiner.Library.Common.AlarmLevel NotUsedCapped
                {
                    get
                    {
                        return (Skyline.DataMiner.Library.Common.AlarmLevel)System.Enum.Parse(typeof(Skyline.DataMiner.Library.Common.AlarmLevel), includedElement.NotUsedCapped, true);
                    }
                }

                /// <summary>
                /// Gets the parameter filters for the included element.
                /// </summary>
                public Skyline.DataMiner.Library.Common.ServiceParamFilterSettings[] ParameterFilters
                {
                    get
                    {
                        if (!isLoaded)
                        {
                            LoadOnDemand();
                        }

                        return serviceParamFilters;
                    }
                }

                private void LoadOnDemand()
                {
                    isLoaded = true;
                    serviceParamFilters = Skyline.DataMiner.Library.Common.ServiceParamFilterSettings.GetParamFilters(includedElement);
                }
            }

            /// <summary>
            /// Represents the spectrum analyzer component of an element.
            /// </summary>
            internal class DmsSpectrumAnalyzer : Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzer
            {
                private readonly Skyline.DataMiner.Library.Common.IDmsElement element;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsSpectrumAnalyzer"/> class.
                /// </summary>
                /// <param name = "element">The element this spectrum analyzer is part of.</param>
                public DmsSpectrumAnalyzer(Skyline.DataMiner.Library.Common.IDmsElement element)
                {
                    this.element = element;
                    Monitors = new Skyline.DataMiner.Library.Common.DmsSpectrumAnalyzerMonitors(element);
                    Presets = new Skyline.DataMiner.Library.Common.DmsSpectrumAnalyzerPresets(element);
                    Scripts = new Skyline.DataMiner.Library.Common.DmsSpectrumAnalyzerScripts(element);
                }

                /// <summary>
                /// Manipulate the spectrum monitors.
                /// </summary>
                public Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzerMonitors Monitors
                {
                    get;
                    private set;
                }

                /// <summary>
                /// Manipulate the spectrum presets.
                /// </summary>
                public Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzerPresets Presets
                {
                    get;
                    private set;
                }

                /// <summary>
                /// Manipulate the spectrum scripts.
                /// </summary>
                public Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzerScripts Scripts
                {
                    get;
                    private set;
                }
            }

            /// <summary>
            /// Represents the spectrum analyzer monitors.
            /// </summary>
            internal class DmsSpectrumAnalyzerMonitors : Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzerMonitors
            {
                private readonly Skyline.DataMiner.Library.Common.IDmsElement element;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsSpectrumAnalyzerMonitors"/> class.
                /// </summary>
                /// <param name = "element">The element to which this spectrum analyzer component is part of.</param>
                public DmsSpectrumAnalyzerMonitors(Skyline.DataMiner.Library.Common.IDmsElement element)
                {
                    this.element = element;
                }
            }

            /// <summary>
            /// Represents spectrum analyzer presets.
            /// </summary>
            internal class DmsSpectrumAnalyzerPresets : Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzerPresets
            {
                private readonly Skyline.DataMiner.Library.Common.IDmsElement element;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsSpectrumAnalyzerPresets"/> class.
                /// </summary>
                /// <param name = "element">The element to which this spectrum analyzer component belongs.</param>
                public DmsSpectrumAnalyzerPresets(Skyline.DataMiner.Library.Common.IDmsElement element)
                {
                    this.element = element;
                }
            }

            /// <summary>
            /// Represents spectrum analyzer scripts.
            /// </summary>
            internal class DmsSpectrumAnalyzerScripts : Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzerScripts
            {
                private readonly Skyline.DataMiner.Library.Common.IDmsElement element;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsSpectrumAnalyzerScripts"/> class.
                /// </summary>
                /// <param name = "element">The element this spectrum analyzer component is part of.</param>
                public DmsSpectrumAnalyzerScripts(Skyline.DataMiner.Library.Common.IDmsElement element)
                {
                    this.element = element;
                }
            }

            /// <summary>
            /// Represents the spectrum analyzer component of an element.
            /// </summary>
            public interface IDmsSpectrumAnalyzer
            {
                /// <summary>
                /// Gets the spectrum analyzer monitors.
                /// </summary>
                /// <value>The spectrum analyzer monitors.</value>
                Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzerMonitors Monitors
                {
                    get;
                }

                /// <summary>
                /// Gets the spectrum analyzer presets.
                /// </summary>
                /// <value>The spectrum analyzer presets.</value>
                Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzerPresets Presets
                {
                    get;
                }

                /// <summary>
                /// Gets the spectrum analyzer scripts.
                /// </summary>
                /// <value>The spectrum analyzer scripts.</value>
                Skyline.DataMiner.Library.Common.IDmsSpectrumAnalyzerScripts Scripts
                {
                    get;
                }
            }

            /// <summary>
            /// Represents the spectrum analyzer monitors.
            /// </summary>
            public interface IDmsSpectrumAnalyzerMonitors
            {
            }

            /// <summary>
            /// Represents the spectrum analyzer presets.
            /// </summary>
            public interface IDmsSpectrumAnalyzerPresets
            {
            }

            /// <summary>
            ///  Represents spectrum analyzer scripts.
            /// </summary>
            public interface IDmsSpectrumAnalyzerScripts
            {
            }

            namespace Templates
            {
                /// <summary>
                /// Base class for standalone alarm templates and alarm template groups.
                /// </summary>
                internal abstract class DmsAlarmTemplate : Skyline.DataMiner.Library.Common.Templates.DmsTemplate, Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate
                {
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsAlarmTemplate"/> class.
                    /// </summary>
                    /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                    /// <param name = "name">The name of the alarm template.</param>
                    /// <param name = "protocol">Instance of the protocol.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "name"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "protocol"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "name"/> is the empty string ("") or white space.</exception>
                    protected DmsAlarmTemplate(Skyline.DataMiner.Library.Common.IDms dms, string name, Skyline.DataMiner.Library.Common.IDmsProtocol protocol): base(dms, name, protocol)
                    {
                    }

                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsAlarmTemplate"/> class.
                    /// </summary>
                    /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                    /// <param name = "name">The name of the alarm template.</param>
                    /// <param name = "protocolName">The name of the protocol.</param>
                    /// <param name = "protocolVersion">The version of the protocol.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "name"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "protocolName"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "protocolVersion"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "name"/> is the empty string ("") or white space.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "protocolName"/> is the empty string ("") or white space.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "protocolVersion"/> is the empty string ("") or white space.</exception>
                    protected DmsAlarmTemplate(Skyline.DataMiner.Library.Common.IDms dms, string name, string protocolName, string protocolVersion): base(dms, name, protocolName, protocolVersion)
                    {
                    }

                    /// <summary>
                    /// Loads all the data and properties found related to the alarm template.
                    /// </summary>
                    /// <exception cref = "TemplateNotFoundException">The template does not exist in the DataMiner system.</exception>
                    internal override void Load()
                    {
                        Skyline.DataMiner.Net.Messages.GetAlarmTemplateMessage message = new Skyline.DataMiner.Net.Messages.GetAlarmTemplateMessage{AsOneObject = true, Protocol = Protocol.Name, Version = Protocol.Version, Template = Name};
                        Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage response = (Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage)Dms.Communication.SendSingleResponseMessage(message);
                        if (response != null)
                        {
                            Parse(response);
                        }
                        else
                        {
                            throw new Skyline.DataMiner.Library.Common.TemplateNotFoundException(Name, Protocol.Name, Protocol.Version);
                        }
                    }

                    /// <summary>
                    /// Parses the alarm template event message.
                    /// </summary>
                    /// <param name = "message">The message received from SLNet.</param>
                    internal abstract void Parse(Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage message);
                }

                /// <summary>
                /// Represents an alarm template group.
                /// </summary>
                internal class DmsAlarmTemplateGroup : Skyline.DataMiner.Library.Common.Templates.DmsAlarmTemplate, Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplateGroup
                {
                    /// <summary>
                    /// The entries of the alarm group.
                    /// </summary>
                    private readonly System.Collections.Generic.List<Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplateGroupEntry> entries = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplateGroupEntry>();
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsAlarmTemplateGroup"/> class.
                    /// </summary>
                    /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                    /// <param name = "name">The name of the alarm template.</param>
                    /// <param name = "protocol">The protocol this alarm template group corresponds with.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "name"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "protocol"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "name"/> is the empty string ("") or white space.</exception>
                    internal DmsAlarmTemplateGroup(Skyline.DataMiner.Library.Common.IDms dms, string name, Skyline.DataMiner.Library.Common.IDmsProtocol protocol): base(dms, name, protocol)
                    {
                        IsLoaded = false;
                    }

                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsAlarmTemplateGroup"/> class.
                    /// </summary>
                    /// <param name = "dms">Instance of <see cref = "Dms"/>.</param>
                    /// <param name = "alarmTemplateEventMessage">An instance of AlarmTemplateEventMessage.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "alarmTemplateEventMessage"/> is invalid.</exception>
                    internal DmsAlarmTemplateGroup(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage alarmTemplateEventMessage): base(dms, alarmTemplateEventMessage.Name, alarmTemplateEventMessage.Protocol, alarmTemplateEventMessage.Version)
                    {
                        IsLoaded = true;
                        foreach (Skyline.DataMiner.Net.Messages.AlarmTemplateGroupEntry entry in alarmTemplateEventMessage.GroupEntries)
                        {
                            Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate template = Protocol.GetAlarmTemplate(entry.Name);
                            entries.Add(new Skyline.DataMiner.Library.Common.Templates.DmsAlarmTemplateGroupEntry(template, entry.IsEnabled, entry.IsScheduled));
                        }
                    }

                    /// <summary>
                    /// Gets the entries of the alarm template group.
                    /// </summary>
                    public System.Collections.ObjectModel.ReadOnlyCollection<Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplateGroupEntry> Entries
                    {
                        get
                        {
                            LoadOnDemand();
                            return entries.AsReadOnly();
                        }
                    }

                    /// <summary>
                    /// Returns a string that represents the current object.
                    /// </summary>
                    /// <returns>A string that represents the current object.</returns>
                    public override string ToString()
                    {
                        return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Template Group Name: {0}, Protocol Name: {1}, Protocol Version: {2}", Name, Protocol.Name, Protocol.Version);
                    }

                    /// <summary>
                    /// Parses the alarm template event message.
                    /// </summary>
                    /// <param name = "message">The message received from the SLNet process.</param>
                    internal override void Parse(Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage message)
                    {
                        IsLoaded = true;
                        entries.Clear();
                        foreach (Skyline.DataMiner.Net.Messages.AlarmTemplateGroupEntry entry in message.GroupEntries)
                        {
                            Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate template = Protocol.GetAlarmTemplate(entry.Name);
                            entries.Add(new Skyline.DataMiner.Library.Common.Templates.DmsAlarmTemplateGroupEntry(template, entry.IsEnabled, entry.IsScheduled));
                        }
                    }
                }

                /// <summary>
                /// Represents an alarm group entry.
                /// </summary>
                internal class DmsAlarmTemplateGroupEntry : Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplateGroupEntry
                {
                    /// <summary>
                    /// The template which is an entry of the alarm group.
                    /// </summary>
                    private readonly Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate template;
                    /// <summary>
                    /// Specifies whether this entry is enabled.
                    /// </summary>
                    private readonly bool isEnabled;
                    /// <summary>
                    /// Specifies whether this entry is scheduled.
                    /// </summary>
                    private readonly bool isScheduled;
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsAlarmTemplateGroupEntry"/> class.
                    /// </summary>
                    /// <param name = "template">The alarm template.</param>
                    /// <param name = "isEnabled">Specifies if the entry is enabled.</param>
                    /// <param name = "isScheduled">Specifies if the entry is scheduled.</param>
                    internal DmsAlarmTemplateGroupEntry(Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate template, bool isEnabled, bool isScheduled)
                    {
                        if (template == null)
                        {
                            throw new System.ArgumentNullException("template");
                        }

                        this.template = template;
                        this.isEnabled = isEnabled;
                        this.isScheduled = isScheduled;
                    }

                    /// <summary>
                    /// Gets the alarm template.
                    /// </summary>
                    public Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate AlarmTemplate
                    {
                        get
                        {
                            return template;
                        }
                    }

                    /// <summary>
                    /// Gets a value indicating whether the entry is enabled.
                    /// </summary>
                    public bool IsEnabled
                    {
                        get
                        {
                            return isEnabled;
                        }
                    }

                    /// <summary>
                    /// Gets a value indicating whether the entry is scheduled.
                    /// </summary>
                    public bool IsScheduled
                    {
                        get
                        {
                            return isScheduled;
                        }
                    }

                    /// <summary>
                    /// Returns a string that represents the current object.
                    /// </summary>
                    /// <returns>A string that represents the current object.</returns>
                    public override string ToString()
                    {
                        return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Alarm template group entry:{0}", template.Name);
                    }
                }

                /// <summary>
                /// Represents a standalone alarm template.
                /// </summary>
                internal class DmsStandaloneAlarmTemplate : Skyline.DataMiner.Library.Common.Templates.DmsAlarmTemplate, Skyline.DataMiner.Library.Common.Templates.IDmsStandaloneAlarmTemplate
                {
                    /// <summary>
                    /// The description of the alarm definition.
                    /// </summary>
                    private string description;
                    /// <summary>
                    /// Indicates whether this alarm template is used in a group.
                    /// </summary>
                    private bool isUsedInGroup;
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsStandaloneAlarmTemplate"/> class.
                    /// </summary>
                    /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                    /// <param name = "name">The name of the alarm template.</param>
                    /// <param name = "protocol">The protocol this standalone alarm template corresponds with.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "name"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "protocol"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "name"/> is the empty string ("") or white space.</exception>
                    internal DmsStandaloneAlarmTemplate(Skyline.DataMiner.Library.Common.IDms dms, string name, Skyline.DataMiner.Library.Common.IDmsProtocol protocol): base(dms, name, protocol)
                    {
                        IsLoaded = false;
                    }

                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsStandaloneAlarmTemplate"/> class.
                    /// </summary>
                    /// <param name = "dms">The DataMiner system reference.</param>
                    /// <param name = "alarmTemplateEventMessage">An instance of AlarmTemplateEventMessage.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "dms"/> is invalid.</exception>
                    internal DmsStandaloneAlarmTemplate(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage alarmTemplateEventMessage): base(dms, alarmTemplateEventMessage.Name, alarmTemplateEventMessage.Protocol, alarmTemplateEventMessage.Version)
                    {
                        IsLoaded = true;
                        description = alarmTemplateEventMessage.Description;
                        isUsedInGroup = alarmTemplateEventMessage.IsUsedInGroup;
                    }

                    /// <summary>
                    /// Gets or sets the alarm template description.
                    /// </summary>
                    public string Description
                    {
                        get
                        {
                            LoadOnDemand();
                            return description;
                        }

                        set
                        {
                            LoadOnDemand();
                            ChangedPropertyList.Add("Description");
                            description = value;
                        }
                    }

                    /// <summary>
                    /// Gets a value indicating whether the alarm template is used in a group.
                    /// </summary>
                    public bool IsUsedInGroup
                    {
                        get
                        {
                            LoadOnDemand();
                            return isUsedInGroup;
                        }
                    }

                    /// <summary>
                    /// Returns a string that represents the current object.
                    /// </summary>
                    /// <returns>A string that represents the current object.</returns>
                    public override string ToString()
                    {
                        return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Alarm Template Name: {0}, Protocol Name: {1}, Protocol Version: {2}", Name, Protocol.Name, Protocol.Version);
                    }

                    /// <summary>
                    /// Parses the alarm template event message.
                    /// </summary>
                    /// <param name = "message">The message received from SLNet.</param>
                    internal override void Parse(Skyline.DataMiner.Net.Messages.AlarmTemplateEventMessage message)
                    {
                        IsLoaded = true;
                        description = message.Description;
                        isUsedInGroup = message.IsUsedInGroup;
                    }
                }

                /// <summary>
                /// Represents an alarm template.
                /// </summary>
                internal abstract class DmsTemplate : Skyline.DataMiner.Library.Common.DmsObject
                {
                    /// <summary>
                    /// Alarm template name.
                    /// </summary>
                    private readonly string name;
                    /// <summary>
                    /// The protocol this alarm template corresponds with.
                    /// </summary>
                    private readonly Skyline.DataMiner.Library.Common.IDmsProtocol protocol;
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsTemplate"/> class.
                    /// </summary>
                    /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                    /// <param name = "name">The name of the alarm template.</param>
                    /// <param name = "protocol">Instance of the protocol.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "name"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "protocol"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "name"/> is the empty string ("") or white space.</exception>
                    protected DmsTemplate(Skyline.DataMiner.Library.Common.IDms dms, string name, Skyline.DataMiner.Library.Common.IDmsProtocol protocol): base(dms)
                    {
                        if (name == null)
                        {
                            throw new System.ArgumentNullException("name");
                        }

                        if (protocol == null)
                        {
                            throw new System.ArgumentNullException("protocol");
                        }

                        if (System.String.IsNullOrWhiteSpace(name))
                        {
                            throw new System.ArgumentException("The name of the template is the empty string (\"\") or white space.");
                        }

                        this.name = name;
                        this.protocol = protocol;
                    }

                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsTemplate"/> class.
                    /// </summary>
                    /// <param name = "dms">The DataMiner System reference.</param>
                    /// <param name = "name">The template name.</param>
                    /// <param name = "protocolName">The name of the protocol.</param>
                    /// <param name = "protocolVersion">The version of the protocol.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "name"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "protocolName"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "protocolVersion"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "name"/> is the empty string ("") or white space.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "protocolName"/> is the empty string ("") or white space.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "protocolVersion"/> is the empty string ("") or white space.</exception>
                    protected DmsTemplate(Skyline.DataMiner.Library.Common.IDms dms, string name, string protocolName, string protocolVersion): base(dms)
                    {
                        if (name == null)
                        {
                            throw new System.ArgumentNullException("name");
                        }

                        if (protocolName == null)
                        {
                            throw new System.ArgumentNullException("protocolName");
                        }

                        if (protocolVersion == null)
                        {
                            throw new System.ArgumentNullException("protocolVersion");
                        }

                        if (System.String.IsNullOrWhiteSpace(name))
                        {
                            throw new System.ArgumentException("The name of the template is the empty string(\"\") or white space.", "name");
                        }

                        if (System.String.IsNullOrWhiteSpace(protocolName))
                        {
                            throw new System.ArgumentException("The name of the protocol is the empty string (\"\") or white space.", "protocolName");
                        }

                        if (System.String.IsNullOrWhiteSpace(protocolVersion))
                        {
                            throw new System.ArgumentException("The version of the protocol is the empty string (\"\") or white space.", "protocolVersion");
                        }

                        this.name = name;
                        protocol = new Skyline.DataMiner.Library.Common.DmsProtocol(dms, protocolName, protocolVersion);
                    }

                    /// <summary>
                    /// Gets the template name.
                    /// </summary>
                    public string Name
                    {
                        get
                        {
                            return name;
                        }
                    }

                    /// <summary>
                    /// Gets the protocol this template corresponds with.
                    /// </summary>
                    public Skyline.DataMiner.Library.Common.IDmsProtocol Protocol
                    {
                        get
                        {
                            return protocol;
                        }
                    }
                }

                /// <summary>
                /// Represents a trend template.
                /// </summary>
                internal class DmsTrendTemplate : Skyline.DataMiner.Library.Common.Templates.DmsTemplate, Skyline.DataMiner.Library.Common.Templates.IDmsTrendTemplate
                {
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsTrendTemplate"/> class.
                    /// </summary>
                    /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                    /// <param name = "name">The name of the alarm template.</param>
                    /// <param name = "protocol">The instance of the protocol.</param>
                    /// <exception cref = "ArgumentNullException">Dms is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException">Name is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException">Protocol is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException"><paramref name = "name"/> is the empty string ("") or white space.</exception>
                    internal DmsTrendTemplate(Skyline.DataMiner.Library.Common.IDms dms, string name, Skyline.DataMiner.Library.Common.IDmsProtocol protocol): base(dms, name, protocol)
                    {
                        IsLoaded = true;
                    }

                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsTrendTemplate"/> class.
                    /// </summary>
                    /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                    /// <param name = "templateInfo">The template info received by SLNet.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException">name is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException">protocolName is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException">protocolVersion is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException">name is the empty string ("") or white space.</exception>
                    /// <exception cref = "ArgumentException">ProtocolName is the empty string ("") or white space.</exception>
                    /// <exception cref = "ArgumentException">ProtocolVersion is the empty string ("") or white space.</exception>
                    internal DmsTrendTemplate(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.GetTrendingTemplateInfoResponseMessage templateInfo): base(dms, templateInfo.Name, templateInfo.Protocol, templateInfo.Version)
                    {
                        IsLoaded = true;
                    }

                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsTrendTemplate"/> class.
                    /// </summary>
                    /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                    /// <param name = "templateInfo">The template info received by SLNet.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException">Name is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException">ProtocolName is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException">ProtocolVersion is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentException">Name is the empty string ("") or white space.</exception>
                    /// <exception cref = "ArgumentException">ProtocolName is the empty string ("") or white space.</exception>
                    /// <exception cref = "ArgumentException">ProtocolVersion is the empty string ("") or white space.</exception>
                    internal DmsTrendTemplate(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.TrendTemplateMetaInfo templateInfo): base(dms, templateInfo.Name, templateInfo.ProtocolName, templateInfo.ProtocolVersion)
                    {
                        IsLoaded = true;
                    }

                    /// <summary>
                    /// Returns a string that represents the current object.
                    /// </summary>
                    /// <returns>A string that represents the current object.</returns>
                    public override string ToString()
                    {
                        return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Trend Template Name: {0}, Protocol Name: {1}, Protocol Version: {2}", Name, Protocol.Name, Protocol.Version);
                    }

                    /// <summary>
                    /// Loads this object.
                    /// </summary>
                    internal override void Load()
                    {
                    }
                }

                /// <summary>
                /// DataMiner alarm template interface.
                /// </summary>
                public interface IDmsAlarmTemplate : Skyline.DataMiner.Library.Common.Templates.IDmsTemplate
                {
                }

                /// <summary>
                /// DataMiner alarm template group interface.
                /// </summary>
                public interface IDmsAlarmTemplateGroup : Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate
                {
                    /// <summary>
                    /// Gets the entries of the alarm template group.
                    /// </summary>
                    System.Collections.ObjectModel.ReadOnlyCollection<Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplateGroupEntry> Entries
                    {
                        get;
                    }
                }

                /// <summary>
                /// DataMiner alarm template group entry interface.
                /// </summary>
                public interface IDmsAlarmTemplateGroupEntry
                {
                    /// <summary>
                    /// Gets a value indicating whether the entry is enabled.
                    /// </summary>
                    bool IsEnabled
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets a value indicating whether the entry is scheduled.
                    /// </summary>
                    bool IsScheduled
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets the alarm template.
                    /// </summary>
                    Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate AlarmTemplate
                    {
                        get;
                    }
                }

                /// <summary>
                /// DataMiner standalone alarm template interface.
                /// </summary>
                public interface IDmsStandaloneAlarmTemplate : Skyline.DataMiner.Library.Common.Templates.IDmsAlarmTemplate
                {
                    /// <summary>
                    /// Gets or sets the alarm template description.
                    /// </summary>
                    string Description
                    {
                        get;
                        set;
                    }

                    /// <summary>
                    /// Gets a value indicating whether the alarm template is used in a group.
                    /// </summary>
                    bool IsUsedInGroup
                    {
                        get;
                    }
                }

                /// <summary>
                /// DataMiner template interface.
                /// </summary>
                public interface IDmsTemplate : Skyline.DataMiner.Library.Common.IDmsObject
                {
                    /// <summary>
                    /// Gets the template name.
                    /// </summary>
                    string Name
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets the protocol this template corresponds with.
                    /// </summary>
                    Skyline.DataMiner.Library.Common.IDmsProtocol Protocol
                    {
                        get;
                    }
                }

                /// <summary>
                /// DataMiner trend template interface.
                /// </summary>
                public interface IDmsTrendTemplate : Skyline.DataMiner.Library.Common.Templates.IDmsTemplate
                {
                }
            }

            /// <summary>
            /// Represents a DataMiner view.
            /// </summary>
            internal class DmsView : Skyline.DataMiner.Library.Common.DmsObject, Skyline.DataMiner.Library.Common.IDmsView
            {
                /// <summary>
                /// The child views.
                /// </summary>
                private readonly System.Collections.Generic.List<Skyline.DataMiner.Library.Common.IDmsView> childViews = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.IDmsView>();
                /// <summary>
                /// The elements that are part of this view.
                /// </summary>
                private readonly System.Collections.Generic.List<Skyline.DataMiner.Library.Common.IDmsElement> elements = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.IDmsElement>();
                /// <summary>
                /// The properties.
                /// </summary>
                private readonly System.Collections.Generic.IDictionary<System.String, Skyline.DataMiner.Library.Common.Properties.DmsViewProperty> properties = new System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Library.Common.Properties.DmsViewProperty>();
                /// <summary>
                /// The names of updated properties.
                /// </summary>
                private readonly System.Collections.Generic.HashSet<System.String> updatedProperties = new System.Collections.Generic.HashSet<System.String>();
                /// <summary>
                /// The display string.
                /// </summary>
                private string display = System.String.Empty;
                /// <summary>
                /// ID of the view.
                /// </summary>
                private int id = -1;
                /// <summary>
                /// The parent view.
                /// </summary>
                private Skyline.DataMiner.Library.Common.IDmsView parentView;
                /// <summary>
                /// The name of the view.
                /// </summary>
                private string name;
                private bool isNameLoaded;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsView"/> class.
                /// </summary>
                /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                /// <param name = "viewId">The ID of the view.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                internal DmsView(Skyline.DataMiner.Library.Common.IDms dms, int viewId): base(dms)
                {
                    id = viewId;
                    IsLoaded = false;
                    isNameLoaded = false;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsView"/> class.
                /// </summary>
                /// <param name = "dms">Object implementing the <see cref = "IDms"/> interface.</param>
                /// <param name = "id">The ID of the view.</param>
                /// <param name = "name">The name of the view.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "dms"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentNullException"><paramref name = "name"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "name">is empty or white space.</paramref></exception>
                internal DmsView(Skyline.DataMiner.Library.Common.IDms dms, int id, string name): base(dms)
                {
                    if (name == null)
                    {
                        throw new System.ArgumentNullException("name");
                    }

                    if (System.String.IsNullOrWhiteSpace(name))
                    {
                        throw new System.ArgumentException("Provided name must not be empty or white space", "name");
                    }

                    this.id = id;
                    this.name = name;
                    IsLoaded = false;
                    isNameLoaded = true;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsView"/> class.
                /// </summary>
                /// <param name = "dms">Instance of the DataMinerSystem class.</param>
                /// <param name = "viewInfo">The view info.</param>
                internal DmsView(Skyline.DataMiner.Library.Common.Dms dms, Skyline.DataMiner.Net.Messages.ViewInfoEventMessage viewInfo): base(dms)
                {
                    Parse(viewInfo);
                    // Remove the properties that are added to the change list because of initialization.
                    ClearChangeList();
                }

                /// <summary>
                /// Gets all child views.
                /// </summary>
                /// <value>The child views.</value>
                public System.Collections.Generic.IList<Skyline.DataMiner.Library.Common.IDmsView> ChildViews
                {
                    get
                    {
                        LoadOnDemand();
                        return childViews.AsReadOnly();
                    }
                }

                /// <summary>
                /// Gets the display string.
                /// </summary>
                /// <value>The display string.</value>
                public string Display
                {
                    get
                    {
                        LoadOnDemand();
                        return display;
                    }
                }

                /// <summary>
                /// Gets all elements contained in this view.
                /// </summary>
                /// <value>The elements contained in this view.</value>
                public System.Collections.Generic.IList<Skyline.DataMiner.Library.Common.IDmsElement> Elements
                {
                    get
                    {
                        LoadOnDemand();
                        return elements.AsReadOnly();
                    }
                }

                /// <summary>
                /// Gets the ID of this view.
                /// </summary>
                /// <value>The view ID.</value>
                public int Id
                {
                    get
                    {
                        return id;
                    }
                }

                /// <summary>
                /// Gets or sets the name of the view.
                /// </summary>
                /// <value>The view name.</value>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation is invalid.</exception>
                /// <remarks>
                /// <para>The following restrictions apply to view names:</para>
                /// <list type = "bullet">
                /// <item><para>Must not be empty ("") or white space.</para></item>
                /// <item><para>Must not exceed 200 characters.</para></item>
                /// <item><para>Names may not start or end with the following characters: '.' (dot), ' ' (space).</para></item>
                /// <item><para>Names may not contain the following character: '|' (pipe).</para></item>
                /// <item><para>The following characters may not occur more than once within a name: '%' (percentage).</para></item>
                /// </list>
                /// </remarks>
                public string Name
                {
                    get
                    {
                        if (!isNameLoaded)
                        {
                            LoadOnDemand();
                        }

                        return name;
                    }

                    set
                    {
                        string validatedViewName = Skyline.DataMiner.Library.Common.InputValidator.ValidateViewName(value, "value");
                        if (!isNameLoaded)
                        {
                            LoadOnDemand();
                        }

                        if (!name.Equals(validatedViewName, System.StringComparison.Ordinal))
                        {
                            ChangedPropertyList.Add("Name");
                            name = validatedViewName;
                        }
                    }
                }

                /// <summary>
                /// Gets or sets the parent view.
                /// </summary>
                /// <value>The parent view.</value>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "NotSupportedException">The root view cannot be assigned a parent view.</exception>
                /// <exception cref = "NotSupportedException">The parent of a view must not be a self-reference.</exception>
                public Skyline.DataMiner.Library.Common.IDmsView Parent
                {
                    get
                    {
                        LoadOnDemand();
                        return parentView;
                    }

                    set
                    {
                        if (value == null)
                        {
                            throw new System.ArgumentNullException("value");
                        }

                        if (Id == -1)
                        {
                            throw new System.NotSupportedException("The root view cannot be assigned a parent view.");
                        }

                        LoadOnDemand();
                        if (value.Id == this.Id)
                        {
                            throw new System.NotSupportedException("The parent of a view must not be a self-reference.");
                        }

                        if (parentView != value)
                        {
                            ChangedPropertyList.Add("ParentView");
                            parentView = value;
                        }
                    }
                }

                /// <summary>
                /// Gets the properties of this view.
                /// </summary>
                /// <value>The view properties.</value>
                public Skyline.DataMiner.Library.Common.IPropertyCollection<Skyline.DataMiner.Library.Common.Properties.IDmsViewProperty, Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition> Properties
                {
                    get
                    {
                        LoadOnDemand();
                        System.Collections.Generic.IDictionary<System.String, Skyline.DataMiner.Library.Common.Properties.IDmsViewProperty> copy = new System.Collections.Generic.Dictionary<System.String, Skyline.DataMiner.Library.Common.Properties.IDmsViewProperty>(properties.Count);
                        foreach (System.Collections.Generic.KeyValuePair<System.String, Skyline.DataMiner.Library.Common.Properties.DmsViewProperty> kvp in properties)
                        {
                            copy.Add(kvp.Key, kvp.Value);
                        }

                        return new Skyline.DataMiner.Library.Common.PropertyCollection<Skyline.DataMiner.Library.Common.Properties.IDmsViewProperty, Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition>(copy);
                    }
                }

                /// <summary>
                /// Returns a string that represents the current object.
                /// </summary>
                /// <returns>A string that represents the current object.</returns>
                public override string ToString()
                {
                    return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "View name: {0}, ID: {1}", Name, Id);
                }

                /// <summary>
                /// Loads the content of the view.
                /// All of the properties.
                /// All of the elements in the view.
                /// </summary>
                /// <exception cref = "ViewNotFoundException">No view with the specified ID exists in the DataMiner System.</exception>
                internal override void Load()
                {
                    try
                    {
                        IsLoaded = true;
                        isNameLoaded = true;
                        Skyline.DataMiner.Net.Messages.ViewInfoEventMessage infoEvent = null;
                        Skyline.DataMiner.Net.Messages.GetInfoMessage message = new Skyline.DataMiner.Net.Messages.GetInfoMessage{Type = Skyline.DataMiner.Net.Messages.InfoType.ViewInfo};
                        Skyline.DataMiner.Net.Messages.DMSMessage[] responses = Communication.SendMessage(message);
                        foreach (Skyline.DataMiner.Net.Messages.DMSMessage response in responses)
                        {
                            Skyline.DataMiner.Net.Messages.ViewInfoEventMessage viewInfo = (Skyline.DataMiner.Net.Messages.ViewInfoEventMessage)response;
                            if (viewInfo.ID.Equals(Id))
                            {
                                infoEvent = viewInfo;
                                break;
                            }
                        }

                        if (infoEvent != null)
                        {
                            Parse(infoEvent);
                        }
                        else
                        {
                            throw new Skyline.DataMiner.Library.Common.ViewNotFoundException(id);
                        }
                    }
                    catch (Skyline.DataMiner.Net.Exceptions.DataMinerException)
                    {
                        IsLoaded = false;
                        isNameLoaded = false;
                        throw;
                    }
                }

                internal void PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
                {
                    updatedProperties.Add(e.PropertyName);
                }

                /// <summary>
                /// Parses the view info event message.
                /// </summary>
                /// <param name = "viewInfo">The view info event message.</param>
                internal void Parse(Skyline.DataMiner.Net.Messages.ViewInfoEventMessage viewInfo)
                {
                    IsLoaded = true;
                    isNameLoaded = true;
                    try
                    {
                        ParseView(viewInfo);
                        ParseChildViews(viewInfo);
                        ParseChildElements(viewInfo);
                        ParseProperties(viewInfo);
                    }
                    catch
                    {
                        IsLoaded = false;
                        isNameLoaded = false;
                        throw;
                    }
                }

                /// <summary>
                /// Clears the property changed list.
                /// </summary>
                private void ClearChangeList()
                {
                    updatedProperties.Clear();
                }

                /// <summary>
                /// Parses the view.
                /// </summary>
                /// <param name = "viewInfo">The view information.</param>
                private void ParseView(Skyline.DataMiner.Net.Messages.ViewInfoEventMessage viewInfo)
                {
                    name = viewInfo.Name;
                    id = viewInfo.ID;
                    display = viewInfo.DisplayName;
                    parentView = Id == -1 ? null : new Skyline.DataMiner.Library.Common.DmsView(dms, viewInfo.ParentId);
                }

                /// <summary>
                /// Parses the child view.
                /// </summary>
                /// <param name = "viewInfo">The view information.</param>
                private void ParseChildViews(Skyline.DataMiner.Net.Messages.ViewInfoEventMessage viewInfo)
                {
                    if (viewInfo.DirectChildViews != null)
                    {
                        foreach (int viewID in viewInfo.DirectChildViews)
                        {
                            Skyline.DataMiner.Library.Common.DmsView childView = new Skyline.DataMiner.Library.Common.DmsView(dms, viewID);
                            childViews.Add(childView);
                        }
                    }
                }

                /// <summary>
                /// Parses the child view.
                /// </summary>
                /// <param name = "viewInfo">The view information.</param>
                private void ParseChildElements(Skyline.DataMiner.Net.Messages.ViewInfoEventMessage viewInfo)
                {
                    if (viewInfo.Elements != null)
                    {
                        foreach (string identifier in viewInfo.Elements)
                        {
                            Skyline.DataMiner.Library.Common.DmsElementId dmaEid = new Skyline.DataMiner.Library.Common.DmsElementId(identifier);
                            Skyline.DataMiner.Library.Common.DmsElement element = new Skyline.DataMiner.Library.Common.DmsElement(dms, dmaEid);
                            elements.Add(element);
                        }
                    }
                }

                /// <summary>
                /// Parses the view properties.
                /// </summary>
                /// <param name = "viewInfo">The view information.</param>
                private void ParseProperties(Skyline.DataMiner.Net.Messages.ViewInfoEventMessage viewInfo)
                {
                    properties.Clear();
                    foreach (Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition definition in Dms.ViewPropertyDefinitions)
                    {
                        Skyline.DataMiner.Net.Messages.PropertyInfo info = null;
                        if (viewInfo.Properties != null)
                        {
                            info = System.Linq.Enumerable.FirstOrDefault(viewInfo.Properties, p => p.Name.Equals(definition.Name, System.StringComparison.OrdinalIgnoreCase));
                            System.Collections.Generic.List<System.String> duplicates = System.Linq.Enumerable.ToList(System.Linq.Enumerable.Select(System.Linq.Enumerable.Where(System.Linq.Enumerable.GroupBy(viewInfo.Properties, p => p.Name), g => System.Linq.Enumerable.Count(g) > 1), g => g.Key));
                            if (System.Linq.Enumerable.Any(duplicates))
                            {
                                string message = "Duplicate view properties detected. View \"" + viewInfo.Name + "\" (" + viewInfo.ID + "), duplicate properties: " + System.String.Join(", ", duplicates) + ".";
                                Skyline.DataMiner.Library.Common.Logger.Log(message);
                            }
                        }

                        string propertyValue = info != null ? info.Value : System.String.Empty;
                        if (definition.IsReadOnly)
                        {
                            properties.Add(definition.Name, new Skyline.DataMiner.Library.Common.Properties.DmsViewProperty(this, definition, propertyValue));
                        }
                        else
                        {
                            var property = new Skyline.DataMiner.Library.Common.Properties.DmsWritableViewProperty(this, definition, propertyValue);
                            properties.Add(definition.Name, property);
                            property.PropertyChanged += this.PropertyChanged;
                        }
                    }
                }
            }

            /// <summary>
            /// DataMiner view interface.
            /// </summary>
            public interface IDmsView : Skyline.DataMiner.Library.Common.IDmsObject, Skyline.DataMiner.Library.Common.IUpdateable
            {
                /// <summary>
                /// Gets all child views.
                /// </summary>
                /// <value>The child views.</value>
                System.Collections.Generic.IList<Skyline.DataMiner.Library.Common.IDmsView> ChildViews
                {
                    get;
                }

                /// <summary>
                /// Gets the display string.
                /// </summary>
                /// <value>The display string.</value>
                string Display
                {
                    get;
                }

                /// <summary>
                /// Gets all elements that are immediate children of this view.
                /// </summary>
                /// <value>The elements that are immediate children of this view.</value>
                System.Collections.Generic.IList<Skyline.DataMiner.Library.Common.IDmsElement> Elements
                {
                    get;
                }

                /// <summary>
                /// Gets the ID of this view.
                /// </summary>
                /// <value>The view ID.</value>
                int Id
                {
                    get;
                }

                /// <summary>
                /// Gets or sets the name of the view.
                /// </summary>
                /// <value>The view name.</value>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The value of a set operation is invalid.</exception>
                /// <remarks>
                /// <para>The following restrictions apply to view names:</para>
                /// <list type = "bullet">
                /// <item><para>Must not be empty ("") or white space.</para></item>
                /// <item><para>Must not exceed 200 characters.</para></item>
                /// <item><para>Names may not start or end with the following characters: '.' (dot), ' ' (space).</para></item>
                /// <item><para>Names may not contain the following character: '|' (pipe).</para></item>
                /// <item><para>The following characters may not occur more than once within a name: '%' (percentage).</para></item>
                /// </list>
                /// </remarks>
                string Name
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets or sets the parent view.
                /// </summary>
                /// <value>The parent view.</value>
                /// <exception cref = "ArgumentNullException">The value of a set operation is <see langword = "null"/>.</exception>
                /// <exception cref = "NotSupportedException">The root view is assigned a parent view.</exception>
                /// <exception cref = "NotSupportedException">The parent view is a self-reference.</exception>
                Skyline.DataMiner.Library.Common.IDmsView Parent
                {
                    get;
                    set;
                }

                /// <summary>
                /// Gets the properties of this view.
                /// </summary>
                /// <value>The view properties.</value>
                Skyline.DataMiner.Library.Common.IPropertyCollection<Skyline.DataMiner.Library.Common.Properties.IDmsViewProperty, Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition> Properties
                {
                    get;
                }
            }

            /// <summary>
            /// Represents a table.
            /// </summary>
            internal class DmsTable : Skyline.DataMiner.Library.Common.IDmsTable
            {
                /// <summary>
                /// The element this table belongs to.
                /// </summary>
                private readonly Skyline.DataMiner.Library.Common.IDmsElement element;
                /// <summary>
                /// The table parameter ID.
                /// </summary>
                private readonly int id;
                /// <summary>
                /// Initializes a new instance of the <see cref = "DmsTable"/> class.
                /// </summary>
                /// <param name = "element">The element this table belongs to.</param>
                /// <param name = "id">The table parameter ID.</param>
                internal DmsTable(Skyline.DataMiner.Library.Common.IDmsElement element, int id)
                {
                    this.element = element;
                    this.id = id;
                }

                /// <summary>
                /// Gets the element this table is part of.
                /// </summary>
                /// <value>The element this table is part of.</value>
                public Skyline.DataMiner.Library.Common.IDmsElement Element
                {
                    get
                    {
                        return element;
                    }
                }

                /// <summary>
                /// Gets the table parameter ID.
                /// </summary>
                /// <value>The table parameter ID.</value>
                public int Id
                {
                    get
                    {
                        return id;
                    }
                }

                /// <summary>
                /// Adds the provided row to this table.
                /// </summary>
                /// <param name = "data">The row data.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "data"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ElementStoppedException">The element is stopped.</exception>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner System.</exception>
                /// <exception cref = "IncorrectDataException">Invalid data was provided.</exception>
                public void AddRow(object[] data)
                {
                    if (data == null)
                    {
                        throw new System.ArgumentNullException("data");
                    }

                    Skyline.DataMiner.Library.Common.HelperClass.CheckElementState(element);
                    try
                    {
                        Skyline.DataMiner.Net.Messages.Advanced.SetDataMinerInfoMessage message = new Skyline.DataMiner.Net.Messages.Advanced.SetDataMinerInfoMessage{DataMinerID = element.AgentId, ElementID = element.Id, What = 149, Var1 = new uint[]{(uint)element.AgentId, (uint)element.Id, (uint)id}, Var2 = data};
                        element.Host.Dms.Communication.SendSingleResponseMessage(message);
                    }
                    catch (Skyline.DataMiner.Net.Exceptions.DataMinerCOMException e)
                    {
                        if (e.ErrorCode == -2147220718)
                        {
                            // 0x80040312, Unknown destination DataMiner specified.
                            throw new Skyline.DataMiner.Library.Common.ElementNotFoundException(element.DmsElementId, e);
                        }
                        else if (e.ErrorCode == -2147220916)
                        {
                            // 0x8004024C, SL_NO_SUCH_ELEMENT, "The element is unknown."
                            throw new Skyline.DataMiner.Library.Common.ElementNotFoundException(element.DmsElementId, e);
                        }
                        else if (e.ErrorCode == -2147220959)
                        {
                            // 0x80040221, SL_INVALID_DATA, "Invalid data".
                            string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid data - element: '{0}', table ID: '{1}', data: [{2}]", element.DmsElementId.Value, Id, System.String.Join(",", data));
                            throw new Skyline.DataMiner.Library.Common.IncorrectDataException(message);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                /// <summary>
                /// Determines whether a row with the specified primary key exists in the table.
                /// </summary>
                /// <param name = "primaryKey">The primary key of the row.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "primaryKey"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "primaryKey"/> is the empty string ("") or white space.</exception>
                /// <exception cref = "IncorrectDataException">The provided data is invalid.</exception>
                /// <exception cref = "ElementStoppedException">The element is stopped.</exception>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner System.</exception>
                /// <returns><c>true</c> if the table contains a row with the specified primary key; otherwise, <c>false</c>.</returns>
                public bool RowExists(string primaryKey)
                {
                    if (primaryKey == null)
                    {
                        throw new System.ArgumentNullException("primaryKey");
                    }

                    if (System.String.IsNullOrWhiteSpace(primaryKey))
                    {
                        throw new System.ArgumentException("The provided primary key must not be the empty string (\"\") or white space.", "primaryKey");
                    }

                    Skyline.DataMiner.Library.Common.HelperClass.CheckElementState(Element);
                    try
                    {
                        bool rowExists = false;
                        Skyline.DataMiner.Net.Messages.Advanced.SetDataMinerInfoMessage message = new Skyline.DataMiner.Net.Messages.Advanced.SetDataMinerInfoMessage{DataMinerID = element.AgentId, ElementID = element.Id, What = 163, Var1 = new uint[]{(uint)element.AgentId, (uint)element.Id, (uint)Id}, Var2 = primaryKey};
                        Skyline.DataMiner.Net.Messages.DMSMessage response = element.Host.Dms.Communication.SendSingleResponseMessage(message);
                        Skyline.DataMiner.Net.Messages.Advanced.SetDataMinerInfoResponseMessage responseMessage = (Skyline.DataMiner.Net.Messages.Advanced.SetDataMinerInfoResponseMessage)response;
                        int position = (int)responseMessage.RawData;
                        if (position > 0)
                        {
                            rowExists = true;
                        }

                        return rowExists;
                    }
                    catch (Skyline.DataMiner.Net.Exceptions.DataMinerCOMException e)
                    {
                        if (e.ErrorCode == -2147220718)
                        {
                            // 0x80040312, Unknown destination DataMiner specified.
                            throw new Skyline.DataMiner.Library.Common.ElementNotFoundException(element.DmsElementId, e);
                        }
                        else if (e.ErrorCode == -2147220916)
                        {
                            // 0x8004024C, SL_NO_SUCH_ELEMENT, "The element is unknown."
                            throw new Skyline.DataMiner.Library.Common.ElementNotFoundException(element.DmsElementId, e);
                        }
                        else if (e.ErrorCode == -2147220959)
                        {
                            // 0x80040221, SL_INVALID_DATA, "Invalid data".
                            string message = System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Invalid data - element: '{0}', table ID: '{1}', primary key: \"{2}\"", element.DmsElementId.Value, Id, primaryKey);
                            throw new Skyline.DataMiner.Library.Common.IncorrectDataException(message);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                /// <summary>
                /// Updates the row with the provided data.
                /// </summary>
                /// <param name = "primaryKey">The primary key of the row that must be updated.</param>
                /// <param name = "data">The new row data.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "primaryKey"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentNullException"><paramref name = "data"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The provided primary key is the empty string ("") or white space.</exception>
                /// <exception cref = "ParameterNotFoundException">The table parameter was not found.</exception>
                /// <exception cref = "ElementStoppedException">The element is stopped.</exception>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner System.</exception>
                public void SetRow(string primaryKey, object[] data)
                {
                    if (primaryKey == null)
                    {
                        throw new System.ArgumentNullException("primaryKey");
                    }

                    if (data == null)
                    {
                        throw new System.ArgumentNullException("data");
                    }

                    if (System.String.IsNullOrWhiteSpace(primaryKey))
                    {
                        throw new System.ArgumentException("The provided primary key must not be the empty string (\"\") or white space.", "primaryKey");
                    }

                    Skyline.DataMiner.Library.Common.HelperClass.CheckElementState(Element);
                    try
                    {
                        object[] ids = new object[4];
                        ids[0] = element.AgentId;
                        ids[1] = element.Id;
                        ids[2] = id;
                        ids[3] = primaryKey;
                        Skyline.DataMiner.Net.Messages.Advanced.SetDataMinerInfoMessage message = new Skyline.DataMiner.Net.Messages.Advanced.SetDataMinerInfoMessage{DataMinerID = element.AgentId, ElementID = element.Id, What = 225, Var1 = ids, Var2 = data};
                        element.Host.Dms.Communication.SendSingleResponseMessage(message);
                    }
                    catch (Skyline.DataMiner.Net.Exceptions.DataMinerCOMException e)
                    {
                        if (e.ErrorCode == -2147220718)
                        {
                            // 0x80040312, Unknown destination DataMiner specified.
                            throw new Skyline.DataMiner.Library.Common.ElementNotFoundException(element.DmsElementId, e);
                        }
                        else if (e.ErrorCode == -2147220935)
                        {
                            // 0x80040239, SL_FAILED_NOT_FOUND, The object or file was not found.
                            throw new Skyline.DataMiner.Library.Common.ParameterNotFoundException(Id, element.DmsElementId, e);
                        }
                        else if (e.ErrorCode == -2147220916)
                        {
                            // 0x8004024C, SL_NO_SUCH_ELEMENT, "The element is unknown."
                            throw new Skyline.DataMiner.Library.Common.ElementNotFoundException(element.DmsElementId, e);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                /// <summary>
                /// Returns a string that represents the current object.
                /// </summary>
                /// <returns>A string that represents the current object.</returns>
                public override string ToString()
                {
                    return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Table Parameter:{0}", id);
                }
            }

            /// <summary>
            /// DataMiner table interface.
            /// </summary>
            public interface IDmsTable
            {
                /// <summary>
                /// Gets the element this table is part of.
                /// </summary>
                /// <value>The element this table is part of.</value>
                Skyline.DataMiner.Library.Common.IDmsElement Element
                {
                    get;
                }

                /// <summary>
                /// Gets the table parameter ID.
                /// </summary>
                /// <value>The table parameter ID.</value>
                int Id
                {
                    get;
                }

                /// <summary>
                /// Adds the provided row to this table.
                /// </summary>
                /// <param name = "data">The row data.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "data"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ElementStoppedException">The element is stopped.</exception>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner System.</exception>
                /// <exception cref = "IncorrectDataException">Invalid data was provided.</exception>
                void AddRow(object[] data);
                /// <summary>
                /// Determines whether a row with the specified primary key exists in the table.
                /// </summary>
                /// <param name = "primaryKey">The primary key of the row.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "primaryKey"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException"><paramref name = "primaryKey"/> is the empty string ("") or white space.</exception>
                /// <exception cref = "IncorrectDataException">The provided data is invalid.</exception>
                /// <exception cref = "ElementStoppedException">The element is stopped.</exception>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner System.</exception>
                /// <returns><c>true</c> if the table contains a row with the specified primary key; otherwise, <c>false</c>.</returns>
                bool RowExists(string primaryKey);
                /// <summary>
                /// Updates the row with the provided data.
                /// </summary>
                /// <param name = "primaryKey">The primary key of the row that must be updated.</param>
                /// <param name = "data">The new row data.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "primaryKey"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentNullException"><paramref name = "data"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentException">The provided primary key is the empty string ("") or white space.</exception>
                /// <exception cref = "ParameterNotFoundException">The table parameter was not found.</exception>
                /// <exception cref = "ElementStoppedException">The element is stopped.</exception>
                /// <exception cref = "ElementNotFoundException">The element was not found in the DataMiner System.</exception>
                void SetRow(string primaryKey, object[] data);
            }

            namespace Properties
            {
                /// <summary>
                /// Represents a DMS element property.
                /// </summary>
                internal class DmsElementProperty : Skyline.DataMiner.Library.Common.Properties.DmsProperty<Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition>, Skyline.DataMiner.Library.Common.Properties.IDmsElementProperty
                {
                    /// <summary>
                    /// The element to which the property belongs.
                    /// </summary>
                    private readonly Skyline.DataMiner.Library.Common.IDmsElement element;
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsElementProperty"/> class.
                    /// </summary>
                    /// <param name = "element">The element to which the property is assigned.</param>
                    /// <param name = "definition">The definition of the property.</param>
                    /// <param name = "value">The current value of the property.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "element"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "definition"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "value"/> is <see langword = "null"/>.</exception>
                    public DmsElementProperty(Skyline.DataMiner.Library.Common.IDmsElement element, Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition definition, string value): base(definition, value)
                    {
                        if (element == null)
                        {
                            throw new System.ArgumentNullException("element");
                        }

                        this.element = element;
                    }

                    /// <summary>
                    /// Gets the element to which the property is assigned.
                    /// </summary>
                    public Skyline.DataMiner.Library.Common.IDmsElement Element
                    {
                        get
                        {
                            return element;
                        }
                    }
                }

                /// <summary>
                /// Represents a DMS property.
                /// </summary>
                internal class DmsProperty<T> : Skyline.DataMiner.Library.Common.Properties.IDmsProperty<T> where T : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyDefinition
                {
                    /// <summary>
                    /// The definition of the property.
                    /// </summary>
                    protected readonly T definition;
                    /// <summary>
                    /// The value of the property.
                    /// </summary>
                    protected string value;
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsProperty{T}"/> class.
                    /// </summary>
                    /// <param name = "definition">The definition of the property.</param>
                    /// <param name = "value">The current value of the property.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "definition"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "value"/> is <see langword = "null"/>.</exception>
                    protected DmsProperty(T definition, string value)
                    {
                        if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(definition, default(T)))
                        {
                            throw new System.ArgumentNullException("definition");
                        }

                        if (value == null)
                        {
                            throw new System.ArgumentNullException("value");
                        }

                        this.definition = definition;
                        this.value = value;
                    }

                    /// <summary>
                    /// Gets the definition of the property.
                    /// </summary>
                    public T Definition
                    {
                        get
                        {
                            return definition;
                        }
                    }

                    /// <summary>
                    /// Gets the value of the property.
                    /// </summary>
                    public string Value
                    {
                        get
                        {
                            return value;
                        }
                    }
                }

                /// <summary>
                /// Entry class for the discrete entries associated with a property definition.
                /// </summary>
                internal class DmsPropertyEntry : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyEntry
                {
                    /// <summary>
                    /// The value of the property.
                    /// </summary>
                    private string value;
                    /// <summary>
                    /// The numeric value attached with this discrete.
                    /// </summary>
                    private int metric;
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsPropertyEntry"/> class.
                    /// </summary>
                    /// <param name = "value">The display value of the entry.</param>
                    /// <param name = "metric">The internal value of the entry.</param>
                    internal DmsPropertyEntry(string value, int metric)
                    {
                        Value = value;
                        Metric = metric;
                    }

                    /// <summary>
                    /// Gets the value of the property.
                    /// </summary>
                    public string Value
                    {
                        get
                        {
                            return value;
                        }

                        internal set
                        {
                            this.value = value;
                        }
                    }

                    /// <summary>
                    /// Gets the numeric value attached with the discrete.
                    /// </summary>
                    public int Metric
                    {
                        get
                        {
                            return metric;
                        }

                        internal set
                        {
                            metric = value;
                        }
                    }

                    /// <summary>
                    /// Returns a string that represents the current object.
                    /// </summary>
                    /// <returns>A string that represents the current object.</returns>
                    public override string ToString()
                    {
                        return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Property Entry:<{0};{1}>", value, metric);
                    }
                }

                /// <summary>
                /// Represents a DMS property.
                /// </summary>
                internal class DmsViewProperty : Skyline.DataMiner.Library.Common.Properties.DmsProperty<Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition>, Skyline.DataMiner.Library.Common.Properties.IDmsViewProperty
                {
                    /// <summary>
                    /// The view to which the property is assigned.
                    /// </summary>
                    private readonly Skyline.DataMiner.Library.Common.IDmsView view;
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsViewProperty"/> class.
                    /// </summary>
                    /// <param name = "view">The view to which the property is assigned.</param>
                    /// <param name = "definition">The definition of the property.</param>
                    /// <param name = "value">The current value of the property.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "definition"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "value"/> is <see langword = "null"/>.</exception>
                    internal DmsViewProperty(Skyline.DataMiner.Library.Common.IDmsView view, Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition definition, string value): base(definition, value)
                    {
                        if (view == null)
                        {
                            throw new System.ArgumentNullException("view");
                        }

                        this.view = view;
                    }

                    /// <summary>
                    /// Gets the view to which the property is assigned.
                    /// </summary>
                    public Skyline.DataMiner.Library.Common.IDmsView View
                    {
                        get
                        {
                            return view;
                        }
                    }
                }

                /// <summary>
                /// Represents a writable DataMiner system element property.
                /// </summary>
                internal class DmsWritableElementProperty : Skyline.DataMiner.Library.Common.Properties.DmsElementProperty, Skyline.DataMiner.Library.Common.Properties.IWritableProperty
                {
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsWritableElementProperty"/> class.
                    /// </summary>
                    /// <param name = "element">The element to which the property is assigned.</param>
                    /// <param name = "definition">The definition of the property.</param>
                    /// <param name = "value">The current value of the property.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "element"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "definition"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "value"/> is <see langword = "null"/>.</exception>
                    public DmsWritableElementProperty(Skyline.DataMiner.Library.Common.IDmsElement element, Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition definition, string value): base(element, definition, value)
                    {
                    }

                    /// <summary>
                    /// Occurs when a property value changes.
                    /// </summary>
                    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
                    /// <summary>
                    /// Gets or sets the value of the property.
                    /// </summary>
                    /// <exception cref = "ArgumentException">Thrown when the value can not be added to the property.</exception>
                    public new string Value
                    {
                        get
                        {
                            return value;
                        }

                        set
                        {
                            if (!definition.IsValidInput(value))
                            {
                                throw new System.ArgumentException(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "The value:'{0}' is not valid for the property", value));
                            }

                            this.value = value;
                            NotifyPropertyChanged();
                        }
                    }

                    private void NotifyPropertyChanged()
                    {
                        System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
                        if (handler != null)
                        {
                            handler.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(definition.Name));
                        }
                    }
                }

                /// <summary>
                /// Represents a DMS property.
                /// </summary>
                internal class DmsWritableViewProperty : Skyline.DataMiner.Library.Common.Properties.DmsViewProperty, Skyline.DataMiner.Library.Common.Properties.IWritableProperty
                {
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsWritableViewProperty"/> class.
                    /// </summary>
                    /// <param name = "view">The view to which this property belongs.</param>
                    /// <param name = "definition">The definition of the property.</param>
                    /// <param name = "value">The current value of the property.</param>
                    /// <exception cref = "ArgumentNullException"><paramref name = "view"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "definition"/> is <see langword = "null"/>.</exception>
                    /// <exception cref = "ArgumentNullException"><paramref name = "value"/> is <see langword = "null"/>.</exception>
                    public DmsWritableViewProperty(Skyline.DataMiner.Library.Common.IDmsView view, Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition definition, string value): base(view, definition, value)
                    {
                    }

                    /// <summary>
                    /// Occurs when the value of a property changes.
                    /// </summary>
                    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
                    /// <summary>
                    /// Gets or sets the value of the property.
                    /// </summary>
                    /// <exception cref = "ArgumentException">Thrown when the value can not be added to the property.</exception>
                    public new string Value
                    {
                        get
                        {
                            return value;
                        }

                        set
                        {
                            if (!definition.IsValidInput(value))
                            {
                                throw new System.ArgumentException(System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "The value:'{0}' is not valid for the property", value));
                            }

                            this.value = value;
                            NotifyPropertyChanged();
                        }
                    }

                    private void NotifyPropertyChanged()
                    {
                        System.ComponentModel.PropertyChangedEventHandler handler = PropertyChanged;
                        if (handler != null)
                        {
                            handler.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(definition.Name));
                        }
                    }
                }

                /// <summary>
                /// DataMiner element property interface.
                /// </summary>
                public interface IDmsElementProperty : Skyline.DataMiner.Library.Common.Properties.IDmsProperty<Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition>
                {
                    /// <summary>
                    /// Gets the element this property belongs to.
                    /// </summary>
                    Skyline.DataMiner.Library.Common.IDmsElement Element
                    {
                        get;
                    }
                }

                /// <summary>
                /// DataMiner property interface.
                /// </summary>
                /// <typeparam name = "T">The property type.</typeparam>
                public interface IDmsProperty<out T>
                    where T : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyDefinition
                {
                    /// <summary>
                    /// Gets the property value.
                    /// </summary>
                    string Value
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets the property definition.
                    /// </summary>
                    T Definition
                    {
                        get;
                    }
                }

                /// <summary>
                /// DataMiner property entry interface.
                /// </summary>
                public interface IDmsPropertyEntry
                {
                    /// <summary>
                    /// Gets the internal value.
                    /// </summary>
                    int Metric
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets the value.
                    /// </summary>
                    string Value
                    {
                        get;
                    }
                }

                /// <summary>
                /// DataMiner service property interface.
                /// </summary>
                public interface IDmsServiceProperty : Skyline.DataMiner.Library.Common.Properties.IDmsProperty<Skyline.DataMiner.Library.Common.Properties.IDmsServicePropertyDefinition>
                {
                    /// <summary>
                    /// Gets the service this property belongs to.
                    /// </summary>
                    Skyline.DataMiner.Library.Common.IDmsService Service
                    {
                        get;
                    }
                }

                /// <summary>
                /// DataMiner view property interface.
                /// </summary>
                public interface IDmsViewProperty : Skyline.DataMiner.Library.Common.Properties.IDmsProperty<Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition>
                {
                    /// <summary>
                    /// Gets the view this property belongs to.
                    /// </summary>
                    Skyline.DataMiner.Library.Common.IDmsView View
                    {
                        get;
                    }
                }

                /// <summary>
                /// DataMiner writable property interface.
                /// </summary>
                public interface IWritableProperty : System.ComponentModel.INotifyPropertyChanged
                {
                    /// <summary>
                    /// Gets or sets the property value.
                    /// </summary>
                    string Value
                    {
                        get;
                        set;
                    }
                }

                /// <summary>
                /// Represents a DMS element property definition.
                /// </summary>
                internal class DmsElementPropertyDefinition : Skyline.DataMiner.Library.Common.Properties.DmsPropertyDefinition, Skyline.DataMiner.Library.Common.Properties.IDmsElementPropertyDefinition
                {
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsElementPropertyDefinition"/> class.
                    /// </summary>
                    /// <param name = "dms">Instance of the DMS.</param>
                    /// <param name = "config">The configuration received from SLNet.</param>
                    internal DmsElementPropertyDefinition(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.PropertyConfig config): base(dms, config)
                    {
                    }

                    /// <summary>
                    /// Returns a string that represents the current object.
                    /// </summary>
                    /// <returns>A string that represents the current object.</returns>
                    public override string ToString()
                    {
                        return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "Element property: {0}", name);
                    }
                }

                /// <summary>
                /// Parent class for all types of DMS properties definitions.
                /// </summary>
                internal abstract class DmsPropertyDefinition : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyDefinition
                {
                    /// <summary>
                    /// Instance of the DMS class.
                    /// </summary>
                    protected readonly Skyline.DataMiner.Library.Common.IDms dms;
                    /// <summary>
                    /// The name of the property.
                    /// </summary>
                    protected string name;
                    /// <summary>
                    /// The id of the property.
                    /// </summary>
                    protected int id;
                    /// <summary>
                    /// Specifies if the property is available for alarm filtering.
                    /// </summary>
                    protected bool isAvailableForAlarmFiltering;
                    /// <summary>
                    /// Specifies if the property is read only.
                    /// </summary>
                    protected bool isReadOnly;
                    /// <summary>
                    /// Specifies if the property is visible in the Surveyor.
                    /// </summary>
                    protected bool isVisibleInSurveyor;
                    /// <summary>
                    /// The regular expression.
                    /// </summary>
                    protected string regex;
                    /// <summary>
                    /// The associated discrete entries with the property.
                    /// </summary>
                    protected System.Collections.Generic.List<Skyline.DataMiner.Library.Common.Properties.IDmsPropertyEntry> entries;
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsPropertyDefinition"/> class.
                    /// </summary>
                    /// <param name = "dms">Instance of DMS.</param>
                    /// <param name = "config">The property configuration received from SLNet.</param>
                    protected DmsPropertyDefinition(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.PropertyConfig config)
                    {
                        if (dms == null)
                        {
                            throw new System.ArgumentNullException("dms");
                        }

                        if (config == null)
                        {
                            throw new System.ArgumentNullException("config");
                        }

                        this.dms = dms;
                        Parse(config);
                    }

                    /// <summary>
                    /// Gets the name of the property.
                    /// </summary>
                    public string Name
                    {
                        get
                        {
                            return name;
                        }
                    }

                    /// <summary>
                    /// Gets the ID of the property.
                    /// </summary>
                    public int Id
                    {
                        get
                        {
                            return id;
                        }
                    }

                    /// <summary>
                    /// Gets a value indicating whether the property is available for alarm filtering.
                    /// </summary>
                    public bool IsAvailableForAlarmFiltering
                    {
                        get
                        {
                            return isAvailableForAlarmFiltering;
                        }
                    }

                    /// <summary>
                    /// Gets a value indicating whether the property is read only or not.
                    /// </summary>
                    public bool IsReadOnly
                    {
                        get
                        {
                            return isReadOnly;
                        }
                    }

                    /// <summary>
                    /// Gets a value indicating whether or not the property is visible in the surveyor.
                    /// </summary>
                    public bool IsVisibleInSurveyor
                    {
                        get
                        {
                            return isVisibleInSurveyor;
                        }
                    }

                    /// <summary>
                    /// Gets the regular expression of the property.
                    /// </summary>
                    public string Regex
                    {
                        get
                        {
                            return regex;
                        }
                    }

                    /// <summary>
                    /// Gets the discrete entries associated with the property.
                    /// </summary>
                    public System.Collections.ObjectModel.ReadOnlyCollection<Skyline.DataMiner.Library.Common.Properties.IDmsPropertyEntry> Entries
                    {
                        get
                        {
                            return entries.AsReadOnly();
                        }
                    }

                    /// <summary>
                    /// Checks if the provided input value matches the definition of the property.
                    /// </summary>
                    /// <param name = "value">The input value.</param>
                    /// <returns><c>true</c> if the input is valid; otherwise, <c>false</c>.</returns>
                    public bool IsValidInput(string value)
                    {
                        if (!System.String.IsNullOrWhiteSpace(regex))
                        {
                            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(regex);
                            return r.Match(value).Success;
                        }

                        return true;
                    }

                    /// <summary>
                    /// Parses the SLNet object.
                    /// </summary>
                    /// <param name = "config">Property configuration object.</param>
                    internal void Parse(Skyline.DataMiner.Net.Messages.PropertyConfig config)
                    {
                        name = config.Name;
                        id = config.ID;
                        isAvailableForAlarmFiltering = config.IsFilterEnabled;
                        isReadOnly = config.IsReadOnly;
                        isVisibleInSurveyor = config.IsVisibleInSurveyor;
                        regex = config.RegEx;
                        if (config.Entries != null)
                        {
                            Skyline.DataMiner.Net.Messages.PropertyConfigEntry[] propertyConfigEntries = config.Entries;
                            entries = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.Properties.IDmsPropertyEntry>(propertyConfigEntries.Length);
                            foreach (Skyline.DataMiner.Net.Messages.PropertyConfigEntry entry in propertyConfigEntries)
                            {
                                Skyline.DataMiner.Library.Common.Properties.DmsPropertyEntry temp = new Skyline.DataMiner.Library.Common.Properties.DmsPropertyEntry(entry.Value, entry.Metric);
                                entries.Add(temp);
                            }
                        }
                        else
                        {
                            entries = new System.Collections.Generic.List<Skyline.DataMiner.Library.Common.Properties.IDmsPropertyEntry>();
                        }
                    }
                }

                internal class DmsServicePropertyDefinition : Skyline.DataMiner.Library.Common.Properties.DmsPropertyDefinition, Skyline.DataMiner.Library.Common.Properties.IDmsServicePropertyDefinition
                {
                    /// <summary>
                    ///     Initializes a new instance of the <see cref = "DmsServicePropertyDefinition"/> class.
                    /// </summary>
                    /// <param name = "dms">Instance of the DMS.</param>
                    /// <param name = "config">The configuration received from SLNet.</param>
                    internal DmsServicePropertyDefinition(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.PropertyConfig config): base(dms, config)
                    {
                    }

                    /// <summary>
                    ///     Returns a string that represents the current object.
                    /// </summary>
                    /// <returns>A string that represents the current object.</returns>
                    public override string ToString()
                    {
                        return string.Format(System.Globalization.CultureInfo.InvariantCulture, "Service property: {0}", this.Name);
                    }
                }

                /// <summary>
                /// Represents a DMS view property definitions.
                /// </summary>
                internal class DmsViewPropertyDefinition : Skyline.DataMiner.Library.Common.Properties.DmsPropertyDefinition, Skyline.DataMiner.Library.Common.Properties.IDmsViewPropertyDefinition
                {
                    /// <summary>
                    /// Initializes a new instance of the <see cref = "DmsViewPropertyDefinition"/> class.
                    /// </summary>
                    /// <param name = "dms">Instance of the DMS.</param>
                    /// <param name = "config">The configuration received from SLNet.</param>
                    internal DmsViewPropertyDefinition(Skyline.DataMiner.Library.Common.IDms dms, Skyline.DataMiner.Net.Messages.PropertyConfig config): base(dms, config)
                    {
                    }

                    /// <summary>
                    /// Returns a string that represents the current object.
                    /// </summary>
                    /// <returns>A string that represents the current object.</returns>
                    public override string ToString()
                    {
                        return System.String.Format(System.Globalization.CultureInfo.InvariantCulture, "View property: {0}", Name);
                    }
                }

                /// <summary>
                /// DataMiner element property definition interface.
                /// </summary>
                public interface IDmsElementPropertyDefinition : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyDefinition
                {
                }

                /// <summary>
                /// DataMiner property definition interface.
                /// </summary>
                public interface IDmsPropertyDefinition : Skyline.DataMiner.Library.Common.IDmsObject
                {
                    /// <summary>
                    /// Gets the property name.
                    /// </summary>
                    string Name
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets the property entries.
                    /// </summary>
                    System.Collections.ObjectModel.ReadOnlyCollection<Skyline.DataMiner.Library.Common.Properties.IDmsPropertyEntry> Entries
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets the property ID.
                    /// </summary>
                    int Id
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets a value indicating whether the property is available for alarm filtering.
                    /// </summary>
                    bool IsAvailableForAlarmFiltering
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets a value indicating whether the property is read-only.
                    /// </summary>
                    bool IsReadOnly
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets a value indicating whether the property is visible in the Surveyor.
                    /// </summary>
                    bool IsVisibleInSurveyor
                    {
                        get;
                    }

                    /// <summary>
                    /// Gets the regular expression the property value must conform to.
                    /// </summary>
                    string Regex
                    {
                        get;
                    }

                    /// <summary>
                    /// Checks if the provided input value matches the definition of the property.
                    /// </summary>
                    /// <param name = "value">The input value.</param>
                    /// <returns><c>true</c> if the input is valid; otherwise, <c>false</c>.</returns>
                    bool IsValidInput(string value);
                }

                /// <summary>
                /// DataMiner service property definition interface.
                /// </summary>
                public interface IDmsServicePropertyDefinition : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyDefinition
                {
                }

                /// <summary>
                /// DataMiner view property definition interface.
                /// </summary>
                public interface IDmsViewPropertyDefinition : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyDefinition
                {
                }
            }

            /// <summary>
            /// Property collection interface.
            /// </summary>
            /// <typeparam name = "TProperty">The property type.</typeparam>
            /// <typeparam name = "TPropertyDefinition">The property definition type.</typeparam>
            public interface IPropertyCollection<TProperty, TPropertyDefinition> : System.Collections.Generic.IEnumerable<TProperty> where TProperty : Skyline.DataMiner.Library.Common.Properties.IDmsProperty<TPropertyDefinition> where TPropertyDefinition : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyDefinition
            {
                /// <summary>
                /// Gets the number of properties in this collection.
                /// </summary>
                /// <value>The number of properties in this collection.</value>
                int Count
                {
                    get;
                }

                /// <summary>
                /// Gets the property associated with the specified name.
                /// </summary>
                /// <param name = "property">The name of the property.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "property"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentOutOfRangeException">An invalid value that is not a member of the set of values.</exception>
                /// <returns>The property.</returns>
                TProperty this[string property]
                {
                    get;
                }
            }

            /// <summary>
            /// Property definition collection interface.
            /// </summary>
            /// <typeparam name = "T">The property definition type.</typeparam>
            public interface IPropertyDefinitionCollection<out T> : System.Collections.Generic.IEnumerable<T> where T : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyDefinition
            {
                /// <summary>
                /// Gets the number of property definitions in this collection.
                /// </summary>
                int Count
                {
                    get;
                }

                /// <summary>
                /// Gets the property definition associated with the specified name.
                /// </summary>
                /// <param name = "property">The name of the property.</param>
                /// <returns>The property definition.</returns>
                T this[string property]
                {
                    get;
                }
            }

            internal class PropertyCollection<T, U> : Skyline.DataMiner.Library.Common.IPropertyCollection<T, U> where T : Skyline.DataMiner.Library.Common.Properties.IDmsProperty<U> where U : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyDefinition
            {
                private readonly System.Collections.Generic.ICollection<T> collection = new System.Collections.Generic.List<T>();
                /// <summary>
                /// Initializes a new instance of the <see cref = "PropertyCollection&lt;T, U&gt;"/> class.
                /// </summary>
                /// <param name = "properties">The properties to initialize the collection with.</param>
                public PropertyCollection(System.Collections.Generic.IDictionary<System.String, T> properties)
                {
                    foreach (T value in properties.Values)
                    {
                        collection.Add(value);
                    }
                }

                /// <summary>
                /// Gets the number of properties in the collection.
                /// </summary>
                /// <value>The number of properties in this collection.</value>
                public int Count
                {
                    get
                    {
                        return collection.Count;
                    }
                }

                /// <summary>
                /// Gets the item at the specified index.
                /// </summary>
                /// <param name = "index">The name of the property.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "index"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentOutOfRangeException">An invalid value that is not a member of the set of values.</exception>
                /// <returns>The property with the specified name.</returns>
                public T this[string index]
                {
                    get
                    {
                        if (index == null)
                        {
                            throw new System.ArgumentNullException("index");
                        }

                        T property = System.Linq.Enumerable.SingleOrDefault(collection, p => p.Definition.Name.Equals(index, System.StringComparison.OrdinalIgnoreCase));
                        if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(property, default(T)))
                        {
                            throw new System.ArgumentOutOfRangeException("index");
                        }
                        else
                        {
                            return property;
                        }
                    }
                }

                /// <summary>
                /// Returns an enumerator that iterates through a collection.
                /// </summary>
                /// <returns>An enumerator that can be used to iterate through the collection.</returns>
                public System.Collections.Generic.IEnumerator<T> GetEnumerator()
                {
                    return collection.GetEnumerator();
                }

                /// <summary>
                /// Returns an enumerator that iterates through a collection.
                /// </summary>
                /// <returns>An <see cref = "IEnumerator"/> object that can be used to iterate through the collection.</returns>
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return ((System.Collections.IEnumerable)collection).GetEnumerator();
                }
            }

            /// <summary>
            /// Represents a collection of property definitions.
            /// </summary>
            /// <typeparam name = "T">The property type.</typeparam>
            internal class PropertyDefinitionCollection<T> : Skyline.DataMiner.Library.Common.IPropertyDefinitionCollection<T> where T : Skyline.DataMiner.Library.Common.Properties.IDmsPropertyDefinition
            {
                private readonly System.Collections.Generic.ICollection<T> collection = new System.Collections.Generic.List<T>();
                /// <summary>
                /// Initializes a new instance of the <see cref = "PropertyDefinitionCollection&lt;T&gt;"/> class.
                /// </summary>
                /// <param name = "properties">The properties to initialize the collection with.</param>
                public PropertyDefinitionCollection(System.Collections.Generic.IDictionary<System.String, T> properties)
                {
                    foreach (T value in properties.Values)
                    {
                        collection.Add(value);
                    }
                }

                /// <summary>
                /// Gets tne number of items in the collection.
                /// </summary>
                public int Count
                {
                    get
                    {
                        return collection.Count;
                    }
                }

                /// <summary>
                /// Gets the item at the specified index.
                /// </summary>
                /// <param name = "index">The name of the property.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "index"/> is <see langword = "null"/>.</exception>
                /// <exception cref = "ArgumentOutOfRangeException">An invalid value that is not a member of the set of values.</exception>
                /// <returns>The property with the specified name.</returns>
                public T this[string index]
                {
                    get
                    {
                        if (index == null)
                        {
                            throw new System.ArgumentNullException("index");
                        }

                        T property = System.Linq.Enumerable.SingleOrDefault(collection, p => p.Name.Equals(index, System.StringComparison.OrdinalIgnoreCase));
                        if (System.Collections.Generic.EqualityComparer<T>.Default.Equals(property, default(T)))
                        {
                            throw new System.ArgumentOutOfRangeException("index");
                        }
                        else
                        {
                            return property;
                        }
                    }
                }

                /// <summary>
                /// Returns an enumerator that iterates through a collection.
                /// </summary>
                /// <returns>An enumerator that can be used to iterate through the collection.</returns>
                public System.Collections.Generic.IEnumerator<T> GetEnumerator()
                {
                    return collection.GetEnumerator();
                }

                /// <summary>
                /// Returns an enumerator that iterates through a collection.
                /// </summary>
                /// <returns>An <see cref = "IEnumerator"/> object that can be used to iterate through the collection.</returns>
                System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
                {
                    return ((System.Collections.IEnumerable)collection).GetEnumerator();
                }
            }

            internal static class Logger
            {
                private const long SizeLimit = 3 * 1024 * 1024;
                private const string LogFileName = @"C:\Skyline DataMiner\logging\ClassLibrary.txt";
                private const string LogPositionPlaceholder = "**********";
                private const int PlaceHolderSize = 10;
                private static long logPositionPlaceholderStart = -1;
                private static System.Threading.Mutex loggerMutex;
#pragma warning disable S3963 // "static" fields should be initialized inline

                static Logger()
                {
                    System.Security.AccessControl.MutexSecurity mutexSecurity = new System.Security.AccessControl.MutexSecurity();
                    var accessRule = new System.Security.AccessControl.MutexAccessRule(new System.Security.Principal.SecurityIdentifier(System.Security.Principal.WellKnownSidType.WorldSid, null), System.Security.AccessControl.MutexRights.Synchronize | System.Security.AccessControl.MutexRights.Modify, System.Security.AccessControl.AccessControlType.Allow);
                    mutexSecurity.AddAccessRule(accessRule);
                    bool createdNew;
                    loggerMutex = new System.Threading.Mutex(false, "clpMutex", out createdNew, mutexSecurity);
                }

#pragma warning restore S3963 // "static" fields should be initialized inline

                public static void Log(string message)
                {
                    try
                    {
                        loggerMutex.WaitOne();
                        string logPrefix = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.fff") + "|";
                        long messageByteCount = System.Text.Encoding.UTF8.GetByteCount(message);
                        // Safeguard for large messages.
                        if (messageByteCount > SizeLimit)
                        {
                            message = "WARNING: message \"" + message.Substring(0, 100) + " not logged as it is too large (over " + SizeLimit + " bytes).";
                        }

                        long limit = SizeLimit / 2; // Safeguard: limit messages. If safeguard removed, the limit would be: SizeLimit - placeholder size - prefix length - 4 (2 * CR LF).
                        if (messageByteCount > limit)
                        {
                            long overhead = messageByteCount - limit;
                            int partToRemove = (int)overhead / 4; // In worst case, each char takes 4 bytes.
                            if (partToRemove == 0)
                            {
                                partToRemove = 1;
                            }

                            while (messageByteCount > limit)
                            {
                                message = message.Substring(0, message.Length - partToRemove);
                                messageByteCount = System.Text.Encoding.UTF8.GetByteCount(message);
                            }
                        }

                        int byteCount = System.Text.Encoding.UTF8.GetByteCount(message);
                        long positionOfPlaceHolder = GetPlaceHolderPosition();
                        System.IO.Stream fileStream = null;
                        try
                        {
                            fileStream = new System.IO.FileStream(LogFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
                            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream))
                            {
                                fileStream = null;
                                if (positionOfPlaceHolder == -1)
                                {
                                    sw.BaseStream.Position = 0;
                                    sw.Write(logPrefix);
                                    sw.WriteLine(message);
                                    logPositionPlaceholderStart = byteCount + logPrefix.Length;
                                    sw.WriteLine(LogPositionPlaceholder);
                                }
                                else
                                {
                                    sw.BaseStream.Position = positionOfPlaceHolder;
                                    if (positionOfPlaceHolder + byteCount + 4 + PlaceHolderSize > SizeLimit)
                                    {
                                        // Overwrite previous placeholder.
                                        byte[] placeholder = System.Text.Encoding.UTF8.GetBytes("          ");
                                        sw.BaseStream.Write(placeholder, 0, placeholder.Length);
                                        sw.BaseStream.Position = 0;
                                    }

                                    sw.Write(logPrefix);
                                    sw.WriteLine(message);
                                    sw.Flush();
                                    logPositionPlaceholderStart = sw.BaseStream.Position;
                                    sw.WriteLine(LogPositionPlaceholder);
                                }
                            }
                        }
                        finally
                        {
                            if (fileStream != null)
                            {
                                fileStream.Dispose();
                            }
                        }
                    }
                    catch
                    {
                    // Do nothing.
                    }
                    finally
                    {
                        loggerMutex.ReleaseMutex();
                    }
                }

                private static long SetToStartOfLine(System.IO.StreamReader streamReader, long startPosition)
                {
                    System.IO.Stream stream = streamReader.BaseStream;
                    for (long position = startPosition - 1; position > 0; position--)
                    {
                        stream.Position = position;
                        if (stream.ReadByte() == '\n')
                        {
                            return position + 1;
                        }
                    }

                    return 0;
                }

                private static long GetPlaceHolderPosition()
                {
                    long result = -1;
                    System.IO.Stream fileStream = null;
                    try
                    {
                        fileStream = System.IO.File.Open(LogFileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite, System.IO.FileShare.ReadWrite);
                        using (System.IO.StreamReader streamReader = new System.IO.StreamReader(fileStream))
                        {
                            fileStream = null;
                            streamReader.DiscardBufferedData();
                            long startOfLinePosition = SetToStartOfLine(streamReader, logPositionPlaceholderStart);
                            streamReader.DiscardBufferedData();
                            streamReader.BaseStream.Position = startOfLinePosition;
                            string line;
                            long postionInFile = startOfLinePosition;
                            while ((line = streamReader.ReadLine()) != null)
                            {
                                if (line == LogPositionPlaceholder)
                                {
                                    streamReader.DiscardBufferedData();
                                    result = postionInFile;
                                    break;
                                }
                                else
                                {
                                    postionInFile = postionInFile + System.Text.Encoding.UTF8.GetByteCount(line) + 2;
                                }
                            }

                            // If this point is reached, it means the placeholder was still not found.
                            if (result == -1 && startOfLinePosition > 0)
                            {
                                streamReader.DiscardBufferedData();
                                streamReader.BaseStream.Position = 0;
                                while ((line = streamReader.ReadLine()) != null)
                                {
                                    if (line == LogPositionPlaceholder)
                                    {
                                        streamReader.DiscardBufferedData();
                                        result = streamReader.BaseStream.Position - PlaceHolderSize - 2;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (fileStream != null)
                        {
                            fileStream.Dispose();
                        }
                    }

                    return result;
                }
            }
        }
    }

    namespace DeveloperCommunityLibrary.InteractiveAutomationToolkit
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
        ///     A drop-down list.
        /// </summary>
        public class DropDown : Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.InteractiveWidget
        {
            private readonly System.Collections.Generic.HashSet<System.String> options = new System.Collections.Generic.HashSet<System.String>();
            private bool changed;
            private string previous;
            /// <summary>
            ///     Initializes a new instance of the <see cref = "DropDown"/> class.
            /// </summary>
            public DropDown(): this(System.Linq.Enumerable.Empty<string>())
            {
            }

            /// <summary>
            ///     Initializes a new instance of the <see cref = "DropDown"/> class.
            /// </summary>
            /// <param name = "options">Options to be displayed in the list.</param>
            /// <param name = "selected">The selected item in the list.</param>
            /// <exception cref = "ArgumentNullException">When options is null.</exception>
            public DropDown(System.Collections.Generic.IEnumerable<System.String> options, string selected = null)
            {
                Type = Skyline.DataMiner.Automation.UIBlockType.DropDown;
                SetOptions(options);
                if (selected != null)
                    Selected = selected;
                ValidationText = "Invalid Input";
                ValidationState = Skyline.DataMiner.Automation.UIValidationState.NotValidated;
            }

            private event System.EventHandler<Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.DropDown.DropDownChangedEventArgs> OnChanged;
            /// <summary>
            ///     Gets or sets the possible options.
            /// </summary>
            public System.Collections.Generic.IEnumerable<System.String> Options
            {
                get
                {
                    return options;
                }

                set
                {
                    SetOptions(value);
                }
            }

            /// <summary>
            ///     Gets or sets the selected option.
            /// </summary>
            public string Selected
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
            ///		Gets or sets the state indicating if a given input field was validated or not and if the validation was valid.
            ///		This should be used by the client to add a visual marker on the input field.
            /// </summary>
            /// <remarks>Available from DataMiner Feature Release 10.0.5 and 10.0.1.0 Main Release.</remarks>
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

            /// <summary>
            ///     Gets or sets a value indicating whether a filter box is available for the drop-down list.
            /// </summary>
            /// <remarks>Available from DataMiner 9.5.6 onwards.</remarks>
            public bool IsDisplayFilterShown
            {
                get
                {
                    return BlockDefinition.DisplayFilter;
                }

                set
                {
                    BlockDefinition.DisplayFilter = value;
                }
            }

            /// <summary>
            ///     Gets or sets a value indicating whether the options are sorted naturally.
            /// </summary>
            /// <remarks>Available from DataMiner 9.5.6 onwards.</remarks>
            public bool IsSorted
            {
                get
                {
                    return BlockDefinition.IsSorted;
                }

                set
                {
                    BlockDefinition.IsSorted = value;
                }
            }

            /// <summary>
            ///     Adds an option to the drop-down list.
            /// </summary>
            /// <param name = "option">Option to add.</param>
            /// <exception cref = "ArgumentNullException">When option is null.</exception>
            public void AddOption(string option)
            {
                if (option == null)
                {
                    throw new System.ArgumentNullException("option");
                }

                if (!options.Contains(option))
                {
                    options.Add(option);
                    BlockDefinition.AddDropDownOption(option);
                }
            }

            /// <summary>
            ///     Sets the displayed options.
            ///     Replaces existing options.
            /// </summary>
            /// <param name = "optionsToSet">Options to set.</param>
            /// <exception cref = "ArgumentNullException">When optionsToSet is null.</exception>
            public void SetOptions(System.Collections.Generic.IEnumerable<System.String> optionsToSet)
            {
                if (optionsToSet == null)
                {
                    throw new System.ArgumentNullException("optionsToSet");
                }

                ClearOptions();
                foreach (string option in optionsToSet)
                {
                    AddOption(option);
                }

                if (Selected == null || !System.Linq.Enumerable.Contains(optionsToSet, Selected))
                {
                    Selected = System.Linq.Enumerable.FirstOrDefault(optionsToSet);
                }
            }

            internal override void LoadResult(Skyline.DataMiner.Automation.UIResults uiResults)
            {
                string selectedValue = Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.UiResultsExtensions.GetString(uiResults, this);
                if (WantsOnChange)
                {
                    changed = selectedValue != Selected;
                }

                previous = Selected;
                Selected = selectedValue;
            }

            /// <inheritdoc/>
            internal override void RaiseResultEvents()
            {
                if (changed && (OnChanged != null))
                {
                    OnChanged(this, new Skyline.DataMiner.DeveloperCommunityLibrary.InteractiveAutomationToolkit.DropDown.DropDownChangedEventArgs(Selected, previous));
                }

                changed = false;
            }

            private void ClearOptions()
            {
                options.Clear();
                RecreateUiBlock();
            }

            /// <summary>
            ///     Provides data for the <see cref = "Changed"/> event.
            /// </summary>
            public class DropDownChangedEventArgs : System.EventArgs
            {
                internal DropDownChangedEventArgs(string selected, string previous)
                {
                    Selected = selected;
                    Previous = previous;
                }

                /// <summary>
                ///     Gets the previously selected option.
                /// </summary>
                public string Previous
                {
                    get;
                    private set;
                }

                /// <summary>
                ///     Gets the option that has been selected.
                /// </summary>
                public string Selected
                {
                    get;
                    private set;
                }
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

            /// <summary>
            /// Ugly method to clear the internal list of DropDown items that can't be accessed.
            /// </summary>
            protected void RecreateUiBlock()
            {
                Skyline.DataMiner.Automation.UIBlockDefinition newUiBlockDefinition = new Skyline.DataMiner.Automation.UIBlockDefinition();
                System.Reflection.PropertyInfo[] propertyInfo = typeof(Skyline.DataMiner.Automation.UIBlockDefinition).GetProperties();
                foreach (System.Reflection.PropertyInfo property in propertyInfo)
                {
                    if (property.CanWrite)
                    {
                        property.SetValue(newUiBlockDefinition, property.GetValue(blockDefinition));
                    }
                }

                blockDefinition = newUiBlockDefinition;
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
}