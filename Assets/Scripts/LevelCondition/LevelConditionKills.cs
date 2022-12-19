using UnityEngine;

namespace SpaceShooter
{
    public class LevelConditionKills : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private int kill;

        private bool m_Reached;

        bool ILevelCondition.IsCompleted
        {
            get
            {
                if (Player.Instance != null && Player.Instance.ActiveShip != null)
                {
                    if (Player.Instance.NumKills >= kill)
                    {
                        m_Reached = true;
                    }
                }

                return m_Reached;
            }
        }
    }
}