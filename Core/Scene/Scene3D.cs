using Core.Entities.Behaviours;

namespace Core.Scene;

/// <summary>
/// Описывает именнованную сцену с объЁмными объектами
/// </summary>
public interface Scene3D
{
    /// <summary>
    /// Объекты находящиеся на сцене
    /// </summary>
    public IPlaceable3D[] Placeables { get; }
    
    /// <summary>
    /// Имя сцены
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// Добавления объекта на сцену
    /// </summary>
    public void AddPlaceable(out string placeableId, IPlaceable3D placeable);
    
}