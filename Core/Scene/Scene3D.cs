using Core.Entities.Base;
using Core.Entities.Behaviours;

namespace Core.Scene;
public interface Scene3D
{
    public IPlaceable3D[] Placeables { get; }
    public string Name { get; }
    public void AddPlaceable(out string placeableId, IPlaceable3D placeable);
    
}