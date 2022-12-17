using UnityEngine;
using TMPro;

namespace SpaceShooter
{
    public class GlobalStatistics : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_AllNumKills;
        [SerializeField] private TextMeshProUGUI m_AllScore;
        [SerializeField] private TextMeshProUGUI m_AllTime;

        private void Start()
        {
            m_AllNumKills.text = "All kills : " + GlobalStatisticsController.Instance.allNumKills.ToString();

            m_AllScore.text = "All score : " + GlobalStatisticsController.Instance.allScore.ToString();

            m_AllTime.text = "All time in game : " + GlobalStatisticsController.Instance.allTime.ToString();
        }
    }
}