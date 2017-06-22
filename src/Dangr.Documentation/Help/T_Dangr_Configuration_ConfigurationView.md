# ConfigurationView Class
 

An object that exposes settings in a <a href="T_Dangr_Configuration_Configuration">Configuration</a> .


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Configuration.ConfigurationView<br />&nbsp;&nbsp;&nbsp;&nbsp;<a href="T_Dangr_Configuration_Views_AllSettingsConfigurationView">Dangr.Configuration.Views.AllSettingsConfigurationView</a><br />
**Namespace:**&nbsp;<a href="N_Dangr_Configuration">Dangr.Configuration</a><br />**Assembly:**&nbsp;Dangr.Configuration (in Dangr.Configuration.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public abstract class ConfigurationView : ICancelable, 
	IDisposable
```

**VB**<br />
``` VB
Public MustInherit Class ConfigurationView
	Implements ICancelable, IDisposable
```

**C++**<br />
``` C++
public ref class ConfigurationView abstract : ICancelable, 
	IDisposable
```

The ConfigurationView type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Configuration_ConfigurationView__ctor">ConfigurationView</a></td><td>
Initializes a new instance of the ConfigurationView class</td></tr></table>&nbsp;
<a href="#configurationview-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Configuration_ConfigurationView_IsDisposed">IsDisposed</a></td><td>
Gets a value indicating whether this <a href="T_Dangr_Util_ICancelable">ICancelable</a> has been disposed.</td></tr></table>&nbsp;
<a href="#configurationview-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Configuration_ConfigurationView_Configuration_SettingChanged">Configuration_SettingChanged</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_ConfigurationView_Dispose">Dispose()</a></td><td>
Disposes the resources managed by this <a href="T_Dangr_Util_ICancelable">ICancelable</a> .</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Configuration_ConfigurationView_Dispose_1">Dispose(Boolean)</a></td><td>
Disposes the resources managed by this <a href="T_Dangr_Util_ICancelable">ICancelable</a> .</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_ConfigurationView_GetSetting">GetSetting</a></td><td>
Gets the setting with the specified name.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Configuration_ConfigurationView_UpdateSetting">UpdateSetting</a></td><td>
Updates the specified setting within the ConfigurationView .</td></tr></table>&nbsp;
<a href="#configurationview-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Configuration_ConfigurationView_config">config</a></td><td /></tr></table>&nbsp;
<a href="#configurationview-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Configuration">Dangr.Configuration Namespace</a><br />