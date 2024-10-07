using System.Numerics;
using Core.Entities.Base;

namespace Core.Entities.Extensions;

public static class CoordinateExtensions
{
    public static Coordinates3D Add(this Coordinates3D coordinates3D, Vector3 vector)
    {
        return new Coordinates3D(
            coordinates3D.X + (int) vector.X, 
            coordinates3D.Y + (int) vector.Y, 
            coordinates3D.Z + + (int) vector.Z
            );
    }
}