/*------------------------------------------------------------------------------
  File:           HandleCubesSystem.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the creation and processing of the DOTS Movement and
                    RotateSpeed components on entities.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 22:05:56 
------------------------------------------------------------------------------*/
using Unity.Burst;
using Unity.Entities;

namespace AlchemicalFlux.DOTS
{
    public partial struct HandleCubesSystem : ISystem
    {
        [BurstCompile]
        void OnUpdate(ref SystemState state)
        {
            foreach (var aspect in SystemAPI.Query<RotatingMovingCubeAspect>().WithAll<RotatingCube>())
            {
                aspect.MoveRotate(SystemAPI.Time.DeltaTime);
            }
        }
    }
}