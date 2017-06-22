# ConcurrentScheduledQueue(*T*).PostAt Method 
 

Queues a *value* to be retrieved at a specified time.

**Namespace:**&nbsp;<a href="N_Dangr_Collections">Dangr.Collections</a><br />**Assembly:**&nbsp;Dangr.Util (in Dangr.Util.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public void PostAt(
	T value,
	DateTimeOffset time
)
```

**VB**<br />
``` VB
Public Sub PostAt ( 
	value As T,
	time As DateTimeOffset
)
```

**C++**<br />
``` C++
public:
void PostAt(
	T value, 
	DateTimeOffset time
)
```


#### Parameters
&nbsp;<dl><dt>value</dt><dd>Type: <a href="T_Dangr_Collections_ConcurrentScheduledQueue_1">*T*</a><br />The value to enqueue.</dd><dt>time</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/bb341783" target="_blank">System.DateTimeOffset</a><br />The time to retrieve the value.</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Collections_ConcurrentScheduledQueue_1">ConcurrentScheduledQueue(T) Class</a><br /><a href="N_Dangr_Collections">Dangr.Collections Namespace</a><br />