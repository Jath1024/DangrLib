# ILogger.Log Method (LogLevel, String, String, Object)
 

Logs a *message* at the specified level.

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
void Log(
	LogLevel level,
	string feature,
	string category,
	Object message
)
```

**VB**<br />
``` VB
Sub Log ( 
	level As LogLevel,
	feature As String,
	category As String,
	message As Object
)
```

**C++**<br />
``` C++
void Log(
	LogLevel level, 
	String^ feature, 
	String^ category, 
	Object^ message
)
```


#### Parameters
&nbsp;<dl><dt>level</dt><dd>Type: <a href="T_Dangr_Logging_LogLevel">Dangr.Logging.LogLevel</a><br />The <a href="T_Dangr_Logging_LogLevel">LogLevel</a> .</dd><dt>feature</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The feature gating this *message* logging.</dd><dt>category</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The category.</dd><dt>message</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />The message.</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Logging_ILogger">ILogger Interface</a><br /><a href="Overload_Dangr_Logging_ILogger_Log">Log Overload</a><br /><a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />