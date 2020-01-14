using System;
using System.Collections;
using System.Collections.Generic;
using Serval.Core;
using Serval.Player.Model;
using UnityEngine;

namespace Serval.Mechanics
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
    public class AnimationController : KinematicObject
    {
        public float maxSpeed = 7;
        public float jumpTakeOffSpeed = 7;

        public Vector2 move;

        public bool jump;
        public bool stopJump;

        private SpriteRenderer spriteRenderer;
        private Animator animator;
        private PlayerModel model = Simulation.GetModel<PlayerModel>();

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.transform.localScale = new Vector3(-1f, spriteRenderer.transform.localScale.y, spriteRenderer.transform.localScale.z);
                // spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.transform.localScale = new Vector3(1f, spriteRenderer.transform.localScale.y, spriteRenderer.transform.localScale.z);
            // spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }
    }
}