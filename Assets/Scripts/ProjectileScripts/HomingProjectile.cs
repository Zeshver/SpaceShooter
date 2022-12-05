using UnityEngine;

namespace SpaceShooter
{
    public class HomingProjectile : Projectile
    {
        [SerializeField] private Destructible[] AllDestructibles;
        [SerializeField] private Destructible m_Target;

        protected override void Update()
        {
            base.Update();

            SearchTarget();
        }

        private void SearchTarget()
        {
            AllDestructibles = FindObjectsOfType<Destructible>();

            float distance = Mathf.Infinity;

            Vector2 m_Position = transform.position;
            float stepLenght = Time.deltaTime * m_Velocity;

            for (int i = 0; i < AllDestructibles.Length; i++)
            {
                Vector2 diff = (Vector2)AllDestructibles[i].transform.position - m_Position;
                float curDistance = diff.sqrMagnitude;

                if (curDistance < distance && AllDestructibles[i] != m_ParentDest)
                {
                    m_Target = AllDestructibles[i];
                    distance = curDistance;
                }
            }

            if (type == ProjectileType.Homing)
            {
                transform.position = Vector3.MoveTowards(m_Position, m_Target.transform.position, stepLenght);
            }
        }
    }
}