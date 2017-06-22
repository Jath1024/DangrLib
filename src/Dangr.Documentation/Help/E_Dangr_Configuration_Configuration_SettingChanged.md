# Configuration.SettingChanged Event
 

Event that is triggered when a setting in this configuration is changed.

**Namespace:**&nbsp;<a href="N_Dangr_Configuration">Dangr.Configuration</a><br />**Assembly:**&nbsp;Dangr.Configuration (in Dangr.Configuration.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public event EventHandler<SettingChangedEventArgs> SettingChanged
```

**VB**<br />
``` VB
Public Event SettingChanged As EventHandler(Of SettingChangedEventArgs)
```

**C++**<br />
``` C++
public:
 event EventHandler<SettingChangedEventArgs^>^ SettingChanged {
	void add (EventHandler<SettingChangedEventArgs^>^ value);
	void remove (EventHandler<SettingChangedEventArgs^>^ value);
}
```


#### Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/db0etb8x" target="_blank">System.EventHandler</a>(<a href="T_Dangr_Configuration_SettingChangedEventArgs">SettingChangedEventArgs</a>)

## See Also


#### Reference
<a href="T_Dangr_Configuration_Configuration">Configuration Class</a><br /><a href="N_Dangr_Configuration">Dangr.Configuration Namespace</a><br />