using System.Numerics;

namespace Core.Entities.Behaviours;

/// <summary>
/// Определяет направление перемещения объекта
/// </summary>
public struct VectorDestination
{
    public Vector3 MovableDirection { get; private set; }

    public void ChangeDirection(Vector3 direction)
    {
        MovableDirection = direction;
    }
}