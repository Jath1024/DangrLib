# MemoryLogger.MaxNumEntries Property 
 

Gets or sets the maximum number entries.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers</a><br />**Assembly:**&nbsp;Dangr.Logging.Loggers (in Dangr.Logging.Loggers.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public int MaxNumEntries { get; set; }
```

**VB**<br />
``` VB
Public Property MaxNumEntries As Integer
	Get
	Set
```

**C++**<br />
``` C++
public:
property int MaxNumEntries {
	int get ();
	void set (int value);
}
```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/td2s409d" target="_blank">Int32</a>

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/8xt94y6e" target="_blank">ArgumentOutOfRangeException</a></td><td>MaxNumEntries;Value must be greater than 0</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Logging_Loggers_MemoryLogger">MemoryLogger Class</a><br /><a href="N_Dangr_Logging_Loggers">Dangr.Logging.Loggers Namespace</a><br />