# IRegistry.GetBool Method 
 

Gets a bool value from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Registry">Dangr.Registry</a><br />**Assembly:**&nbsp;Dangr.Registry (in Dangr.Registry.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
bool GetBool(
	string key,
	bool defaultValue
)
```

**VB**<br />
``` VB
Function GetBool ( 
	key As String,
	defaultValue As Boolean
) As Boolean
```

**C++**<br />
``` C++
bool GetBool(
	String^ key, 
	bool defaultValue
)
```


#### Parameters
&nbsp;<dl><dt>key</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The key used to store the value in the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</dd><dt>defaultValue</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />The default value to return if the specified key is not found.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />The value stored in the registry with the specified key, or the given default value if not found.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/3w1b3114" target="_blank">ArgumentException</a></td><td>Thrown when the value stored with the specified key is not compatible with the requested type.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Registry_IRegistry">IRegistry Interface</a><br /><a href="N_Dangr_Registry">Dangr.Registry Namespace</a><br />