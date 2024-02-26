/*------------------------------------------------------------------------------
  File:           SpawnCubesConfigAuthoring.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the creation and processing of the DOTS 
                    SpawnCubesConfig component on entities.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 22:04:46 
------------------------------------------------------------------------------*/
using Unity.Burst;
using Unity.Entities;
using UnityEngine;

namespace AlchemicalFlux.DOTS
{
    [BurstCompile]
    public class SpawnCubesConfigAuthoring : MonoBehaviour
    {
        public GameObject CubePrefab;
        public int SpawnAmount;

        private class Baker : Baker<SpawnCubesConfigAuthoring>
        {
            public override void Bake(SpawnCubesConfigAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new SpawnCubesConfig()
                {
                    CubePrefabEntity = GetEntity(authoring.CubePrefab, TransformUsageFlags.Dynamic),
                    SpawnAmount = authoring.SpawnAmount,
                });
            }
        }
    }

    public struct SpawnCubesConfig : IComponentData
    {
        public Entity CubePrefabEntity;
        public int SpawnAmount;
    }
}