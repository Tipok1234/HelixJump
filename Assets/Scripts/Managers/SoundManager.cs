using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance => _instanceSound;
        [SerializeField] private AudioSource _jumpSound;
        [SerializeField] private AudioSource _deathSound;
        [SerializeField] private AudioSource _finishSound;
        private static SoundManager _instanceSound;

        private void Awake()
        {
            if (_instanceSound == null)
                _instanceSound = this;
        }
        public void JumpSound()
        {
            _jumpSound.Play();
        }
        public void DeathSound()
        {
            _deathSound.Play();
        }
        public void FinishSound()
        {
            _finishSound.Play();
        }
    }
}
