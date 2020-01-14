using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Serval.Core;
using Serval.Mechanics;
using static Serval.Core.Simulation;
namespace Serval.Player
{
    public class EnemyDeath : Simulation.Event<EnemyDeath>
    {
        public EnemyController enemy;
        public override void Execute()
        {
            enemy.enemySource.PlayOneShot(enemy.enemyDeath);
            enemy._collider.enabled = false;
            enemy.control.enabled = false;
        }
    }

}