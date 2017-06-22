# EntityTable(*TEntity*).Remove Method 
 

Removes an [!:TEntity] from the [!:Dangr.Entity.EntityTable`1] .

**Namespace:**&nbsp;<a href="N_Dangr_Entity">Dangr.Entity</a><br />**Assembly:**&nbsp;Dangr.Entity (in Dangr.Entity.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public void Remove(
	TEntity entity
)
```

**VB**<br />
``` VB
Public Sub Remove ( 
	entity As TEntity
)
```

**C++**<br />
``` C++
public:
void Remove(
	TEntity entity
)
```


#### Parameters
&nbsp;<dl><dt>entity</dt><dd>Type: <a href="T_Dangr_Entity_EntityTable_1">*TEntity*</a><br />The [!:TEntity] to remove.</dd></dl>

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/27426hcy" target="_blank">ArgumentNullException</a></td><td>If the specified [!:TEntity] is null.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Entity_EntityTable_1">EntityTable(TEntity) Class</a><br /><a href="N_Dangr_Entity">Dangr.Entity Namespace</a><br />