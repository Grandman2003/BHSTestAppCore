using Core.Game.Systems;
using Core.Scene;
using Leopotam.EcsLite;

namespace Core.Game.Controllers;

/// <summary>
/// Контроллер для взаимодействия с системами игрового мира
/// </summary>
public sealed class GameController
{
    private EcsWorld? _world;
    private IEcsSystems? _systems;
    private readonly PlainScene3D _gameScene;

    public GameController(PlainScene3D gameScene)
    {
        _gameScene = gameScene;
    }

    /// <summary>
    /// Инициализация систем
    /// </summary>
    public void Init()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems
            .Add(new GreetingsSystem(5000, 300))
            .Add(new InitPlaceablesSystem(_gameScene))
            .Add(new MovePlaceablesSystem())
            .Add(new LogMovablesSystem(500))
            .Add(new DestroyPlaceablesSystem())
            .Init();
    }
    
    /// <summary>
    /// Обновление прогоняемых систем
    /// </summary>
    public void Update () {
        _systems?.Run ();
    }

    /// <summary>
    /// Чистка систем и мира игры
    /// </summary>
    public void OnDestroy () {
        _systems?.Destroy ();
        _systems?.GetWorld ()?.Destroy ();
        _systems = null;
    }
}