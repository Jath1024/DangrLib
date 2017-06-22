# LogEntry.TimeStamp Property 
 

Gets the timestamp when this <a href="T_Dangr_Logging_LogEntry">LogEntry</a> was created.

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
[DataMemberAttribute(Order = 2, IsRequired = true)]
public DateTimeOffset TimeStamp { get; private set; }
```

**VB**<br />
``` VB
<DataMemberAttribute(Order := 2, IsRequired := true)>
Public Property TimeStamp As DateTimeOffset
	Get
	Private Set
```

**C++**<br />
``` C++
public:
[DataMemberAttribute(Order = 2, IsRequired = true)]
property DateTimeOffset TimeStamp {
	DateTimeOffset get ();
	private: void set (DateTimeOffset value);
}
```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/bb341783" target="_blank">DateTimeOffset</a>

## See Also


#### Reference
<a href="T_Dangr_Logging_LogEntry">LogEntry Class</a><br /><a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />