using UnityEngine;
using Serval.Mechanics;
using static Serval.Core.Simulation;
using Serval.Core;
using Serval.Player.Model;
using Serval.Audio;

namespace Serval.Player
{
    public class PlayerController : KinematicObject
    {

        [Header("Player Functions")]
        public float maxSpeed = 7;
        public float jumpTakeOffSpeed = 7;

        [Header("Player Meta")]
        public bool isPlayer2;
        public bool controlEnabled = true;
        public Health health;

        [Header("Player State")]
        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;

        [Header("Player Controllers")]
        /*internal new*/
        public Collider2D collider2d;
        /*internal new*/
        public AudioSource audioSource;
        
        public AudioClip jumpSound;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlayerModel model = Simulation.GetModel<PlayerModel>();

        public Bounds Bounds => collider2d.bounds;

        private void Awake()
        {
            health = GetComponent<Health>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                if (!isPlayer2)
                {
                    move.x = Input.GetAxis("Horizontal");
                    if (jumpState == JumpState.Grounded && Input.GetButton("Jump"))
                        jumpState = JumpState.PrepareToJump;
                    else if (Input.GetButtonUp("Jump"))
                    {
                        stopJump = true;
                        Schedule<PlayerStopJump>().player = this;
                    }
                }
                else
                {
                    move.x = Input.GetAxis("Horizontal 2");
                    if (jumpState == JumpState.Grounded && Input.GetButton("Jump 2"))
                        jumpState = JumpState.PrepareToJump;
                    else if (Input.GetButtonUp("Jump"))
                    {
                        stopJump = true;
                        Schedule<PlayerStopJump>().player = this;
                    }
                }

            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        audioSource.PlayOneShot(jumpSound);
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
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
                transform.localScale = new Vector2(1, transform.localScale.y);
            else if (move.x < -0.01f)
                transform.localScale = new Vector2(-1, transform.localScale.y);

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }


        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }

}