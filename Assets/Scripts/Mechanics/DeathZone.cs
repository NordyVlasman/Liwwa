using UnityEngine;
using Serval.Player;
using static Serval.Core.Simulation;

namespace Serval.Mechanics
{
    public class DeathZone : MonoBehaviour
    {
        public GameObject spawnPoint;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var p = collision.gameObject.GetComponent<PlayerController>();
            if(p != null)
            {
                var ev = Schedule<PlayerEnteredDeathZone>();
                ev.deathZone = this;
            }
        }
    }
}