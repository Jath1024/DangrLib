# QuadraticAnimator Class<a href="T_Dangr_Math_Animator">Animator</a> that animates using the equation: V = T * T Starts out slow, speeds up to the end.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="T_Dangr_Math_Animator">Dangr.Math.Animator</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Dangr.Math.QuadraticAnimator<br />
**Namespace:**&nbsp;<a href="N_Dangr_Math">Dangr.Math</a><br />**Assembly:**&nbsp;Dangr.Math (in Dangr.Math.dll) Version: 1.0.6381.41472 (1.0.*)

## Syntax

**C#**<br />
``` C#
public class QuadraticAnimator : Animator
```

**VB**<br />
``` VB
Public Class QuadraticAnimator
	Inherits Animator
```

**C++**<br />
``` C++
public ref class QuadraticAnimator : public Animator
```

The QuadraticAnimator type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Math_QuadraticAnimator__ctor">QuadraticAnimator</a></td><td>
Initializes a new instance of the QuadraticAnimator class.</td></tr></table>&nbsp;
<a href="#quadraticanimator-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Math_Animator_EndValue">EndValue</a></td><td>
Gets the animated value when <a href="P_Dangr_Math_Animator_T">T</a> = 1.
 (Inherited from <a href="T_Dangr_Math_Animator">Animator</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Math_Animator_StartValue">StartValue</a></td><td>
Gets the animated value when <a href="P_Dangr_Math_Animator_T">T</a> = 0.
 (Inherited from <a href="T_Dangr_Math_Animator">Animator</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Math_Animator_T">T</a></td><td>
Gets or sets the current <a href="P_Dangr_Math_Animator_T">T</a> value for the animation. Clamped between 0 and 1.
 (Inherited from <a href="T_Dangr_Math_Animator">Animator</a>.)</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Math_Animator_Value">Value</a></td><td>
Gets the animated value at the current T.
 (Inherited from <a href="T_Dangr_Math_Animator">Animator</a>.)</td></tr></table>&nbsp;
<a href="#quadraticanimator-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="M_Dangr_Math_QuadraticAnimator_CalculateScale">CalculateScale</a></td><td>
Calculates the new value as a scale from 0 to 1.
 (Overrides <a href="M_Dangr_Math_Animator_CalculateScale">Animator.CalculateScale(Single)</a>.)</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Math_Animator_CalculateValue">CalculateValue</a></td><td> (Inherited from <a href="T_Dangr_Math_Animator">Animator</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Equals</a></td><td>
Determines whether the specified object is equal to the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">GetHashCode</a></td><td>
Serves as the default hash function.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#quadraticanimator-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Math_Animator_range">range</a></td><td> (Inherited from <a href="T_Dangr_Math_Animator">Animator</a>.)</td></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Math_Animator_t">t</a></td><td> (Inherited from <a href="T_Dangr_Math_Animator">Animator</a>.)</td></tr></table>&nbsp;
<a href="#quadraticanimator-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Math">Dangr.Math Namespace</a><br />