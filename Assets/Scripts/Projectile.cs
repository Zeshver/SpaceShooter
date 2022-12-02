using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : Entity
    {
        private enum ProjectileType
        {
            Explosion,
            Single
        }

        [SerializeField] private float m_Velocity;

        [SerializeField] private float m_Lifetime;

        [SerializeField] private int m_Damage;

        [SerializeField] private ImpactEffect m_ImpactEffect;

        private Destructible m_ParentDest;

        private float m_Timer;

        protected virtual void Update()
        {
            float stepLenght = Time.deltaTime * m_Velocity;
            Vector2 step = transform.up * stepLenght;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLenght);

            if (hit)
            {
                Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();

                if (dest != null && dest != m_ParentDest)
                {
                    dest.ApplyDamage(m_Damage);
                }

                OnProjectileLifeEnd(hit.collider, hit.point);
            }

            m_Timer += Time.deltaTime;

            if (m_Timer > m_Lifetime)
            {
                Destroy(gameObject);
            }

            transform.position += new Vector3(step.x, step.y, 0);
        }

        private void OnProjectileLifeEnd(Collider2D col, Vector2 pos)
        {
            Destroy(gameObject);
        }

        public void SetParentShooter(Destructible parent)
        {
            m_ParentDest = parent;
        }
    }
}