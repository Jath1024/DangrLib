# InjectionCore.Get Method (String)
 

Gets an instance of the dependency defined with the specified name.

**Namespace:**&nbsp;<a href="N_Dangr_Inject">Dangr.Inject</a><br />**Assembly:**&nbsp;Dangr.Inject (in Dangr.Inject.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public Object Get(
	string name
)
```

**VB**<br />
``` VB
Public Function Get ( 
	name As String
) As Object
```

**C++**<br />
``` C++
public:
Object^ Get(
	String^ name
)
```


#### Parameters
&nbsp;<dl><dt>name</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The dependency name.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a><br />\[Missing <returns> documentation for "M:Dangr.Inject.InjectionCore.Get(System.String)"\]

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/2asft85a" target="_blank">InvalidOperationException</a></td><td>If no dependency with the specified *name* is defined.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Inject_InjectionCore">InjectionCore Class</a><br /><a href="Overload_Dangr_Inject_InjectionCore_Get">Get Overload</a><br /><a href="N_Dangr_Inject">Dangr.Inject Namespace</a><br />