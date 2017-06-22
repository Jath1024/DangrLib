# LogEntry.Category Property 
 

Gets the log category for this <a href="T_Dangr_Logging_LogEntry">LogEntry</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
[DataMemberAttribute(Order = 4, IsRequired = true)]
public string Category { get; private set; }
```

**VB**<br />
``` VB
<DataMemberAttribute(Order := 4, IsRequired := true)>
Public Property Category As String
	Get
	Private Set
```

**C++**<br />
``` C++
public:
[DataMemberAttribute(Order = 4, IsRequired = true)]
property String^ Category {
	String^ get ();
	private: void set (String^ value);
}
```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>

## See Also


#### Reference
<a href="T_Dangr_Logging_LogEntry">LogEntry Class</a><br /><a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />