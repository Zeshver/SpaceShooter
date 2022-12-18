using UnityEngine;
using TMPro;

namespace SpaceShooter
{
    public class GlobalStatisticsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_AllNumKills;
        [SerializeField] private TextMeshProUGUI m_AllScore;
        [SerializeField] private TextMeshProUGUI m_AllTime;

        private void Update()
        {
            m_AllNumKills.text = "All kills : " + GlobalStatistics.Instance.allNumKills.ToString();

            m_AllScore.text = "All score : " + GlobalStatistics.Instance.allScore.ToString();

            m_AllTime.text = "All time in game : " + GlobalStatistics.Instance.allTime.ToString();
        }
    }
}