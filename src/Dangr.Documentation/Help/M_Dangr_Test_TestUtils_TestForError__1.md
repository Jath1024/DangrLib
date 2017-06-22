# TestUtils.TestForError(*T*) Method 
 

Runs a *test* and validates that an error of the specified t ype was thrown.

**Namespace:**&nbsp;<a href="N_Dangr_Test">Dangr.Test</a><br />**Assembly:**&nbsp;Dangr.Test (in Dangr.Test.dll) Version: 1.0.6381.41478 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static void TestForError<T>(
	Action test,
	string message
)
where T : Exception

```

**VB**<br />
``` VB
Public Shared Sub TestForError(Of T As Exception) ( 
	test As Action,
	message As String
)
```

**C++**<br />
``` C++
public:
generic<typename T>
where T : Exception
static void TestForError(
	Action^ test, 
	String^ message
)
```


#### Parameters
&nbsp;<dl><dt>test</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/bb534741" target="_blank">System.Action</a><br />The test to run.</dd><dt>message</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The error message to display if the error is not caught.</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>The type of error to catch.</dd></dl>

## See Also


#### Reference
<a href="T_Dangr_Test_TestUtils">TestUtils Class</a><br /><a href="N_Dangr_Test">Dangr.Test Namespace</a><br />