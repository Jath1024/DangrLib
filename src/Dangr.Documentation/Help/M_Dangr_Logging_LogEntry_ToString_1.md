# LogEntry.ToString Method (String, String)
 

Returns a string that represents the current <a href="T_Dangr_Logging_LogEntry">LogEntry</a> in the specified format.

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
public string ToString(
	string logFormat,
	string timeStampFormat = "yy.MM.dd HH:mm:ss.fffff"
)
```

**VB**<br />
``` VB
Public Function ToString ( 
	logFormat As String,
	Optional timeStampFormat As String = "yy.MM.dd HH:mm:ss.fffff"
) As String
```

**C++**<br />
``` C++
public:
String^ ToString(
	String^ logFormat, 
	String^ timeStampFormat = L"yy.MM.dd HH:mm:ss.fffff"
)
```


#### Parameters
&nbsp;<dl><dt>logFormat</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The format to use to log the <a href="T_Dangr_Logging_LogEntry">LogEntry</a>.</dd><dt>timeStampFormat (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The format to use for the <a href="T_Dangr_Logging_LogEntry">LogEntry</a> timestamp.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a><br />\[Missing <returns> documentation for "M:Dangr.Logging.LogEntry.ToString(System.String,System.String)"\]

## See Also


#### Reference
<a href="T_Dangr_Logging_LogEntry">LogEntry Class</a><br /><a href="Overload_Dangr_Logging_LogEntry_ToString">ToString Overload</a><br /><a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />