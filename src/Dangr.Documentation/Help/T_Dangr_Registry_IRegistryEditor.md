# IRegistryEditor Interface
 

Allows editing of a <a href="T_Dangr_Registry_IRegistry">IRegistry</a> object. Changes are all made in a batch after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>. A lock may also be manually acquired, and is released on <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Registry">Dangr.Registry</a><br />**Assembly:**&nbsp;Dangr.Registry (in Dangr.Registry.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public interface IRegistryEditor
```

**VB**<br />
``` VB
Public Interface IRegistryEditor
```

**C++**<br />
``` C++
public interface class IRegistryEditor
```

The IRegistryEditor type exposes the following members.


## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply</a></td><td>
Commit the changes that have been made in this IRegistryEditor.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_IRegistryEditor_Clear">Clear</a></td><td>
Marks all values for deletion from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>. Will be applied before any sets in the same batch from this editor.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_IRegistryEditor_Lock">Lock</a></td><td>
Acquire a lock preventing any changes to this IRegistryEditor's <a href="T_Dangr_Registry_IRegistry">IRegistry</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_IRegistryEditor_Remove">Remove</a></td><td>
Marks a value for deletion from the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>. Will be applied before any sets in the same batch from this editor.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_IRegistryEditor_SetBool">SetBool</a></td><td>
Set a bool value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_IRegistryEditor_SetDouble">SetDouble</a></td><td>
Set a double value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_IRegistryEditor_SetFloat">SetFloat</a></td><td>
Set a float value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_IRegistryEditor_SetInt">SetInt</a></td><td>
Set an int value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_IRegistryEditor_SetLong">SetLong</a></td><td>
Set a long value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Registry_IRegistryEditor_SetString">SetString</a></td><td>
Set a string value to be written to the <a href="T_Dangr_Registry_IRegistry">IRegistry</a> after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>.</td></tr></table>&nbsp;
<a href="#iregistryeditor-interface">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Registry">Dangr.Registry Namespace</a><br />