using UnityEngine;

namespace SpaceShooter
{
    public class HomingProjectile : Projectile
    {
        [SerializeField] private Destructible[] AllDestructible;
        [SerializeField] private Destructible m_Target;

        private Vector2 m_Position;       

        protected override void Update()
        {
            SearchTarget();

            base.Update();
        }

        private void SearchTarget()
        {
            AllDestructible = FindObjectsOfType<Destructible>();

            float stepLenght = Time.deltaTime * m_Velocity;

            m_Target = null;
            float distance = Mathf.Infinity;
            m_Position = transform.position;

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

            //foreach (Destructible destructible in AllDestructible)
            //{
            //    Vector2 diff = (Vector2)destructible.transform.position - m_Position;
            //    float curDistance = diff.sqrMagnitude;

            //    if (curDistance < distance)
            //    {
            //        m_Target = destructible;
            //        distance = curDistance;
            //    }
            //}

            if (type == ProjectileType.Homing)
            {
                transform.position = Vector3.MoveTowards(m_Position, m_Target.transform.position, stepLenght);
            }
        }
    }
}