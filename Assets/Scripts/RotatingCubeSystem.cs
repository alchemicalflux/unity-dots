/*------------------------------------------------------------------------------
  File:           RotatingCubeSystem.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Handles the creation and processing of the DOTS RotateSpeed
                    component on entities.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 21:07:29 
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
            // Querys all instances of RotateSpeed with a LocalTransform, exluding Players.
            //var query = SystemAPI.Query<RefRW<LocalTransform>, RefRO<RotateSpeed>>()
            //    .WithAny<RotatingCube>();

            var job = new RotatingCubeJob { DeltaTime = SystemAPI.Time.DeltaTime };
            job.ScheduleParallel();
        }
    }

    [BurstCompile]
    [WithAll(typeof(RotatingCube))]
    public partial struct RotatingCubeJob : IJobEntity
    {
        public float DeltaTime;

        public void Execute(ref LocalTransform localTransform, in RotateSpeed rotateSpeed)
        {
            localTransform = localTransform.RotateY(rotateSpeed.Value * DeltaTime);
        }
    }
}