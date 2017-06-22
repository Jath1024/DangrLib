# MultiThreadedTaskScheduler.TryExecuteTaskInline Method 
 

Attempts to execute the specified *task* on the current thread.

**Namespace:**&nbsp;<a href="N_Dangr_Async">Dangr.Async</a><br />**Assembly:**&nbsp;Dangr.Async (in Dangr.Async.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected override sealed bool TryExecuteTaskInline(
	Task task,
	bool taskWasPreviouslyQueued
)
```

**VB**<br />
``` VB
Protected Overrides NotOverridable Function TryExecuteTaskInline ( 
	task As Task,
	taskWasPreviouslyQueued As Boolean
) As Boolean
```

**C++**<br />
``` C++
protected:
virtual bool TryExecuteTaskInline(
	Task^ task, 
	bool taskWasPreviouslyQueued
) override sealed
```


#### Parameters
&nbsp;<dl><dt>task</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/dd235678" target="_blank">System.Threading.Tasks.Task</a><br />The task to execute.</dd><dt>taskWasPreviouslyQueued</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />Indicates whether this *task* was previously queued.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />True if the *task* was executed.

## See Also


#### Reference
<a href="T_Dangr_Async_MultiThreadedTaskScheduler">MultiThreadedTaskScheduler Class</a><br /><a href="N_Dangr_Async">Dangr.Async Namespace</a><br />