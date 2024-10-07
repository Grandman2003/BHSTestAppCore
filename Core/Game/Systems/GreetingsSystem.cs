using Leopotam.EcsLite;

namespace Core.Game.Systems;

public sealed class GreetingsSystem: IEcsInitSystem
{
    private readonly int _startDelayMillis;
    private readonly int _printDelayMillis;
    private readonly string[] _greetings =
    {
        @"||===\\ //===\\ ||      ||        ||===\\ //===\\ \\  //",
        @"||   || ||   || ||      ||        ||   || ||   ||  \\// ",
        @"||===// ||===|| ||      ||        ||===// ||   ||   ||  ",
        @"||   || ||   || ||      ||        ||   || ||   ||  //\\ ",
        @"||===// ||   || ||===== ||=====   ||===// \\===// //  \\"
    };

    private readonly string _title = "\nBall Box - тестовое задание для BaerHeadStudio";
    private readonly string _description = @"В данном задании для команды Core было необходимо сделать систему с использованием библиотеки LeoEcsLite.
Данная система должна представлять собой каробку с шариком в которой он двигается и отталкивается от стен.
В задании требовалось рассмотреть 2D случай, но я реализовал 3D вариант - более комлексную систему.
С подробным описанием системы можно ознакомиться в GitHub по ссылке:

Ниже будет приведён лог системы, для читабельности стоит задержка вывода";
    public GreetingsSystem(int startDelayMillis, int printDelayMillis)
    {
        _startDelayMillis = startDelayMillis;
        _printDelayMillis = printDelayMillis;
        
    }
    public void Init(IEcsSystems systems)
    {
        Console.Title = "Ball Box";
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        foreach (var line in _greetings)
        {
            Console.WriteLine(line);
            Thread.Sleep(_printDelayMillis);
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(_title);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(_description);
        Console.ResetColor();
        Thread.Sleep(_startDelayMillis);
    }
}