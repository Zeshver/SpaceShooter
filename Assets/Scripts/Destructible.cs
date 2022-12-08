using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SpaceShooter
{
    /// <summary>
    /// Destructible object
    /// </summary>
    public class Destructible : Entity
    {
        #region Properties

        /// <summary>
        /// Object ignores damage
        /// </summary>
        [SerializeField] private bool m_Indestructible;
        public bool IsIndestructible => m_Indestructible;

        /// <summary>
        /// Starting number of hitpoints
        /// </summary>
        [SerializeField] private int m_HitPoints;

        /// <summary>
        /// Maximum number of hitpoints
        /// </summary>
        [SerializeField] private int m_MaxHitPoints;

        /// <summary>
        /// Current hitpoints
        /// </summary>
        private int m_CurrentHitPoints;
        public int HitPoints => m_CurrentHitPoints;

        [SerializeField] private float m_TimerIndestructible;

        #endregion

        #region Unity Events

        protected virtual void Start()
        {
            m_CurrentHitPoints = m_HitPoints;
        }

        protected virtual void Update()
        {
            if (m_TimerIndestructible > 0)
            {
                m_TimerIndestructible -= Time.deltaTime;

                if (m_TimerIndestructible <= 0)
                {
                    m_TimerIndestructible = 0;
                }
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Object damage
        /// </summary>
        public void ApplyDamage(int damage)
        {
            if (m_Indestructible) return;

            if (m_TimerIndestructible <= 0)
            {
                m_CurrentHitPoints -= damage;
            }            

            if (m_CurrentHitPoints <= 0)
            {
                OnDeath();
            }
        }

        public void AddIndestructible(int timer)
        {
            m_TimerIndestructible = timer;
        }

        #endregion

        /// <summary>
        /// Redefinable object destruction event
        /// </summary>
        protected virtual void OnDeath()
        {
            Destroy(gameObject);

            m_EventOnDeath?.Invoke();
        }

        [SerializeField] private static HashSet<Destructible> m_AllDestructibles;

        public static IReadOnlyCollection<Destructible> AllDestructibles => m_AllDestructibles;

        protected virtual void OnEnable()
        {
            if (m_AllDestructibles == null)
            {
                m_AllDestructibles = new HashSet<Destructible>();
            }

            m_AllDestructibles.Add(this);
        }

        protected virtual void OnDestroy()
        {
            m_AllDestructibles.Remove(this);
        }

        [SerializeField] private int m_TeamId;
        public int TeamId => m_TeamId;

        [SerializeField] private UnityEvent m_EventOnDeath;
        public UnityEvent EventOnDeath => m_EventOnDeath;
    }
}

