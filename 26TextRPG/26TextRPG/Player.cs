public class Player
{
    int level { get; set; } = 1;
    string name { get; set; }
    string job { get; set; } = "ภüป็";
    int attack { get; set; } = 10;
    int defense { get; set; } = 5;
    int health { get; set; } = 100;
    int gold { get; set; } = 1500;
    int speed { get; set; }

	public Player(string _name, int _speed)
	{
		name = _name;
		// speed = _speed;
	}

}