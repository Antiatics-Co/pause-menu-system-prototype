using Godot;
using System;

/*
 * Author: Aidan Cox
 * Version: 1.0
 * Godot Version: 4.4.1
 * Date: August 2, 2025
 * Title: Global.cs
 * Description: 
 *		 Global Singleton for prototype of a menu system in a Godot game, which should fairly easily transpose to games
 */

namespace PauseMenuSystemPrototype
{
    // This class serves as a global singleton for the project.
    // It can be used to store global settings or paths.
    // The class is empty but can be extended as needed.


    public partial class Global : Node
    {
    }

    public class Locations
    {
        public static string SettingsScenePath = "res://Settings.tscn";
        public static string PauseMenuScenePath = "res://PauseMenu.tscn";
        public static string LevelSelectorScenePath = "res://LevelSelector.tscn"; // Example path for level selector

        public static string SaveFilePath = "/file.dat"; // Example path for main menu
    }

    public class GlobalSettings
    {
        public static string ReturnPath;
    }

    public class  PackedScenes
    {
        //needs to be instantiated and added to GetTree().Root.AddChild(); to open the pause menu
        //destroy instance when done with it with             GetNode("/root/Main").Free(); or this.QueueFree();
        public static readonly PackedScene pauseMenu = ResourceLoader.Load<PackedScene>(Locations.PauseMenuScenePath);
    }
}
