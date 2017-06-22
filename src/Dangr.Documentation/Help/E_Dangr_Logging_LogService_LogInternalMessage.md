# LogService.LogInternalMessage Event
 

\[Missing <summary> documentation for "E:Dangr.Logging.LogService.LogInternalMessage"\]

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
private event Action<LogEntry> LogInternalMessage
```

**VB**<br />
``` VB
Private Event LogInternalMessage As Action(Of LogEntry)
```

**C++**<br />
``` C++
private:
 event Action<LogEntry^>^ LogInternalMessage {
	void add (Action<LogEntry^>^ value);
	void remove (Action<LogEntry^>^ value);
}
```


#### Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/018hxwa8" target="_blank">System.Action</a>(<a href="T_Dangr_Logging_LogEntry">LogEntry</a>)

## See Also


#### Reference
<a href="T_Dangr_Logging_LogService">LogService Class</a><br /><a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />