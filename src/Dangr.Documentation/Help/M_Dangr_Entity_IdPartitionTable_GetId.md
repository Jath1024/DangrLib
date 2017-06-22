# IdPartitionTable.GetId Method 
 

Gets the next ID in the partition defined for the given entity name.

**Namespace:**&nbsp;<a href="N_Dangr_Entity">Dangr.Entity</a><br />**Assembly:**&nbsp;Dangr.Entity (in Dangr.Entity.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public ulong GetId(
	string entityName
)
```

**VB**<br />
``` VB
Public Function GetId ( 
	entityName As String
) As ULong
```

**C++**<br />
``` C++
public:
unsigned long long GetId(
	String^ entityName
)
```


#### Parameters
&nbsp;<dl><dt>entityName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The entity name.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/06cf7918" target="_blank">UInt64</a><br />The next ID in the partition defined for the given entity name.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/2asft85a" target="_blank">InvalidOperationException</a></td><td>If an ID cannot be generated for the given entity name.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Entity_IdPartitionTable">IdPartitionTable Class</a><br /><a href="N_Dangr_Entity">Dangr.Entity Namespace</a><br />