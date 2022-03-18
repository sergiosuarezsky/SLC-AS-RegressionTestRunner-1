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
            /// Defines extension methods on the <see cref = "Engine"/> class.
            /// </summary>
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("SLManagedAutomation.dll")]
            [Skyline.DataMiner.Library.Common.Attributes.DllImport("SLNetTypes.dll")]
            public static class EngineExtensions
            {
#pragma warning disable S1104 // Fields should not have public accessibility

#pragma warning disable S2223 // Non-constant static fields should not be visible

                /// <summary>
                /// Allows an override of the behavior of GetDms to return a Fake or Mock of <see cref = "IDms"/>.
                /// Important: When this is used, unit tests should never be run in parallel.
                /// </summary>
                public static System.Func<Skyline.DataMiner.Automation.Engine, Skyline.DataMiner.Library.Common.IDms> OverrideGetDms = engine =>
                {
                    return new Skyline.DataMiner.Library.Common.Dms(new Skyline.DataMiner.Library.Common.ConnectionCommunication(Skyline.DataMiner.Automation.Engine.SLNetRaw));
                }

                ;
#pragma warning restore S2223 // Non-constant static fields should not be visible

#pragma warning restore S1104 // Fields should not have public accessibility

                /// <summary>
                /// Retrieves an object implementing the <see cref = "IDms"/> interface.
                /// </summary>
                /// <param name = "engine">The <see cref = "Engine"/> instance.</param>
                /// <exception cref = "ArgumentNullException"><paramref name = "engine"/> is <see langword = "null"/>.</exception>
                /// <returns>The <see cref = "IDms"/> object.</returns>
                public static Skyline.DataMiner.Library.Common.IDms GetDms(this Skyline.DataMiner.Automation.Engine engine)
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
            /// Class containing helper methods.
            /// </summary>
            internal static class HelperClass
            {
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
                ///     Gets the DataMiner Agents found in the DataMiner System.
                /// </summary>
                /// <returns>The DataMiner Agents in the DataMiner System.</returns>
                System.Collections.Generic.ICollection<Skyline.DataMiner.Library.Common.IDma> GetAgents();
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
            /// Represents the parent for every type of object that can be present on a DataMiner system.
            /// </summary>
            internal abstract class DmsObject
            {
                /// <summary>
                /// The DataMiner system the object belongs to.
                /// </summary>
                protected readonly Skyline.DataMiner.Library.Common.IDms dms;
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

            namespace Properties
            {
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