using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
    class InputManager
    {
      public static string mode = "";
      public static bool showCompleted = false;
      public static string showOrHide = "Show";


      public static void GetInput()
      {
        Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
        string input = Console.ReadKey().KeyChar.ToString();
        switch (input)
        {
          case "a":
            mode = "add";
            DrawToDoScreen.DrawScreen();
            ToDoManager.AddTask();
            break;
          case "c":
            mode = "complete";
            DrawToDoScreen.DrawScreen();
            string toComplete = "complete";
            ToDoManager.ChooseWhich(ref toComplete);
            break;
          case "r":
            mode = "remove";
            DrawToDoScreen.DrawScreen();
            string toRemove = "remove";
            ToDoManager.ChooseWhich(ref toRemove);
            break;
          case "s":
            showCompleted = !showCompleted;
            DrawToDoScreen.MainScreen();
            break;
          case "e":
            mode = "empty";
            DrawToDoScreen.DrawScreen();
            ToDoManager.EmptyOptions();
            break;
          case "w":
            ToDoFileManager.Save();
            DrawToDoScreen.MainScreen();
            break;
          case "l":
            ToDoFileManager.Load();
            DrawToDoScreen.MainScreen();
            break;
          case "q":
            Program.End();
            break;

          case "h":
            Console.WriteLine(ToDoManager.toDoList);
            Console.ReadLine();
            DrawToDoScreen.MainScreen();
            break;

          default:
            Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
            Console.WriteLine("sorry not an option");
            Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
            Console.ReadKey();
            DrawToDoScreen.MainScreen();
            break;
        }
      }
    }
}
