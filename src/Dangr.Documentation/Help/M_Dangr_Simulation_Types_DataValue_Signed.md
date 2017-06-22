# DataValue.Signed Method 
 

Creates a new <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a> that has a binary value equal to specified the 2's complement signed long value.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static DataValue Signed(
	long value,
	int bitWidth
)
```

**VB**<br />
``` VB
Public Shared Function Signed ( 
	value As Long,
	bitWidth As Integer
) As DataValue
```

**C++**<br />
``` C++
public:
static DataValue^ Signed(
	long long value, 
	int bitWidth
)
```


#### Parameters
&nbsp;<dl><dt>value</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/6yy583ek" target="_blank">System.Int64</a><br />The long value to create the <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>.</dd><dt>bitWidth</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The bitwidth of the new <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>. The bit width must be large enough to contain the given value.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a><br />A newly created <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_DataValue">DataValue Class</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />