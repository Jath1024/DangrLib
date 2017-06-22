# LogService.SignalShutDown Method (TimeSpan)
 

Signals the <a href="T_Dangr_Logging_LogService">LogService</a> a signal to start shutting down, and waits the specified time for completion.

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
public void SignalShutDown(
	TimeSpan timeout
)
```

**VB**<br />
``` VB
Public Sub SignalShutDown ( 
	timeout As TimeSpan
)
```

**C++**<br />
``` C++
public:
void SignalShutDown(
	TimeSpan timeout
)
```


#### Parameters
&nbsp;<dl><dt>timeout</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/269ew577" target="_blank">System.TimeSpan</a><br />The time to wait for completion. (Use -1 milliseconds to wait indefinitely.)</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Logging_LogService">LogService Class</a><br /><a href="Overload_Dangr_Logging_LogService_SignalShutDown">SignalShutDown Overload</a><br /><a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />