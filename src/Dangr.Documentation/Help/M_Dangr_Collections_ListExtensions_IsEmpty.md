# ListExtensions.IsEmpty Method 
 

Gets whether the *list* is empty.

**Namespace:**&nbsp;<a href="N_Dangr_Collections">Dangr.Collections</a><br />**Assembly:**&nbsp;Dangr.Util (in Dangr.Util.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static bool IsEmpty(
	this IList list
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function IsEmpty ( 
	list As IList
) As Boolean
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
static bool IsEmpty(
	IList^ list
)
```


#### Parameters
&nbsp;<dl><dt>list</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/30ft6hw7" target="_blank">System.Collections.IList</a><br />The list to check.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />True if there are no elements left in the list.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="http://msdn2.microsoft.com/en-us/library/30ft6hw7" target="_blank">IList</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Collections_ListExtensions">ListExtensions Class</a><br /><a href="N_Dangr_Collections">Dangr.Collections Namespace</a><br />