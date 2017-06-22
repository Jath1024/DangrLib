# WcfLogService.ServiceHolder Class
 

Object used to hold a reference to the running <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a>.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Logging.Wcf.WcfLogService.ServiceHolder<br />
**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class ServiceHolder : ICancelable, 
	IDisposable
```

**VB**<br />
``` VB
Public Class ServiceHolder
	Implements ICancelable, IDisposable
```

**C++**<br />
``` C++
public ref class ServiceHolder : ICancelable, 
	IDisposable
```

The WcfLogService.ServiceHolder type exposes the following members.


## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Wcf_WcfLogService_ServiceHolder_IsDisposed">IsDisposed</a></td><td>
Gets a value that indicates whether the object is disposed.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Logging_Wcf_WcfLogService_ServiceHolder_IsRunning">IsRunning</a></td><td>
Gets a value indicating whether the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a> is running</td></tr></table>&nbsp;
<a href="#wcflogservice.serviceholder-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService_ServiceHolder_Dispose">Dispose()</a></td><td>
Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService_ServiceHolder_Dispose_1">Dispose(Boolean)</a></td><td>
Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService_ServiceHolder_Shutdown">Shutdown</a></td><td>
Shuts down the <a href="T_Dangr_Logging_Wcf_WcfLogService">WcfLogService</a> using the specified timeout.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Logging_Wcf_WcfLogService_ServiceHolder_Wait">Wait</a></td><td>
Waits for the service to shut down.</td></tr></table>&nbsp;
<a href="#wcflogservice.serviceholder-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Logging_Wcf_WcfLogService_ServiceHolder_serviceTask">serviceTask</a></td><td /></tr></table>&nbsp;
<a href="#wcflogservice.serviceholder-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />