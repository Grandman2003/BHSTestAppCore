using Core.Entities.Behaviours;

namespace Core.Entities.Base;

/// <summary>
/// Интрефейс объёмного объекта, который можно расположить на плоскости или в пространстве
/// </summary>
public interface SurfaceObject3D : IPlaceable3D, ISpacialFeatures
{
}