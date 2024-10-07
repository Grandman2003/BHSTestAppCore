using Leopotam.EcsLite;

namespace Core.Game.Systems;

public sealed class DestroyPlaceablesSystem: IEcsDestroySystem
{
    public void Destroy(IEcsSystems systems)
    {
        systems.GetWorld().Destroy();
    }
}