using Serval.Player;
using Serval.Core;
using Serval.Player.Model;
using UnityEditor;
using UnityEngine;

namespace Serval.Player
{
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        private PlayerModel model = Simulation.GetModel<PlayerModel>();
        private Vector3 defSpawn;
        public override void Execute()
        {
            defSpawn = model.spawnPoint.transform.position;
            var player = model.players;
            for (int i = 0; i < model.players.Count; i++)
            {
                if (i > 0)
                {
                    var pos = model.spawnPoint.transform.position;
                    model.spawnPoint.transform.position = new Vector3(pos.x + 1.5f, pos.y, pos.z);
                }
                player[i].collider2d.enabled = true;
                player[i].controlEnabled = false;
                player[i].Teleport(model.spawnPoint.transform.position);
                player[i].jumpState = PlayerController.JumpState.Grounded;
//                model.virtualCamera.m_Follow = model.player.transform;
//                model.virtualCamera.m_LookAt = model.player.transform;
                model.spawnPoint.transform.position = defSpawn;
                Simulation.Schedule<EnablePlayerInput>(2f); 
            }
        }
    }
}