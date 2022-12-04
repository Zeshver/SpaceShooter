using UnityEngine;

namespace SpaceShooter
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField] private Teleporter target;

        [SerializeField] private bool IsReceive;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsReceive == true)
            {
                return;
            }

            SpaceShip ship = collision.transform.root.GetComponent<SpaceShip>();

            if (ship != null)
            {
                target.IsReceive = true;

                ship.transform.position = target.transform.position;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            SpaceShip ship = collision.transform.root.GetComponent<SpaceShip>();

            if (ship != null)
            {
                IsReceive = false;
            }
        }
    }
}
