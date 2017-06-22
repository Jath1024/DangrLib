# IPooledObject Interface
 

Provides methods for acquiring and resetting items that can be used in an object pool.

**Namespace:**&nbsp;<a href="N_Dangr_ObjectPool">Dangr.ObjectPool</a><br />**Assembly:**&nbsp;Dangr.ObjectPool (in Dangr.ObjectPool.dll) Version: 1.0.6381.41477 (1.0.*)

## Syntax

**C#**<br />
``` C#
public interface IPooledObject
```

**VB**<br />
``` VB
Public Interface IPooledObject
```

**C++**<br />
``` C++
public interface class IPooledObject
```

The IPooledObject type exposes the following members.


## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_ObjectPool_IPooledObject_Acquire">Acquire</a></td><td>
Acquires this IPooledObject instance as it is pulled from an [!:Dangr.ObjectPool.ObjectPool`1] . Should only be called by the [!:Dangr.ObjectPool.ObjectPool`1] .</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_ObjectPool_IPooledObject_Reset">Reset</a></td><td>
Resets this IPooledObject instance as it is returned to an [!:Dangr.ObjectPool.ObjectPool`1] . Should only be called by the [!:Dangr.ObjectPool.ObjectPool`1] .</td></tr></table>&nbsp;
<a href="#ipooledobject-interface">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_ObjectPool">Dangr.ObjectPool Namespace</a><br />