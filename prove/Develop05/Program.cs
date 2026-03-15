// Creativity Feature:
// This program includes a Level System that increases the user's level
// as their score increases. Each level also has a title such as
// Beginner, Follower, Disciple, Master, and Eternal Champion.
// When the user reaches a new level, the program displays a level-up message.
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}