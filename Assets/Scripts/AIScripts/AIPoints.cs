using UnityEngine;

namespace SpaceShooter
{
    public class AIPoints : MonoBehaviour
    {
        [SerializeField] private AIPointPatrol m_AIPointPatrol;

        private void Start()
        {
            m_AIPointPatrol = FindObjectOfType<AIPointPatrol>();

            m_AIPointPatrol.AllPoints.Add(this);
        }
    }
}