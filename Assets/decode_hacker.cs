using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decode_hacker : MonoBehaviour
{
    //Game State
    int level;
    enum Screen { MainMenu, Password, Win }; 
    Screen currentScreen;
    const string menuHint = "You may type menu at any time.";

    string password;
    // Decoder information
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    string[] level3Passwords = { "starfield", "telescope", "environment", "exploration", "astronauts" };

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen=Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("It is a decode game. Choose a category by typing 1/2/3.");
        Terminal.WriteLine("Press 1 for Animals");
        Terminal.WriteLine("Press 2 for Devices");
        Terminal.WriteLine("Press 3 for Terminology");
        Terminal.WriteLine("Your selection is:");
    }
    
    // get directly to thd 3 main screen
    void OnUserInput(string input) 
    { 
        if (input == "menu") 
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            MainMenu(input);
        }
         else if (currentScreen == Screen.Password)
         {
             CheckPassword(input);
         }
    }
    void MainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007") // easter egg
        {
            Terminal.WriteLine("Please select a level Mr Bond!");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void StartGame()
    {
        currentScreen=Screen.Password;
        Terminal.WriteLine("The current level is: "+level);
        Terminal.WriteLine("Enter the password:");
    }
    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password.");
        Terminal.WriteLine("hint:"+ password.Anagram());
        Terminal.WriteLine(menuHint);
    }
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }
    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /      //
  /      //
 /_____ //
(______(/           
"
                );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key!");
                Terminal.WriteLine("Play again for a greater challenge.");
                Terminal.WriteLine(@"
 __
/0 \_______
\__/-=' = '         
"
                );
                break;
            case 3:
                Terminal.WriteLine(@"
 _ __   __ _ ___  __ _
| '_ \ / _` / __|/ _` |
| | | | (_| \__ \ (_| |
|_| |_|\__,_|___)\__,_|



"
                );
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
