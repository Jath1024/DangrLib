# Wire Class
 

\[Missing <summary> documentation for "T:Dangr.Simulation.Connections.Wire"\]


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="T_Dangr_Simulation_Types_SimulationEntity">Dangr.Simulation.Types.SimulationEntity</a><br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Dangr_Simulation_Components_SimulationComponent">Dangr.Simulation.Components.SimulationComponent</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dangr.Simulation.Connections.Wire<br />
**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Connections">Dangr.Simulation.Connections</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class Wire : SimulationComponent
```

**VB**<br />
``` VB
Public Class Wire
	Inherits SimulationComponent
```

**C++**<br />
``` C++
public ref class Wire : public SimulationComponent
```

The Wire type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Connections_Wire__ctor">Wire</a></td><td>
Initializes a new instance of the Wire class</td></tr></table>&nbsp;
<a href="#wire-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Connections_Wire_BitWidth">BitWidth</a></td><td /></tr><tr><td>![Protected property](media/protproperty.gif "Protected property")</td><td><a href="P_Dangr_Simulation_Types_SimulationEntity_Engine">Engine</a></td><td>
Gets the <a href="T_Dangr_Simulation_SimulationEngine">SimulationEngine</a> this <a href="T_Dangr_Simulation_Types_SimulationEntity">SimulationEntity</a> is a part of.
 (Inherited from <a href="T_Dangr_Simulation_Types_SimulationEntity">SimulationEntity</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Types_SimulationEntity_Id">Id</a></td><td>
Gets the globally unique identifier for this <a href="T_Dangr_Simulation_Types_SimulationEntity">SimulationEntity</a> .
 (Inherited from <a href="T_Dangr_Simulation_Types_SimulationEntity">SimulationEntity</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Connections_Wire_PullDirection">PullDirection</a></td><td /></tr></table>&nbsp;
<a href="#wire-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Connections_Wire_Connect_1">Connect(SimulationEngine, IConnection[])</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Connections_Wire_Connect">Connect(Wire, IConnection[])</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Simulation_Connections_Wire_OnDataValueChanged">OnDataValueChanged</a></td><td /></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Simulation_Components_SimulationComponent_OnInputUpdated">OnInputUpdated</a></td><td> (Inherited from <a href="T_Dangr_Simulation_Components_SimulationComponent">SimulationComponent</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Connections_Wire_Update">Update</a></td><td> (Overrides <a href="M_Dangr_Simulation_Components_SimulationComponent_Update">SimulationComponent.Update()</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Connections_Wire_UpdateInput">UpdateInput</a></td><td /></tr></table>&nbsp;
<a href="#wire-class">Back to Top</a>

## Events
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Dangr_Simulation_Connections_Wire_DataValueChanged">DataValueChanged</a></td><td /></tr></table>&nbsp;
<a href="#wire-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Simulation_Connections_Wire_inputConnections">inputConnections</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Simulation_Components_SimulationComponent_updateScheduled">updateScheduled</a></td><td> (Inherited from <a href="T_Dangr_Simulation_Components_SimulationComponent">SimulationComponent</a>.)</td></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Simulation_Connections_Wire_value">value</a></td><td /></tr></table>&nbsp;
<a href="#wire-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Simulation_Connections">Dangr.Simulation.Connections Namespace</a><br />