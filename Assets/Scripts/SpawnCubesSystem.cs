/*------------------------------------------------------------------------------
  File:           SpawnCubesSystem.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the spawning of cube objects using the DOTS system.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 22:31:20 
------------------------------------------------------------------------------*/
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace AlchemicalFlux.DOTS
{
    [BurstCompile]
    public partial class SpawnCubesSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<SpawnCubesConfig>();
        }

        protected override void OnUpdate()
        {
            Enabled = false; // Only occurs once.

            var spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

            //for(var iter = 0; iter < spawnCubesConfig.SpawnAmount; ++iter)
            //{
            //    var entity = EntityManager.Instantiate(spawnCubesConfig.CubePrefabEntity);
            //    EntityManager.SetComponentData(entity, new LocalTransform
            //    {
            //        Position = new(UnityEngine.Random.Range(-5f, 5f), 0, UnityEngine.Random.Range(-5f, 5f)),
            //        Scale = 1f,
            //        Rotation = Unity.Mathematics.quaternion.identity
            //    });
            //}

            var outputEntities = new NativeArray<Entity>(spawnCubesConfig.SpawnAmount, Allocator.Temp);
            EntityManager.Instantiate(spawnCubesConfig.CubePrefabEntity, outputEntities);
            foreach(var entity in outputEntities)
            {
                SystemAPI.SetComponent(entity, new LocalTransform
                {
                    Position = new(UnityEngine.Random.Range(-5f, 5f), 0, UnityEngine.Random.Range(-5f, 5f)),
                    Scale = 1f,
                    Rotation = Unity.Mathematics.quaternion.identity
                });
            }
        }
    }
}