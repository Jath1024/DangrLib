# DataValue.Split Method 
 

Creates a new array of <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>s that are created by splitting the given <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a> in chunks specified by the bitWidths parameter. The sum of all bit widths must be equal to the bitwidth of the input <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static DataValue[] Split(
	DataValue value,
	params int[] bitWidths
)
```

**VB**<br />
``` VB
Public Shared Function Split ( 
	value As DataValue,
	ParamArray bitWidths As Integer()
) As DataValue()
```

**C++**<br />
``` C++
public:
static array<DataValue^>^ Split(
	DataValue^ value, 
	... array<int>^ bitWidths
)
```


#### Parameters
&nbsp;<dl><dt>value</dt><dd>Type: <a href="T_Dangr_Simulation_Types_DataValue">Dangr.Simulation.Types.DataValue</a><br />The value to split.</dd><dt>bitWidths</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a>[]<br />The bit widths of the requested split parts.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>[]<br />An array of newly created <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>s.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_DataValue">DataValue Class</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />