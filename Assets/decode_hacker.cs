using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decode_hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void ShowMainMenu(){
        Terminal.WriteLine("It is a decode game. Choose a category by typing 1/2/3.");
        Terminal.WriteLine("1:");
        Terminal.WriteLine("2:");
    }
    void Update()
    {
        
    }
    void OnUserInput(string input)
    {
        if (input == "menu") // we can always go direct to main menu
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab.");
            Application.Quit();
        }
        // else if (currentScreen == Screen.MainMenu)
        // {
        //     RunMainMenu(input);
        // }
        // else if (currentScreen == Screen.Password)
        // {
        //     CheckPassword(input);
        // }
    }
}
