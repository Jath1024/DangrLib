# OutputTypeExtensions.Convert Method (OutputType, BitValue[], BitValue[])
 

Converts the <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> array using the <a href="T_Dangr_Simulation_Types_OutputType">OutputType</a> .

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static void Convert(
	this OutputType type,
	BitValue[] value,
	ref BitValue[] output
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Sub Convert ( 
	type As OutputType,
	value As BitValue(),
	ByRef output As BitValue()
)
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
static void Convert(
	OutputType type, 
	array<BitValue>^ value, 
	array<BitValue>^% output
)
```


#### Parameters
&nbsp;<dl><dt>type</dt><dd>Type: <a href="T_Dangr_Simulation_Types_OutputType">Dangr.Simulation.Types.OutputType</a><br />The <a href="T_Dangr_Simulation_Types_OutputType">OutputType</a> .</dd><dt>value</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a>[]<br />The <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> array.</dd><dt>output</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a>[]<br />The <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> array to store the result in.</dd></dl>

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="T_Dangr_Simulation_Types_OutputType">OutputType</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_OutputTypeExtensions">OutputTypeExtensions Class</a><br /><a href="Overload_Dangr_Simulation_Types_OutputTypeExtensions_Convert">Convert Overload</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />