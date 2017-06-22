# IdPartitionTable.AddStaticId Method (String, UInt64)
 

Adds a partition with a single ID for the specified entity name.

**Namespace:**&nbsp;<a href="N_Dangr_Entity">Dangr.Entity</a><br />**Assembly:**&nbsp;Dangr.Entity (in Dangr.Entity.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected void AddStaticId(
	string entityName,
	ulong id
)
```

**VB**<br />
``` VB
Protected Sub AddStaticId ( 
	entityName As String,
	id As ULong
)
```

**C++**<br />
``` C++
protected:
void AddStaticId(
	String^ entityName, 
	unsigned long long id
)
```


#### Parameters
&nbsp;<dl><dt>entityName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The entity name to add the partition for.</dd><dt>id</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/06cf7918" target="_blank">System.UInt64</a><br />The id to give to the partition</dd></dl>

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/2asft85a" target="_blank">InvalidOperationException</a></td><td>If the *id* specified is not larger than the last specified partition.</td></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/8xt94y6e" target="_blank">ArgumentOutOfRangeException</a></td><td>If the Id overflows uint.MaxValue.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Entity_IdPartitionTable">IdPartitionTable Class</a><br /><a href="Overload_Dangr_Entity_IdPartitionTable_AddStaticId">AddStaticId Overload</a><br /><a href="N_Dangr_Entity">Dangr.Entity Namespace</a><br />