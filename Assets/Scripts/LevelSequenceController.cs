using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class LevelSequenceController : SingletonBase<LevelSequenceController>
    {
        public static string MainMenuSceneNickname = "main_menu";

        public Episode CurrentEpisode { get; private set; }

        public int CurrentLevel { get; private set; }

        public static SpaceShip PlayerShip { get; set; }

        public void StartEpisode(Episode episode)
        {
            CurrentEpisode = episode;
            CurrentLevel = 0;

            SceneManager.LoadScene(episode.Levels[CurrentLevel]);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
        }

        public void FinishCurrentLevel(bool success)
        {
            if (success)
            {
                AdvanceLevel();
            }
        }

        public void AdvanceLevel()
        {
            CurrentLevel++;

            if (CurrentEpisode.Levels.Length <= CurrentLevel)
            {
                SceneManager.LoadScene(MainMenuSceneNickname);
            }
            else
            {
                SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
            }
        }
    }
}