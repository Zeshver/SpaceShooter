using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(CircleCollider2D))]
    public abstract class Powerup : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            SpaceShip ship = collision.transform.root.GetComponent<SpaceShip>();

            if (ship != null && Player.Instance.ActiveShip)
            {
                OnPickeUp(ship);

                Destroy(gameObject);
            }
        }

        protected abstract void OnPickeUp(SpaceShip ship);
    }
}
