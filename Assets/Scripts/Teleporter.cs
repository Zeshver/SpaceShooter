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

            if (collision != null)
            {
                target.IsReceive = true;

                collision.transform.position = target.transform.position;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision != null)
            {
                IsReceive = false;
            }
        }
    }
}
