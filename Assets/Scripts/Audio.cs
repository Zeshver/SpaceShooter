using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(AudioSource))]
    public class Audio : MonoBehaviour
    {
        [SerializeField] private AudioSource m_AudioSource;

        [SerializeField] private AudioClip m_AudioClip;

        private void Start()
        {
            m_AudioSource = GetComponent<AudioSource>();

            SetAudio();
        }

        public void SetAudio()
        {
            m_AudioSource.clip = m_AudioClip;
            m_AudioSource.Play();
        }
    }
}