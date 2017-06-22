# DataValue.Item Property 
 

Gets the <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> of the bit at the specified index.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public BitValue this[
	int index
] { get; }
```

**VB**<br />
``` VB
Public ReadOnly Default Property Item ( 
	index As Integer
) As BitValue
	Get
```

**C++**<br />
``` C++
public:
property BitValue default[int index] {
	BitValue get (int index);
}
```


#### Parameters
&nbsp;<dl><dt>index</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The index.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a><br />The <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a>.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/77c5xay2" target="_blank">IndexOutOfRangeException</a></td><td>If the index specified is < 0 or >= <a href="P_Dangr_Simulation_Types_DataValue_BitWidth">BitWidth</a>.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_DataValue">DataValue Class</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />