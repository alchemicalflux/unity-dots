/*------------------------------------------------------------------------------
  File:           RotatingCubeSystem.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the creation and processing of the DOTS RotateSpeed
                    component on entities.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 15:13:37 
------------------------------------------------------------------------------*/
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace AlchemicalFlux.DOTS
{
    public partial struct RotatingCubeSystem : ISystem
    {
        void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<RotateSpeed>();
        }
        
        void OnDestroy(ref SystemState state) { }

        [BurstCompile]
        void OnUpdate(ref SystemState state)
        {
            foreach(var (localTransform, rotateSpeed) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>())
            {
                localTransform.ValueRW = 
                    localTransform.ValueRO.RotateY(rotateSpeed.ValueRO.Value * SystemAPI.Time.DeltaTime);
            }
        }
    }
}