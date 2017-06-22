# EntityTable(*TEntity*).Add Method 
 

Adds an [!:TEntity] to the [!:Dangr.Entity.EntityTable`1] .

**Namespace:**&nbsp;<a href="N_Dangr_Entity">Dangr.Entity</a><br />**Assembly:**&nbsp;Dangr.Entity (in Dangr.Entity.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public EntityInfo Add(
	TEntity entity
)
```

**VB**<br />
``` VB
Public Function Add ( 
	entity As TEntity
) As EntityInfo
```

**C++**<br />
``` C++
public:
EntityInfo^ Add(
	TEntity entity
)
```


#### Parameters
&nbsp;<dl><dt>entity</dt><dd>Type: <a href="T_Dangr_Entity_EntityTable_1">*TEntity*</a><br />The [!:TEntity] to add.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Entity_EntityInfo">EntityInfo</a><br />The <a href="T_Dangr_Entity_EntityInfo">EntityInfo</a> describing the added [!:TEntity] .

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/3w1b3114" target="_blank">ArgumentException</a></td><td>If the [!:TEntity] was already added to this [!:Dangr.Entity.EntityTable`1] .</td></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/2asft85a" target="_blank">InvalidOperationException</a></td><td>If the specified <a href="T_Dangr_Entity_IEntity">IEntity</a> does not have an <a href="T_Dangr_Entity_EntityAttribute">EntityAttribute</a> or its *entity* name does not have an ID partition.</td></tr><tr><td><a href="T_Dangr_Util_IdCounterOutOfRangeException">IdCounterOutOfRangeException</a></td><td>If the *entity* partition for the [!:TEntity] 's *entity* name runs out of bounds.</td></tr></table>

## See Also


#### Reference
<a href="T_Dangr_Entity_EntityTable_1">EntityTable(TEntity) Class</a><br /><a href="N_Dangr_Entity">Dangr.Entity Namespace</a><br />