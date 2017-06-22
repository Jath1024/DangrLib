# IWcfLogService Interface
 

Interface for a service that listens for connections from WcfLogClients and logs the messages to a designated <a href="T_Dangr_Logging_LogService">LogService</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
[ServiceContractAttribute(Namespace = "http://Dangr/Logging/2015/10")]
public interface IWcfLogService
```

**VB**<br />
``` VB
<ServiceContractAttribute(Namespace := "http://Dangr/Logging/2015/10")>
Public Interface IWcfLogService
```

**C++**<br />
``` C++
[ServiceContractAttribute(Namespace = L"http://Dangr/Logging/2015/10")]
public interface class IWcfLogService
```

The IWcfLogService type exposes the following members.


## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Wcf_IWcfLogService_Log">Log</a></td><td>
Logs the specified message.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Wcf_IWcfLogService_LogBatch">LogBatch</a></td><td>
Logs a batch of messages.</td></tr></table>&nbsp;
<a href="#iwcflogservice-interface">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />