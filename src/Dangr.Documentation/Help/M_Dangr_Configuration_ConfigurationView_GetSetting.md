# ConfigurationView.GetSetting Method 
 

Gets the setting with the specified name.

**Namespace:**&nbsp;<a href="N_Dangr_Configuration">Dangr.Configuration</a><br />**Assembly:**&nbsp;Dangr.Configuration (in Dangr.Configuration.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public string GetSetting(
	string name
)
```

**VB**<br />
``` VB
Public Function GetSetting ( 
	name As String
) As String
```

**C++**<br />
``` C++
public:
String^ GetSetting(
	String^ name
)
```


#### Parameters
&nbsp;<dl><dt>name</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the setting to get.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a><br />The value of the setting with the specified name.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/3w1b3114" target="_blank">ArgumentException</a></td><td>Thrown when there is no setting with the specified key.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView Class</a><br /><a href="N_Dangr_Configuration">Dangr.Configuration Namespace</a><br />