/*------------------------------------------------------------------------------
  File:           PlayerAuthoring.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the creation and processing of the DOTS Player
                    component on entities.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 21:07:29 
------------------------------------------------------------------------------*/
using Unity.Entities;
using UnityEngine;

namespace AlchemicalFlux.DOTS
{
    public class PlayerAuthoring : MonoBehaviour
    {
        private class Baker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                // Set to dynamic due to changing rotation position.
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Player());
            }
        }
    }

    public struct Player : IComponentData
    {
        public float Value;
    }
}