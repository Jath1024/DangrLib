# EventBus.Unregister Method 
 

Unregisters an object from receiving events.

**Namespace:**&nbsp;<a href="N_Dangr_Event">Dangr.Event</a><br />**Assembly:**&nbsp;Dangr.Event (in Dangr.Event.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public void Unregister(
	Object listener
)
```

**VB**<br />
``` VB
Public Sub Unregister ( 
	listener As Object
)
```

**C++**<br />
``` C++
public:
void Unregister(
	Object^ listener
)
```


#### Parameters
&nbsp;<dl><dt>listener</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />The object to unregister</dd></dl>

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/27426hcy" target="_blank">ArgumentNullException</a></td><td>If the object is null.</td></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/2asft85a" target="_blank">InvalidOperationException</a></td><td>If the object contains a non-public method witout exactly one parameter marked with an <a href="T_Dangr_Event_EventHandlerAttribute">EventHandlerAttribute</a> .</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Event_EventBus">EventBus Class</a><br /><a href="N_Dangr_Event">Dangr.Event Namespace</a><br />