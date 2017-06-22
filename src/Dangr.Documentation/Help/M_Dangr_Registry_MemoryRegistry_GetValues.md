# MemoryRegistry.GetValues Method 
 

Gets all values from the registry.

**Namespace:**&nbsp;<a href="N_Dangr_Registry">Dangr.Registry</a><br />**Assembly:**&nbsp;Dangr.Registry (in Dangr.Registry.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public IDictionary<string, string> GetValues()
```

**VB**<br />
``` VB
Public Function GetValues As IDictionary(Of String, String)
```

**C++**<br />
``` C++
public:
virtual IDictionary<String^, String^>^ GetValues() sealed
```


#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s4ys34ea" target="_blank">IDictionary</a>(<a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>, <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a>)<br />A <a href="http://msdn2.microsoft.com/en-us/library/s4ys34ea" target="_blank">IDictionary(TKey, TValue)</a> containing all the values in the registry.

#### Implements
<a href="M_Dangr_Registry_IRegistry_GetValues">IRegistry.GetValues()</a><br />

## See Also


#### Reference
<a href="T_Dangr_Registry_MemoryRegistry">MemoryRegistry Class</a><br /><a href="N_Dangr_Registry">Dangr.Registry Namespace</a><br />