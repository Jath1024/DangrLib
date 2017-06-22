# MemoryRegistry Class
 

Provides access to a shared set of data in memory.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Registry.MemoryRegistry<br />
**Namespace:**&nbsp;<a href="N_Dangr_Registry">Dangr.Registry</a><br />**Assembly:**&nbsp;Dangr.Registry (in Dangr.Registry.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
[DataContractAttribute]
public sealed class MemoryRegistry : IRegistry
```

**VB**<br />
``` VB
<DataContractAttribute>
Public NotInheritable Class MemoryRegistry
	Implements IRegistry
```

**C++**<br />
``` C++
[DataContractAttribute]
public ref class MemoryRegistry sealed : IRegistry
```

The MemoryRegistry type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry__ctor">MemoryRegistry</a></td><td>
Initializes a new instance of the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> class.</td></tr></table>&nbsp;
<a href="#memoryregistry-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Registry_MemoryRegistry_Count">Count</a></td><td>
Gets the number of elements stored in this <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</td></tr></table>&nbsp;
<a href="#memoryregistry-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_DeserializeInitialization">DeserializeInitialization</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_Edit">Edit</a></td><td>
Create a new editor for this registry.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_GetBool">GetBool</a></td><td>
Gets a bool value from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_GetDouble">GetDouble</a></td><td>
Gets a double value from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_GetFloat">GetFloat</a></td><td>
Gets a float value from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_GetInt">GetInt</a></td><td>
Gets an int value from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_GetLong">GetLong</a></td><td>
Gets an long value from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_GetString">GetString</a></td><td>
Gets a string value from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_GetValue">GetValue</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_GetValues">GetValues</a></td><td>
Gets all values from the registry.</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_Initialize">Initialize</a></td><td /></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_NotifyChanges">NotifyChanges</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_ToString">ToString</a></td><td>
Returns a string that represents the current object.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">Object.ToString()</a>.)</td></tr></table>&nbsp;
<a href="#memoryregistry-class">Back to Top</a>

## Events
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public event](media/pubevent.gif "Public event")</td><td><a href="E_Dangr_Registry_MemoryRegistry_ValueChanged">ValueChanged</a></td><td>
Occurs when a value stored in this <a href="T_Dangr_Registry_IRegistry">IRegistry</a> is added, updated, or removed.</td></tr></table>&nbsp;
<a href="#memoryregistry-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Registry_MemoryRegistry_values">values</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Registry_MemoryRegistry_writeLock">writeLock</a></td><td /></tr></table>&nbsp;
<a href="#memoryregistry-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Registry">Dangr.Registry Namespace</a><br />