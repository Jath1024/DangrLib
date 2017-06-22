# ConfigurationSource.TryAddOrUpdateSetting Method 
 

Tries to add or update a setting in the registered <a href="T_Dangr_Configuration_Configuration">Configuration</a> .

**Namespace:**&nbsp;<a href="N_Dangr_Configuration">Dangr.Configuration</a><br />**Assembly:**&nbsp;Dangr.Configuration (in Dangr.Configuration.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected bool TryAddOrUpdateSetting(
	string name,
	string value
)
```

**VB**<br />
``` VB
Protected Function TryAddOrUpdateSetting ( 
	name As String,
	value As String
) As Boolean
```

**C++**<br />
``` C++
protected:
bool TryAddOrUpdateSetting(
	String^ name, 
	String^ value
)
```


#### Parameters
&nbsp;<dl><dt>name</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the setting.</dd><dt>value</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The new value for the setting.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />False if the setting is locked.

## See Also


#### Reference
<a href="T_Dangr_Configuration_ConfigurationSource">ConfigurationSource Class</a><br /><a href="N_Dangr_Configuration">Dangr.Configuration Namespace</a><br />