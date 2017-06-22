# DebugConfigurationSource.TryLockSetting Method 
 

Tries to lock the setting with the specified name.

**Namespace:**&nbsp;<a href="N_Dangr_Configuration_Sources">Dangr.Configuration.Sources</a><br />**Assembly:**&nbsp;Dangr.Configuration (in Dangr.Configuration.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public bool TryLockSetting(
	string settingName
)
```

**VB**<br />
``` VB
Public Function TryLockSetting ( 
	settingName As String
) As Boolean
```

**C++**<br />
``` C++
public:
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
<a href="T_Dangr_Configuration_Sources_DebugConfigurationSource">DebugConfigurationSource Class</a><br /><a href="N_Dangr_Configuration_Sources">Dangr.Configuration.Sources Namespace</a><br />