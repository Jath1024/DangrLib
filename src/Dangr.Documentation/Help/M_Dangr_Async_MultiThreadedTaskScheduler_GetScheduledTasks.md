# MultiThreadedTaskScheduler.GetScheduledTasks Method 
 

Gets an enumerable of the <a href="F_Dangr_Async_MultiThreadedTaskScheduler_tasks">tasks</a> currently scheduled on this scheduler.

**Namespace:**&nbsp;<a href="N_Dangr_Async">Dangr.Async</a><br />**Assembly:**&nbsp;Dangr.Async (in Dangr.Async.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected override sealed IEnumerable<Task> GetScheduledTasks()
```

**VB**<br />
``` VB
Protected Overrides NotOverridable Function GetScheduledTasks As IEnumerable(Of Task)
```

**C++**<br />
``` C++
protected:
virtual IEnumerable<Task^>^ GetScheduledTasks() override sealed
```


#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">IEnumerable</a>(<a href="http://msdn2.microsoft.com/en-us/library/dd235678" target="_blank">Task</a>)<br />An enumerable of the <a href="F_Dangr_Async_MultiThreadedTaskScheduler_tasks">tasks</a> currently scheduled on this scheduler.

## See Also


#### Reference
<a href="T_Dangr_Async_MultiThreadedTaskScheduler">MultiThreadedTaskScheduler Class</a><br /><a href="N_Dangr_Async">Dangr.Async Namespace</a><br />