using Core.Game.Controllers;
using Core.Scene;

namespace Core.Game;

/// <summary>
/// Реализация игры для работы с 3D сценой
/// Для управления процессами игрового движка используется
/// <see name="" cref="Core.Game.Controllers.GameController"/>
/// </summary>
public sealed class Game3D: IGame
{
    private readonly GameController _controller;
    private bool _isRunning;
    
    private Game3D(PlainScene3D scene)
    {
        _controller = new GameController(scene);
    } 
    
    /// <summary>
    /// Создание инстанса игры
    /// </summary>
    /// <param name="scene"></param>
    /// <returns></returns>
    public static Game3D CreateGame(PlainScene3D scene)
    {
        return new Game3D(scene);
    }

    /// <summary>
    /// Запуск игры
    /// </summary>
    public void Start()
    {
        _controller.Init();
        _isRunning = true;
        while (_isRunning)
        {
            _controller.Update();
        }
    }

    /// <summary>
    /// Остановка игры
    /// </summary>
    public void Stop()
    {
        _isRunning = false;
        _controller.OnDestroy();
    }
}
