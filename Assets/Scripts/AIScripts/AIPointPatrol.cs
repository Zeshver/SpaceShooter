using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class AIPointPatrol : MonoBehaviour
    {
        [SerializeField] private float m_Radius;
        public float Radius => m_Radius;

        [SerializeField] private List<AIPoints> m_AllPoints;
        public List<AIPoints> AllPoints => m_AllPoints;

        private static readonly Color GizmoColor = new Color(1, 0, 0, 0.3f);

        private void Start()
        {
            if (m_AllPoints == null)
            {
                m_AllPoints = new List<AIPoints>();
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = GizmoColor;
            Gizmos.DrawSphere(transform.position, m_Radius);
        }
    }
}