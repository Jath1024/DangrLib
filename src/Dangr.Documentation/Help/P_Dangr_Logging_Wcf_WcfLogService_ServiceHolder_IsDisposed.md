# WcfLogService.ServiceHolder.IsDisposed Property 
 

Gets a value that indicates whether the object is disposed.

**Namespace:**&nbsp;<a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf</a><br />**Assembly:**&nbsp;Dangr.Logging.Wcf (in Dangr.Logging.Wcf.dll) Version: 1.0.6375.1749 (1.0.*)

## Syntax

**C#**<br />
``` C#
public bool IsDisposed { get; private set; }
```

**VB**<br />
``` VB
Public Property IsDisposed As Boolean
	Get
	Private Set
```

**C++**<br />
``` C++
public:
virtual property bool IsDisposed {
	bool get () sealed;
	private: void set (bool value) sealed;
}
```


#### Property Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a>

#### Implements
ICancelable.IsDisposed()<br />

## See Also


#### Reference
<a href="T_Dangr_Logging_Wcf_WcfLogService_ServiceHolder">WcfLogService.ServiceHolder Class</a><br /><a href="N_Dangr_Logging_Wcf">Dangr.Logging.Wcf Namespace</a><br />