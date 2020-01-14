using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Serval.Core;
using Serval.Mechanics;
using Serval.Player.Model;

namespace Serval.Player
{
    public class PlayerEnteredDeathZone : Simulation.Event<PlayerEnteredDeathZone>
    {
        public DeathZone deathZone;

        PlayerModel model = Simulation.GetModel<PlayerModel>();

        public override void Execute()
        {
            Simulation.Schedule<PlayerDeath>(0);
        }
    }
}