/*------------------------------------------------------------------------------
  File:           StunnedAuthoring.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Implements Stun enableable component for DOTS system
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 23:04:40 
------------------------------------------------------------------------------*/
using Unity.Entities;
using UnityEngine;

namespace AlchemicalFlux.DOTS
{
    public class StunnedAuthoring : MonoBehaviour
    {
        private partial class Baker : Baker<StunnedAuthoring>
        {
            public override void Bake(StunnedAuthoring authoring)
            {
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Stunned());
                SetComponentEnabled<Stunned>(entity, false);
            }
        }
    }

    public struct Stunned : IComponentData, IEnableableComponent
    {
    }
}
