using Serval.Core;
using Serval.Mechanics;
using Serval.Player.Model;
using UnityEngine;
using UnityEngine.UI;

namespace Serval.Player
{

    /// <summary>
    /// This event is triggered when the player character enters a trigger with a VictoryZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredVictoryZone"></typeparam>
    public class PlayerEnteredEndZone : Simulation.Event<PlayerEnteredEndZone>
    {
        public EndZone endZone;
        public GameObject panel;
        public Text text;
        
        public PlayerController player1;
        public PlayerController player2;
        
        public bool isPlayer1;
        public bool isPlayer2;

        PlayerModel model = Simulation.GetModel<PlayerModel>();

        public override void Execute()
        {

            if (isPlayer1 && isPlayer2)
            {
                // Simulation.GetModel<Pla>()
                Debug.Log(player1.transform.position);

                player1.controlEnabled = false;
                player2.controlEnabled = false;

                panel.SetActive(true);
                text.text = "Eind";
                text.gameObject.SetActive(true);
            }
        }
    }
}