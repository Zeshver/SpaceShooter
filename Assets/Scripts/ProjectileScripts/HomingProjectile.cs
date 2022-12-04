using UnityEngine;

namespace SpaceShooter
{
    public class HomingProjectile : Projectile
    {
        [SerializeField] private Destructible[] AllDestructible;
        [SerializeField] private Destructible m_Target;

        protected override void Update()
        {
            base.Update();

            SearchTarget();
        }

        private void SearchTarget()
        {
            AllDestructible = FindObjectsOfType<Destructible>();

            float stepLenght = Time.deltaTime * m_Velocity;
            float distance = Mathf.Infinity;

            Vector2 m_Position = transform.position;

            for (int i = 0; i < AllDestructible.Length; i++)
            {
                Vector2 diff = (Vector2)AllDestructible[i].transform.position - m_Position;
                float curDistance = diff.sqrMagnitude;

                if (curDistance < distance)
                {
                    m_Target = AllDestructible[i];
                    distance = curDistance;
                }
            }

            if (type == ProjectileType.Homing)
            {
                transform.position = Vector3.MoveTowards(m_Position, m_Target.transform.position, distance);
            }
        }
    }
}