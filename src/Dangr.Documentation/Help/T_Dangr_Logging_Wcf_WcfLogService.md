# WcfLogService Class
 

A service that listens for connections from WcfLogClients and logs the messages to a designated <a href="T_Dangr_Logging_LogService">LogService</a>.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Logging.Wcf.WcfLogService<br />
**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class WcfLogService : IWcfLogService
```

**VB**<br />
``` VB
Public Class WcfLogService
	Implements IWcfLogService
```

**C++**<br />
``` C++
public ref class WcfLogService : IWcfLogService
```

The WcfLogService type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService__cctor">WcfLogService</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService__ctor">WcfLogService</a></td><td>
Initializes a new instance of the WcfLogService class</td></tr></table>&nbsp;
<a href="#wcflogservice-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService_Log">Log</a></td><td>
Logs the specified message.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService_LogBatch">LogBatch</a></td><td>
Logs a batch of messages.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService_Run">Run(LogService, Uri[], Dictionary(String, Binding))</a></td><td>
Runs the WcfLogService.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService_Run_1">Run(LogService, Uri[], String, Binding)</a></td><td>
Runs the WcfLogService.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService_SignalShutdown">SignalShutdown</a></td><td>
Signals the WcfLogService to shutdown.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#wcflogservice-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Wcf_WcfLogService_cancelTokenSource">cancelTokenSource</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Wcf_WcfLogService_isRunning">isRunning</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Wcf_WcfLogService_logService">logService</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Wcf_WcfLogService_RunLock">RunLock</a></td><td /></tr></table>&nbsp;
<a href="#wcflogservice-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />