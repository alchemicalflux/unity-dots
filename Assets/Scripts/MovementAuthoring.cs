/*------------------------------------------------------------------------------
  File:           MovementAuthoring.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the creation and processing of the DOTS Movement 
                    component on entities.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 22:05:56 
------------------------------------------------------------------------------*/
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace AlchemicalFlux.DOTS
{
    public class MovementAuthoring : MonoBehaviour
    {
        private class Baker : Baker<MovementAuthoring>
        {
            public override void Bake(MovementAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new Movement()
                {
                    Vector = new(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f))
                });
            }
        }
    }

    public struct Movement : IComponentData
    {
        public float3 Vector;
    }
}