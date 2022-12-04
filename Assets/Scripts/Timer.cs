using UnityEngine;

namespace SpaceShooter
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float m_Timer;
        public float TimerBase => m_Timer;

        private void Update()
        {
            if (m_Timer < 0)
            {
                m_Timer = 0;
            }

            if (m_Timer > 0)
            {
                m_Timer -= Time.deltaTime;
            }
        }

        public void AddTimer(float timer)
        {
            m_Timer = timer;
        }
    }
}