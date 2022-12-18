using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SpaceShooter
{
    public class LevelConditionPosition : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private float m_Radius;

        [SerializeField] private bool m_InRadius;

        bool ILevelCondition.IsCompleted
        {
            get
            {
                if (Player.Instance != null && Player.Instance.ActiveShip != null)
                {
                    bool isInsidePatrolZone = (transform.position - Player.Instance.ActiveShip.transform.position).sqrMagnitude < m_Radius * m_Radius;

                    if (isInsidePatrolZone == true)
                    {
                        m_InRadius = true;
                    }
                }

                return m_InRadius;
            }
        }

#if UNITY_EDITOR
        private static Color GizmoColor = new Color(0, 1, 0, 0.3f);

        private void OnDrawGizmosSelected()
        {
            Handles.color = GizmoColor;
            Handles.DrawSolidDisc(transform.position, transform.forward, m_Radius);
        }
#endif
    }
}