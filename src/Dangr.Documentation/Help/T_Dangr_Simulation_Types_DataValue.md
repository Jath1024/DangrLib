# DataValue Class
 

Represents the value stored in a wire or component.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Dangr.Simulation.Types.DataValue<br />
**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public sealed class DataValue
```

**VB**<br />
``` VB
Public NotInheritable Class DataValue
```

**C++**<br />
``` C++
public ref class DataValue sealed
```

The DataValue type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private method](media/privmethod.gif "Private method")</td><td><a href="M_Dangr_Simulation_Types_DataValue__ctor">DataValue</a></td><td>
Initializes a new instance of the DataValue class</td></tr></table>&nbsp;
<a href="#datavalue-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Types_DataValue_BitWidth">BitWidth</a></td><td>
Gets the number of bits in this DataValue.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="P_Dangr_Simulation_Types_DataValue_Item">Item</a></td><td>
Gets the <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a> of the bit at the specified index.</td></tr></table>&nbsp;
<a href="#datavalue-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Boolean">Boolean</a></td><td>
Creates a new DataValue from a boolean value. The binary value with be 1 for `true` and 0 for `false`.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Concatenate">Concatenate</a></td><td>
Creates a new DataValue that has a value equal to all of the specified DataValues concatenated together. The sum of the bit widths of all input values must be less than <a href="F_Dangr_Simulation_Types_DataValue_MaxBitWidth">MaxBitWidth</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Types_DataValue_CopyBitValues">CopyBitValues</a></td><td>
Copies the bit values stored in this DataValue.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Equals_1">Equals(Object)</a></td><td>
Determines whether the specified <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>, is equal to this instance.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Object.Equals(Object)</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Equals">Equals(DataValue)</a></td><td>
Determines whether the specified DataValue, is equal to this instance.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Error">Error</a></td><td>
Creates a new DataValue with all bits initialized to <a href="T_Dangr_Simulation_Types_BitValue">Error</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Floating">Floating</a></td><td>
Creates a new DataValue with all bits initialized to <a href="T_Dangr_Simulation_Types_BitValue">Floating</a>.</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_FromULong">FromULong</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_FromValues">FromValues</a></td><td>
Creates a new DataValue from an array of <a href="T_Dangr_Simulation_Types_BitValue">BitValue</a>s.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Types_DataValue_GetHashCode">GetHashCode</a></td><td>
Returns a hash code for this instance.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">Object.GetHashCode()</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Merge">Merge</a></td><td>
Creates a new DataValue that has a value equal to all of the specified values merged together, using the specified pull behavior. To merge values, each bit is compared. If there is more than one non-<a href="T_Dangr_Simulation_Types_BitValue">Floating</a> value for that bit, the resulting bit is <a href="T_Dangr_Simulation_Types_BitValue">Error</a>. If there is only one non-<a href="T_Dangr_Simulation_Types_BitValue">Floating</a> value for that bit, the resulting bit is equal to that value. If all values for that bit are <a href="T_Dangr_Simulation_Types_BitValue">Floating</a>, the resulting bit is determined by the given <a href="T_Dangr_Simulation_Types_PullBehavior">PullBehavior</a>.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_One">One</a></td><td>
Creates a new DataValue that has a binary value of 1.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Signed">Signed</a></td><td>
Creates a new DataValue that has a binary value equal to specified the 2's complement signed long value.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Split">Split</a></td><td>
Creates a new array of DataValues that are created by splitting the given DataValue in chunks specified by the bitWidths parameter. The sum of all bit widths must be equal to the bitwidth of the input DataValue.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="M_Dangr_Simulation_Types_DataValue_ToString">ToString</a></td><td>
Returns a <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a> that represents this instance.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">Object.ToString()</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Unsigned">Unsigned</a></td><td>
Creates a new DataValue that has a binary value equal to specified the unsigned long value.</td></tr><tr><td>![Private method](media/privmethod.gif "Private method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_ValidateBitWidth">ValidateBitWidth</a></td><td /></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="M_Dangr_Simulation_Types_DataValue_Zero">Zero</a></td><td>
Creates a new DataValue that has a binary value of 0.</td></tr></table>&nbsp;
<a href="#datavalue-class">Back to Top</a>

## Fields
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Private field](media/privfield.gif "Private field")</td><td><a href="F_Dangr_Simulation_Types_DataValue_bitValues">bitValues</a></td><td /></tr><tr><td>![Public field](media/pubfield.gif "Public field")![Static member](media/static.gif "Static member")</td><td><a href="F_Dangr_Simulation_Types_DataValue_MaxBitWidth">MaxBitWidth</a></td><td>
The maximum bit width allowed for a single bit value.</td></tr></table>&nbsp;
<a href="#datavalue-class">Back to Top</a>

## See Also


#### Reference
<a href="N_Dangr_Simulation_Types">Dangr.Simulation.Types Namespace</a><br />