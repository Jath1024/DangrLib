# ListExtensions.Peek(*T*) Method 
 

Returns the value from the end of the *list* without removing it.

**Namespace:**&nbsp;<a href="N_Dangr_Collections">Dangr.Collections</a><br />**Assembly:**&nbsp;Dangr.Util (in Dangr.Util.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static T Peek<T>(
	this List<T> list
)

```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function Peek(Of T) ( 
	list As List(Of T)
) As T
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
generic<typename T>
static T Peek(
	List<T>^ list
)
```


#### Parameters
&nbsp;<dl><dt>list</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">System.Collections.Generic.List</a>(*T*)<br />The list to peek an object from.</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>The type stored in the list.</dd></dl>

#### Return Value
Type: *T*<br />The object peeked from the list.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="http://msdn2.microsoft.com/en-us/library/6sh2ey19" target="_blank">List</a>(*T*). When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Collections_ListExtensions">ListExtensions Class</a><br /><a href="N_Dangr_Collections">Dangr.Collections Namespace</a><br />