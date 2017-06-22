# LogEntry.LogLevel Property 
 

Gets the LogLevel used to log this <a href="T_Dangr_Logging_LogEntry">LogEntry</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
[DataMemberAttribute(Order = 3, IsRequired = true)]
public LogLevel LogLevel { get; private set; }
```

**VB**<br />
``` VB
<DataMemberAttribute(Order := 3, IsRequired := true)>
Public Property LogLevel As LogLevel
	Get
	Private Set
```

**C++**<br />
``` C++
public:
[DataMemberAttribute(Order = 3, IsRequired = true)]
property LogLevel LogLevel {
	LogLevel get ();
	private: void set (LogLevel value);
}
```


#### Property Value
Type: <a href="T_Dangr_Logging_LogLevel">LogLevel</a>

## See Also


#### Reference
<a href="T_Dangr_Logging_LogEntry">LogEntry Class</a><br /><a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />