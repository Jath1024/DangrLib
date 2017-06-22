# BitValueExtensions.And Method (BitValue, BitValue, Boolean)
 

Logical Ands the specified values if they ar binary. Returns <a href="T_Dangr_Simulation_Types_BitValue">Error</a> if either value is <a href="T_Dangr_Simulation_Types_BitValue">Error</a> . If either value is <a href="T_Dangr_Simulation_Types_BitValue">Floating</a> , then the *ignoreFloating* parameter determines if the result should be <a href="T_Dangr_Simulation_Types_BitValue">Error</a> ( `false` ) or pass through the other value ( `true` ).

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static BitValue And(
	this BitValue a,
	BitValue b,
	bool ignoreFloating
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function And ( 
	a As BitValue,
	b As BitValue,
	ignoreFloating As Boolean
) As BitValue
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
static BitValue And(
	BitValue a, 
	BitValue b, 
	bool ignoreFloating
)
```


#### Parameters
&nbsp;<dl><dt>a</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a><br />The value.</dd><dt>b</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a><br />The other value.</dd><dt>ignoreFloating</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />Indicates whether floating values should be ignored.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a><br />The result value.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_BitValueExtensions">BitValueExtensions Class</a><br /><a href="Overload_Dangr_Simulation_Types_BitValueExtensions_And">And Overload</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />