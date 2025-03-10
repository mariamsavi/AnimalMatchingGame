namespace AnimalMatchingGame;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void SpillIgjenButton_Clicked(object sender, EventArgs e)
	{
		AnimalButtons.IsVisible = true;
		SpillIgjenButton.IsVisible = false;

		List<string> AnimalEmoji = [
			"🐭", "🐭",
			"🐷","🐷",
			"🐶","🐶",
			"🐮", "🐮",
			"🐨","🐨",
			"🕊️","🕊️",
			"🐲","🐲",
			"🐠","🐠",
		];
		foreach (var button in AnimalButtons.Children.OfType<Button>())
		{
			int index = Random.Shared.Next(AnimalEmoji.Count);
			string nextEmoji = AnimalEmoji[index];
			button.Text = nextEmoji;
			AnimalEmoji.RemoveAt(index);
		}
	}

	Button lastClicked;
	bool findingMatch = false;
	int matchesFound;
	private void Button_Clicked(object sender, EventArgs e)
	{
		if (sender is Button buttonClicked)
		{

			if (!string.IsNullOrWhiteSpace(buttonClicked.Text) && (findingMatch == false))
			{
				buttonClicked.BackgroundColor = Color.FromArgb("#E085B0");
				lastClicked = buttonClicked;
				findingMatch = true;
			}
			else
			{
				if ((buttonClicked != lastClicked) && (buttonClicked.Text == lastClicked.Text)
				&& (!String.IsNullOrWhiteSpace(buttonClicked.Text)))
				{
					matchesFound++;
					lastClicked.Text = " ";
					buttonClicked.Text = " ";
				}
				lastClicked.BackgroundColor = Color.FromArgb("#FF98C8");
				buttonClicked.BackgroundColor = Color.FromArgb("#FF98C8");
				findingMatch = false;
			}
		}
		if (matchesFound == 8)
		{
			matchesFound = 0;
			AnimalButtons.IsVisible = false;
			SpillIgjenButton.IsVisible = true;


		}
	}

}
