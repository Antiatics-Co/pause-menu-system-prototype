using Godot;
using System;
using System.IO;


/*
 * Author: Aidan Cox
 * Version: 1.0
 * Godot Version: 4.4.1
 * Date: August 2, 2025
 * Title: PauseMenu.cs
 * Description: 
 *		 prototype for a MainMenu System in a Godot game, which should fairly easily transpose to games
 */

namespace PauseMenuSystemPrototype
{
    public partial class MainMenu : Node
    {
        private Button newGameButton;
        private Button resumeButton;
        private Button settingsButton;
        private Button quitButton;
        public override void _Ready()
        {
            newGameButton = GetNode<Button>("%NewGameButton");
            newGameButton.Pressed += OnNewGameButtonPressed;

            resumeButton = GetNode<Button>("%ResumeButton");
            resumeButton.Pressed += OnResumeButtonPressed;
            if (!IsSaveAvailable())
            {
                resumeButton.Disabled = true; // Disable the resume button if no save is available
            }

            settingsButton = GetNode<Button>("%SettingsButton");
            settingsButton.Pressed += OnSettingsButtonPressed;

            quitButton = GetNode<Button>("%ExitButton");
            quitButton.Pressed += OnQuitButtonPressed;
        }

        private bool IsSaveAvailable()
        {
            // Logic to check if a save file exists at specified path in Global
            return(File.Exists(Locations.SaveFilePath));

        }

        private void OnNewGameButtonPressed()
        {
            // Logic to start the game, e.g., change to the first level scene
            if (ResourceLoader.Exists(Locations.LevelSelectorScenePath))
            {
                GetTree().ChangeSceneToFile(Locations.LevelSelectorScenePath);
            }
            else
            {
                GD.Print("No level selector scene found, Implement different start method");
            }
        }

        private void OnResumeButtonPressed()
        {
            GD.Print("Resume button pressed, save file found, implement IO, and pull data from Global");
        }

        private void OnSettingsButtonPressed()
        {
            // Load settings scene
            GlobalSettings.ReturnPath = GetTree().CurrentScene.SceneFilePath;
            GetTree().ChangeSceneToFile(Locations.SettingsScenePath);
        }
        private void OnQuitButtonPressed()
        {
            GetTree().Quit(); // Quit the game
        }

    }
}