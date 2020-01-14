using Serval.Core;
using Serval.Player.Model;

namespace Serval.Player
{
    /// <summary>
    /// This event is fired when user input should be enabled.
    /// </summary>
    public class EnablePlayerInput : Simulation.Event<EnablePlayerInput>
    {
        PlayerModel model = Simulation.GetModel<PlayerModel>();

        public override void Execute()
        {
            var player = model.players;

            foreach (PlayerController controller in player)
            {
                controller.controlEnabled = true;
            }
        }
    }
}
