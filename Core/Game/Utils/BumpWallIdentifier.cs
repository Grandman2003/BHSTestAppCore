namespace Core.Game.Utils;

public struct BumpIdentifier
{
    private static BumpIdentifier _instance;
    public string? Id { get; private set; }
    public void UpdateIdentifier(string identifier) => Id = identifier;
    public void CleanIdentifier() => Id = null;
    public bool IsInited => Id != null;

    public static ref BumpIdentifier Get()
    {
        return ref _instance;
    }
}