namespace Labyrinth
{
    public class LabyrinthDemo
    {
        static public void Main()
        {
            PlayerPosition startPosition = new PlayerPosition(3, 3);
            Labyrinth labyrinth = new Labyrinth(startPosition);
            labyrinth.StartGame();
        }
    }
}