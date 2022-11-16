using UnityEngine;

namespace SpaceShooter
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class SpaceShip : Destructible
    {
        /// <summary>
        /// Mass for rigid
        /// </summary>
        [Header("Space ship")]
        [SerializeField] private float m_Mass;

        /// <summary>
        /// Pushing force
        /// </summary>
        [SerializeField] private float m_Thrust;

        /// <summary>
        /// Rotating force
        /// </summary>
        [SerializeField] private float m_Mobility;

        /// <summary>
        /// Maximum line speed
        /// </summary>
        [SerializeField] private float m_MaxLinearVelocity;

        /// <summary>
        /// Maximum rotate speed
        /// </summary>
        [SerializeField] private float m_MaxAngularVelocity;

        private Rigidbody2D m_Rigid;

        #region Public API

        /// <summary>
        /// Linear thrust control
        /// </summary>
        public float ThrustControl { get; set; }

        /// <summary>
        /// Rotary thrust control
        /// </summary>
        public float TorqueControl { get; set; }

        #endregion

        protected override void Start()
        {
            base.Start();

            m_Rigid = GetComponent<Rigidbody2D>();
            m_Rigid.mass = m_Mass;

            m_Rigid.inertia = 1;
        }
    }
}
