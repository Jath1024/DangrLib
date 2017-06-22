# ConsoleLogger Class
 

Logger pipeline logger that will log a message to the console.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Logging.Loggers.ConsoleLogger<br />
**Namespace:**&nbsp;<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers</a><br />**Assembly:**&nbsp;Dangr.Logging.Loggers (in Dangr.Logging.Loggers.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class ConsoleLogger : ILogEndpoint, 
	ICancelable, IDisposable
```

**VB**<br />
``` VB
Public Class ConsoleLogger
	Implements ILogEndpoint, ICancelable, IDisposable
```

**C++**<br />
``` C++
public ref class ConsoleLogger : ILogEndpoint, 
	ICancelable, IDisposable
```

The ConsoleLogger type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_ConsoleLogger__ctor">ConsoleLogger</a></td><td>
Initializes a new instance of the ConsoleLogger class.</td></tr></table>&nbsp;
<a href="#consolelogger-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_ConsoleLogger_IsDisposed">IsDisposed</a></td><td>
Gets a value indicating whether this object is disposed.</td></tr></table>&nbsp;
<a href="#consolelogger-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Loggers_ConsoleLogger_AllocConsole">AllocConsole</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_ConsoleLogger_Dispose">Dispose()</a></td><td>
Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Logging_Loggers_ConsoleLogger_Dispose_1">Dispose(Boolean)</a></td><td>
Releases unmanaged and - optionally - managed resources.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Logging_Loggers_ConsoleLogger_Finalize">Finalize</a></td><td>
Finalizes an instance of the ConsoleLogger class.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Object.Finalize()</a>.)</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Loggers_ConsoleLogger_GetConsoleWindow">GetConsoleWindow</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Loggers_ConsoleLogger_HideConsoleWindow">HideConsoleWindow</a></td><td>
Hides the console window.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_ConsoleLogger_Log">Log</a></td><td>
Logs the specified entry.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Loggers_ConsoleLogger_ShowConsoleWindow">ShowConsoleWindow</a></td><td>
Shows the console window.</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_Loggers_ConsoleLogger_ShowWindow">ShowWindow</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#consolelogger-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Loggers_ConsoleLogger_SW_HIDE">SW_HIDE</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Loggers_ConsoleLogger_SW_SHOW">SW_SHOW</a></td><td /></tr></table>&nbsp;
<a href="#consolelogger-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers Namespace</a><br />