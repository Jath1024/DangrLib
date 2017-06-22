# IRegistryEditor.Remove Method 
 

Marks a value for deletion from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>. Will be applied before any sets in the same batch from this editor.

**Namespace:**&nbsp;<a href="N_Dangr_Registry">Dangr.Registry</a><br />**Assembly:**&nbsp;Dangr.Registry (in Dangr.Registry.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
IRegistryEditor Remove(
	string key
)
```

**VB**<br />
``` VB
Function Remove ( 
	key As String
) As IRegistryEditor
```

**C++**<br />
``` C++
IRegistryEditor^ Remove(
	String^ key
)
```


#### Parameters
&nbsp;<dl><dt>key</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The key used to store the value in the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor</a><br />A reference to this <a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor</a> instance that can be used to chain calls together.

## See Also


#### Reference
<a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor Interface</a><br /><a href="N_Dangr_Registry">Dangr.Registry Namespace</a><br />