using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Serval.Audio
{
    public class SoundManagerScript : MonoBehaviour {

        public static AudioClip PlayerDeathSound;
        public static AudioClip PlayerJumpSound;
        public static AudioClip EnemieDeathSound;
        public static AudioSource audioSrc;

        // Start is called before the first frame update
        void Start()
        {
            PlayerDeathSound = Resources.Load<AudioClip> ("playerHit");
            PlayerJumpSound = Resources.Load<AudioClip> ("playerJump");
            EnemieDeathSound = Resources.Load<AudioClip> ("enemieHit");
        
            audioSrc = GetComponent<AudioSource> ();
        }   

        public static void PlaySound (string clip) 
        {
            switch (clip) {
                case "playerHit":
                    audioSrc.PlayOneShot(PlayerDeathSound);
                    break;
                case "playerJump":
                    audioSrc.PlayOneShot(PlayerJumpSound);
                    break;
                case "enemieHit":
                    audioSrc.PlayOneShot(EnemieDeathSound);
                    break;
            }
        }
    }
}