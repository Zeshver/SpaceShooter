using UnityEngine;

namespace SpaceShooter
{
    public class ExplosionProjectile : Projectile
    {
        [SerializeField] private float m_Radius;
        [SerializeField] private int m_ExplosionDamage;

        protected override void Update()
        {
            base.Update();
        }

        private void OnDestroy()
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, m_Radius);

            foreach(Collider2D target in cols)
            {
                Destructible dest = target.transform.root.GetComponent<Destructible>();

                if (dest != null)
                {
                    dest.ApplyDamage(m_ExplosionDamage);
                }
            }
        }
    }
}