# DebugConfigurationSource Class<a href="T_Dangr_Configuration_ConfigurationSource">ConfigurationSource</a> that can be used to programmatically populate settings in a <a href="T_Dangr_Configuration_Configuration">Configuration</a> .


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="T_Dangr_Configuration_ConfigurationSource">Dangr.Configuration.ConfigurationSource</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Dangr.Configuration.Sources.DebugConfigurationSource<br />
**Namespace:**&nbsp;<a href="N_Dangr_Configuration_Sources">Dangr.Configuration.Sources</a><br />**Assembly:**&nbsp;Dangr.Configuration (in Dangr.Configuration.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class DebugConfigurationSource : ConfigurationSource
```

**VB**<br />
``` VB
Public Class DebugConfigurationSource
	Inherits ConfigurationSource
```

**C++**<br />
``` C++
public ref class DebugConfigurationSource : public ConfigurationSource
```

The DebugConfigurationSource type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_Sources_DebugConfigurationSource__ctor">DebugConfigurationSource</a></td><td>
Initializes a new instance of the DebugConfigurationSource class.</td></tr></table>&nbsp;
<a href="#debugconfigurationsource-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_Sources_DebugConfigurationSource_TryAddOrUpdateSetting">TryAddOrUpdateSetting</a></td><td>
Tries to add or update a setting in the registered <a href="T_Dangr_Configuration_Configuration">Configuration</a> .</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_Sources_DebugConfigurationSource_TryLockSetting">TryLockSetting</a></td><td>
Tries to lock the setting with the specified name.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_Sources_DebugConfigurationSource_TryUnlockSetting">TryUnlockSetting</a></td><td>
Tries to unlock the setting with the specified name.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Configuration_Sources_DebugConfigurationSource_UpdateConfiguration">UpdateConfiguration</a></td><td>
Populates all of this <a href="T_Dangr_Configuration_ConfigurationSource">ConfigurationSource</a> s settings in the registered <a href="T_Dangr_Configuration_Configuration">Configuration</a> .
 (Overrides <a href="M_Dangr_Configuration_ConfigurationSource_UpdateConfiguration">ConfigurationSource.UpdateConfiguration()</a>.)</td></tr></table>&nbsp;
<a href="#debugconfigurationsource-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Configuration_ConfigurationSource_config">config</a></td><td> (Inherited from <a href="T_Dangr_Configuration_ConfigurationSource">ConfigurationSource</a>.)</td></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Configuration_Sources_DebugConfigurationSource_modifiedSettings">modifiedSettings</a></td><td /></tr></table>&nbsp;
<a href="#debugconfigurationsource-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Configuration_Sources">Dangr.Configuration.Sources Namespace</a><br />