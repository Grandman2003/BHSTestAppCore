using Leopotam.EcsLite;

namespace Core.Game.Systems;

/// <summary>
/// Система для чистики мира
/// </summary>
public sealed class DestroyPlaceablesSystem: IEcsDestroySystem
{
    public void Destroy(IEcsSystems systems)
    {
        systems.GetWorld().Destroy();
    }
}