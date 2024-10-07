using System.Numerics;
using Core.Entities.Behaviours;
using Core.Entities.Extensions;
using Core.Entities.Figures;
using Core.Game.Utils;
using Leopotam.EcsLite;

namespace Core.Game.Systems;

public sealed class MovePlaceablesSystem: IEcsRunSystem
{
    private Wall[]? _walls;
    private Movable[]? _movables;
    private EcsPool<VectorDestination>? _vectorDestinationPool;
    

    private Dictionary<Wall.Orientation, Vector3> wallNormals = new();

    public MovePlaceablesSystem()
    {
        wallNormals.Add(Wall.Orientation.XY, new Vector3(0.0f, 0.0f, 1.0f));
        wallNormals.Add(Wall.Orientation.XZ, new Vector3(0.0f, 1.0f, 0.0f));
        wallNormals.Add(Wall.Orientation.YZ, new Vector3(1.0f, 0.0f, 0.0f));
    }
    
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        _movables ??= world.GetPool<Movable>().GetRawDenseItems().Where(movable => movable.Placeable != null).ToArray();
        _walls ??= world.GetPool<Wall>().GetRawDenseItems().Where(wall => wall.WallOrientation != Wall.Orientation.INVALID).ToArray();
        _vectorDestinationPool ??= world.GetPool<VectorDestination>();
        _movables.AsParallel().ForAll(TryMove);
    }
    
    private void TryMove(Movable movable)
    {
        if (_walls is null) return;
        
        if (movable.Placeable is Sphere sphere)
        {
            if (!CheckSpherePosition(_walls,ref movable, sphere.Radius)) return;
            Move(ref movable);
        }
    }

    private void Move(ref Movable movable)
    {
        if (movable.DirectionEntity == null) return;
        ref var direction = ref _vectorDestinationPool!.Get(movable.DirectionEntity.Value);
        movable.UpdateCoordinates(movable.Coordinates.Add(direction.MovableDirection));
    }

    private bool CheckSpherePosition(Wall[] walls,ref Movable movable, int sphereRadius)
    {
        var minimumDistance = int.MaxValue;
        var wallPosition = 1;
        Wall? nearestWall = null;
        
        foreach (var wall in walls)
        {
            int wallDistance = int.MaxValue;
            int currentWallPosition = 1;
            switch (wall.WallOrientation)
            {
                case Wall.Orientation.XY:
                    GetWallDistance(
                        movable.Coordinates.Z,
                        wall.Coordinates.Z,
                        sphereRadius,
                        out wallDistance,
                        out currentWallPosition
                    );
                    break;
                case Wall.Orientation.XZ:
                    GetWallDistance(
                        movable.Coordinates.Y,
                        wall.Coordinates.Y,
                        sphereRadius,
                        out wallDistance,
                        out currentWallPosition
                    );
                    break;
                case Wall.Orientation.YZ:
                    GetWallDistance(
                        movable.Coordinates.X,
                        wall.Coordinates.X,
                        sphereRadius,
                        out wallDistance,
                        out currentWallPosition
                    );
                    break;
            }

            if (wallDistance < minimumDistance)
            {
                nearestWall = wall;
                minimumDistance = wallDistance;
                wallPosition = currentWallPosition;
            }
        }
        
        if (!nearestWall.HasValue) return false;

        if (minimumDistance < sphereRadius)
        {
            if (movable.DirectionEntity == null) return false;
            
            BumpIdentifier.Get().updateIdentifier($"WallID: {nearestWall.Value.Coordinates}");
            ref var direction = ref _vectorDestinationPool!.Get(movable.DirectionEntity.Value);
            var newDestionation = Vector3.Reflect(
                vector: direction.MovableDirection,
                normal: wallNormals[nearestWall.Value.WallOrientation] * wallPosition
            );
            direction.ChangeDirection(newDestionation);
        }

        return true;
    }

    private void GetWallDistance(
        int movableCoordinate, 
        int wallCoordinate, 
        int sphereRadius, 
        out int wallDistance,
        out int wallDirection
        )
    {
        if (movableCoordinate > wallCoordinate)
        {
            wallDistance = movableCoordinate - sphereRadius - wallCoordinate;
            wallDirection = 1;
        }
        else
        {
            wallDistance = wallCoordinate - sphereRadius - movableCoordinate;
            wallDirection = -1;
        }
    }
}