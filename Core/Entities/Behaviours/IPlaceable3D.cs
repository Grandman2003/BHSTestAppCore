using Core.Entities.Base;

namespace Core.Entities.Behaviours;

public interface IPlaceable3D
{
    public Coordinates3D Coordinates { get; }
    public void UpdateCoordinates(Coordinates3D coordinates);
    public int X => Coordinates.X;
    public int Y => Coordinates.Y;
    public int Z => Coordinates.Z;
}