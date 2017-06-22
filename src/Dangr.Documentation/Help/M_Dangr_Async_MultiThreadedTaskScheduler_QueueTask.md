# MultiThreadedTaskScheduler.QueueTask Method 
 

Queues a *task* to the scheduler.

**Namespace:**&nbsp;<a href="N_Dangr_Async">Dangr.Async</a><br />**Assembly:**&nbsp;Dangr.Async (in Dangr.Async.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected override sealed void QueueTask(
	Task task
)
```

**VB**<br />
``` VB
Protected Overrides NotOverridable Sub QueueTask ( 
	task As Task
)
```

**C++**<br />
``` C++
protected:
virtual void QueueTask(
	Task^ task
) override sealed
```


#### Parameters
&nbsp;<dl><dt>task</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/dd235678" target="_blank">System.Threading.Tasks.Task</a><br />The task.</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Async_MultiThreadedTaskScheduler">MultiThreadedTaskScheduler Class</a><br /><a href="N_Dangr_Async">Dangr.Async Namespace</a><br />