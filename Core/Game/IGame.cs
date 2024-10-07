namespace Core.Game;

/// <summary>
/// Используется для предоставления интерфейса для работы с игрой
/// </summary>
/// <seealso cref="Core.Game.Game3D"/>
public interface IGame
{
    /// <summary>
    /// Вызывается для старта игры
    /// </summary>
    void Start();
    /// <summary>
    /// Вызывается для остановки игры
    /// </summary>
    void Stop();
}