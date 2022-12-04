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
        [SerializeField] private float m_MinThrust;
        [SerializeField] private float m_MaxThrust;

        /// <summary>
        /// Rotating force
        /// </summary>
        [SerializeField] private float m_Mobility;

        /// <summary>
        /// Default,maximum and minimum line speed
        /// </summary>
        [SerializeField] private float m_LinearVelocity;
        [SerializeField] private float m_MinLinearVelocity;
        [SerializeField] private float m_MaxLinearVelocity;

        /// <summary>
        /// Maximum rotate speed
        /// </summary>
        [SerializeField] private float m_MaxAngularVelocity;
        
        [SerializeField] private int m_MaxAmmo;
        [SerializeField] private int m_MaxEnergy;
        [SerializeField] private int m_EnergyRegenPerSecond;

        [SerializeField] private float m_TimerThrustBoost;

        [SerializeField] private Turret[] m_Turrets;

        private Rigidbody2D m_Rigid;

        private float m_PrimaryEnergy;
        private int m_SecondaryAmmo;

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

        #region Unity Event

        protected override void Start()
        {
            base.Start();

            m_Thrust = m_MinThrust;
            m_LinearVelocity = m_MinLinearVelocity;

            m_Rigid = GetComponent<Rigidbody2D>();
            m_Rigid.mass = m_Mass;

            m_Rigid.inertia = 1;

            InitOffensive();
        }

        protected override void Update()
        {
            base.Update();

            if (m_TimerThrustBoost > 0)
            {
                m_TimerThrustBoost -= Time.deltaTime;

                if (m_TimerThrustBoost <= 0)
                {
                    m_TimerThrustBoost = 0;
                    m_Thrust = m_MinThrust;
                    m_LinearVelocity = m_MinLinearVelocity;
                }
            }            
        }

        private void FixedUpdate()
        {
            UpdateRigidbody();

            UpdateEnergyRegen();
        }

        #endregion

        /// <summary>
        /// The method that add force the ship for movement
        /// </summary>
        private void UpdateRigidbody()
        {
            m_Rigid.AddForce(ThrustControl * m_Thrust * transform.up * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddForce(-m_Rigid.velocity * (m_Thrust / m_LinearVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddTorque(TorqueControl * m_Mobility * Time.fixedDeltaTime, ForceMode2D.Force);

            m_Rigid.AddTorque(-m_Rigid.angularVelocity * (m_Mobility / m_MaxAngularVelocity) * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        public void Fire(TurretMode mode)
        {
            for (int i = 0; i < m_Turrets.Length; i++)
            {
                if (m_Turrets[i].Mode == mode)
                {
                    m_Turrets[i].Fire();
                }
            }
        }

        public void AddEnergy(int e)
        {
            m_PrimaryEnergy = Mathf.Clamp(m_PrimaryEnergy + e, 0, m_MaxEnergy);
        }

        public void AddAmmo(int ammo)
        {
            m_SecondaryAmmo = Mathf.Clamp(m_SecondaryAmmo + ammo, 0, m_MaxAmmo);
        }

        public void AddSpeed(int thrust, int maxLinearVelocity, float timer)
        {
            m_Thrust = Mathf.Clamp(m_Thrust + thrust, 0, m_MaxThrust);
            m_LinearVelocity = maxLinearVelocity;

            m_TimerThrustBoost = timer;
        }

        private void InitOffensive()
        {
            m_PrimaryEnergy = m_MaxEnergy;
            m_SecondaryAmmo = m_MaxAmmo;
        }

        private void UpdateEnergyRegen()
        {
            m_PrimaryEnergy += (float)m_EnergyRegenPerSecond * Time.fixedDeltaTime;
            m_PrimaryEnergy = Mathf.Clamp(m_PrimaryEnergy, 0, m_MaxEnergy);
        }

        public bool DrawEnergy(int count)
        {
            if (count == 0)
            {
                return true;
            }

            if (m_PrimaryEnergy >= count)
            {
                m_PrimaryEnergy -= count;
                return true;
            }

            return false;
        }

        public bool DrawAmmo(int count)
        {
            if (count == 0)
            {
                return true;
            }

            if (m_SecondaryAmmo >= count)
            {
                m_SecondaryAmmo -= count;
                return true;
            }

            return false;
        }

        public void AssingWeapon(TurretProperties props)
        {
            for (int i = 0; i < m_Turrets.Length; i++)
            {
                m_Turrets[i].AssignLoadout(props);
            }
        }
    }
}
