# DefaultWcfEndpoints.GetHttpEndpointAddress Method 
 

Gets the HTTP endpoint address.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static EndpointAddress GetHttpEndpointAddress(
	string ip = "localhost",
	int port = 8185,
	string serviceName = "HttpService"
)
```

**VB**<br />
``` VB
Public Shared Function GetHttpEndpointAddress ( 
	Optional ip As String = "localhost",
	Optional port As Integer = 8185,
	Optional serviceName As String = "HttpService"
) As EndpointAddress
```

**C++**<br />
``` C++
public:
static EndpointAddress^ GetHttpEndpointAddress(
	String^ ip = L"localhost", 
	int port = 8185, 
	String^ serviceName = L"HttpService"
)
```


#### Parameters
&nbsp;<dl><dt>ip (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The ip.</dd><dt>port (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The port.</dd><dt>serviceName (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Name of the service.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/ms405980" target="_blank">EndpointAddress</a><br />\[Missing <returns> documentation for "M:Dangr.Logging.Wcf.DefaultWcfEndpoints.GetHttpEndpointAddress(System.String,System.Int32,System.String)"\]

## See Also


#### Reference
<a href="T_Dangr_Logging_Wcf_DefaultWcfEndpoints">DefaultWcfEndpoints Class</a><br /><a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />