# LogEntry.Message Property 
 

Gets the Message that was logged.

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
[DataMemberAttribute(Order = 5, IsRequired = true)]
public Object Message { get; private set; }
```

**VB**<br />
``` VB
<DataMemberAttribute(Order := 5, IsRequired := true)>
Public Property Message As Object
	Get
	Private Set
```

**C++**<br />
``` C++
public:
[DataMemberAttribute(Order = 5, IsRequired = true)]
property Object^ Message {
	Object^ get ();
	private: void set (Object^ value);
}
```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>

## See Also


#### Reference
<a href="T_Dangr_Logging_LogEntry">LogEntry Class</a><br /><a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />