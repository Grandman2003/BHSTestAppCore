using Core.Entities.Behaviours;
using Core.Entities.Figures;
using Core.Game.Utils;
using Core.Scene;
using Leopotam.EcsLite;

namespace Core.Game.Systems;

/// <summary>
/// Система инициализации мира
/// </summary>
public sealed class InitPlaceablesSystem: IEcsInitSystem
{
    private readonly PlainScene3D _gameScene;

    public InitPlaceablesSystem(PlainScene3D gameScene)
    {
        _gameScene = gameScene;
    }
    
    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        AddScene(world);
        AddSceneEntites(world);
        IEcsPool[] pools = Array.Empty<IEcsPool>();
        world.GetAllPools(ref pools);
    }
    
    private void AddScene(EcsWorld world)
    {
        var sceneEntity = world.NewEntity();
        ref var sceneComponent = ref world.GetPool<PlainScene3D>().Add(sceneEntity);
        sceneComponent = _gameScene;
    }

    private void AddSceneEntites(EcsWorld world)
    {
        var wallPool = world.GetPool<Wall>();
        var spherePool = world.GetPool<Sphere>();
        var movablePool = world.GetPool<Movable>();
        var directionPool = world.GetPool<VectorDestination>();
        
        foreach (var component in _gameScene.Placeables)
        {
            var componentEntity = world.NewEntity();
            switch (component)
            {
                case Sphere sphere: 
                    ref var sphereComponent = ref spherePool.Add(componentEntity);
                    sphereComponent = sphere;
                    break;
                case Movable movable:
                    ref var movableComponent = ref movablePool.Add(componentEntity);
                    ref var directionComponent = ref directionPool.Add(componentEntity);
                    movableComponent = movable;
                    directionComponent = movable.StartDirection;
                    movableComponent.LinkDirection(componentEntity);
                    break;
                case Wall wall:
                    ref var wallComponent = ref wallPool.Add(componentEntity);
                    wallComponent = wall;
                    break;
            }
        }
    }
}