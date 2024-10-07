using Core.Entities.Behaviours;
using Core.Game.Utils;
using Leopotam.EcsLite;

namespace Core.Game.Systems;

/// <summary>
/// Система логирования событий о движимых в мире объектах
/// </summary>
/// <seealso cref="Core.Game.Systems.MovePlaceablesSystem"/>
/// <seealso cref="Core.Entities.Behaviours.Movable"/>
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

    /// <summary>
    /// Выводит данные о текущей позиции <see cref="Core.Entities.Behaviours.Movable"/>
    /// </summary>
    /// <param name="movable"></param>
    private void LogPosition(Movable movable)
    {
        Thread.Sleep(_printDelay);
        LogBump();
        Console.WriteLine(
            $@"{DateTimeOffset.Now} 
Current movable: {movable.Placeable.GetType().Name}
Current position: {movable.Coordinates}
            "
        );
    }

    /// <summary>
    /// Выводит данные о текущем ударе об стену
    /// </summary>
    /// <seealso cref="Core.Entities.Figures.Wall"/>>
    private void LogBump()
    {
        if (BumpIdentifier.Get().IsInited)
        {
            Console.WriteLine(
                $@"{DateTimeOffset.Now} 
Was bumped to Wall with ID: {BumpIdentifier.Get().Id}");
            BumpIdentifier.Get().CleanIdentifier();
        }
    }
}