# DefaultWcfEndpoints.GetNetTcpEndpointAddress Method 
 

Gets the net TCP endpoint address.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static EndpointAddress GetNetTcpEndpointAddress(
	string ip = "localhost",
	int port = 8186,
	string serviceName = "NetTcpService"
)
```

**VB**<br />
``` VB
Public Shared Function GetNetTcpEndpointAddress ( 
	Optional ip As String = "localhost",
	Optional port As Integer = 8186,
	Optional serviceName As String = "NetTcpService"
) As EndpointAddress
```

**C++**<br />
``` C++
public:
static EndpointAddress^ GetNetTcpEndpointAddress(
	String^ ip = L"localhost", 
	int port = 8186, 
	String^ serviceName = L"NetTcpService"
)
```


#### Parameters
&nbsp;<dl><dt>ip (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The ip.</dd><dt>port (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The port.</dd><dt>serviceName (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Name of the service.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/ms405980" target="_blank">EndpointAddress</a><br />\[Missing <returns> documentation for "M:Dangr.Logging.Wcf.DefaultWcfEndpoints.GetNetTcpEndpointAddress(System.String,System.Int32,System.String)"\]

## See Also


#### Reference
<a href="T_Dangr_Logging_Wcf_DefaultWcfEndpoints">DefaultWcfEndpoints Class</a><br /><a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />