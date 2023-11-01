using Leopotam.Ecs;

namespace Prototype.Helpers
{
    public static class EntityExtensions
    {
        public static void AddComponent<T>(this EcsEntity entity, in T component) where T : struct
        {
            entity.Get<T>() = component;
        }
    }
}
