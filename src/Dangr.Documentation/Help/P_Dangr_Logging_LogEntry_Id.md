# LogEntry.Id Property 
 

Gets the unique Id for this <a href="T_Dangr_Logging_LogEntry">LogEntry</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
[DataMemberAttribute(Order = 1, IsRequired = true)]
public ulong Id { get; private set; }
```

**VB**<br />
``` VB
<DataMemberAttribute(Order := 1, IsRequired := true)>
Public Property Id As ULong
	Get
	Private Set
```

**C++**<br />
``` C++
public:
[DataMemberAttribute(Order = 1, IsRequired = true)]
property unsigned long long Id {
	unsigned long long get ();
	private: void set (unsigned long long value);
}
```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/06cf7918" target="_blank">UInt64</a>

## See Also


#### Reference
<a href="T_Dangr_Logging_LogEntry">LogEntry Class</a><br /><a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />