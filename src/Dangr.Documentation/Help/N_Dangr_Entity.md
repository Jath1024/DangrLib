# Dangr.Entity Namespace
 

The Dangr.Entity namespace provides utilities for creating and tracking entities with unique ids.


## Classes
&nbsp;<table><tr><th></th><th>Class</th><th>Description</th></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Entity_EntityAttribute">EntityAttribute</a></td><td>
Attribute that can be used on an <a href="T_Dangr_Entity_IEntity">IEntity</a> to specify the EntityName.</td></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Entity_EntityInfo">EntityInfo</a></td><td>
Stores information about an entity. Created by adding an entity to an [!:Dangr.Entity.EntityTable`1] .</td></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Entity_EntityTable_1">EntityTable(TEntity)</a></td><td>
Table that contains references to all of the <a href="T_Dangr_Entity_IEntity">IEntity</a> s currently instantiated.</td></tr><tr><td>![Public class](media/pubclass.gif "Public class")</td><td><a href="T_Dangr_Entity_IdPartitionTable">IdPartitionTable</a></td><td>
A partition table used to generate IDs for <a href="T_Dangr_Entity_IEntity">IEntity</a> s.</td></tr></table>

## Interfaces
&nbsp;<table><tr><th></th><th>Interface</th><th>Description</th></tr><tr><td>![Public interface](media/pubinterface.gif "Public interface")</td><td><a href="T_Dangr_Entity_IEntity">IEntity</a></td><td>
Interface that defines an entity that can be stored in an [!:Dangr.Entity.EntityTable`1] .</td></tr></table>&nbsp;
