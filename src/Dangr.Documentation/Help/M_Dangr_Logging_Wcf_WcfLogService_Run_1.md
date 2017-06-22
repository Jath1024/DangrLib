# WcfLogService.Run Method (LogService, Uri[], String, Binding)
 

Runs the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static WcfLogService.ServiceHolder Run(
	LogService logService,
	Uri[] baseAddresses,
	string endpointAddress,
	Binding binding
)
```

**VB**<br />
``` VB
Public Shared Function Run ( 
	logService As LogService,
	baseAddresses As Uri(),
	endpointAddress As String,
	binding As Binding
) As WcfLogService.ServiceHolder
```

**C++**<br />
``` C++
public:
static WcfLogService.ServiceHolder^ Run(
	LogService^ logService, 
	array<Uri^>^ baseAddresses, 
	String^ endpointAddress, 
	Binding^ binding
)
```


#### Parameters
&nbsp;<dl><dt>logService</dt><dd>Type: <a href="T_Dangr_Logging_LogService">Dangr.Logging.LogService</a><br />The <a href="T_Dangr_Logging_LogService">LogService</a> that will log the incoming messages.</dd><dt>baseAddresses</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/txt7706a" target="_blank">System.Uri</a>[]<br />The base addresses for the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a>.</dd><dt>endpointAddress</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The endpoint address for the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a>.</dd><dt>binding</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/ms405791" target="_blank">System.ServiceModel.Channels.Binding</a><br />The wcf binding for the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a>.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Logging_Wcf_WcfLogService_ServiceHolder">WcfLogService.ServiceHolder</a><br />A <a href="T_Dangr_Logging_Wcf_WcfLogService_ServiceHolder">WcfLogService.ServiceHolder</a> that can be used to shut down the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a> or `null` if the service was already running.

## See Also


#### Reference
<a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService Class</a><br /><a href="Overload_Dangr_Logging_Wcf_WcfLogService_Run">Run Overload</a><br /><a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />