using UnityEngine;

namespace SpaceShooter
{
    public class GlobalStatisticsController : SingletonBase<GlobalStatisticsController>
    {
        public int allNumKills { get; set; }
        public int allScore { get; set; }
        public int allTime { get; set; }
    }
}