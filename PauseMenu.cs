using Godot;
using System;

/*
 * Author: Aidan Cox
 * Version: 1.0
 * Godot Version: 4.4.1
 * Date: August 2, 2025
 * Title: PauseMenu.cs
 * Description: 
 *		 prototype for a pause menu in a Godot game, which should fairly easily transpose to games
 */

namespace PauseMenuSystemPrototype
{ 
	public partial class PauseMenu : Control
	{
		private Button resumeButton;
		private Button settingsButton;
		private Button quitButton;
        private bool selector = false;

        public override void _Ready()
		{


            resumeButton = GetNode<Button>("%Resume");
			resumeButton.ProcessMode = ProcessModeEnum.WhenPaused; // Ensure the button is always responsive
            resumeButton.Pressed += OnResumeButtonPressed;

			settingsButton = GetNode<Button>("%Settings");
			settingsButton.ProcessMode = ProcessModeEnum.WhenPaused;
			settingsButton.Pressed += OnSettingsButtonPressed;

			quitButton = GetNode<Button>("%Exit");
			quitButton.ProcessMode = ProcessModeEnum.WhenPaused; // Ensure the button is always responsive
            quitButton.Pressed += OnQuitButtonPressed;

            if (ResourceLoader.Exists(Locations.LevelSelectorScenePath))
            {
                quitButton.Text = "Return to Level Selector";
                selector = true; // Set selector to true if the level selector scene exists
            }
            GetTree().Paused = true; // Pause the game when the menu is opened
        }

		private void OnResumeButtonPressed()
		{
            GetTree().Paused = false; //unPause the game when the menu is opened
        }

        private void OnSettingsButtonPressed()
        {
            //load settings scene - could pack onready, or perhaps keep it loaded in a global singleton
            //requires a variable for the path to return to after leaving settings
            GlobalSettings.ReturnPath = GetTree().CurrentScene.SceneFilePath;
            GetTree().ChangeSceneToFile(Locations.SettingsScenePath);
        }

        private void OnQuitButtonPressed()
		{
			if(selector)
			{
                //make sure all necessary data is saved in global singleton
            }
			else
			{
                SaveGameState();
            }

            GetTree().Paused = false;
            this.QueueFree(); // Free the pause menu instance
        }

		private void SaveGameState()
		{
			GD.Print("call IO and sae data.");
		}
    }
}
