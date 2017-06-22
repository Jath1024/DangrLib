# TextLogger Class
 

A logger pipeline logger that will log entries to a text file.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Logging.Loggers.TextLogger<br />
**Namespace:**&nbsp;<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers</a><br />**Assembly:**&nbsp;Dangr.Logging.Loggers (in Dangr.Logging.Loggers.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class TextLogger : ILogEndpoint, ICancelable, 
	IDisposable
```

**VB**<br />
``` VB
Public Class TextLogger
	Implements ILogEndpoint, ICancelable, IDisposable
```

**C++**<br />
``` C++
public ref class TextLogger : ILogEndpoint, 
	ICancelable, IDisposable
```

The TextLogger type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Loggers_TextLogger__cctor">TextLogger</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_TextLogger__ctor">TextLogger</a></td><td>
Initializes a new instance of the TextLogger class.</td></tr></table>&nbsp;
<a href="#textlogger-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_TextLogger_IsDisposed">IsDisposed</a></td><td>
Gets a value indicating whether this object is disposed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_TextLogger_LogFile">LogFile</a></td><td>
Gets the file that this TextLogger is logging to.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_TextLogger_LogFileDateFormat">LogFileDateFormat</a></td><td>
Gets the log file date format.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_TextLogger_LogFileDirectory">LogFileDirectory</a></td><td>
Gets the log file directory.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_TextLogger_LogFilePrefix">LogFilePrefix</a></td><td>
Gets the log file prefix.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_TextLogger_MaxLogFileEntries">MaxLogFileEntries</a></td><td>
Gets or sets the maximum number of log file entries in a single log file.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_TextLogger_MaxLogFileFlushSize">MaxLogFileFlushSize</a></td><td>
Gets or sets the maximum size of the log file before changes are flushed to disk.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_TextLogger_MaxLogFileInterval">MaxLogFileInterval</a></td><td>
Gets or sets the maximum interval that can pass before creating a new log file.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_TextLogger_MaxLogFileSize">MaxLogFileSize</a></td><td>
Gets or sets the maximum size of the log file before creating a new file.</td></tr></table>&nbsp;
<a href="#textlogger-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_TextLogger_Dispose">Dispose()</a></td><td>
Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Logging_Loggers_TextLogger_Dispose_1">Dispose(Boolean)</a></td><td>
Releases unmanaged and - optionally - managed resources.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_Loggers_TextLogger_GetNewLogFile">GetNewLogFile</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_TextLogger_Log">Log</a></td><td>
Logs the specified entry.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#textlogger-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Loggers_TextLogger_DefaultLogFileDateFormat">DefaultLogFileDateFormat</a></td><td>
The default log file date format.</td></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Loggers_TextLogger_DefaultLogFileFlushSize">DefaultLogFileFlushSize</a></td><td>
The default log file flush size in bytes.</td></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Loggers_TextLogger_DefaultMaxLogFileEntries">DefaultMaxLogFileEntries</a></td><td>
The default maximum log file entries.</td></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Loggers_TextLogger_DefaultMaxLogFileInterval">DefaultMaxLogFileInterval</a></td><td>
The default maximum log file interval.</td></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Loggers_TextLogger_DefaultMaxLogFileSize">DefaultMaxLogFileSize</a></td><td>
The default maximum log file size in bytes.</td></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Loggers_TextLogger_lastFlushSize">lastFlushSize</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Loggers_TextLogger_logCounter">logCounter</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Loggers_TextLogger_writer">writer</a></td><td /></tr></table>&nbsp;
<a href="#textlogger-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers Namespace</a><br />