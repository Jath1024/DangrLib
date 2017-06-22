# MultiThreadedTaskScheduler Constructor 
 

Initializes a new instance of the <a href="T_Dangr_Async_MultiThreadedTaskScheduler">MultiThreadedTaskScheduler</a> class.

**Namespace:**&nbsp;<a href="N_Dangr_Async">Dangr.Async</a><br />**Assembly:**&nbsp;Dangr.Async (in Dangr.Async.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public MultiThreadedTaskScheduler(
	int maxThreads
)
```

**VB**<br />
``` VB
Public Sub New ( 
	maxThreads As Integer
)
```

**C++**<br />
``` C++
public:
MultiThreadedTaskScheduler(
	int maxThreads
)
```


#### Parameters
&nbsp;<dl><dt>maxThreads</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The maximum number of thread that can be run concurrently.</dd></dl>

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/8xt94y6e" target="_blank">ArgumentOutOfRangeException</a></td><td>Thrown if the maximum number of threads is %lt;= 0.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Async_MultiThreadedTaskScheduler">MultiThreadedTaskScheduler Class</a><br /><a href="N_Dangr_Async">Dangr.Async Namespace</a><br />