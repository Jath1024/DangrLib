# AssertResolver.IsInRange Method (Double, Double, Double, String, ILogSource, String, Int32)
 

Show a *message* if the *value* is outside of the specified range.

**Namespace:**&nbsp;<a href="N_Dangr_Diagnostics">Dangr.Diagnostics</a><br />**Assembly:**&nbsp;Dangr.Diagnostics (in Dangr.Diagnostics.dll) Version: 1.0.6381.41477 (1.0.*)

## Syntax

**C#**<br />
``` C#
public bool IsInRange(
	double value,
	double min,
	double max,
	string message,
	ILogSource logSource = null,
	[CallerFilePathAttribute] string filePath = "",
	[CallerLineNumberAttribute] int lineNumber = 0
)
```

**VB**<br />
``` VB
Public Function IsInRange ( 
	value As Double,
	min As Double,
	max As Double,
	message As String,
	Optional logSource As ILogSource = Nothing,
	<CallerFilePathAttribute> Optional filePath As String = "",
	<CallerLineNumberAttribute> Optional lineNumber As Integer = 0
) As Boolean
```

**C++**<br />
``` C++
public:
bool IsInRange(
	double value, 
	double min, 
	double max, 
	String^ message, 
	ILogSource^ logSource = nullptr, 
	[CallerFilePathAttribute] String^ filePath = L"", 
	[CallerLineNumberAttribute] int lineNumber = 0
)
```


#### Parameters
&nbsp;<dl><dt>value</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/643eft0t" target="_blank">System.Double</a><br />The value to check.</dd><dt>min</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/643eft0t" target="_blank">System.Double</a><br />The minimum *value* of the range inclusive.</dd><dt>max</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/643eft0t" target="_blank">System.Double</a><br />The maximum *value* of the range inclusive.</dd><dt>message</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The message to show.</dd><dt>logSource (Optional)</dt><dd>Type: <a href="T_Dangr_Logging_ILogSource">Dangr.Logging.ILogSource</a><br />The <a href="T_Dangr_Logging_ILogSource">ILogSource</a> used to log messages on failure.</dd><dt>filePath (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The file path of the caller. (Do not use)</dd><dt>lineNumber (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The line number of the caller. (Do not use)</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />True only if the assert condition passed. Otherwise false.

## See Also


#### Reference
<a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver Class</a><br /><a href="Overload_Dangr_Diagnostics_AssertResolver_IsInRange">IsInRange Overload</a><br /><a href="N_Dangr_Diagnostics">Dangr.Diagnostics Namespace</a><br />