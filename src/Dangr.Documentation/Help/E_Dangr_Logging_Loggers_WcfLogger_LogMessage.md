# WcfLogger.LogMessage Event
 

\[Missing <summary> documentation for "E:Dangr.Logging.Loggers.WcfLogger.LogMessage"\]

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
private event Action<LogEntry> LogMessage
```

**VB**<br />
``` VB
Private Event LogMessage As Action(Of LogEntry)
```

**C++**<br />
``` C++
private:
 event Action<LogEntry^>^ LogMessage {
	void add (Action<LogEntry^>^ value);
	void remove (Action<LogEntry^>^ value);
}
```


#### Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/018hxwa8" target="_blank">System.Action</a>(<a href="T_Dangr_Logging_LogEntry">LogEntry</a>)

## See Also


#### Reference
<a href="T_Dangr_Logging_Loggers_WcfLogger">WcfLogger Class</a><br /><a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers Namespace</a><br />