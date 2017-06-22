# EntityTable(*TEntity*).GetAll Method (String)
 

Gets all of the [!:TEntity] s with the specified *name* from the [!:Dangr.Entity.EntityTable`1] .

**Namespace:**&nbsp;<a href="N_Dangr_Entity">Dangr.Entity</a><br />**Assembly:**&nbsp;Dangr.Entity (in Dangr.Entity.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public IEnumerable<TEntity> GetAll(
	string name
)
```

**VB**<br />
``` VB
Public Function GetAll ( 
	name As String
) As IEnumerable(Of TEntity)
```

**C++**<br />
``` C++
public:
IEnumerable<TEntity>^ GetAll(
	String^ name
)
```


#### Parameters
&nbsp;<dl><dt>name</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the [!:TEntity] s to get.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">IEnumerable</a>(<a href="T_Dangr_Entity_EntityTable_1">*TEntity*</a>)<br />A list of the [!:TEntity] s with the specified name.

## See Also


#### Reference
<a href="T_Dangr_Entity_EntityTable_1">EntityTable(TEntity) Class</a><br /><a href="Overload_Dangr_Entity_EntityTable_1_GetAll">GetAll Overload</a><br /><a href="N_Dangr_Entity">Dangr.Entity Namespace</a><br />