# EntityTable(*TEntity*).Get(*T*) Method (String)
 

Gets an [!:TEntity] from the [!:Dangr.Entity.EntityTable`1] .

**Namespace:**&nbsp;<a href="N_Dangr_Entity">Dangr.Entity</a><br />**Assembly:**&nbsp;Dangr.Entity (in Dangr.Entity.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public T Get<T>(
	string name
)
where T : class, TEntity

```

**VB**<br />
``` VB
Public Function Get(Of T As {Class, TEntity}) ( 
	name As String
) As T
```

**C++**<br />
``` C++
public:
generic<typename T>
where T : ref class, TEntity
T Get(
	String^ name
)
```


#### Parameters
&nbsp;<dl><dt>name</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the [!:TEntity] to get.</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>The type of the [!:TEntity] to get.</dd></dl>

#### Return Value
Type: *T*<br />A [!:TEntity] with the specified name, or null.

## See Also


#### Reference
<a href="T_Dangr_Entity_EntityTable_1">EntityTable(TEntity) Class</a><br /><a href="Overload_Dangr_Entity_EntityTable_1_Get">Get Overload</a><br /><a href="N_Dangr_Entity">Dangr.Entity Namespace</a><br />