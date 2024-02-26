/*------------------------------------------------------------------------------
  File:           PlayerShootManager.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Manages the text the displays on player shoot.
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-26 00:01:21 
------------------------------------------------------------------------------*/
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace AlchemicalFlux.DOTS
{
    public class PlayerShootManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _textPrefab;

        private void Start()
        {
            var system = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<PlayerShootingSystem>();

            system.OnShoot += OnShoot;
        }

        private void OnShoot(object sender, System.EventArgs e)
        {
            var player = (Entity)sender;
            var transform = World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalTransform>(player);
            Instantiate(_textPrefab, transform.Position, Quaternion.identity);
        }
    }
}