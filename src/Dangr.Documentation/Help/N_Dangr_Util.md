# Dangr.Util Namespace
 

The Dangr.Util namespace provides miscellaneous utilities for use with DangrLib.


## Classes
&nbsp;<table><tr><th></th><th>Class</th><th>Description</th></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Util_IdCounter">IdCounter</a></td><td>
A counter that keeps track of the next ID within a range of IDs.</td></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Util_IdCounter_Range">IdCounter.Range</a></td><td>
Helper class with constants definine ranges.</td></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Util_IdCounterOutOfRangeException">IdCounterOutOfRangeException</a></td><td>
Exception thrown when an <a href="T_Dangr_Util_IdCounter">IdCounter</a> attempts to get an ID outside of its specified range.</td></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Util_InitializableExtensions">InitializableExtensions</a></td><td>

Provides extension methods to the <a href="T_Dangr_Util_IInitializable">IInitializable</a>

interface.</td></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Util_StaticIdCounter">StaticIdCounter</a></td><td>
An <a href="T_Dangr_Util_IIdCounter">IIdCounter</a> that contains a single ID.</td></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Util_StringExtensions">StringExtensions</a></td><td>
Provides string utility methods</td></tr></table>

## Interfaces
&nbsp;<table><tr><th></th><th>Interface</th><th>Description</th></tr><tr><td>![Public interface](media/pubinterface.gif "Public interface")</td><td><a href="T_Dangr_Util_ICancelable">ICancelable</a></td><td>
Disposable resource with dipsosal state tracking.</td></tr><tr><td>![Public interface](media/pubinterface.gif "Public interface")</td><td><a href="T_Dangr_Util_IIdCounter">IIdCounter</a></td><td>
Interface for a counter that keeps track of the next ID within a range of IDs.</td></tr><tr><td>![Public interface](media/pubinterface.gif "Public interface")</td><td><a href="T_Dangr_Util_IInitializable">IInitializable</a></td><td>
Provides a mechanism for performing instance initialization as a separate step from construction, and provides a property to get whether this instance has been initialized.</td></tr><tr><td>![Public interface](media/pubinterface.gif "Public interface")</td><td><a href="T_Dangr_Util_INamedObject">INamedObject</a></td><td>
Defines a property to retrieve the name of an object.</td></tr><tr><td>![Public interface](media/pubinterface.gif "Public interface")</td><td><a href="T_Dangr_Util_IUidObject">IUidObject</a></td><td>
Defines a property to retrieve an identifier unique to this object within a specific group.</td></tr></table>&nbsp;
