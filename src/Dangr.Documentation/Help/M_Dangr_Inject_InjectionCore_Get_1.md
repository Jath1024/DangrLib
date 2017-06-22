# InjectionCore.Get Method (Type)
 

Gets an instance of the dependency defined with the specified type.

**Namespace:**&nbsp;<a href="N_Dangr_Inject">Dangr.Inject</a><br />**Assembly:**&nbsp;Dangr.Inject (in Dangr.Inject.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public Object Get(
	Type type
)
```

**VB**<br />
``` VB
Public Function Get ( 
	type As Type
) As Object
```

**C++**<br />
``` C++
public:
Object^ Get(
	Type^ type
)
```


#### Parameters
&nbsp;<dl><dt>type</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">System.Type</a><br />The dependency type.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a><br />\[Missing <returns> documentation for "M:Dangr.Inject.InjectionCore.Get(System.Type)"\]

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/2asft85a" target="_blank">InvalidOperationException</a></td><td>If no dependency with the specified *type* is defined.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Inject_InjectionCore">InjectionCore Class</a><br /><a href="Overload_Dangr_Inject_InjectionCore_Get">Get Overload</a><br /><a href="N_Dangr_Inject">Dangr.Inject Namespace</a><br />