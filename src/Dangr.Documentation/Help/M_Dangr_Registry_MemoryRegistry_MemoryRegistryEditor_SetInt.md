# MemoryRegistry.MemoryRegistryEditor.SetInt Method 
 

Set an int value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Registry">Dangr.Registry</a><br />**Assembly:**&nbsp;Dangr.Registry (in Dangr.Registry.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public IRegistryEditor SetInt(
	string key,
	int value
)
```

**VB**<br />
``` VB
Public Function SetInt ( 
	key As String,
	value As Integer
) As IRegistryEditor
```

**C++**<br />
``` C++
public:
virtual IRegistryEditor^ SetInt(
	String^ key, 
	int value
) sealed
```


#### Parameters
&nbsp;<dl><dt>key</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The key used to store the value in the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</dd><dt>value</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The value to store in the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor</a><br />A reference to this <a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor</a> instance that can be used to chain calls together.

#### Implements
<a href="M_Dangr_Registry_IRegistryEditor_SetInt">IRegistryEditor.SetInt(String, Int32)</a><br />

## See Also


#### Reference
<a href="T_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor">MemoryRegistry.MemoryRegistryEditor Class</a><br /><a href="N_Dangr_Registry">Dangr.Registry Namespace</a><br />