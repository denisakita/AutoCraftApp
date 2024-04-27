using System;
using System.Collections.Generic;
using domain.Domains;
using domain.Interfaces;
using IComponent = System.ComponentModel.IComponent;

namespace infrastructure.Database;

internal interface IEntity : IDomain;

public class EngineEntity : Engine, IEntity;

public class ChassisEntity: Chassis, IEntity;

public class OptionPackEntity: OptionPack, IEntity;

public class OrderEntity : Order, IEntity
{
    public IEnumerable<ComponentEntity> ComponentEntities { get; set; }
}

public class ComponentEntity : Component, IEntity
{
    public Guid? OptionPackId { get; set; }

    public Guid? ChassisId { get; set; }
    
    public Guid? OrderEntityId { get; set; }
    
    public Guid? EngineId { get; set; }

    public OptionPackEntity OptionPack { get; set; }
    public EngineEntity Engine { get; set; }
    public ChassisEntity Chassis { get; set; }
     
    public OrderEntity OrderEntity { get; set; }
}