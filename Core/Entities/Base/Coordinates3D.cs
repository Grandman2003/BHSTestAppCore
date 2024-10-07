namespace Core.Entities.Base;

public struct Coordinates3D
{
    public int X { get; }
    public int Y { get; }
    public int Z { get; }

    public Coordinates3D(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public override string ToString()
    {
        return $"X: {X}, Y: {Y}, Z: {Z}";
    }
}