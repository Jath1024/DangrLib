# MathHelper.Clamp Method (Int32, Int32, Int32)
 

Clamps a number between a minimum and a maximum.

**Namespace:**&nbsp;<a href="N_Dangr_Math">Dangr.Math</a><br />**Assembly:**&nbsp;Dangr.Math (in Dangr.Math.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static int Clamp(
	int n,
	int min,
	int max
)
```

**VB**<br />
``` VB
Public Shared Function Clamp ( 
	n As Integer,
	min As Integer,
	max As Integer
) As Integer
```

**C++**<br />
``` C++
public:
static int Clamp(
	int n, 
	int min, 
	int max
)
```


#### Parameters
&nbsp;<dl><dt>n</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The number to clamp.</dd><dt>min</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The minimum allowed value.</dd><dt>max</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The maximum allowed value.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">Int32</a><br />min, if n is lower than min; max, if n is higher than max; n otherwise.

## See Also


#### Reference
<a href="T_Dangr_Math_MathHelper">MathHelper Class</a><br /><a href="Overload_Dangr_Math_MathHelper_Clamp">Clamp Overload</a><br /><a href="N_Dangr_Math">Dangr.Math Namespace</a><br />