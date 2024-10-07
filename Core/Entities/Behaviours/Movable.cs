using System.Numerics;
using Core.Entities.Base;

namespace Core.Entities.Behaviours;

public struct Movable : IPlaceable3D
{
    public IPlaceable3D Placeable { get; }
    public Coordinates3D Coordinates => Placeable.Coordinates;
    public VectorDestination StartDirection { get; }
    public int? DirectionEntity { get; private set; }

    public Movable(IPlaceable3D placeable, Vector3 startDirection)
    {
        Placeable = placeable;
        var vectorDestination = new VectorDestination();
        vectorDestination.ChangeDirection(startDirection);
        StartDirection = vectorDestination;
        DirectionEntity = null;
    }
    
    public void UpdateCoordinates(Coordinates3D coordinates)
    {
        Placeable.UpdateCoordinates(coordinates);
    }

    public void LinkDirection(int directionEntity)
    {
        DirectionEntity = directionEntity;
    }
}