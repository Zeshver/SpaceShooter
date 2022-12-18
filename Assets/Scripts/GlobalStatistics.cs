using UnityEngine;

namespace SpaceShooter
{
    public class GlobalStatistics : SingletonBase<GlobalStatistics>
    {
        public int allNumKills { get; set; }
        public int allScore { get; set; }
        public int allTime { get; set; }

        protected override void Awake()
        {
            base.Awake();

            Load();
        }

        public void Save()
        {
            PlayerPrefs.SetInt("GlobalStatistics : allNumKills", allNumKills);
            PlayerPrefs.SetInt("GlobalStatistics : allScore", allScore);
            PlayerPrefs.SetInt("GlobalStatistics : allTime", allTime);
        }

        public void Load()
        {
            allNumKills = PlayerPrefs.GetInt("GlobalStatistics : allNumKills", allNumKills);
            allScore = PlayerPrefs.GetInt("GlobalStatistics : allScore", allScore);
            allTime = PlayerPrefs.GetInt("GlobalStatistics : allTime", allTime);
        }

        public void Reset()
        {
            PlayerPrefs.DeleteAll();

            allNumKills = 0;
            allScore = 0;
            allTime = 0;
        }
    }
}