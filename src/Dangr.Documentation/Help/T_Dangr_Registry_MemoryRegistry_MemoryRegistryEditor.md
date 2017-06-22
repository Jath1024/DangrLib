# MemoryRegistry.MemoryRegistryEditor Class
 

Allows editing of a <a href="T_Dangr_Registry_IRegistry">IRegistry</a> object. Changes are all made in a batch after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>. A lock may also be manually acquired, and is released on <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Registry.MemoryRegistry.MemoryRegistryEditor<br />
**Namespace:**&nbsp;<a href="N_Dangr_Registry">Dangr.Registry</a><br />**Assembly:**&nbsp;Dangr.Registry (in Dangr.Registry.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public sealed class MemoryRegistryEditor : IRegistryEditor
```

**VB**<br />
``` VB
Public NotInheritable Class MemoryRegistryEditor
	Implements IRegistryEditor
```

**C++**<br />
``` C++
public ref class MemoryRegistryEditor sealed : IRegistryEditor
```

The MemoryRegistry.MemoryRegistryEditor type exposes the following members.


## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply</a></td><td>
Commit the changes that have been made in this <a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Clear">Clear</a></td><td>
Marks all values for deletion from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>. Will be applied before any sets in the same batch from this editor.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Lock">Lock</a></td><td>
Acquire a lock preventing any changes to this <a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor</a>'s <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Remove">Remove</a></td><td>
Marks a value for deletion from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>. Will be applied before any sets in the same batch from this editor.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_SetBool">SetBool</a></td><td>
Set a bool value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_SetDouble">SetDouble</a></td><td>
Set a double value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_SetFloat">SetFloat</a></td><td>
Set a float value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_SetInt">SetInt</a></td><td>
Set an int value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_SetLong">SetLong</a></td><td>
Set a long value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_SetString">SetString</a></td><td>
Set a string value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#memoryregistry.memoryregistryeditor-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_clearValues">clearValues</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_hasLock">hasLock</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_newValues">newValues</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_registry">registry</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_valuesToRemove">valuesToRemove</a></td><td /></tr></table>&nbsp;
<a href="#memoryregistry.memoryregistryeditor-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Registry">Dangr.Registry Namespace</a><br />