# IdPartitionTable.PopulateTable Method 
 

Populates the <a href="T_Dangr_Entity_IdPartitionTable">IdPartitionTable</a> with values.

**Namespace:**&nbsp;<a href="N_Dangr_Entity">Dangr.Entity</a><br />**Assembly:**&nbsp;Dangr.Entity (in Dangr.Entity.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected abstract void PopulateTable()
```

**VB**<br />
``` VB
Protected MustOverride Sub PopulateTable
```

**C++**<br />
``` C++
protected:
virtual void PopulateTable() abstract
```


## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/8xt94y6e" target="_blank">ArgumentOutOfRangeException</a></td><td>If an added Id overflows uint.MaxValue.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Entity_IdPartitionTable">IdPartitionTable Class</a><br /><a href="N_Dangr_Entity">Dangr.Entity Namespace</a><br />