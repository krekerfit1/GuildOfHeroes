public class GameLibrary {
    public string Name { get; private set; }
    public List<Game> Games { get; private set; } = new List<Game>();

    public GameLibrary(string name) {
        Name = name;
    }
}