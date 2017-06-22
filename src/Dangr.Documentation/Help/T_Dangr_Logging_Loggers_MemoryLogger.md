# MemoryLogger Class
 

Logger pipeline logger that will log entries to memory.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Logging.Loggers.MemoryLogger<br />
**Namespace:**&nbsp;<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers</a><br />**Assembly:**&nbsp;Dangr.Logging.Loggers (in Dangr.Logging.Loggers.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class MemoryLogger : ILogEndpoint, 
	INotifyPropertyChanged
```

**VB**<br />
``` VB
Public Class MemoryLogger
	Implements ILogEndpoint, INotifyPropertyChanged
```

**C++**<br />
``` C++
public ref class MemoryLogger : ILogEndpoint, 
	INotifyPropertyChanged
```

The MemoryLogger type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_MemoryLogger__ctor">MemoryLogger</a></td><td>
Initializes a new instance of the MemoryLogger class.</td></tr></table>&nbsp;
<a href="#memorylogger-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_MemoryLogger_Entries">Entries</a></td><td>
Gets the entries stored in memory.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Loggers_MemoryLogger_MaxNumEntries">MaxNumEntries</a></td><td>
Gets or sets the maximum number entries.</td></tr></table>&nbsp;
<a href="#memorylogger-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Loggers_MemoryLogger_Log">Log</a></td><td>
Logs the specified entry.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Logging_Loggers_MemoryLogger_OnPropertyChanged">OnPropertyChanged</a></td><td>
Called when [property changed].</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#memorylogger-class">Back to Top</a>

## Events
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Dangr_Logging_Loggers_MemoryLogger_PropertyChanged">PropertyChanged</a></td><td>
Occurs when a property of this object is changed.</td></tr></table>&nbsp;
<a href="#memorylogger-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_Loggers_MemoryLogger_DefaultMaxNumEntries">DefaultMaxNumEntries</a></td><td>
The default maximum number of entries</td></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Loggers_MemoryLogger_entries">entries</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Loggers_MemoryLogger_entriesLock">entriesLock</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Loggers_MemoryLogger_maxNumEntries">maxNumEntries</a></td><td /></tr></table>&nbsp;
<a href="#memorylogger-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers Namespace</a><br />