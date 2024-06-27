namespace KaifGames.TestClicker.Saves
{
    public interface ISaveHandler<T>
    {
        void WriteToSave(T data);
        void ReadFromSave(T data);
    }
}