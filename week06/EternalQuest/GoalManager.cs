using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

public class GoalManager
{
	private List<Goal> _goals;
	private int _score;
	private int _level;
	private int _levelProgression;

	public GoalManager()
	{
		_goals = [];
		_score = 0;
		_levelProgression = 0;
		_level = 1;
	}

	public void Start()
	{
		while (true)
		{
			// Console.Clear();
			DisplayPlayerInfo();

			Console.Write("Menu Options:\n" +
			"\t1. Create New Goal\n" +
			"\t2. List Goals\n" +
			"\t3. Save Goals\n" +
			"\t4. Load Goals\n" +
			"\t5. Record Event\n" +
			"\t6. Quit\n" +
			"Select a choice from the menu: ");

			string userInput = Console.ReadLine();

			switch (userInput)
			{
				case "1":
					CreateGoal();
					break;

				case "2":
					ListGoalDetails();
					break;

				case "3":
					SaveGoals();
					break;

				case "4":
					LoadGoals();
					break;

				case "5":
					RecordEvent();
					break;

				case "6":
					return;

				default:
					Console.WriteLine("That's not a valid option.");
					break;
			}
		}
	}

	public void DisplayPlayerInfo()
	{
		Console.WriteLine($"You are a Level {_level} Quester.");
		Console.WriteLine($"You are {_levelProgression}% of the way to your next level.");
		                                                //Is points plural?
		Console.WriteLine($"You have {_score} total point{(_score == 1 ? "" : "s")}.\n");
	}

	public void ListGoalNames()
	{
		if (_goals.Count > 0)
		{
			Console.WriteLine("The goals are:");
			for (int i = 0; i < _goals.Count; i++)
			{
				Console.WriteLine($"\t{i + 1}. {_goals[i].GetName()}");
			}
			return;
		}
		else
		{
			Console.WriteLine("There are no goals currently created.");
			return;
		}
	}

	public void ListGoalDetails()
	{
		if (_goals.Count > 0)
		{
			Console.WriteLine("The goals are:");
			for (int i = 0; i < _goals.Count; i++)
			{
				Console.WriteLine($"\t{i + 1}. [{(_goals[i].isComplete() ? "X" : " ")}] {_goals[i].GetDetailsString()}");
			}
		}
		else
		{
			Console.WriteLine("There are no goals currently created.");
			return;
		}
	}


	public void CreateGoal()
	{
		Console.Write("The types of Goals are:\n" +
		"\t1. Simple Goal\n" +
		"\t2. Eternal Goal\n" +
		"\t3. Checklist Goal\n" +
		"\t4. Back\n" +
		"What type of goal would you like to create? ");

		string goalTypeEnum = Console.ReadLine();

		//Get the shared details first, then break out into handling the goal type.
		Console.Write("What is the name of your goal? ");
		string name = Console.ReadLine();

		Console.Write("What is a short description of it? ");
		string description = Console.ReadLine();

		Console.Write("How many points are associated with this goal? ");
		if (!int.TryParse(Console.ReadLine(), out int points))
		{
			Console.WriteLine("Your answer is not recognized as a number.  Returning to main menu.");
			return;
		}

		switch (goalTypeEnum)
		{
			case "1":
				_goals.Add(new SimpleGoal(name, description, points));
				break;

			case "2":
				_goals.Add(new EternalGoal(name, description, points));
				break;

			case "3":
				Console.Write("How many times do you need to accomplish this goal to receive bonus points? ");
				if (!int.TryParse(Console.ReadLine(), out int target))
				{
					Console.WriteLine("Your answer is not recognized as a number.  Returning to main menu.");
					return;
				}

				Console.Write("And how many points are awarded as the goal's bonus? ");
				if (!int.TryParse(Console.ReadLine(), out int bonus))
				{
					Console.WriteLine("Your answer is not recognized as a number.  Returning to main menu.");
					return;
				}
				_goals.Add(new ChecklistGoal(name, description, points, target, bonus));
				break;

			default:
				return;

		}

	}

	public void RecordEvent()
	{
		ListGoalNames();
		if (_goals.Count > 0)
		//This same if check happens in the ListGoalNames(), but I still need
		//to know if I need to go through the steps of getting the goal to record.
		{
			Console.Write("Which goal did you accomplish? ");

			//Error handling with getting the index
			if (!int.TryParse(Console.ReadLine(), out int goalSelector))
			{
				Console.WriteLine("That isn't a number that I recognize.");
				return;
			}
			if (0 < goalSelector && goalSelector <= _goals.Count)
			{
				int goalPoints = _goals[goalSelector - 1].RecordEvent();
				if (goalPoints > 0)
				{
					_levelProgression += goalPoints / 10; //Discard the remainder.  Hahaha
					if (_levelProgression >= 100)
					{
						_levelProgression = 0;
						//_level++ in the string will also take care of increasing the variable.
						Console.Write($"LEVEL UP!  Level {_level} Quester ");
						_level++;
						Console.WriteLine($">> {_level}");
					}
				}
				return;
			}
			else
			{
				Console.WriteLine($"There isn't a goal #{goalSelector}.");
				return;
			}
		}
	}

	public void SaveGoals()
	{
		Console.Write("What is the name of the file to write the goals to? ");
		string outFile = Console.ReadLine();

		using (StreamWriter outputFile = new StreamWriter(outFile))
		{
			outputFile.WriteLine($"{_level}‚{_levelProgression}‚{_score}");
			foreach (Goal goal in _goals)
			{
				outputFile.WriteLine(goal.GetStringRepresentation());
			}
		}
	}

	public void LoadGoals()
	{
		Console.Write("What is the name of the file to read the goals from? ");
		string inFile = Console.ReadLine();
		string[] lines = File.ReadAllLines(inFile);

		//Set score to the score from the file.
		string[] playerInfo = lines[0].Split('‚');
		_level = int.Parse(playerInfo[0]);
		_levelProgression = int.Parse(playerInfo[1]);
		_score = int.Parse(playerInfo[2]);

		//Reset the _goals list incase there is something there already.
		_goals = [];
		//Skip the first line since that will always be the player score. 
		foreach (string line in lines.Skip(1).ToArray())
		{
			string[] parts = line.Split('‚'); //The Goal type is split by a : and the rest by the inverted single-quote.
			switch (parts[0])
			{
				case "SimpleGoal":
					_goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
					break;
				case "EternalGoal":
					_goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
					break;
				case "ChecklistGoal":
					_goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
					break;
				default:
					Console.WriteLine($"There was an error parsing the line:\n\t{line}");
					return;
			}
		}

	}
}