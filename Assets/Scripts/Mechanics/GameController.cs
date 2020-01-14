using UnityEngine;
using Serval.Core;
using Serval.Player.Model;

namespace Serval.Mechanics
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }

        public PlayerModel model = Simulation.GetModel<PlayerModel>();

        private void OnEnable()
        {
            Instance = this;
        }

        private void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        private void Update()
        {
            if (Instance == this) Simulation.Tick();
        }
    }
}