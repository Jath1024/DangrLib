# ReadConnection.DataValueChanged Event
 

Occurs when a <a href="T_Dangr_Simulation_Types_DataValue">DataValue</a> is written to this <a href="T_Dangr_Simulation_Connections_ReadConnection">ReadConnection</a>.

**Namespace:**&nbsp;<a href="N_Dangr_Simulation_Connections">Dangr.Simulation.Connections</a><br />**Assembly:**&nbsp;Dangr.Simulation (in Dangr.Simulation.dll) Version: 1.0.6381.41481 (1.0.*)

## Syntax

**C#**<br />
``` C#
public event EventHandler<DataValueChangedEventArgs> DataValueChanged
```

**VB**<br />
``` VB
Public Event DataValueChanged As EventHandler(Of DataValueChangedEventArgs)
```

**C++**<br />
``` C++
public:
 event EventHandler<DataValueChangedEventArgs^>^ DataValueChanged {
	void add (EventHandler<DataValueChangedEventArgs^>^ value);
	void remove (EventHandler<DataValueChangedEventArgs^>^ value);
}
```


#### Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/db0etb8x" target="_blank">System.EventHandler</a>(<a href="T_Dangr_Simulation_Types_DataValueChangedEventArgs">DataValueChangedEventArgs</a>)

## See Also


#### Reference
<a href="T_Dangr_Simulation_Connections_ReadConnection">ReadConnection Class</a><br /><a href="N_Dangr_Simulation_Connections">Dangr.Simulation.Connections Namespace</a><br />