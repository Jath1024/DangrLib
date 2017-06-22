# LogService Class
 

Service that logs messages at various levels using different logging endpoints.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Logging.LogService<br />
**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class LogService : ILogService, ILogger, 
	ILogSource, ICancelable, IDisposable
```

**VB**<br />
``` VB
Public Class LogService
	Implements ILogService, ILogger, ILogSource, ICancelable, 
	IDisposable
```

**C++**<br />
``` C++
public ref class LogService : ILogService, 
	ILogger, ILogSource, ICancelable, IDisposable
```

The LogService type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService__ctor">LogService</a></td><td>
Initializes a new instance of the LogService class.</td></tr></table>&nbsp;
<a href="#logservice-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_LogService_IsDisposed">IsDisposed</a></td><td>
Gets a value indicating whether this object is disposed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_LogService_LogCategory">LogCategory</a></td><td>
Gets the log category of this <a href="T_Dangr_Logging_ILogSource">ILogSource</a> used when logging.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_LogService_Logger">Logger</a></td><td>
Gets the logger used when logging from this source.</td></tr></table>&nbsp;
<a href="#logservice-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_AddFeature">AddFeature</a></td><td>
Add a feature to be logged.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_Dispose">Dispose()</a></td><td>
Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Logging_LogService_Dispose_1">Dispose(Boolean)</a></td><td>
Releases unmanaged and - optionally - managed resources.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Logging_LogService_Finalize">Finalize</a></td><td>
Finalizes an instance of the LogService class.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Object.Finalize()</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_Log">Log(LogLevel, Object)</a></td><td>
Logs a message at the specified level.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_Log_1">Log(LogLevel, String, Object)</a></td><td>
Logs a message at the specified level.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_Log_2">Log(LogLevel, String, String, Object)</a></td><td>
Logs a message at the specified level.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_LogEntry">LogEntry</a></td><td>
Logs an entry to the LogService.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_LogInternal">LogInternal</a></td><td>
Logs a message internal to the LogService.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_LogService_OnLogInternalMessage">OnLogInternalMessage</a></td><td /></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_LogService_OnLogMessage">OnLogMessage</a></td><td /></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_LogService_OnShutDown">OnShutDown</a></td><td /></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_LogService_OnShuttingDown">OnShuttingDown</a></td><td /></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_LogService_OnStarted">OnStarted</a></td><td /></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_LogService_ProcessLogs">ProcessLogs</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_RegisterEndpoint">RegisterEndpoint</a></td><td>
Registers an <a href="T_Dangr_Logging_ILogEndpoint">ILogEndpoint</a> to receive log events from this LogService.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_RegisterInternalEndpoint">RegisterInternalEndpoint</a></td><td>
Registers an <a href="T_Dangr_Logging_ILogEndpoint">ILogEndpoint</a> to receive internal log events from this LogService.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_RemoveFeature">RemoveFeature</a></td><td>
Removes a feature from being logged.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_SignalShutDown">SignalShutDown()</a></td><td>
Signals the LogService a signal to start shutting down, and waits for completion.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_SignalShutDown_1">SignalShutDown(TimeSpan)</a></td><td>
Signals the LogService a signal to start shutting down, and waits the specified time for completion.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_UnregisterEndpoint">UnregisterEndpoint</a></td><td>
Stops a registered <a href="T_Dangr_Logging_ILogEndpoint">ILogEndpoint</a> from receiving log events from this LogService.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogService_UnregisterInternalEndpoint">UnregisterInternalEndpoint</a></td><td>
Stops a registered <a href="T_Dangr_Logging_ILogEndpoint">ILogEndpoint</a> from receiving internal log events from this LogService.</td></tr></table>&nbsp;
<a href="#logservice-class">Back to Top</a>

## Events
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private event](media/privevent.gif "Private event")</td><td><a href="E_Dangr_Logging_LogService_LogInternalMessage">LogInternalMessage</a></td><td /></tr><tr><td>![Private event](media/privevent.gif "Private event")</td><td><a href="E_Dangr_Logging_LogService_LogMessage">LogMessage</a></td><td /></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Dangr_Logging_LogService_ShutDown">ShutDown</a></td><td>
Occurs when the LogService has finished shutting down.</td></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Dangr_Logging_LogService_ShuttingDown">ShuttingDown</a></td><td>
Occurs when the LogService receives a shut down signal.</td></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Dangr_Logging_LogService_Started">Started</a></td><td>
Occurs when the LogService is started.</td></tr></table>&nbsp;
<a href="#logservice-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_LogService_entriesQueue">entriesQueue</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_LogService_features">features</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_LogService_processTask">processTask</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_LogService_processTaskCancellationTokenSource">processTaskCancellationTokenSource</a></td><td /></tr></table>&nbsp;
<a href="#logservice-class">Back to Top</a>

## Extension Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogCritical">LogCritical(Object)</a></td><td>Overloaded.  
Logs a *message* that a critical, but recoverable, error has occurred.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogCritical_1">LogCritical(String, Object)</a></td><td>Overloaded.  
Logs a *message* that a critical, but recoverable, error has occurred.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogDebug">LogDebug(Object)</a></td><td>Overloaded.  
Logs a *message* used to display diagnostic information.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogDebug_1">LogDebug(String, Object)</a></td><td>Overloaded.  
Logs a *message* used to display diagnostic information.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogFatal">LogFatal(Object)</a></td><td>Overloaded.  
Logs a *message* that a fatal, non-recoverable, error has occurred.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogFatal_1">LogFatal(String, Object)</a></td><td>Overloaded.  
Logs a *message* that a fatal, non-recoverable, error has occurred.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogInfo">LogInfo(Object)</a></td><td>Overloaded.  
Logs an informational message.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogInfo_1">LogInfo(String, Object)</a></td><td>Overloaded.  
Logs an informational message.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogStatus">LogStatus(Object)</a></td><td>Overloaded.  
Logs a *message* used to display a status change of an object.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogStatus_1">LogStatus(String, Object)</a></td><td>Overloaded.  
Logs a *message* used to display a status change of an object.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogVerbose">LogVerbose(Object)</a></td><td>Overloaded.  
Logs a *message* used to display verbose information.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogVerbose_1">LogVerbose(String, Object)</a></td><td>Overloaded.  
Logs a *message* used to display verbose information.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogWarning">LogWarning(Object)</a></td><td>Overloaded.  
Logs a warning.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="M_Dangr_Logging_LogSourceExtensions_LogWarning_1">LogWarning(String, Object)</a></td><td>Overloaded.  
Logs a warning.
 (Defined by <a href="T_Dangr_Logging_LogSourceExtensions">LogSourceExtensions</a>.)</td></tr></table>&nbsp;
<a href="#logservice-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />