# ValidateResolver Class
 

Throws an exception if specific conditions are not met.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="T_Dangr_Diagnostics_AssertResolver">Dangr.Diagnostics.AssertResolver</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Dangr.Diagnostics.ValidateResolver<br />
**Namespace:**&nbsp;<a href="N_Dangr_Diagnostics">Dangr.Diagnostics</a><br />**Assembly:**&nbsp;Dangr.Diagnostics (in Dangr.Diagnostics.dll) Version: 1.0.6381.41477 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class ValidateResolver : AssertResolver
```

**VB**<br />
``` VB
Public Class ValidateResolver
	Inherits AssertResolver
```

**C++**<br />
``` C++
public ref class ValidateResolver : public AssertResolver
```

The ValidateResolver type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Diagnostics_ValidateResolver__cctor">ValidateResolver</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_ValidateResolver__ctor">ValidateResolver</a></td><td>
Initializes a new instance of the ValidateResolver class.</td></tr></table>&nbsp;
<a href="#validateresolver-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_AreEqual">AreEqual</a></td><td>
Show a *message* if the specified values are not equal.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_AreNotEqual">AreNotEqual</a></td><td>
Show a *message* if the specified values are equal.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_Check">Check</a></td><td> (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_Compare">Compare(Double, CompareOperation, Double, String, ILogSource, String, Int32)</a></td><td>
Show a *message* if the specified values do not compare in the specified way.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_Compare_1">Compare(Int32, CompareOperation, Int32, String, ILogSource, String, Int32)</a></td><td>
Show a *message* if the specified values do not compare in the specified way.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_Compare_2">Compare(Single, CompareOperation, Single, String, ILogSource, String, Int32)</a></td><td>
Show a *message* if the specified values do not compare in the specified way.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_Fail">Fail</a></td><td>
Unconditionally Show a message.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Diagnostics_ValidateResolver_Failed">Failed</a></td><td>
Shows a *message* and gets an exception that should be thrown.
 (Overrides <a href="M_Dangr_Diagnostics_AssertResolver_Failed">AssertResolver.Failed(AssertType, String, ILogSource, Exception)</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsEmpty">IsEmpty</a></td><td>
Show a *message* if the specified *collection* is not empty.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsFalse">IsFalse</a></td><td>
Show a *message* if the specified *condition* is true.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsInRange">IsInRange(Double, Double, Double, String, ILogSource, String, Int32)</a></td><td>
Show a *message* if the *value* is outside of the specified range.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsInRange_1">IsInRange(Int32, Int32, Int32, String, ILogSource, String, Int32)</a></td><td>
Show a *message* if the *value* is outside of the specified range.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsInRange_2">IsInRange(Single, Single, Single, String, ILogSource, String, Int32)</a></td><td>
Show a *message* if the *value* is outside of the specified range.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsNotEmpty">IsNotEmpty</a></td><td>
Show a *message* if the specified *collection* is empty.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsNotNull">IsNotNull</a></td><td>
Show a *message* if the specified object is null.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsNotNullOrEmpty">IsNotNullOrEmpty</a></td><td>
Show a *message* if the specified string is `null` or empty.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsNotNullOrWhiteSpace">IsNotNullOrWhiteSpace</a></td><td>
Show a *message* if the specified string is `null` or white space.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsNotZero">IsNotZero(Double, String, ILogSource, String, Int32)</a></td><td>
Show a *message* if the specified *value* is 0.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsNotZero_1">IsNotZero(Int32, String, ILogSource, String, Int32)</a></td><td>
Show a *message* if the specified *value* is 0.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsNotZero_2">IsNotZero(Single, String, ILogSource, String, Int32)</a></td><td>
Show a *message* if the specified *value* is 0.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsNull">IsNull</a></td><td>
Show a *message* if the specified object is not null.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsNullOrEmpty">IsNullOrEmpty</a></td><td>
Show a *message* if the specified string is not `null` or empty.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsNullOrWhiteSpace">IsNullOrWhiteSpace</a></td><td>
Show a *message* if the specified string is not `null` or white space.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsTrue">IsTrue</a></td><td>
Show a *message* if the specified *condition* is false.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsType__1">IsType(T)</a></td><td>
Show a *message* if the specified object is not of the specified type.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_IsTypeOrNull__1">IsTypeOrNull(T)</a></td><td>
Show a *message* if the specified object is not of the specified type or null.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_NotDisposed">NotDisposed(ICancelable, String, ILogSource, String, Int32)</a></td><td>
Show a message if the specified <a href="T_Dangr_Util_ICancelable">ICancelable</a> is disposed.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Diagnostics_AssertResolver_NotDisposed__1">NotDisposed(T)(T, ILogSource, String, Int32)</a></td><td>
Show a message if the specified <a href="T_Dangr_Util_ICancelable">ICancelable</a> is disposed.
 (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#validateresolver-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Diagnostics_AssertResolver_assertPaths">assertPaths</a></td><td> (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr><tr><td>![Private field](media/privfield.gif "Private field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Diagnostics_ValidateResolver_LogCategory">LogCategory</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Diagnostics_AssertResolver_rememberAsserts">rememberAsserts</a></td><td> (Inherited from <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a>.)</td></tr></table>&nbsp;
<a href="#validateresolver-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Diagnostics">Dangr.Diagnostics Namespace</a><br />