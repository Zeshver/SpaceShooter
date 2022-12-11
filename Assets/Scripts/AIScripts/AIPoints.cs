using UnityEngine;

namespace SpaceShooter
{
    public class AIPoints : MonoBehaviour
    {
        [SerializeField] private AIPointPatrol m_AIPointPatrol;

        [SerializeField] private float m_Radius;
        public float Radius => m_Radius;

        private static readonly Color GizmoColor = new Color(1, 0, 0, 0.3f);

        private void Start()
        {
            m_AIPointPatrol = FindObjectOfType<AIPointPatrol>();

            m_AIPointPatrol.AllPoints.Add(this);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = GizmoColor;
            Gizmos.DrawSphere(transform.position, m_Radius);
        }
    }
}