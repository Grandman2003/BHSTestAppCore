﻿using Core.Entities.Base;
using Core.Entities.Behaviours;

namespace Core.Entities.Figures;

public struct Sphere: SurfaceObject3D
{
    public int Radius { get; }
    public double Area => 4 * Math.PI * Radius * Radius;
    public double Volume => 0;
    
    public Coordinates3D Coordinates { get; private set; }

    public Sphere(Coordinates3D centerCoordinates, int radius)
    {
        Radius = radius;
        Coordinates = centerCoordinates;
    }

    public Sphere(int centerX, int centerY, int centerZ, int radius)
    {
        Radius = radius;
        Coordinates = new Coordinates3D(centerX, centerY, centerZ);
    }
    
    public void UpdateCoordinates(Coordinates3D coordinates)
    {
        Coordinates = coordinates;
    }
}