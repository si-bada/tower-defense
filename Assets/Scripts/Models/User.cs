[System.Serializable]
public class User
{
    public int id;
    public string first_name;
    public string last_name;
    public string username;
    public string email;
    public int score;
    public int level_reached;

    public User(int id, string first_name, string last_name, string username, string email, int score, int level_reached)
    {
        this.id = id;
        this.first_name = first_name;
        this.last_name = last_name;
        this.username = username;
        this.email = email;
        this.score = score;
        this.level_reached = level_reached;
    }
    public User() { }

}
