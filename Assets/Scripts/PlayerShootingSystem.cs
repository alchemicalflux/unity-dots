/*------------------------------------------------------------------------------
  File:           PlayerShootingSystem.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the spawning of cube objects from the Player entities
                    using the DOTS system.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 22:40:05 
------------------------------------------------------------------------------*/
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace AlchemicalFlux.DOTS
{
    [BurstCompile]
    public partial class PlayerShootingSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate<Player>();
        }

        protected override void OnUpdate()
        {
            if(!Input.GetKeyDown(KeyCode.Space)) { return; }

            var spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();
            foreach(var player in SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>())
            {
                var entity = EntityManager.Instantiate(spawnCubesConfig.CubePrefabEntity);
                EntityManager.SetComponentData(entity, new LocalTransform
                {
                    Position = player.ValueRO.Position,
                    Scale = 1f,
                    Rotation = Unity.Mathematics.quaternion.identity
                });
            }
        }
    }
}