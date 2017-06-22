# LogEntry Class
 

An entry in a log.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Logging.LogEntry<br />
**Namespace:**&nbsp;<a href="N_Dangr_Logging">Dangr.Logging</a><br />**Assembly:**&nbsp;Dangr.Logging (in Dangr.Logging.dll) Version: 1.0.6381.41475 (1.0.*)

## Syntax

**C#**<br />
``` C#
[DataContractAttribute(Namespace = "http://Dangr/Logging/2015/10")]
public sealed class LogEntry
```

**VB**<br />
``` VB
<DataContractAttribute(Namespace := "http://Dangr/Logging/2015/10")>
Public NotInheritable Class LogEntry
```

**C++**<br />
``` C++
[DataContractAttribute(Namespace = L"http://Dangr/Logging/2015/10")]
public ref class LogEntry sealed
```

The LogEntry type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Logging_LogEntry__cctor">LogEntry</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogEntry__ctor">LogEntry(LogEntry)</a></td><td>
Initializes a new instance of the LogEntry class.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogEntry__ctor_1">LogEntry(LogLevel, String, Object)</a></td><td>
Initializes a new instance of the LogEntry class.</td></tr></table>&nbsp;
<a href="#logentry-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_LogEntry_Category">Category</a></td><td>
Gets the log category for this LogEntry.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_LogEntry_Id">Id</a></td><td>
Gets the unique Id for this LogEntry.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_LogEntry_LogLevel">LogLevel</a></td><td>
Gets the <a href="P_Dangr_Logging_LogEntry_LogLevel">LogLevel</a> used to log this LogEntry.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_LogEntry_Message">Message</a></td><td>
Gets the Message that was logged.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_LogEntry_TimeStamp">TimeStamp</a></td><td>
Gets the timestamp when this LogEntry was created.</td></tr></table>&nbsp;
<a href="#logentry-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Logging_LogEntry_Initialize">Initialize</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogEntry_ToString">ToString()</a></td><td>
Returns a string that represents the current object.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">Object.ToString()</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_LogEntry_ToString_1">ToString(String, String)</a></td><td>
Returns a string that represents the current LogEntry in the specified format.</td></tr></table>&nbsp;
<a href="#logentry-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_LogEntry_DefaultLogFormat">DefaultLogFormat</a></td><td>
The default log format to use when logging.</td></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_LogEntry_DefaultTimeStampFormat">DefaultTimeStampFormat</a></td><td>
The default timestamp format to use when logging.</td></tr><tr><td>![Private field](media/privfield.gif "Private field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Logging_LogEntry_IdCounter">IdCounter</a></td><td /></tr></table>&nbsp;
<a href="#logentry-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging">Dangr.Logging Namespace</a><br />