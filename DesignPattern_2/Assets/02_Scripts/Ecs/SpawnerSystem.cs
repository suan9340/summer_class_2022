using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

public partial class SpawnerSystem : SystemBase
{
    EndSimulationEntityCommandBufferSystem m_EntityCommandBufferSystem;

    protected override void OnCreate()
    {
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    partial struct SpawnJob : IJobEntity
    {
        public EntityCommandBuffer _commandBuffer;

        public void Execute(Entity _entity, [EntityInQueryIndex] int _index, [ReadOnly] ref Spawner _spawner,
            [ReadOnly] ref LocalToWorld _location)
        {
            for (int x = 0; x < _spawner.erows; x++)
            {
                for (int z = 0; z < _spawner.ecols; z++)
                {
                    var _instance = _commandBuffer.Instantiate(_spawner.prefab);
                    var _pos = math.transform(_location.Value,
                        new float3(x, noise.cnoise(new float2(x, z) * 0.21f), z));

                    _commandBuffer.SetComponent(_instance, new Translation { Value = _pos });
                }
            }

            _commandBuffer.DestroyEntity(_entity);
        }
    }

    protected override void OnUpdate()
    {
        var job = new SpawnJob
        {
            _commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer(),
        };

        Dependency = job.Schedule(Dependency);
        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
}
