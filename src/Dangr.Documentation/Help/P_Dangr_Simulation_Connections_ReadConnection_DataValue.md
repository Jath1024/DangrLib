# ReadConnection.DataValue Property 
 

Gets the <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a> that was read from the connected <a href="T_Dangr_Simulation_Connections_Wire">Wire</a>. All bits will be <a href="T_Dangr_Simulation_Types_BitValue">Floating</a> if the connection has not been written to.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Connections">Dangr.Simulation.Connections</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public DataValue DataValue { get; private set; }
```

**VB**<br />
``` VB
Public Property DataValue As DataValue
	Get
	Private Set
```

**C++**<br />
``` C++
public:
property DataValue^ DataValue {
	DataValue^ get ();
	private: void set (DataValue^ value);
}
```


#### Property Value
Type: <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a>

## See Also


#### Reference
<a href="T_Dangr_Simulation_Connections_ReadConnection">ReadConnection Class</a><br /><a href="N_Dangr_Simulation_Connections">Dangr.Simulation.Connections Namespace</a><br />