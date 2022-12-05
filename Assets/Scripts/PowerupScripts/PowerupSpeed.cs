using UnityEngine;

namespace SpaceShooter
{
    public class PowerupSpeed : Powerup
    {
        [SerializeField] private float m_Thrust;
        [SerializeField] private float m_LinearVelocity;
        [SerializeField] private float m_ThrustBoostTime;

        protected override void OnPickeUp(SpaceShip ship)
        {
            ship.AddSpeed((int)m_Thrust, (int)m_LinearVelocity, (int)m_ThrustBoostTime);
        }
    }
}