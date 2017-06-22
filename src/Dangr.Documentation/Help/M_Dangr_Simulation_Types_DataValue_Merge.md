# DataValue.Merge Method 
 

Creates a new <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a> that has a value equal to all of the specified values merged together, using the specified pull behavior. To merge values, each bit is compared. If there is more than one non-<a href="T_Dangr_Simulation_Types_BitValue">Floating</a> value for that bit, the resulting bit is <a href="T_Dangr_Simulation_Types_BitValue">Error</a>. If there is only one non-<a href="T_Dangr_Simulation_Types_BitValue">Floating</a> value for that bit, the resulting bit is equal to that value. If all values for that bit are <a href="T_Dangr_Simulation_Types_BitValue">Floating</a>, the resulting bit is determined by the given <a href="T_Dangr_Simulation_Types_PullBehavior">PullBehavior</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static DataValue Merge(
	ICollection<DataValue> values,
	PullBehavior pullBehavior
)
```

**VB**<br />
``` VB
Public Shared Function Merge ( 
	values As ICollection(Of DataValue),
	pullBehavior As PullBehavior
) As DataValue
```

**C++**<br />
``` C++
public:
static DataValue^ Merge(
	ICollection<DataValue^>^ values, 
	PullBehavior pullBehavior
)
```


#### Parameters
&nbsp;<dl><dt>values</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/92t2ye13" target="_blank">System.Collections.Generic.ICollection</a>(<a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>)<br />The values to merge.</dd><dt>pullBehavior</dt><dd>Type: <a href="T_Dangr_Simulation_Types_PullBehavior">Dangr.Simulation.Types.PullBehavior</a><br />The pull behavior to use when a bit for all input values is <a href="T_Dangr_Simulation_Types_BitValue">Floating</a>.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a><br />A newly created <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_DataValue">DataValue Class</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />