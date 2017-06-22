# AssertResolver.NotDisposed Method (ICancelable, String, ILogSource, String, Int32)
 

Show a message if the specified <a href="T_Dangr_Util_ICancelable">ICancelable</a> is disposed.

**Namespace:**&nbsp;<a href="N_Dangr_Diagnostics">Dangr.Diagnostics</a><br />**Assembly:**&nbsp;Dangr.Diagnostics (in Dangr.Diagnostics.dll) Version: 1.0.6381.41477 (1.0.*)

## Syntax

**C#**<br />
``` C#
public bool NotDisposed(
	ICancelable disposable,
	string name,
	ILogSource logSource = null,
	[CallerFilePathAttribute] string filePath = "",
	[CallerLineNumberAttribute] int lineNumber = 0
)
```

**VB**<br />
``` VB
Public Function NotDisposed ( 
	disposable As ICancelable,
	name As String,
	Optional logSource As ILogSource = Nothing,
	<CallerFilePathAttribute> Optional filePath As String = "",
	<CallerLineNumberAttribute> Optional lineNumber As Integer = 0
) As Boolean
```

**C++**<br />
``` C++
public:
bool NotDisposed(
	ICancelable^ disposable, 
	String^ name, 
	ILogSource^ logSource = nullptr, 
	[CallerFilePathAttribute] String^ filePath = L"", 
	[CallerLineNumberAttribute] int lineNumber = 0
)
```


#### Parameters
&nbsp;<dl><dt>disposable</dt><dd>Type: <a href="T_Dangr_Util_ICancelable">Dangr.Util.ICancelable</a><br />The <a href="T_Dangr_Util_ICancelable">ICancelable</a> to check.</dd><dt>name</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the <a href="T_Dangr_Util_ICancelable">ICancelable</a> .</dd><dt>logSource (Optional)</dt><dd>Type: <a href="T_Dangr_Logging_ILogSource">Dangr.Logging.ILogSource</a><br />The <a href="T_Dangr_Logging_ILogSource">ILogSource</a> used to log messages on failure.</dd><dt>filePath (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The file path of the caller. (Do not use)</dd><dt>lineNumber (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The line number of the caller. (Do not use)</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />True only if the assert condition passed. Otherwise false.

## See Also


#### Reference
<a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver Class</a><br /><a href="Overload_Dangr_Diagnostics_AssertResolver_NotDisposed">NotDisposed Overload</a><br /><a href="N_Dangr_Diagnostics">Dangr.Diagnostics Namespace</a><br />