# IWcfLogService.LogBatch Method 
 

Logs a batch of messages.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
[OperationContractAttribute]
void LogBatch(
	LogEntry[] messages
)
```

**VB**<br />
``` VB
<OperationContractAttribute>
Sub LogBatch ( 
	messages As LogEntry()
)
```

**C++**<br />
``` C++
[OperationContractAttribute]
void LogBatch(
	array<LogEntry^>^ messages
)
```


#### Parameters
&nbsp;<dl><dt>messages</dt><dd>Type: <a href="T_Dangr_Logging_LogEntry">Dangr.Logging.LogEntry</a>[]<br />The messages.</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Logging_Wcf_IWcfLogService">IWcfLogService Interface</a><br /><a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />