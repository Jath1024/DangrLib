# WriteConnection Class
 

Defines an <a href="T_Dangr_Simulation_Connections_IConnection">IConnection</a> used to write a value to a connected <a href="T_Dangr_Simulation_Connections_Wire">Wire</a> .


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Simulation.Connections.WriteConnection<br />
**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Connections">Dangr.Simulation.Connections</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class WriteConnection : IConnection
```

**VB**<br />
``` VB
Public Class WriteConnection
	Implements IConnection
```

**C++**<br />
``` C++
public ref class WriteConnection : IConnection
```

The WriteConnection type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Connections_WriteConnection__ctor">WriteConnection</a></td><td>
Initializes a new instance of the WriteConnection class.</td></tr></table>&nbsp;
<a href="#writeconnection-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private property](media/privproperty.gif "Private property")</td><td><a href="P_Dangr_Simulation_Connections_WriteConnection_ConnectedWire">ConnectedWire</a></td><td /></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Connections_WriteConnection_DataBitWidth">DataBitWidth</a></td><td>
Gets the number of data bits in the <a href="T_Dangr_Simulation_Connections_IConnection">IConnection</a> .</td></tr></table>&nbsp;
<a href="#writeconnection-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Connections_WriteConnection_ConnectTo">ConnectTo</a></td><td>
Connects this <a href="T_Dangr_Simulation_Connections_IConnection">IConnection</a> to a <a href="T_Dangr_Simulation_Connections_Wire">Wire</a> .</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Connections_WriteConnection_WriteValue">WriteValue</a></td><td>
Writes the specified <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a> to this WriteConnection .</td></tr></table>&nbsp;
<a href="#writeconnection-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Simulation_Connections">Dangr.Simulation.Connections Namespace</a><br /><a href="T_Dangr_Simulation_Connections_IConnection">Dangr.Simulation.Connections.IConnection</a><br />