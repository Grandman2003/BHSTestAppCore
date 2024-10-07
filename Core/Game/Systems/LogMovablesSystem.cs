using Core.Entities.Behaviours;
using Core.Game.Utils;
using Leopotam.EcsLite;

namespace Core.Game.Systems;

public sealed class LogMovablesSystem: IEcsRunSystem
{
    private Movable[]? _movables;
    private readonly int _printDelay;
    
    public LogMovablesSystem(int printDelay)
    {
        _printDelay = printDelay;
    }
    
    public void Run(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        var movablesPool = world.GetPool<Movable>();
        _movables ??= movablesPool.GetRawDenseItems().Where(movable => movable.Placeable != null).ToArray();
        _movables 
            .AsParallel()
            .ForAll(LogPosition);
    }

    private void LogPosition(Movable movable)
    {
        Thread.Sleep(_printDelay);
        if (BumpIdentifier.Get().IsInited)
        {
            Console.WriteLine(
                $@"{DateTimeOffset.Now} 
Was bumped to Wall with ID: {BumpIdentifier.Get().Id}");
            BumpIdentifier.Get().cleanIdentifier();
        }

        Console.WriteLine(
            $@"{DateTimeOffset.Now} 
Current movable: {movable.Placeable.GetType().Name}
Current position: {movable.Coordinates}
            "
        );
    }
}