# AllSettingsConfigurationView Class
 

A <a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView</a> that exposes all of the settings in the <a href="T_Dangr_Configuration_Configuration">Configuration</a> as a dictionary.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="T_Dangr_Configuration_ConfigurationView">Dangr.Configuration.ConfigurationView</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Dangr.Configuration.Views.AllSettingsConfigurationView<br />
**Namespace:**&nbsp;<a href="N_Dangr_Configuration_Views">Dangr.Configuration.Views</a><br />**Assembly:**&nbsp;Dangr.Configuration (in Dangr.Configuration.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class AllSettingsConfigurationView : ConfigurationView
```

**VB**<br />
``` VB
Public Class AllSettingsConfigurationView
	Inherits ConfigurationView
```

**C++**<br />
``` C++
public ref class AllSettingsConfigurationView : public ConfigurationView
```

The AllSettingsConfigurationView type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_Views_AllSettingsConfigurationView__ctor">AllSettingsConfigurationView</a></td><td>
Initializes a new instance of the AllSettingsConfigurationView class.</td></tr></table>&nbsp;
<a href="#allsettingsconfigurationview-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Configuration_ConfigurationView_IsDisposed">IsDisposed</a></td><td>
Gets a value indicating whether this <a href="T_Dangr_Util_ICancelable">ICancelable</a> has been disposed.
 (Inherited from <a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Configuration_Views_AllSettingsConfigurationView_Settings">Settings</a></td><td>
Gets the dictionary of settings exposed in the <a href="T_Dangr_Configuration_Configuration">Configuration</a> .</td></tr></table>&nbsp;
<a href="#allsettingsconfigurationview-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Configuration_ConfigurationView_Configuration_SettingChanged">Configuration_SettingChanged</a></td><td> (Inherited from <a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_ConfigurationView_Dispose">Dispose()</a></td><td>
Disposes the resources managed by this <a href="T_Dangr_Util_ICancelable">ICancelable</a> .
 (Inherited from <a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Configuration_ConfigurationView_Dispose_1">Dispose(Boolean)</a></td><td>
Disposes the resources managed by this <a href="T_Dangr_Util_ICancelable">ICancelable</a> .
 (Inherited from <a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_ConfigurationView_GetSetting">GetSetting</a></td><td>
Gets the setting with the specified name.
 (Inherited from <a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_Views_AllSettingsConfigurationView_ToString">ToString</a></td><td>
Returns a string representation of all of the settings and their values.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">Object.ToString()</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Configuration_Views_AllSettingsConfigurationView_UpdateSetting">UpdateSetting</a></td><td>
Updates the specified setting within the <a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView</a> .
 (Overrides <a href="M_Dangr_Configuration_ConfigurationView_UpdateSetting">ConfigurationView.UpdateSetting(String, String)</a>.)</td></tr></table>&nbsp;
<a href="#allsettingsconfigurationview-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Configuration_ConfigurationView_config">config</a></td><td> (Inherited from <a href="T_Dangr_Configuration_ConfigurationView">ConfigurationView</a>.)</td></tr></table>&nbsp;
<a href="#allsettingsconfigurationview-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Configuration_Views">Dangr.Configuration.Views Namespace</a><br />