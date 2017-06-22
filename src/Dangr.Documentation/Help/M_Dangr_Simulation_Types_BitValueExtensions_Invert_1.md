# BitValueExtensions.Invert Method (BitValue[], BitValue[])
 

Inverts the specified *value* and stores the result in the array specified by output. Output can be equal to value.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static void Invert(
	this BitValue[] value,
	ref BitValue[] output
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Sub Invert ( 
	value As BitValue(),
	ByRef output As BitValue()
)
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
static void Invert(
	array<BitValue>^ value, 
	array<BitValue>^% output
)
```


#### Parameters
&nbsp;<dl><dt>value</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a>[]<br />The value to invert.</dd><dt>output</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a>[]<br />The output array.</dd></dl>

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type . When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_BitValueExtensions">BitValueExtensions Class</a><br /><a href="Overload_Dangr_Simulation_Types_BitValueExtensions_Invert">Invert Overload</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />