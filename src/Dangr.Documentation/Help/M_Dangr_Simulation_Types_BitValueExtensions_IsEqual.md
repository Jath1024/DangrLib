# BitValueExtensions.IsEqual Method 
 

Determines whether the specified <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> arrays are equal.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static bool IsEqual(
	this BitValue[] a,
	BitValue[] b
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function IsEqual ( 
	a As BitValue(),
	b As BitValue()
) As Boolean
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
static bool IsEqual(
	array<BitValue>^ a, 
	array<BitValue>^ b
)
```


#### Parameters
&nbsp;<dl><dt>a</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a>[]<br />The first <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> array.</dd><dt>b</dt><dd>Type: <a href="T_Dangr_Simulation_Types_BitValue">Dangr.Simulation.Types.BitValue</a>[]<br />The second <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> array.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />`true` if the specified <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> array is equal; otherwise, `false` .

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type . When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_BitValueExtensions">BitValueExtensions Class</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />