namespace Core.Game.Utils;

public struct BumpIdentifier
{
    private static BumpIdentifier _instance;
    public string? Id { get; private set; }
    public void updateIdentifier(string identifier) => Id = identifier;
    public void cleanIdentifier() => Id = null;
    public bool IsInited => Id != null;

    public static ref BumpIdentifier Get()
    {
        return ref _instance;
    }
}