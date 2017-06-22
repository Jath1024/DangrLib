# IdCounter Constructor 
 

Initializes a new instance of the <a href="T_Dangr_Util_IdCounter">IdCounter</a> class.

**Namespace:**&nbsp;<a href="N_Dangr_Util">Dangr.Util</a><br />**Assembly:**&nbsp;Dangr.Util (in Dangr.Util.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public IdCounter(
	ulong min,
	ulong size
)
```

**VB**<br />
``` VB
Public Sub New ( 
	min As ULong,
	size As ULong
)
```

**C++**<br />
``` C++
public:
IdCounter(
	unsigned long long min, 
	unsigned long long size
)
```


#### Parameters
&nbsp;<dl><dt>min</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/06cf7918" target="_blank">System.UInt64</a><br />The minimum value used by this <a href="T_Dangr_Util_IdCounter">IdCounter</a>.</dd><dt>size</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/06cf7918" target="_blank">System.UInt64</a><br />The size of the range of this <a href="T_Dangr_Util_IdCounter">IdCounter</a>.</dd></dl>

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/8xt94y6e" target="_blank">ArgumentOutOfRangeException</a></td><td>If the specified range overflows uint.MaxValue.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Util_IdCounter">IdCounter Class</a><br /><a href="N_Dangr_Util">Dangr.Util Namespace</a><br />