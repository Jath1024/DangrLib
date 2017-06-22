# ConcurrentScheduledQueue(*T*).PostDelayed Method 
 

Queues a *value* to be retrieved after a delay.

**Namespace:**&nbsp;<a href="N_Dangr_Collections">Dangr.Collections</a><br />**Assembly:**&nbsp;Dangr.Util (in Dangr.Util.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public void PostDelayed(
	T value,
	TimeSpan delay
)
```

**VB**<br />
``` VB
Public Sub PostDelayed ( 
	value As T,
	delay As TimeSpan
)
```

**C++**<br />
``` C++
public:
void PostDelayed(
	T value, 
	TimeSpan delay
)
```


#### Parameters
&nbsp;<dl><dt>value</dt><dd>Type: <a href="T_Dangr_Collections_ConcurrentScheduledQueue_1">*T*</a><br />The value to enqueue.</dd><dt>delay</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/269ew577" target="_blank">System.TimeSpan</a><br />The time to wait before retrieving the value.</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Collections_ConcurrentScheduledQueue_1">ConcurrentScheduledQueue(T) Class</a><br /><a href="N_Dangr_Collections">Dangr.Collections Namespace</a><br />