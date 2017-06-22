# MultiThreadedTaskScheduler.TryDequeue Method 
 

Attempt to remove a previously scheduled *task* from the scheduler.

**Namespace:**&nbsp;<a href="N_Dangr_Async">Dangr.Async</a><br />**Assembly:**&nbsp;Dangr.Async (in Dangr.Async.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected override sealed bool TryDequeue(
	Task task
)
```

**VB**<br />
``` VB
Protected Overrides NotOverridable Function TryDequeue ( 
	task As Task
) As Boolean
```

**C++**<br />
``` C++
protected:
virtual bool TryDequeue(
	Task^ task
) override sealed
```


#### Parameters
&nbsp;<dl><dt>task</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/dd235678" target="_blank">System.Threading.Tasks.Task</a><br />The task to remove.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />`true` if the *task* was removed.

## See Also


#### Reference
<a href="T_Dangr_Async_MultiThreadedTaskScheduler">MultiThreadedTaskScheduler Class</a><br /><a href="N_Dangr_Async">Dangr.Async Namespace</a><br />