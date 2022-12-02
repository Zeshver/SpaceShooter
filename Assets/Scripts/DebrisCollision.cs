using UnityEngine;

namespace SpaceShooter
{
    public class DebrisCollision : Destructible
    {
        [SerializeField] private Destructible[] m_SmallDebrisPrefabs;
        [SerializeField] private float m_Speed;

        private void SpawnSmallDebris()
        {
            for (int i = 0; i < m_SmallDebrisPrefabs.Length; i++)
            {
                var smallDebris = Instantiate(m_SmallDebrisPrefabs[i], transform.position, Quaternion.identity);

                Rigidbody2D rigidbody2D = smallDebris.GetComponent<Rigidbody2D>();

                if (rigidbody2D != null && m_Speed > 0)
                {
                    rigidbody2D.velocity = (Vector2)Random.insideUnitSphere * m_Speed;
                }
            }
        }

        protected override void OnDeath()
        {
            base.OnDeath();

            SpawnSmallDebris();
        }
    }
}