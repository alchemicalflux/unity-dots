/*------------------------------------------------------------------------------
  File:           ShootPopup.cs 
  Project:        AlchemicalFlux Unity-Dots
  Description:    Implements Stun enableable component for DOTS system
  Copyright:      

  Last commit by: alchemicalflux 
  Last commit at: 2024-02-26 00:01:21 
------------------------------------------------------------------------------*/
using UnityEngine;

namespace AlchemicalFlux.DOTS
{
    public class ShootPopup : MonoBehaviour
    {
        private float _destoryTimer = 1f;

        private void Update()
        {
            var moveSpeed = 2f;
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;

            _destoryTimer -= Time.deltaTime;
            if (_destoryTimer <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}