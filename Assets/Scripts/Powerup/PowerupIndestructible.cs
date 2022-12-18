using UnityEngine;

namespace SpaceShooter
{
    public class PowerupIndestructible : Powerup
    {
        [SerializeField] private float m_IndestructibleTime;

        protected override void OnPickeUp(SpaceShip ship)
        {
            ship.AddIndestructible((int)m_IndestructibleTime);
        }
    }
}