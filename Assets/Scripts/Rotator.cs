using UnityEngine;

namespace SpaceShooter
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private GameObject m_center;
        [SerializeField] private GameObject m_satellite;

        [SerializeField] private Vector3 m_rotation;
        [SerializeField] private float m_rotationAngle;

        private void Update()
        {
            m_satellite.transform.Rotate(-m_rotation * Time.deltaTime);
            m_satellite.transform.RotateAround(m_center.transform.position, m_rotation, m_rotationAngle * Time.deltaTime);
        }
    }
}
