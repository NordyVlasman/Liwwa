using System;
using System.Collections;
using System.Collections.Generic;
using Serval.Mechanics.Patrol;
using Serval.Player;
using UnityEngine;
using static Serval.Core.Simulation;

namespace Serval.Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public PatrolPath path;

        internal PatrolPath.Mover mover;
        internal AnimationController control;

        internal Collider2D _collider;

        private SpriteRenderer spriteRenderer;

        public Bounds Bounds => _collider.bounds;

        public AudioClip enemyDeath;
        
        public AudioSource enemySource;

        private void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player !=  null)
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }
        }

        void Update()
        {
            if (path != null)
            {
                if (mover == null)
                {
                    mover = path.CreateMover(control.maxSpeed * 0.5f);
                }
                control.move.x = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);
            }
        }
    }
   
}