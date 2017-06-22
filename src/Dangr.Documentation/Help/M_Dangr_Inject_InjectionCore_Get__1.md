# InjectionCore.Get(*T*) Method 
 

Gets an instance of the dependency defined with the specified type.

**Namespace:**&nbsp;<a href="N_Dangr_Inject">Dangr.Inject</a><br />**Assembly:**&nbsp;Dangr.Inject (in Dangr.Inject.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public T Get<T>()

```

**VB**<br />
``` VB
Public Function Get(Of T) As T
```

**C++**<br />
``` C++
public:
generic<typename T>
T Get()
```


#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>The dependency type.</dd></dl>

#### Return Value
Type: *T*<br />\[Missing <returns> documentation for "M:Dangr.Inject.InjectionCore.Get``1"\]

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/2asft85a" target="_blank">InvalidOperationException</a></td><td>If no dependency with the specified type is defined.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Inject_InjectionCore">InjectionCore Class</a><br /><a href="Overload_Dangr_Inject_InjectionCore_Get">Get Overload</a><br /><a href="N_Dangr_Inject">Dangr.Inject Namespace</a><br />