# MemoryLogger.OnPropertyChanged Method 
 

Called when [property changed].

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers</a><br />**Assembly:**&nbsp;Dangr.Logging.Loggers (in Dangr.Logging.Loggers.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected void OnPropertyChanged(
	[CallerMemberNameAttribute] string name = ""
)
```

**VB**<br />
``` VB
Protected Sub OnPropertyChanged ( 
	<CallerMemberNameAttribute> Optional name As String = ""
)
```

**C++**<br />
``` C++
protected:
void OnPropertyChanged(
	[CallerMemberNameAttribute] String^ name = L""
)
```


#### Parameters
&nbsp;<dl><dt>name (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name.</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Logging_Loggers_MemoryLogger">MemoryLogger Class</a><br /><a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers Namespace</a><br />