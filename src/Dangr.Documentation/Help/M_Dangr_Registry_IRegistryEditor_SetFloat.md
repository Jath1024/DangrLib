# IRegistryEditor.SetFloat Method 
 

Set a float value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Registry">Dangr.Registry</a><br />**Assembly:**&nbsp;Dangr.Registry (in Dangr.Registry.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
IRegistryEditor SetFloat(
	string key,
	float value
)
```

**VB**<br />
``` VB
Function SetFloat ( 
	key As String,
	value As Single
) As IRegistryEditor
```

**C++**<br />
``` C++
IRegistryEditor^ SetFloat(
	String^ key, 
	float value
)
```


#### Parameters
&nbsp;<dl><dt>key</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The key used to store the value in the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</dd><dt>value</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/3www918f" target="_blank">System.Single</a><br />The value to store in the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor</a><br />A reference to this <a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor</a> instance that can be used to chain calls together.

## See Also


#### Reference
<a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor Interface</a><br /><a href="N_Dangr_Registry">Dangr.Registry Namespace</a><br />