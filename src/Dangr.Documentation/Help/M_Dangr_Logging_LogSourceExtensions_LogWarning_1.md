# LogSourceExtensions.LogWarning Method (ILogSource, String, Object)
 

Logs a warning.

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static void LogWarning(
	this ILogSource logSource,
	string feature,
	Object message
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Sub LogWarning ( 
	logSource As ILogSource,
	feature As String,
	message As Object
)
```

**C++**<br />
``` C++
public:
[ExtensionAttribute]
static void LogWarning(
	ILogSource^ logSource, 
	String^ feature, 
	Object^ message
)
```


#### Parameters
&nbsp;<dl><dt>logSource</dt><dd>Type: <a href="T_Dangr_Logging_ILogSource">Dangr.Logging.ILogSource</a><br />The <a href="T_Dangr_Logging_ILogSource">ILogSource</a> used to log the message.</dd><dt>feature</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The feature gating this *message* logging.</dd><dt>message</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />The message to log.</dd></dl>

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="T_Dangr_Logging_ILogSource">ILogSource</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions Class</a><br /><a href="Overload_Dangr_Logging_LogSourceExtensions_LogWarning">LogWarning Overload</a><br /><a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />