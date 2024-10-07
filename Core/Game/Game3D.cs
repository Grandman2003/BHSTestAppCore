using Core.Game.Controllers;
using Core.Scene;

namespace Core.Game;

public sealed class Game3D: IGame
{
    private readonly GameController _controller;
    private bool _isRunning;
    
    private Game3D(PlainScene3D scene)
    {
        _controller = new GameController(scene);
    } 
        
    public static Game3D CreateGame(PlainScene3D scene)
    {
        return new Game3D(scene);
    }

    public void Start()
    {
        _controller.Init();
        _isRunning = true;
        while (_isRunning)
        {
            _controller.Update();
        }
    }

    public void Stop()
    {
        _isRunning = false;
        _controller.OnDestroy();
    }
}
