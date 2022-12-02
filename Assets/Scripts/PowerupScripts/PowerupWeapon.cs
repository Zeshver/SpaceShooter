using UnityEngine;

namespace SpaceShooter
{
    public class PowerupWeapon : Powerup
    {
        [SerializeField] private TurretProperties m_Properties;

        protected override void OnPickeUp(SpaceShip ship)
        {
            ship.AssingWeapon(m_Properties);
        }
    }
}