# InitializableExtensions.Initialize(*T*) Method 
 

Initializes the specified <a href="T_Dangr_Util_IInitializable">IInitializable</a> instance, and returns a typed reference to it.

**Namespace:**&nbsp;<a href="N_Dangr_Util">Dangr.Util</a><br />**Assembly:**&nbsp;Dangr.Util (in Dangr.Util.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static T Initialize<T>(
	this T initializable
)
where T : IInitializable

```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function Initialize(Of T As IInitializable) ( 
	initializable As T
) As T
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
generic<typename T>
where T : IInitializable
static T Initialize(
	T initializable
)
```


#### Parameters
&nbsp;<dl><dt>initializable</dt><dd>Type: *T*<br />The <a href="T_Dangr_Util_IInitializable">IInitializable</a> .</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>The type of <a href="T_Dangr_Util_IInitializable">IInitializable</a> to initialize.</dd></dl>

#### Return Value
Type: *T*<br />The reference that was initialized.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type . When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Util_InitializableExtensions">InitializableExtensions Class</a><br /><a href="N_Dangr_Util">Dangr.Util Namespace</a><br />