# DataValue.Concatenate Method 
 

Creates a new <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a> that has a value equal to all of the specified <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>s concatenated together. The sum of the bit widths of all input values must be less than <a href="F_Dangr_Simulation_Types_DataValue_MaxBitWidth">MaxBitWidth</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static DataValue Concatenate(
	params DataValue[] values
)
```

**VB**<br />
``` VB
Public Shared Function Concatenate ( 
	ParamArray values As DataValue()
) As DataValue
```

**C++**<br />
``` C++
public:
static DataValue^ Concatenate(
	... array<DataValue^>^ values
)
```


#### Parameters
&nbsp;<dl><dt>values</dt><dd>Type: <a href="T_Dangr_Simulation_Types_DataValue">Dangr.Simulation.Types.DataValue</a>[]<br />The values to concatenate.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a><br />A newly created <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_DataValue">DataValue Class</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />