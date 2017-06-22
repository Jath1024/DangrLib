# ConfigurationView.UpdateSetting Method 
 

Updates the specified setting within the <a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView</a> .

**Namespace:**&nbsp;<a href="N_Dangr_Configuration">Dangr.Configuration</a><br />**Assembly:**&nbsp;Dangr.Configuration (in Dangr.Configuration.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected abstract void UpdateSetting(
	string settingName,
	string settingValue
)
```

**VB**<br />
``` VB
Protected MustOverride Sub UpdateSetting ( 
	settingName As String,
	settingValue As String
)
```

**C++**<br />
``` C++
protected:
virtual void UpdateSetting(
	String^ settingName, 
	String^ settingValue
) abstract
```


#### Parameters
&nbsp;<dl><dt>settingName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the setting to update.</dd><dt>settingValue</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The new value of the setting.</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView Class</a><br /><a href="N_Dangr_Configuration">Dangr.Configuration Namespace</a><br />