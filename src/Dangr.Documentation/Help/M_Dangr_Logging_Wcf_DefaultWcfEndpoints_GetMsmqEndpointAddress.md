# DefaultWcfEndpoints.GetMsmqEndpointAddress Method 
 

Gets the MSMQ endpoint address.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static EndpointAddress GetMsmqEndpointAddress(
	string ip = "localhost",
	string serviceName = "MsmqService"
)
```

**VB**<br />
``` VB
Public Shared Function GetMsmqEndpointAddress ( 
	Optional ip As String = "localhost",
	Optional serviceName As String = "MsmqService"
) As EndpointAddress
```

**C++**<br />
``` C++
public:
static EndpointAddress^ GetMsmqEndpointAddress(
	String^ ip = L"localhost", 
	String^ serviceName = L"MsmqService"
)
```


#### Parameters
&nbsp;<dl><dt>ip (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The ip.</dd><dt>serviceName (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Name of the service.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/ms405980" target="_blank">EndpointAddress</a><br />\[Missing <returns> documentation for "M:Dangr.Logging.Wcf.DefaultWcfEndpoints.GetMsmqEndpointAddress(System.String,System.String)"\]

## See Also


#### Reference
<a href="T_Dangr_Logging_Wcf_DefaultWcfEndpoints">DefaultWcfEndpoints Class</a><br /><a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />