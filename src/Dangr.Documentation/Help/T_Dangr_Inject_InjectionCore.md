# InjectionCore Class
 

Component that is responsible for gathering and exposing provided dependencies.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Inject.InjectionCore<br />
**Namespace:**&nbsp;<a href="N_Dangr_Inject">Dangr.Inject</a><br />**Assembly:**&nbsp;Dangr.Inject (in Dangr.Inject.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class InjectionCore
```

**VB**<br />
``` VB
Public Class InjectionCore
```

**C++**<br />
``` C++
public ref class InjectionCore
```

The InjectionCore type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Inject_InjectionCore__ctor">InjectionCore</a></td><td>
Initializes a new instance of the InjectionCore class</td></tr></table>&nbsp;
<a href="#injectioncore-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Inject_InjectionCore_CreateProvider">CreateProvider</a></td><td /></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Inject_InjectionCore_CreateSetProvider">CreateSetProvider</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Inject_InjectionCore_Get">Get(String)</a></td><td>
Gets an instance of the dependency defined with the specified name.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Inject_InjectionCore_Get_1">Get(Type)</a></td><td>
Gets an instance of the dependency defined with the specified type.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Inject_InjectionCore_Get__1">Get(T)()</a></td><td>
Gets an instance of the dependency defined with the specified type.</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Inject_InjectionCore_GetConstructor">GetConstructor</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Inject_InjectionCore_LoadModule">LoadModule</a></td><td>
Loads the providers defined in the given module.</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Inject_InjectionCore_ScanAssembly">ScanAssembly</a></td><td>
Scans the *assembly* for all classes with the <a href="T_Dangr_Inject_InjectionModuleAttribute">InjectionModuleAttribute</a> and loads them into the InjectionCore .</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#injectioncore-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Inject_InjectionCore_namedProviderMap">namedProviderMap</a></td><td /></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Inject_InjectionCore_providerMap">providerMap</a></td><td /></tr></table>&nbsp;
<a href="#injectioncore-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Inject">Dangr.Inject Namespace</a><br />