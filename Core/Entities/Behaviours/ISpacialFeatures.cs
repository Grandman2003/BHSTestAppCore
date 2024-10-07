namespace Core.Entities.Behaviours;

/// <summary>
/// Определяет дополнительные параметры объёмных фигур
/// </summary>
public interface ISpacialFeatures
{
    double Area { get; }
    double Volume { get; }
}