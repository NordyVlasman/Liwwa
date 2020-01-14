using System;
using Serval.Mechanics;
using static Serval.Core.Simulation;
using Serval.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Serval.Mechanics
{
    public class EndZone : MonoBehaviour
    {
        public GameObject canvas;
        public Text text;
        private bool player2Done;
        private bool player1Done;

        public GameController gameController;
        private void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                var ev = Schedule<PlayerEnteredEndZone>();
                if (p.isPlayer2)
                {
                    ev.isPlayer2 = true;
                    player2Done = true;
                    ev.player2 = collider.gameObject.GetComponent<PlayerController>();
                }
                else
                {
                    ev.isPlayer1 = true;
                    player1Done = true;
                    ev.player1 = collider.gameObject.GetComponent<PlayerController>();
                }

                if (player1Done && player2Done)
                {
                    text.text = "Eind";
                    text.gameObject.SetActive(true);
                    canvas.SetActive(true);
                    foreach (var player in gameController.model.players)
                    {
                        player.gameObject.SetActive(false);
                    }
                }

                ev.panel = canvas;
                ev.text = text;
            }
        }
    }
}