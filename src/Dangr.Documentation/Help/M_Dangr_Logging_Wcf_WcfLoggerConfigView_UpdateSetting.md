# WcfLoggerConfigView.UpdateSetting Method 
 

Updates the specified setting within the <a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected override void UpdateSetting(
	string settingName,
	string settingValue
)
```

**VB**<br />
``` VB
Protected Overrides Sub UpdateSetting ( 
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
) override
```


#### Parameters
&nbsp;<dl><dt>settingName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the setting to update.</dd><dt>settingValue</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The new value of the setting.</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Logging_Wcf_WcfLoggerConfigView">WcfLoggerConfigView Class</a><br /><a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />