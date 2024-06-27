using UnityEngine;
using KaifGames.TestClicker.Saves;
using KaifGames.TestClicker.Saves.Models;

namespace KaifGames.TestClicker.LevelProgression
{
    public sealed class LevelProgress : ILevelProgress, ISaveHandler<LevelProgressSaveData>
    {
        public int CurrentLevel { get; private set; }
        public int CurrentExperience { get; private set; }
        public int ExperienceToLevelUp { get; private set; }

        public event System.Action<int> ExperienceAdded;
        public event System.Action<int> LevelChanged;

        public LevelProgress()
        {
            ExperienceToLevelUp = GetExperienceToLevelUp(CurrentLevel);
        }

        public void AddExperience(int amount)
        {
            CurrentExperience += amount;
            ExperienceAdded?.Invoke(amount);

            while (CurrentExperience >= ExperienceToLevelUp)
            {
                CurrentExperience -= ExperienceToLevelUp;
                CurrentLevel++;
                ExperienceToLevelUp = GetExperienceToLevelUp(CurrentLevel);
                LevelChanged?.Invoke(CurrentLevel);
            }
        }

        public void WriteToSave(LevelProgressSaveData data)
        {
            data.Level = CurrentLevel;
            data.Experience = CurrentExperience;
        }

        public void ReadFromSave(LevelProgressSaveData data)
        {
            CurrentLevel = data.Level;
            CurrentExperience = data.Experience;
            ExperienceToLevelUp = GetExperienceToLevelUp(CurrentLevel);
        }

        private static int GetExperienceToLevelUp(int level)
        {
            return (int)Mathf.Pow(2f, level); // Well, this line is not really computationally efficient, but whatever
        }
    }
}
