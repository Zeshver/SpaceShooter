using UnityEngine;
using TMPro;

namespace SpaceShooter
{
    public class ResultPanelController : SingletonBase<ResultPanelController>
    {
        [SerializeField] private TextMeshProUGUI m_Kills;
        [SerializeField] private TextMeshProUGUI m_Score;
        [SerializeField] private TextMeshProUGUI m_Time;
        [SerializeField] private float m_LimitTime;

        [SerializeField] private TextMeshProUGUI m_Result;

        [SerializeField] private TextMeshProUGUI m_ButtonNextText;

        private bool m_Success;

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void ShowResults(PlayerStatistics levelResult, bool success)
        {
            gameObject.SetActive(true);

            m_Success = success;

            m_Kills.text = "Kills : " + levelResult.numKills.ToString();

            if (levelResult.time < m_LimitTime && success)
            {
                m_Score.text = "Score 2X : " + (levelResult.score * 2).ToString();
            }
            else
            {
                m_Score.text = "Score : " + levelResult.score.ToString();
            }

            m_Time.text = "Time : " + levelResult.time.ToString();

            m_Result.text = success ? "Win" : "Lose";
            m_ButtonNextText.text = success ? "Next" : "Restart";

            Time.timeScale = 0;
        }

        public void OnButtonNextAction()
        {
            gameObject.SetActive(false);

            Time.timeScale = 1;

            if (m_Success)
            {
                LevelSequenceController.Instance.AdvanceLevel();
            }
            else
            {
                LevelSequenceController.Instance.RestartLevel();
            }
        }
    }
}