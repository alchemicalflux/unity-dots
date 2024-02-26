/*------------------------------------------------------------------------------
  File:           HandleCubesSystem.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the creation and processing of the DOTS Movement and
                    RotateSpeed components on entities.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 21:29:54 
------------------------------------------------------------------------------*/
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace AlchemicalFlux.DOTS
{
    public partial struct HandleCubesSystem : ISystem
    {
        [BurstCompile]
        void OnUpdate(ref SystemState state)
        {
            foreach (var (localTransform, rotateSpeed, movement) in 
                SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>, RefRO<Movement>>()
                .WithAll<RotatingCube>())
            {
                localTransform.ValueRW = localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.Value * SystemAPI.Time.DeltaTime);
                localTransform.ValueRW = localTransform.ValueRO.Translate(movement.ValueRO.Vector * SystemAPI.Time.DeltaTime);
            }
        }
    }
}