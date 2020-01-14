using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Serval.Player;

namespace Serval.Mechanics

{
    public class DoorCollsion : MonoBehaviour
    {
        public PlayerController disabledPlayerController;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            disabledPlayerController = collision.gameObject.GetComponent<PlayerController>();
            if (disabledPlayerController != null)
            {
                StartCoroutine(disablePlayercController(disabledPlayerController));
            }        
        }

        IEnumerator disablePlayercController(PlayerController player)
        {
            disabledPlayerController.enabled = false;
            yield return new WaitForSeconds(0.2f);
            disabledPlayerController.enabled = true;
            
        }
    }
}
