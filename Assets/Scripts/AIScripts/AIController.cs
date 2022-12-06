using UnityEngine;

namespace SpaceShooter
{
    public class AIController : MonoBehaviour
    {
        public enum AIBehaviour
        {
            Null,
            Patrol
        }

        [SerializeField] private AIBehaviour m_AIBehaviour;

        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationLinear;

        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationAngular;

        [SerializeField] private float m_RandomSelectMovePointTime;

        [SerializeField] private float m_FindNewTargetTime;

        [SerializeField] private float m_ShootDelay;

        [SerializeField] private float m_EvadeRayLenght;

        private SpaceShip m_SpaceShip;

        private Vector3 m_MovePosition;

        private Destructible m_SelectedTarget;

        private Timer TestTimer;

        private void Start()
        {
            TestTimer = new Timer(3);
        }

        private void Update()
        {
            TestTimer.RemoveTime(Time.deltaTime);

            if (TestTimer.IsFinished == true)
            {
                Debug.Log("Test");

                TestTimer.Start(3);
            }
        }
    }
}