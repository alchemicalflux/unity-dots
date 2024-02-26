/*------------------------------------------------------------------------------
  File:           RotatingMovingCubeAspect.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Consolidates LocalTransform, Movement, and RotateSpeed 
                    components to declutter queries.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-25 21:42:32 
------------------------------------------------------------------------------*/
using Unity.Entities;
using Unity.Transforms;

namespace AlchemicalFlux.DOTS
{
    public readonly partial struct RotatingMovingCubeAspect : IAspect
    {
        public readonly RefRW<LocalTransform> LocalTransform;
        public readonly RefRO<Movement> Movement;
        public readonly RefRO<RotateSpeed> RotateSpeed;

        public void MoveRotate(float deltaTime)
        {
            LocalTransform.ValueRW = LocalTransform.ValueRO.RotateY(RotateSpeed.ValueRO.Value * deltaTime);
            LocalTransform.ValueRW = LocalTransform.ValueRO.Translate(Movement.ValueRO.Vector * deltaTime);
        }
    }
}