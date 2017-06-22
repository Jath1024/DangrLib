# AssertResolver.Failed Method 
 

Shows a *message* and gets an exception that should be thrown.

**Namespace:**&nbsp;<a href="N_Dangr_Diagnostics">Dangr.Diagnostics</a><br />**Assembly:**&nbsp;Dangr.Diagnostics (in Dangr.Diagnostics.dll) Version: 1.0.6381.41477 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected abstract bool Failed(
	AssertType type,
	string message,
	ILogSource logSource,
	out Exception ex
)
```

**VB**<br />
``` VB
Protected MustOverride Function Failed ( 
	type As AssertType,
	message As String,
	logSource As ILogSource,
	<OutAttribute> ByRef ex As Exception
) As Boolean
```

**C++**<br />
``` C++
protected:
virtual bool Failed(
	AssertType type, 
	String^ message, 
	ILogSource^ logSource, 
	[OutAttribute] Exception^% ex
) abstract
```


#### Parameters
&nbsp;<dl><dt>type</dt><dd>Type: <a href="T_Dangr_Diagnostics_AssertType">Dangr.Diagnostics.AssertType</a><br />The type of assert condition that was evaluated.</dd><dt>message</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The message that should be shown.</dd><dt>logSource</dt><dd>Type: <a href="T_Dangr_Logging_ILogSource">Dangr.Logging.ILogSource</a><br />The <a href="T_Dangr_Logging_ILogSource">ILogSource</a> used to log messages on failure.</dd><dt>ex</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/c18k6c59" target="_blank">System.Exception</a><br />Out param for an exception that should be thrown or null.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />True if the assert should be remembered.

## See Also


#### Reference
<a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver Class</a><br /><a href="N_Dangr_Diagnostics">Dangr.Diagnostics Namespace</a><br />