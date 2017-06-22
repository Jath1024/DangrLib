# WcfLogger Class
 

Logger pipeline logger that will use WCF to send logs to a <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a> that is listening for logs.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Logging.Loggers.WcfLogger<br />
**Namespace:**&nbsp;<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class WcfLogger : ILogEndpoint, ICancelable, 
	IDisposable
```

**VB**<br />
``` VB
Public Class WcfLogger
	Implements ILogEndpoint, ICancelable, IDisposable
```

**C++**<br />
``` C++
public ref class WcfLogger : ILogEndpoint, 
	ICancelable, IDisposable
```

The WcfLogger type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Loggers_WcfLogger__cctor">WcfLogger</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_WcfLogger__ctor">WcfLogger(LogService, Binding, EndpointAddress)</a></td><td>
Initializes a new instance of the WcfLogger class.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_WcfLogger__ctor_1">WcfLogger(LogService, Binding, EndpointAddress, Int32, TimeSpan)</a></td><td>
Initializes a new instance of the WcfLogger class.</td></tr></table>&nbsp;
<a href="#wcflogger-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_WcfLogger_IsDisposed">IsDisposed</a></td><td>
Gets a value indicating whether this object is disposed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_WcfLogger_MaxBatchSize">MaxBatchSize</a></td><td>
Gets or sets the maximum size of the batch.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_WcfLogger_MessageInterval">MessageInterval</a></td><td>
Gets or sets the interval to wait before sending a batch of logs.</td></tr></table>&nbsp;
<a href="#wcflogger-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_Loggers_WcfLogger_ConnectClient">ConnectClient</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_WcfLogger_Dispose">Dispose()</a></td><td>
Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Logging_Loggers_WcfLogger_Dispose_1">Dispose(Boolean)</a></td><td>
Releases unmanaged and - optionally - managed resources.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_WcfLogger_Log">Log</a></td><td>
Logs the specified entry.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_Loggers_WcfLogger_OnLogMessage">OnLogMessage</a></td><td /></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_Loggers_WcfLogger_ProcessMessages">ProcessMessages</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#wcflogger-class">Back to Top</a>

## Events
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private event](media/privevent.gif "Private event")</td><td><a href="E_Dangr_Logging_Loggers_WcfLogger_LogMessage">LogMessage</a></td><td /></tr></table>&nbsp;
<a href="#wcflogger-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Loggers_WcfLogger_client">client</a></td><td /></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Loggers_WcfLogger_DefaultMaxBatchSize">DefaultMaxBatchSize</a></td><td>
The default maximum batch size.</td></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Loggers_WcfLogger_DefaultMessageInterval">DefaultMessageInterval</a></td><td>
The default interval to wait before sending a batch of logs.</td></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Loggers_WcfLogger_disposable">disposable</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Loggers_WcfLogger_loggedEndpointNotFound">loggedEndpointNotFound</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Loggers_WcfLogger_logService">logService</a></td><td /></tr></table>&nbsp;
<a href="#wcflogger-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers Namespace</a><br />