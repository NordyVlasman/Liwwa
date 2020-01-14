using System;
using System.Collections;
using System.Collections.Generic;
using Serval.Player;
using UnityEngine;
using static Serval.Core.Simulation;

namespace Serval.Mechanics
{
    public class Health : MonoBehaviour
    {
        public int maxHealth = 1;

        public bool isAlive => currentHp > 0;

        private int currentHp;

        public void Increment()
        {
            currentHp = Mathf.Clamp(currentHp + 1, 0, maxHealth);
        }

        public void Decrement()
        {
            currentHp = Mathf.Clamp(currentHp - 1, 0, maxHealth);
            if (currentHp == 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }

        public void Die()
        {
            while(currentHp > 0) Decrement();
        }

        void Awake()
        {
            currentHp = maxHealth;
        }
    }
}