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

            SpaceShip m_Ship = FindObjectOfType<SpaceShip>();

            if (m_Ship != null)
            {
                target.IsReceive = true;
                                
                m_Ship.transform.position = target.transform.position;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            SpaceShip m_Ship = FindObjectOfType<SpaceShip>();

            if (m_Ship != null)
            {
                IsReceive = false;
            }
        }
    }
}
