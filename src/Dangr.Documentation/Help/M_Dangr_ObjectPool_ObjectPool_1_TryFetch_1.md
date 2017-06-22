# ObjectPool(*T*).TryFetch Method (*T*)
 

Tries to get a reference to an object of type [!:T] .

**Namespace:**&nbsp;<a href="N_Dangr_ObjectPool">Dangr.ObjectPool</a><br />**Assembly:**&nbsp;Dangr.ObjectPool (in Dangr.ObjectPool.dll) Version: 1.0.6381.41477 (1.0.*)

## Syntax

**C#**<br />
``` C#
protected abstract bool TryFetch(
	out T obj
)
```

**VB**<br />
``` VB
Protected MustOverride Function TryFetch ( 
	<OutAttribute> ByRef obj As T
) As Boolean
```

**C++**<br />
``` C++
protected:
virtual bool TryFetch(
	[OutAttribute] T% obj
) abstract
```


#### Parameters
&nbsp;<dl><dt>obj</dt><dd>Type: <a href="T_Dangr_ObjectPool_ObjectPool_1">*T*</a><br />The reference to the object fetched from the [!:Dangr.ObjectPool.ObjectPool`1] .</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />`true` if a reference was fetched.

## See Also


#### Reference
<a href="T_Dangr_ObjectPool_ObjectPool_1">ObjectPool(T) Class</a><br /><a href="Overload_Dangr_ObjectPool_ObjectPool_1_TryFetch">TryFetch Overload</a><br /><a href="N_Dangr_ObjectPool">Dangr.ObjectPool Namespace</a><br />