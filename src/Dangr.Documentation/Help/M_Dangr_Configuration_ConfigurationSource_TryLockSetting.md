# ConfigurationSource.TryLockSetting Method 
 

Tries to lock the setting with the specified name.

**Namespace:**&nbsp;<a href="N_Dangr_Configuration">Dangr.Configuration</a><br />**Assembly:**&nbsp;Dangr.Configuration (in Dangr.Configuration.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected bool TryLockSetting(
	string settingName
)
```

**VB**<br />
``` VB
Protected Function TryLockSetting ( 
	settingName As String
) As Boolean
```

**C++**<br />
``` C++
protected:
bool TryLockSetting(
	String^ settingName
)
```


#### Parameters
&nbsp;<dl><dt>settingName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the setting to lock.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />True if the setting was successfully locked.

## See Also


#### Reference
<a href="T_Dangr_Configuration_ConfigurationSource">ConfigurationSource Class</a><br /><a href="N_Dangr_Configuration">Dangr.Configuration Namespace</a><br />