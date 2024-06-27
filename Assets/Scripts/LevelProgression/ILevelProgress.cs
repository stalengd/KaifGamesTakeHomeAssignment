namespace KaifGames.TestClicker.LevelProgression
{
    public interface ILevelProgress : IReadOnlyLevelProgress
    {
        void AddExperience(int amount);
    }
}