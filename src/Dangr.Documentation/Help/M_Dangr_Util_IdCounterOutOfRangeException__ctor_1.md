# IdCounterOutOfRangeException Constructor (UInt64, UInt64, UInt64)
 

Initializes a new instance of the <a href="T_Dangr_Util_IdCounterOutOfRangeException">IdCounterOutOfRangeException</a> class.

**Namespace:**&nbsp;<a href="N_Dangr_Util">Dangr.Util</a><br />**Assembly:**&nbsp;Dangr.Util (in Dangr.Util.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public IdCounterOutOfRangeException(
	ulong min,
	ulong max,
	ulong next
)
```

**VB**<br />
``` VB
Public Sub New ( 
	min As ULong,
	max As ULong,
	next As ULong
)
```

**C++**<br />
``` C++
public:
IdCounterOutOfRangeException(
	unsigned long long min, 
	unsigned long long max, 
	unsigned long long next
)
```


#### Parameters
&nbsp;<dl><dt>min</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/06cf7918" target="_blank">System.UInt64</a><br />The minimum value for the <a href="T_Dangr_Util_IdCounter">IdCounter</a> .</dd><dt>max</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/06cf7918" target="_blank">System.UInt64</a><br />The maximum value for the <a href="T_Dangr_Util_IdCounter">IdCounter</a> .</dd><dt>next</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/06cf7918" target="_blank">System.UInt64</a><br />The next value for the <a href="T_Dangr_Util_IdCounter">IdCounter</a> .</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Util_IdCounterOutOfRangeException">IdCounterOutOfRangeException Class</a><br /><a href="Overload_Dangr_Util_IdCounterOutOfRangeException__ctor">IdCounterOutOfRangeException Overload</a><br /><a href="N_Dangr_Util">Dangr.Util Namespace</a><br />