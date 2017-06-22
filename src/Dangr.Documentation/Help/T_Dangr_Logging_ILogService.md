# ILogService Interface
 

\[Missing <summary> documentation for "T:Dangr.Logging.ILogService"\]

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
public interface ILogService : ILogger, 
	ILogSource, ICancelable, IDisposable
```

**VB**<br />
``` VB
Public Interface ILogService
	Inherits ILogger, ILogSource, ICancelable, IDisposable
```

**C++**<br />
``` C++
public interface class ILogService : ILogger, 
	ILogSource, ICancelable, IDisposable
```

The ILogService type exposes the following members.


## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Util_ICancelable_IsDisposed">IsDisposed</a></td><td>
Gets a value that indicates whether the object is disposed.
 (Inherited from <a href="T_Dangr_Util_ICancelable">ICancelable</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_ILogSource_LogCategory">LogCategory</a></td><td>
Gets the log category of this <a href="T_Dangr_Logging_ILogSource">ILogSource</a> used when logging.
 (Inherited from <a href="T_Dangr_Logging_ILogSource">ILogSource</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_ILogSource_Logger">Logger</a></td><td>
Gets the logger used when logging from this source.
 (Inherited from <a href="T_Dangr_Logging_ILogSource">ILogSource</a>.)</td></tr></table>&nbsp;
<a href="#ilogservice-interface">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/es4s3w1d" target="_blank">Dispose</a></td><td>
Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/aax125c9" target="_blank">IDisposable</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_ILogger_Log">Log(LogLevel, Object)</a></td><td>
Logs a *message* at the specified level.
 (Inherited from <a href="T_Dangr_Logging_ILogger">ILogger</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_ILogger_Log_1">Log(LogLevel, String, Object)</a></td><td>
Logs a *message* at the specified level.
 (Inherited from <a href="T_Dangr_Logging_ILogger">ILogger</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_ILogger_Log_2">Log(LogLevel, String, String, Object)</a></td><td>
Logs a *message* at the specified level.
 (Inherited from <a href="T_Dangr_Logging_ILogger">ILogger</a>.)</td></tr></table>&nbsp;
<a href="#ilogservice-interface">Back to Top</a>

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
<a href="#ilogservice-interface">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br /><a href="T_Dangr_Logging_ILogger">Dangr.Logging.ILogger</a><br /><a href="T_Dangr_Logging_ILogSource">Dangr.Logging.ILogSource</a><br /><a href="T_Dangr_Util_ICancelable">Dangr.Util.ICancelable</a><br />