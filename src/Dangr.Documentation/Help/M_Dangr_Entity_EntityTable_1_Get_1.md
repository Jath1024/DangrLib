# EntityTable(*TEntity*).Get Method (UInt64)
 

Gets a [!:TEntity] from the [!:Dangr.Entity.EntityTable`1] .

**Namespace:**&nbsp;<a href="N_Dangr_Entity">Dangr.Entity</a><br />**Assembly:**&nbsp;Dangr.Entity (in Dangr.Entity.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public TEntity Get(
	ulong id
)
```

**VB**<br />
``` VB
Public Function Get ( 
	id As ULong
) As TEntity
```

**C++**<br />
``` C++
public:
TEntity Get(
	unsigned long long id
)
```


#### Parameters
&nbsp;<dl><dt>id</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/06cf7918" target="_blank">System.UInt64</a><br />The id of the [!:TEntity] to get.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_Entity_EntityTable_1">*TEntity*</a><br />The [!:TEntity] with the specified Id, or null.

## See Also


#### Reference
<a href="T_Dangr_Entity_EntityTable_1">EntityTable(TEntity) Class</a><br /><a href="Overload_Dangr_Entity_EntityTable_1_Get">Get Overload</a><br /><a href="N_Dangr_Entity">Dangr.Entity Namespace</a><br />