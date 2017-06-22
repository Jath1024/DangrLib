# Assert Class
 

Contains build dependent <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a> s for various scenarios.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Diagnostics.Assert<br />
**Namespace:**&nbsp;<a href="N_Dangr_Diagnostics">Dangr.Diagnostics</a><br />**Assembly:**&nbsp;Dangr.Diagnostics (in Dangr.Diagnostics.dll) Version: 1.0.6381.41477 (1.0.*)

## Syntax

**C#**<br />
``` C#
public static class Assert
```

**VB**<br />
``` VB
Public NotInheritable Class Assert
```

**C++**<br />
``` C++
public ref class Assert abstract sealed
```

The Assert type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Diagnostics_Assert__cctor">Assert</a></td><td /></tr></table>&nbsp;
<a href="#assert-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Dangr_Diagnostics_Assert_Debug">Debug</a></td><td>
Shows a dialog if specific conditions are not met. Same as <a href="P_Dangr_Diagnostics_Assert_Warn">Warn</a> in release builds.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Dangr_Diagnostics_Assert_DefaultLogger">DefaultLogger</a></td><td><a href="T_Dangr_Logging_ILogger">ILogger</a> to use when no log source is passed in to an <a href="T_Dangr_Diagnostics_AssertResolver">AssertResolver</a> .</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Dangr_Diagnostics_Assert_Validate">Validate</a></td><td>
Throws an exception if specific conditions are not met.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")![Static member](media/static.gif "Static member")</td><td><a href="P_Dangr_Diagnostics_Assert_Warn">Warn</a></td><td>
Logs a warning if specific conditions are not met.</td></tr></table>&nbsp;
<a href="#assert-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Diagnostics">Dangr.Diagnostics Namespace</a><br />