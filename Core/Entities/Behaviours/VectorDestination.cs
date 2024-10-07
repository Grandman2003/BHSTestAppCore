using System.Numerics;

namespace Core.Entities.Behaviours;

public struct VectorDestination
{
    public Vector3 MovableDirection { get; private set; }

    public void ChangeDirection(Vector3 direction)
    {
        MovableDirection = direction;
    }
}