# WcfLogService.Run Method (LogService, Uri[], Dictionary(String, Binding))
 

Runs the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static WcfLogService.ServiceHolder Run(
	LogService logService,
	Uri[] baseAddresses,
	Dictionary<string, Binding> endpoints
)
```

**VB**<br />
``` VB
Public Shared Function Run ( 
	logService As LogService,
	baseAddresses As Uri(),
	endpoints As Dictionary(Of String, Binding)
) As WcfLogService.ServiceHolder
```

**C++**<br />
``` C++
public:
static WcfLogService.ServiceHolder^ Run(
	LogService^ logService, 
	array<Uri^>^ baseAddresses, 
	Dictionary<String^, Binding^>^ endpoints
)
```


#### Parameters
&nbsp;<dl><dt>logService</dt><dd>Type: <a href="T_Dangr_Logging_LogService">Dangr.Logging.LogService</a><br />The <a href="T_Dangr_Logging_LogService">LogService</a> that will log the incoming messages.</dd><dt>baseAddresses</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/txt7706a" target="_blank">System.Uri</a>[]<br />The base addresses for the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a>.</dd><dt>endpoints</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/xfhwa508" target="_blank">System.Collections.Generic.Dictionary</a>(<a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>, <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">Binding</a>)<br />The endpoints for the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a>.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Logging_Wcf_WcfLogService_ServiceHolder">WcfLogService.ServiceHolder</a><br />A <a href="T_Dangr_Logging_Wcf_WcfLogService_ServiceHolder">WcfLogService.ServiceHolder</a> that can be used to shut down the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a> or `null` if the service was already running.

## See Also


#### Reference
<a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService Class</a><br /><a href="Overload_Dangr_Logging_Wcf_WcfLogService_Run">Run Overload</a><br /><a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />