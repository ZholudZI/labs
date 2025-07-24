abstract class Stats
{
	int health = 0;
	int strength = 0;
}

class Race : Stats
{

}
class Class : Stats
{

}

class Character : IFighter
{

}

interface IFighter
{
	void Attack();
	void CheckStats();
}

//Dictionary<string, Character> characters = new Dictionary<string, Character>();