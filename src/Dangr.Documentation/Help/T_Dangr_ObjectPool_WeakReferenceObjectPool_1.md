# WeakReferenceObjectPool(*T*) Class
 

A generic implementation of an [!:Dangr.ObjectPool.ObjectPool`1] that uses <a href="http://msdn2.microsoft.com/en-us/library/hbh8w2zd" target="_blank">WeakReference</a> s to store it's objects.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="T_Dangr_ObjectPool_ObjectPool_1">Dangr.ObjectPool.ObjectPool</a>(*T*)<br />&nbsp;&nbsp;&nbsp;&nbsp;Dangr.ObjectPool.WeakReferenceObjectPool(T)<br />
**Namespace:**&nbsp;<a href="N_Dangr_ObjectPool">Dangr.ObjectPool</a><br />**Assembly:**&nbsp;Dangr.ObjectPool (in Dangr.ObjectPool.dll) Version: 1.0.6381.41477 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class WeakReferenceObjectPool<T> : ObjectPool<T>
where T : class, new(), IPooledObject

```

**VB**<br />
``` VB
Public Class WeakReferenceObjectPool(Of T As {Class, New, IPooledObject})
	Inherits ObjectPool(Of T)
```

**C++**<br />
``` C++
generic<typename T>
where T : ref class, gcnew(), IPooledObject
public ref class WeakReferenceObjectPool : public ObjectPool<T>
```


#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>The type of objects to store.</dd></dl>&nbsp;
The WeakReferenceObjectPool(T) type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_ObjectPool_WeakReferenceObjectPool_1__ctor">WeakReferenceObjectPool(T)</a></td><td>
Initializes a new instance of the WeakReferenceObjectPool(T) class</td></tr></table>&nbsp;
<a href="#weakreferenceobjectpool(*t*)-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_ObjectPool_WeakReferenceObjectPool_1_Clear">Clear</a></td><td>
Clears all items from the [!:Dangr.ObjectPool.ObjectPool`1] .
 (Overrides <a href="M_Dangr_ObjectPool_ObjectPool_1_Clear">ObjectPool(T).Clear()</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_ObjectPool_ObjectPool_1_Create">Create</a></td><td>
Creates a new instance of the pooled object.
 (Inherited from <a href="T_Dangr_ObjectPool_ObjectPool_1">ObjectPool(T)</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_ObjectPool_ObjectPool_1_Get">Get()</a></td><td>
Gets the first available object from the [!:Dangr.ObjectPool.ObjectPool`1] .
 (Inherited from <a href="T_Dangr_ObjectPool_ObjectPool_1">ObjectPool(T)</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_ObjectPool_ObjectPool_1_Get_1">Get(Predicate(T))</a></td><td>
Gets the first available object from the [!:Dangr.ObjectPool.ObjectPool`1] that matches the given [!:System.Predicate`1] .
 (Inherited from <a href="T_Dangr_ObjectPool_ObjectPool_1">ObjectPool(T)</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_ObjectPool_ObjectPool_1_Return">Return</a></td><td>
Returns the specified object to the [!:Dangr.ObjectPool.ObjectPool`1] .
 (Inherited from <a href="T_Dangr_ObjectPool_ObjectPool_1">ObjectPool(T)</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_ObjectPool_WeakReferenceObjectPool_1_Store">Store</a></td><td>
Stores the given object in the [!:Dangr.ObjectPool.ObjectPool`1] .
 (Overrides <a href="M_Dangr_ObjectPool_ObjectPool_1_Store">ObjectPool(T).Store(T)</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_ObjectPool_WeakReferenceObjectPool_1_TryFetch_1">TryFetch(T)</a></td><td>
Tries to get a reference to an object of type [!:T] .
 (Overrides <a href="M_Dangr_ObjectPool_ObjectPool_1_TryFetch_1">ObjectPool(T).TryFetch(T)</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_ObjectPool_WeakReferenceObjectPool_1_TryFetch">TryFetch(Predicate(T), T)</a></td><td>
Tries to get a reference to an object of type [!:T] .
 (Overrides <a href="M_Dangr_ObjectPool_ObjectPool_1_TryFetch">ObjectPool(T).TryFetch(Predicate(T), T)</a>.)</td></tr></table>&nbsp;
<a href="#weakreferenceobjectpool(*t*)-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_ObjectPool_WeakReferenceObjectPool_1_pool">pool</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_ObjectPool_WeakReferenceObjectPool_1_poolLock">poolLock</a></td><td /></tr></table>&nbsp;
<a href="#weakreferenceobjectpool(*t*)-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_ObjectPool">Dangr.ObjectPool Namespace</a><br />