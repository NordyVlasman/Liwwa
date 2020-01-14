using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Serval.Core;
using Serval.Player.Model;

namespace Serval.Player
{
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        PlayerModel model = Simulation.GetModel<PlayerModel>();

        public AudioSource audioSource;

        public AudioClip playerDeath;

        public override void Execute()
        {
            var player = model.player;
            player.controlEnabled = false;
//            model.virtualCamera.m_Follow = null;
//            model.virtualCamera.m_LookAt = null;
            Simulation.Schedule<PlayerSpawn>();
        }
    }
}