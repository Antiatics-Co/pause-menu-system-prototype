using Godot;
using System;

/*
 * Author: Aidan Cox
 * Version: 1.0
 * Godot Version: 4.4.1
 * Date: August 2, 2025
 * Title: Settingd.cs
 * Description: 
 *		 prototype of  settings menu for a menu system in a Godot game, which should fairly easily transpose to games
 */

namespace PauseMenuSystemPrototype
{
    public partial class Settings : Node
    {

        private int volume = 50; // Default volume level
        private HSlider volumeSlider;
        private Label volumeLabel;
        private Button backButton;

        public override void _Ready()
        {
            volumeSlider = GetNode<HSlider>("%VolumeSlider");
            volumeSlider.Value = volume; // Set the initial value of the slider
            volumeSlider.ValueChanged += OnVolumeSliderValueChanged;
            volumeLabel = GetNode<Label>("%VolumeLabel");
            volumeLabel.Text = $"Volume: {volume}%"; // Update the label with the initial volume
            backButton = GetNode<Button>("%BackButton");
            backButton.Pressed += OnBackButtonPressed;

            volumeSlider.ProcessMode = ProcessModeEnum.Always; // Ensure the slider is responsive when paused
            backButton.ProcessMode = ProcessModeEnum.Always; // Ensure the button is responsive when paused
        }

        private void OnBackButtonPressed()
        {
            GetTree().ChangeSceneToFile(GlobalSettings.ReturnPath); // Change to the stored scene path
        }

        private void OnVolumeSliderValueChanged(double value)
        {
            throw new NotImplementedException();
        }
    }
}

