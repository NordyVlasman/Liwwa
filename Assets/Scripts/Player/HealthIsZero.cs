using Serval.Core;
using Serval.Mechanics;
using static Serval.Core.Simulation;

namespace Serval.Player
{
    public class HealthIsZero : Simulation.Event<HealthIsZero>
    {
        public Health health;

        public override void Execute()
        {
            Schedule<PlayerDeath>();
        }
    }
}