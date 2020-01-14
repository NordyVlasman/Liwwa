using System.Collections;
using System.Collections.Generic;
using Serval.Player;
using UnityEngine;


namespace Serval.Boosts
{
    public class PlayerJumpPad : MonoBehaviour
    {
        public float maxJump;
        [Range(0, 5)] public float duration = 1f;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var rigidBody = collision.attachedRigidbody;
            if (rigidBody == null) return;
            var player = rigidBody.GetComponent<PlayerController>();
            if (player == null) return;
            player.StartCoroutine(PlayerModifier(player, duration));
        }

        IEnumerator PlayerModifier(PlayerController player, float lifetime)
        {
            var initialSpeed = player.jumpTakeOffSpeed;
            player.jumpTakeOffSpeed = maxJump;
            yield return new WaitForSeconds(lifetime);
            player.jumpTakeOffSpeed = initialSpeed;
        }
    }
}