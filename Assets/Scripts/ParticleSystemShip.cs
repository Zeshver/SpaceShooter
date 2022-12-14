using UnityEngine;

namespace SpaceShooter
{
    public class ParticleSystemShip : MonoBehaviour
    {
        [SerializeField] private SpaceShip m_Ship;        
        [SerializeField] private ParticleSystem m_ParticleOnDeath;

        [SerializeField] private int m_LifeTimeParticleOnDeath;

        private void Start()
        {
            m_Ship.EventOnDeath.AddListener(ParticleShip);
        }

        private void ParticleShip()
        {
            m_ParticleOnDeath.transform.parent = null;
            m_ParticleOnDeath.Play();
            Destroy(m_ParticleOnDeath.gameObject, m_LifeTimeParticleOnDeath);
        }
    }
}
