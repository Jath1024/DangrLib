# MultiThreadedTaskScheduler Class
 

Provides a task scheduler that ensures a maximum concurrency level while running on top of the thread pool.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/dd321418" target="_blank">System.Threading.Tasks.TaskScheduler</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Dangr.Async.MultiThreadedTaskScheduler<br />
**Namespace:**&nbsp;<a href="N_Dangr_Async">Dangr.Async</a><br />**Assembly:**&nbsp;Dangr.Async (in Dangr.Async.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class MultiThreadedTaskScheduler : TaskScheduler
```

**VB**<br />
``` VB
Public Class MultiThreadedTaskScheduler
	Inherits TaskScheduler
```

**C++**<br />
``` C++
public ref class MultiThreadedTaskScheduler : public TaskScheduler
```

The MultiThreadedTaskScheduler type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Async_MultiThreadedTaskScheduler__ctor">MultiThreadedTaskScheduler</a></td><td>
Initializes a new instance of the MultiThreadedTaskScheduler class.</td></tr></table>&nbsp;
<a href="#multithreadedtaskscheduler-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dd321552" target="_blank">Id</a></td><td>
Gets the unique ID for this <a href="http://msdn2.microsoft.com/en-us/library/dd321418" target="_blank">TaskScheduler</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/dd321418" target="_blank">TaskScheduler</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Async_MultiThreadedTaskScheduler_MaximumConcurrencyLevel">MaximumConcurrencyLevel</a></td><td>
Gets the maximum concurrency level supported by this scheduler.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/dd321559" target="_blank">TaskScheduler.MaximumConcurrencyLevel</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Async_MultiThreadedTaskScheduler_NumThreadsRunning">NumThreadsRunning</a></td><td>
Gets the number threads currently running.</td></tr></table>&nbsp;
<a href="#multithreadedtaskscheduler-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Async_MultiThreadedTaskScheduler_GetScheduledTasks">GetScheduledTasks</a></td><td>
Gets an enumerable of the <a href="F_Dangr_Async_MultiThreadedTaskScheduler_tasks">tasks</a> currently scheduled on this scheduler.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/dd321302" target="_blank">TaskScheduler.GetScheduledTasks()</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Async_MultiThreadedTaskScheduler_NotifyThreadPoolOfPendingWork">NotifyThreadPoolOfPendingWork</a></td><td /></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Async_MultiThreadedTaskScheduler_QueueTask">QueueTask</a></td><td>
Queues a *task* to the scheduler.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/dd321313" target="_blank">TaskScheduler.QueueTask(Task)</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Async_MultiThreadedTaskScheduler_TryDequeue">TryDequeue</a></td><td>
Attempt to remove a previously scheduled *task* from the scheduler.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/dd449203" target="_blank">TaskScheduler.TryDequeue(Task)</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dd449173" target="_blank">TryExecuteTask</a></td><td>
Attempts to execute the provided <a href="http://msdn2.microsoft.com/en-us/library/dd235678" target="_blank">Task</a> on this scheduler.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/dd321418" target="_blank">TaskScheduler</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Async_MultiThreadedTaskScheduler_TryExecuteTaskInline">TryExecuteTaskInline</a></td><td>
Attempts to execute the specified *task* on the current thread.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/dd449178" target="_blank">TaskScheduler.TryExecuteTaskInline(Task, Boolean)</a>.)</td></tr></table>&nbsp;
<a href="#multithreadedtaskscheduler-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Async_MultiThreadedTaskScheduler_currentThreadIsProcessingItems">currentThreadIsProcessingItems</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Async_MultiThreadedTaskScheduler_tasks">tasks</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Async_MultiThreadedTaskScheduler_tasksLock">tasksLock</a></td><td /></tr></table>&nbsp;
<a href="#multithreadedtaskscheduler-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Async">Dangr.Async Namespace</a><br />