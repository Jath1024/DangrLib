# ConcurrentScheduledQueue(*T*) Class
 


Maintains a queue of items that can be scheduled to be retrieved immediately, after a delay, or after a specific time. The [!:Dangr.Collections.ConcurrentScheduledQueue`1]

can be safely accessed and enumerated from multiple threads concurrently.



## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Collections.ConcurrentScheduledQueue(T)<br />
**Namespace:**&nbsp;<a href="N_Dangr_Collections">Dangr.Collections</a><br />**Assembly:**&nbsp;Dangr.Util (in Dangr.Util.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class ConcurrentScheduledQueue<T>

```

**VB**<br />
``` VB
Public Class ConcurrentScheduledQueue(Of T)
```

**C++**<br />
``` C++
generic<typename T>
public ref class ConcurrentScheduledQueue
```


#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>The type of value stored in this [!:Dangr.Collections.ConcurrentScheduledQueue`1] .</dd></dl>&nbsp;
The ConcurrentScheduledQueue(T) type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Collections_ConcurrentScheduledQueue_1__ctor">ConcurrentScheduledQueue(T)</a></td><td>
Initializes a new instance of the [!:Dangr.Collections.ConcurrentScheduledQueue`1] class.</td></tr></table>&nbsp;
<a href="#concurrentscheduledqueue(*t*)-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Collections_ConcurrentScheduledQueue_1_Count">Count</a></td><td>
Gets the number of items enqueued in this [!:Dangr.Collections.ConcurrentScheduledQueue`1] .</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Collections_ConcurrentScheduledQueue_1_ReadyCount">ReadyCount</a></td><td>

Gets the number of items enqueued in this [!:Dangr.Collections.ConcurrentScheduledQueue`1]

that are ready to be retrieved immediately.</td></tr></table>&nbsp;
<a href="#concurrentscheduledqueue(*t*)-class">Back to Top</a>

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
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Collections_ConcurrentScheduledQueue_1_Post">Post</a></td><td>
Queues a *value* to be retrieved immediately.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Collections_ConcurrentScheduledQueue_1_PostAt">PostAt</a></td><td>
Queues a *value* to be retrieved at a specified time.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Collections_ConcurrentScheduledQueue_1_PostDelayed">PostDelayed</a></td><td>
Queues a *value* to be retrieved after a delay.</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Collections_ConcurrentScheduledQueue_1_QueueDelayed">QueueDelayed</a></td><td /></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Collections_ConcurrentScheduledQueue_1_QueueImmediate">QueueImmediate</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Collections_ConcurrentScheduledQueue_1_TryGetNext">TryGetNext</a></td><td>
Returns an enumerator that iterates through the collection.</td></tr></table>&nbsp;
<a href="#concurrentscheduledqueue(*t*)-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Collections_ConcurrentScheduledQueue_1_delayedQueue">delayedQueue</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Collections_ConcurrentScheduledQueue_1_delayedQueueLock">delayedQueueLock</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Collections_ConcurrentScheduledQueue_1_immediateQueue">immediateQueue</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Collections_ConcurrentScheduledQueue_1_immediateQueueLock">immediateQueueLock</a></td><td /></tr></table>&nbsp;
<a href="#concurrentscheduledqueue(*t*)-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Collections">Dangr.Collections Namespace</a><br />