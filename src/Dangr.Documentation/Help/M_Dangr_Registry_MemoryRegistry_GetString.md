# MemoryRegistry.GetString Method 
 

Gets a string value from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Registry">Dangr.Registry</a><br />**Assembly:**&nbsp;Dangr.Registry (in Dangr.Registry.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public string GetString(
	string key,
	string defaultValue
)
```

**VB**<br />
``` VB
Public Function GetString ( 
	key As String,
	defaultValue As String
) As String
```

**C++**<br />
``` C++
public:
virtual String^ GetString(
	String^ key, 
	String^ defaultValue
) sealed
```


#### Parameters
&nbsp;<dl><dt>key</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The key used to store the value in the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</dd><dt>defaultValue</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The default value to return if the specified key is not found.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a><br />The value stored in the registry with the specified key, or the given default value if not found.

#### Implements
<a href="M_Dangr_Registry_IRegistry_GetString">IRegistry.GetString(String, String)</a><br />

## See Also


#### Reference
<a href="T_Dangr_Registry_MemoryRegistry">MemoryRegistry Class</a><br /><a href="N_Dangr_Registry">Dangr.Registry Namespace</a><br />