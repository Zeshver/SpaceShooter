using UnityEngine;

/// <summary>
/// The base class of all interactive objects in the scene
/// </summary>

namespace SpaceShooter
{
    public abstract class Entity : MonoBehaviour
    {
        /// <summary>
        /// Name of the object for the user
        /// </summary>
        [SerializeField] private string m_Nickname;
        public string Nickname => m_Nickname;
    }
}