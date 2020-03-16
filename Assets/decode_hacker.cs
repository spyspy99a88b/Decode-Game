using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decode_hacker : MonoBehaviour
{
    //Game State
    int level;
    enum Screen { MainMenu, Password, Win }; 
    Screen currentScreen;
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
        if(input == "1"){
            level=1;
            password=level1Passwords;
            StartGame();
        }
        else if (input == "2"){
            level=2;
            password=level2Passwords;
            StartGame();
        }
        else if (input == "3"){
            level=3;
            password=level3Passwords;
            StartGame();
        }
        else{

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
        if(input==password)
        {
            Terminal.WriteLine("Good job!");
        }
        else
        {
           Terminal.WriteLine("Wrong password!"); 
        }
    }
}
