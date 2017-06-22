# ILogSource Interface
 

Interface for an object that can log messages.

**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
public interface ILogSource
```

**VB**<br />
``` VB
Public Interface ILogSource
```

**C++**<br />
``` C++
public interface class ILogSource
```

The ILogSource type exposes the following members.


## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_ILogSource_LogCategory">LogCategory</a></td><td>
Gets the log category of this ILogSource used when logging.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_ILogSource_Logger">Logger</a></td><td>
Gets the logger used when logging from this source.</td></tr></table>&nbsp;
<a href="#ilogsource-interface">Back to Top</a>

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
<a href="#ilogsource-interface">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />