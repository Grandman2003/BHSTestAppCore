using Core.Entities.Base;

namespace Core.Entities.Figures;

public struct Wall: SurfaceObject3D
{
    public double Width { get; }
    public double Height { get; }
    public Orientation WallOrientation { get; }
    public double Area => Width * Height;
    public double Volume => 0;
    
    public Coordinates3D Coordinates { get; private set; }

    public Wall(
        Coordinates3D centerCoordinates,
        int width,
        int height,
        Orientation wallOrientation)
    {
        Width = width;
        Height = height;
        WallOrientation = wallOrientation;
        Coordinates = centerCoordinates;
    }

    public Wall(int startX, int startY, int startZ, int width, int height, Orientation wallOrientation)
    {
        Width = width;
        Height = height;
        WallOrientation = wallOrientation;
        Coordinates = new Coordinates3D(startX, startY, startZ);
    }
    
    public void UpdateCoordinates(Coordinates3D coordinates)
    {
        Coordinates = coordinates;
    }

    public enum Orientation
    {
        INVALID, XY, YZ, XZ
    }
}