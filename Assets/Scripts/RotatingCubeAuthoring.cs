/*------------------------------------------------------------------------------
  File:           RotatingCubeAuthoring.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the creation and processing of the DOTS RotatingCube
                    component on entities.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 21:07:29 
------------------------------------------------------------------------------*/
using Unity.Entities;
using UnityEngine;

namespace AlchemicalFlux.DOTS
{
    public class RotatingCubeAuthoring : MonoBehaviour
    {
        private class Baker : Baker<RotatingCubeAuthoring>
        {
            public override void Bake(RotatingCubeAuthoring authoring)
            {
                // Set to dynamic due to changing rotation position.
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new RotatingCube());
            }
        }
    }

    public struct RotatingCube : IComponentData
    {
    }
}