# BitValueExtensions.Or Method (BitValue[], BitValue[], BitValue[], Boolean)
 

Performs a bitwise logcial <a href="M_Dangr_Simulation_Types_BitValueExtensions_Or">Or(BitValue, BitValue, Boolean)</a> of the specified values and stores the result in the array specified by output. Output can be equal to one of the inputs.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static void Or(
	this BitValue[] a,
	BitValue[] b,
	ref BitValue[] output,
	bool ignoreFloating
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Sub Or ( 
	a As BitValue(),
	b As BitValue(),
	ByRef output As BitValue(),
	ignoreFloating As Boolean
)
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
static void Or(
	array<BitValue>^ a, 
	array<BitValue>^ b, 
	array<BitValue>^% output, 
	bool ignoreFloating
)
```


#### Parameters
&nbsp;<dl><dt>a</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a>[]<br />The value.</dd><dt>b</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a>[]<br />The other value.</dd><dt>output</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a>[]<br />The output array.</dd><dt>ignoreFloating</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />Indicates whether floating values should be ignored.</dd></dl>

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type . When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_BitValueExtensions">BitValueExtensions Class</a><br /><a href="Overload_Dangr_Simulation_Types_BitValueExtensions_Or">Or Overload</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />