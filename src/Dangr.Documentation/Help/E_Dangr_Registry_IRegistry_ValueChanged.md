# IRegistry.ValueChanged Event
 

Occurs when a value stored in this <a href="T_Dangr_Registry_IRegistry">IRegistry</a> is added, updated, or removed.

**Namespace:**&nbsp;<a href="N_Dangr_Registry">Dangr.Registry</a><br />**Assembly:**&nbsp;Dangr.Registry (in Dangr.Registry.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
event EventHandler<RegistryValueChangedEventArgs> ValueChanged
```

**VB**<br />
``` VB
Event ValueChanged As EventHandler(Of RegistryValueChangedEventArgs)
```

**C++**<br />
``` C++
 event EventHandler<RegistryValueChangedEventArgs^>^ ValueChanged {
	void add (EventHandler<RegistryValueChangedEventArgs^>^ value);
	void remove (EventHandler<RegistryValueChangedEventArgs^>^ value);
}
```


#### Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/db0etb8x" target="_blank">System.EventHandler</a>(<a href="T_Dangr_Registry_RegistryValueChangedEventArgs">RegistryValueChangedEventArgs</a>)

## See Also


#### Reference
<a href="T_Dangr_Registry_IRegistry">IRegistry Interface</a><br /><a href="N_Dangr_Registry">Dangr.Registry Namespace</a><br />