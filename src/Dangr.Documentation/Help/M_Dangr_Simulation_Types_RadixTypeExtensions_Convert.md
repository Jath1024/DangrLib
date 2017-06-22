# RadixTypeExtensions.Convert Method 
 

Converts the specified <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a> to a string using the given <a href="T_Dangr_Simulation_Types_RadixType">RadixType</a> .

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static string Convert(
	this RadixType radix,
	DataValue value
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function Convert ( 
	radix As RadixType,
	value As DataValue
) As String
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
static String^ Convert(
	RadixType radix, 
	DataValue^ value
)
```


#### Parameters
&nbsp;<dl><dt>radix</dt><dd>Type: <a href="T_Dangr_Simulation_Types_RadixType">Dangr.Simulation.Types.RadixType</a><br />The <a href="T_Dangr_Simulation_Types_RadixType">RadixType</a> .</dd><dt>value</dt><dd>Type: <a href="T_Dangr_Simulation_Types_DataValue">Dangr.Simulation.Types.DataValue</a><br />The value.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a><br />A string of the <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a> interpreted using the given <a href="T_Dangr_Simulation_Types_RadixType">RadixType</a> .

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="T_Dangr_Simulation_Types_RadixType">RadixType</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Simulation_Types_RadixTypeExtensions">RadixTypeExtensions Class</a><br /><a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />