# StringExtensions.IsCapsCase Method 
 

Determines whether the specified string is caps case.

**Namespace:**&nbsp;<a href="N_Dangr_Util">Dangr.Util</a><br />**Assembly:**&nbsp;Dangr.Util (in Dangr.Util.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static bool IsCapsCase(
	this string capsString
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function IsCapsCase ( 
	capsString As String
) As Boolean
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
static bool IsCapsCase(
	String^ capsString
)
```


#### Parameters
&nbsp;<dl><dt>capsString</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The caps string.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />`true` if the specified string is caps case; otherwise, `false` .

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Util_StringExtensions">StringExtensions Class</a><br /><a href="N_Dangr_Util">Dangr.Util Namespace</a><br />