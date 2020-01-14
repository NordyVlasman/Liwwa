using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Serval.Player.Model
{
    [System.Serializable]
    public class PlayerModel
    {
        [Header("Player Model")]
        public Cinemachine.CinemachineVirtualCamera virtualCamera;
        public PlayerController player;
        public Transform spawnPoint;
        public float jumpModifier = 1.5f;
        public float jumpDeceleration = 0.5f;
        public List<PlayerController> players;
    }

}