using Core.Entities.Behaviours;

namespace Core.Scene;

public struct PlainScene3D: Scene3D
{
    public IPlaceable3D[] Placeables => _placeables.Values.ToArray();
    public string Name { get; }
    
    private readonly Dictionary<string, IPlaceable3D> _placeables = new();

    private PlainScene3D(string name, params IPlaceable3D[] placeables)
    {
        Name = $"PlainScene3D_{name}";
        foreach (var placeable in placeables)
        {
            AddPlaceableInternal(placeable);
        }
    }
    
    public void AddPlaceable(out string placeableId, IPlaceable3D placeable)
    {
        placeableId = AddPlaceableInternal(placeable);
    }

    private string AddPlaceableInternal(IPlaceable3D placeable)
    {
        var placeableId = $"{placeable.GetType().Name}_{_placeables.Values.Count}";
        _placeables.Add(placeableId, placeable);
        return placeableId;
    }
    
    public static PlainScene3D Create(string name, params IPlaceable3D[] placeables) => new PlainScene3D(name, placeables);
}