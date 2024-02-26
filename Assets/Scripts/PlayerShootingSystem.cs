/*------------------------------------------------------------------------------
  File:           PlayerShootingSystem.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the spawning of cube objects from the Player entities
                    using the DOTS system.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-26 00:01:21 
------------------------------------------------------------------------------*/
using System;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace AlchemicalFlux.DOTS
{
    [BurstCompile]
    public partial class PlayerShootingSystem : SystemBase
    {
        public event EventHandler OnShoot;

        protected override void OnCreate()
        {
            RequireForUpdate<Player>();
        }

        protected override void OnUpdate()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                var player = SystemAPI.GetSingletonEntity<Player>();
                EntityManager.SetComponentEnabled<Stunned>(player, true);
            }

            if (Input.GetKeyDown(KeyCode.Y))
            {
                var player = SystemAPI.GetSingletonEntity<Player>();
                EntityManager.SetComponentEnabled<Stunned>(player, false);
            }

            if (!Input.GetKeyDown(KeyCode.Space)) { return; }

            var spawnCubesConfig = SystemAPI.GetSingleton<SpawnCubesConfig>();

            var commandBuffer = new EntityCommandBuffer(WorldUpdateAllocator);
            foreach(var (transform, entity) in 
                SystemAPI.Query<RefRO<LocalTransform>>().WithAll<Player>().WithDisabled<Stunned>().WithEntityAccess())
            {
                var spawnedEntity = commandBuffer.Instantiate(spawnCubesConfig.CubePrefabEntity);
                commandBuffer.SetComponent(spawnedEntity, new LocalTransform
                {
                    Position = transform.ValueRO.Position,
                    Scale = 1f,
                    Rotation = Unity.Mathematics.quaternion.identity
                });

                OnShoot?.Invoke(entity, EventArgs.Empty);
            }
            commandBuffer.Playback(EntityManager);
        }
    }
}