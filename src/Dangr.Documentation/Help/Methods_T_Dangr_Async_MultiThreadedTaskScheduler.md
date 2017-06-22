# MultiThreadedTaskScheduler Methods
 

The <a href="T_Dangr_Async_MultiThreadedTaskScheduler">MultiThreadedTaskScheduler</a> type exposes the following members.


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
<a href="#multithreadedtaskscheduler-methods">Back to Top</a>

## See Also


#### Reference
<a href="T_Dangr_Async_MultiThreadedTaskScheduler">MultiThreadedTaskScheduler Class</a><br /><a href="N_Dangr_Async">Dangr.Async Namespace</a><br />