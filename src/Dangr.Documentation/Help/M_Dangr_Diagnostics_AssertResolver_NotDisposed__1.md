# AssertResolver.NotDisposed(*T*) Method (*T*, ILogSource, String, Int32)
 

Show a message if the specified <a href="T_Dangr_Util_ICancelable">ICancelable</a> is disposed.

**Namespace:**&nbsp;<a href="N_Dangr_Diagnostics">Dangr.Diagnostics</a><br />**Assembly:**&nbsp;Dangr.Diagnostics (in Dangr.Diagnostics.dll) Version: 1.0.6381.41477 (1.0.*)

## Syntax

**C#**<br />
``` C#
public bool NotDisposed<T>(
	T disposable,
	ILogSource logSource = null,
	[CallerFilePathAttribute] string filePath = "",
	[CallerLineNumberAttribute] int lineNumber = 0
)
where T : ICancelable, INamedObject

```

**VB**<br />
``` VB
Public Function NotDisposed(Of T As {ICancelable, INamedObject}) ( 
	disposable As T,
	Optional logSource As ILogSource = Nothing,
	<CallerFilePathAttribute> Optional filePath As String = "",
	<CallerLineNumberAttribute> Optional lineNumber As Integer = 0
) As Boolean
```

**C++**<br />
``` C++
public:
generic<typename T>
where T : ICancelable, INamedObject
bool NotDisposed(
	T disposable, 
	ILogSource^ logSource = nullptr, 
	[CallerFilePathAttribute] String^ filePath = L"", 
	[CallerLineNumberAttribute] int lineNumber = 0
)
```


#### Parameters
&nbsp;<dl><dt>disposable</dt><dd>Type: *T*<br />The <a href="T_Dangr_Util_ICancelable">ICancelable</a> and <a href="T_Dangr_Util_INamedObject">INamedObject</a> to check.</dd><dt>logSource (Optional)</dt><dd>Type: <a href="T_Dangr_Logging_ILogSource">Dangr.Logging.ILogSource</a><br />The <a href="T_Dangr_Logging_ILogSource">ILogSource</a> used to log messages on failure.</dd><dt>filePath (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The file path of the caller. (Do not use)</dd><dt>lineNumber (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">System.Int32</a><br />The line number of the caller. (Do not use)</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>\[Missing <typeparam name="T"/> documentation for "M:Dangr.Diagnostics.AssertResolver.NotDisposed``1(``0,Dangr.Logging.ILogSource,System.String,System.Int32)"\]</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />True only if the assert condition passed. Otherwise false.

## See Also


#### Reference
<a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver Class</a><br /><a href="Overload_Dangr_Diagnostics_AssertResolver_NotDisposed">NotDisposed Overload</a><br /><a href="N_Dangr_Diagnostics">Dangr.Diagnostics Namespace</a><br />