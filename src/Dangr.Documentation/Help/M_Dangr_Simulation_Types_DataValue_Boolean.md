# DataValue.Boolean Method 
 

Creates a new <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a> from a boolean value. The binary value with be 1 for `true` and 0 for `false`.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static DataValue Boolean(
	bool value,
	int bitWidth
)
```

**VB**<br />
``` VB
Public Shared Function Boolean ( 
	value As Boolean,
	bitWidth As Integer
) As DataValue
```

**C++**<br />
``` C++
public:
static DataValue^ Boolean(
	bool value, 
	int bitWidth
)
```


#### Parameters
&nbsp;<dl><dt>value</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />The boolean value to create the <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>.</dd><dt>bitWidth</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The bitwidth of the new <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a><br />A newly created <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_DataValue">DataValue Class</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />