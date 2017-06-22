# ObjectPool(*T*).Get Method (Predicate(*T*))
 

Gets the first available object from the [!:Dangr.ObjectPool.ObjectPool`1] that matches the given [!:System.Predicate`1] .

**Namespace:**&nbsp;<a href="N_Dangr_ObjectPool">Dangr.ObjectPool</a><br />**Assembly:**&nbsp;Dangr.ObjectPool (in Dangr.ObjectPool.dll) Version: 1.0.6381.41477 (1.0.*)

## Syntax

**C#**<br />
``` C#
public T Get(
	Predicate<T> condition
)
```

**VB**<br />
``` VB
Public Function Get ( 
	condition As Predicate(Of T)
) As T
```

**C++**<br />
``` C++
public:
T Get(
	Predicate<T>^ condition
)
```


#### Parameters
&nbsp;<dl><dt>condition</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/bfcke1bz" target="_blank">System.Predicate</a>(<a href="T_Dangr_ObjectPool_ObjectPool_1">*T*</a>)<br />The [!:System.Predicate`1] to match.</dd></dl>

#### Return Value
Type: <a href="T_Dangr_ObjectPool_ObjectPool_1">*T*</a><br />The first available object from the [!:Dangr.ObjectPool.ObjectPool`1] .

## See Also


#### Reference
<a href="T_Dangr_ObjectPool_ObjectPool_1">ObjectPool(T) Class</a><br /><a href="Overload_Dangr_ObjectPool_ObjectPool_1_Get">Get Overload</a><br /><a href="N_Dangr_ObjectPool">Dangr.ObjectPool Namespace</a><br />