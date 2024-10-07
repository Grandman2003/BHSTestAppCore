using Core.Entities.Base;
using Core.Entities.Behaviours;

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
    
    public bool hasIntersaction(Coordinates3D outsidePoint)
    {
        IPlaceable3D placeable = this as IPlaceable3D;
        
        double halfWidth = Width / 2.0;
        double halfHeight = Height / 2.0;
        bool hasIntersaction = false;
        
        bool inXBoarders = outsidePoint.X >= placeable.X - halfWidth && outsidePoint.X <= placeable.X + halfWidth;
        bool inZBoarders = outsidePoint.Z >= placeable.Z - halfHeight && outsidePoint.Z <= placeable.Z + halfHeight;
        
        switch (WallOrientation)
        {
            case Orientation.XY: 
                var inYHeightBoarders = outsidePoint.Y >= placeable.Y - halfHeight && outsidePoint.Y <= placeable.Y + halfHeight;
                hasIntersaction = inXBoarders && inYHeightBoarders;
                break;
            case Orientation.XZ:
                hasIntersaction = inXBoarders && inZBoarders;
                break;
            case Orientation.YZ:
                var inYWidthBoarders = outsidePoint.Y >= placeable.Y - halfWidth && outsidePoint.Y <= placeable.Y + halfWidth;
                hasIntersaction = inYWidthBoarders && inZBoarders;
                break;
        }
        
        return hasIntersaction;
    }

    public enum Orientation
    {
        INVALID, XY, YZ, XZ
    }
}