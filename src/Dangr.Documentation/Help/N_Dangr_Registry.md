# Dangr.Registry Namespace
 

The Dangr.Registry namespace provides utilities for accessing shared data in a scoped manner.


## Classes
&nbsp;<table><tr><th></th><th>Class</th><th>Description</th></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Registry_MemoryRegistry">MemoryRegistry</a></td><td>
Provides access to a shared set of data in memory.</td></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor">MemoryRegistry.MemoryRegistryEditor</a></td><td>
Allows editing of a <a href="T_Dangr_Registry_IRegistry">IRegistry</a> object. Changes are all made in a batch after <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>. A lock may also be manually acquired, and is released on <a href="M_Dangr_Registry_MemoryRegistry_MemoryRegistryEditor_Apply">Apply()</a>.</td></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Registry_RegistryValueChangedEventArgs">RegistryValueChangedEventArgs</a></td><td>

EventArgs for an <a href="E_Dangr_Registry_IRegistry_ValueChanged">ValueChanged</a>

event.</td></tr></table>

## Interfaces
&nbsp;<table><tr><th></th><th>Interface</th><th>Description</th></tr><tr><td>![Public interface](media/pubinterface.gif "Public interface")</td><td><a href="T_Dangr_Registry_IRegistry">IRegistry</a></td><td>
Provides access to a shared set of data</td></tr><tr><td>![Public interface](media/pubinterface.gif "Public interface")</td><td><a href="T_Dangr_Registry_IRegistryEditor">IRegistryEditor</a></td><td>
Allows editing of a <a href="T_Dangr_Registry_IRegistry">IRegistry</a> object. Changes are all made in a batch after <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>. A lock may also be manually acquired, and is released on <a href="M_Dangr_Registry_IRegistryEditor_Apply">Apply()</a>.</td></tr></table>&nbsp;
