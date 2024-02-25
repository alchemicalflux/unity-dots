/*------------------------------------------------------------------------------
  File:           RotateSpeed.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    DOTS component for processing rotation speed of an entity.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 00:01:04 
------------------------------------------------------------------------------*/
using Unity.Entities;

namespace AlchemicalFlux.DOTS
{
    public struct RotateSpeed : IComponentData
    {
        public float Value;
    }
}
