# WcfLogService.LogBatch Method 
 

Logs a batch of messages.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
public void LogBatch(
	LogEntry[] messages
)
```

**VB**<br />
``` VB
Public Sub LogBatch ( 
	messages As LogEntry()
)
```

**C++**<br />
``` C++
public:
virtual void LogBatch(
	array<LogEntry^>^ messages
) sealed
```


#### Parameters
&nbsp;<dl><dt>messages</dt><dd>Type: <a href="T_Dangr_Logging_LogEntry">Dangr.Logging.LogEntry</a>[]<br />The messages.</dd></dl>

#### Implements
<a href="M_Dangr_Logging_Wcf_IWcfLogService_LogBatch">IWcfLogService.LogBatch(LogEntry[])</a><br />

## See Also


#### Reference
<a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService Class</a><br /><a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />