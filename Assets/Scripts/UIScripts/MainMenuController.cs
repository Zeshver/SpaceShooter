using UnityEngine;

namespace SpaceShooter
{
    public class MainMenuController : SingletonBase<MainMenuController>
    {
        [SerializeField] private SpaceShip m_DefaultSpaceShip;

        [SerializeField] private GameObject m_EpisodeSelection;

        [SerializeField] private GameObject m_ShipSelection;

        [SerializeField] private GameObject m_GlobalStatistic;

        [SerializeField] private GameObject m_MainMenu;

        private void Start()
        {
            LevelSequenceController.PlayerShip = m_DefaultSpaceShip;
        }

        public void OnButtonStartNew()
        {
            m_EpisodeSelection.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnSelectShip()
        {
            m_ShipSelection.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnGlobalStatistic()
        {
            m_GlobalStatistic.SetActive(true);
        }

        public void OnBack()
        {
            m_MainMenu.SetActive(true);
            m_EpisodeSelection.SetActive(false);
            m_ShipSelection.SetActive(false);
            m_GlobalStatistic.SetActive(false);
        }

        public void OnButtonExit()
        {
            Application.Quit();
        }
    }
}