# LogicGate Class
 

\[Missing <summary> documentation for "T:Dangr.Simulation.Components.Gates.LogicGate"\]


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="T_Dangr_Simulation_Types_SimulationEntity">Dangr.Simulation.Types.SimulationEntity</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Dangr.Simulation.Components.Gates.LogicGate<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="#inheritance-hierarchy">More...</a>
**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Components_Gates">Dangr.Simulation.Components.Gates</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public abstract class LogicGate : SimulationEntity
```

**VB**<br />
``` VB
Public MustInherit Class LogicGate
	Inherits SimulationEntity
```

**C++**<br />
``` C++
public ref class LogicGate abstract : public SimulationEntity
```

The LogicGate type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Simulation_Components_Gates_LogicGate__ctor">LogicGate</a></td><td>
Initializes a new instance of the LogicGate class</td></tr></table>&nbsp;
<a href="#logicgate-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Components_Gates_LogicGate_DataBitWidth">DataBitWidth</a></td><td /></tr><tr><td>![Protected property](media/protproperty.gif "Protected property")</td><td><a href="P_Dangr_Simulation_Types_SimulationEntity_Engine">Engine</a></td><td>
Gets the <a href="T_Dangr_Simulation_SimulationEngine">SimulationEngine</a> this <a href="T_Dangr_Simulation_Types_SimulationEntity">SimulationEntity</a> is a part of.
 (Inherited from <a href="T_Dangr_Simulation_Types_SimulationEntity">SimulationEntity</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Types_SimulationEntity_Id">Id</a></td><td>
Gets the globally unique identifier for this <a href="T_Dangr_Simulation_Types_SimulationEntity">SimulationEntity</a> .
 (Inherited from <a href="T_Dangr_Simulation_Types_SimulationEntity">SimulationEntity</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Components_Gates_LogicGate_In">In</a></td><td /></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Components_Gates_LogicGate_InvertInput">InvertInput</a></td><td /></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Components_Gates_LogicGate_NumberOfInputs">NumberOfInputs</a></td><td /></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Components_Gates_LogicGate_Out">Out</a></td><td /></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Components_Gates_LogicGate_OutputType">OutputType</a></td><td /></tr></table>&nbsp;
<a href="#logicgate-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Simulation_Components_Gates_LogicGate_OnInputDataValueChanged">OnInputDataValueChanged</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#logicgate-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Simulation_Components_Gates">Dangr.Simulation.Components.Gates Namespace</a><br />

## Inheritance Hierarchy<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="T_Dangr_Simulation_Types_SimulationEntity">Dangr.Simulation.Types.SimulationEntity</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Dangr.Simulation.Components.Gates.LogicGate<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Dangr_Simulation_Components_Gates_AndGate">Dangr.Simulation.Components.Gates.AndGate</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Dangr_Simulation_Components_Gates_EvenParityGate">Dangr.Simulation.Components.Gates.EvenParityGate</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Dangr_Simulation_Components_Gates_NandGate">Dangr.Simulation.Components.Gates.NandGate</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Dangr_Simulation_Components_Gates_NorGate">Dangr.Simulation.Components.Gates.NorGate</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Dangr_Simulation_Components_Gates_OddParityGate">Dangr.Simulation.Components.Gates.OddParityGate</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Dangr_Simulation_Components_Gates_OrGate">Dangr.Simulation.Components.Gates.OrGate</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Dangr_Simulation_Components_Gates_XnorGate">Dangr.Simulation.Components.Gates.XnorGate</a><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Dangr_Simulation_Components_Gates_XorGate">Dangr.Simulation.Components.Gates.XorGate</a><br />