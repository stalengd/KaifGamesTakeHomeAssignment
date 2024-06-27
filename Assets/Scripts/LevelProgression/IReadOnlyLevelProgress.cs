using System;

namespace KaifGames.TestClicker.LevelProgression
{
    public interface IReadOnlyLevelProgress
    {
        int CurrentExperience { get; }
        int CurrentLevel { get; }
        int ExperienceToLevelUp { get; }

        event Action<int> ExperienceAdded;
        event Action<int> LevelChanged;
    }
}