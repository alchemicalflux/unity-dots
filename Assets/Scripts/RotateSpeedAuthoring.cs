/*------------------------------------------------------------------------------
  File:           RotateSpeedAuthoring.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the attachment of the RotateSpeed component to the 
                    parent GameObject.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 00:01:04 
------------------------------------------------------------------------------*/
using Unity.Entities;
using UnityEngine;

namespace AlchemicalFlux.DOTS
{

    public class RotateSpeedAuthoring : MonoBehaviour
    {
        public float Value;

        private class Baker : Baker<RotateSpeedAuthoring>
        {
            public override void Bake(RotateSpeedAuthoring authoring)
            {
                // Set to dynamic due to changing rotation position.
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new RotateSpeed { Value = authoring.Value });
            }
        }
    }
}