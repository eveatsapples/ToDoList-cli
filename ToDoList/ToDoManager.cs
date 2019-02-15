using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;


namespace ToDoList
{
  class ToDoManager
  {
    public static List<string> toDoList = new List<string>() {};
    public static List<string> completedList = new List<string>() {};

    public static void ChooseWhich(ref string completeOrDelete)
    {
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine("Choose which number to " + completeOrDelete);
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      string chosen = Console.ReadLine();
      int number;
      bool success = Int32.TryParse(chosen, out number);
      if (success)
      {
        int chosenNumber = Int32.Parse(chosen);
        if (chosenNumber < toDoList.Count)
        {
          switch (completeOrDelete)
          {
            case "complete":
              CompleteTask(ref chosenNumber);
              break;
            case "remove":
              RemoveTask(ref chosenNumber);
              break;
          }
        }
        else
        {
          Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
          Console.WriteLine("there is no ToDo at position " + chosenNumber);
          Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
          Console.ReadKey();
          InputManager.mode = "";
        }
      }
      else
      {
        Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
        Console.WriteLine("choose a number");
        Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
        Console.ReadKey();
        InputManager.mode = "";
      }
      DrawToDoScreen.MainScreen();
    }


    public static void AddTask()
    {
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine("Enter in a new ToDo");
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      string input = Console.ReadLine();
      if(input.Count() >= 1)
      {
        toDoList.Add(input);
      }
      InputManager.mode = "";
      DrawToDoScreen.MainScreen();
    }   

    public static void CompleteTask(ref int task)
    {
      string completedTask = toDoList[task];
      completedList.Add(completedTask);
      toDoList.RemoveAt(task);
      InputManager.mode = "";
      DrawToDoScreen.MainScreen();
    }

    public static void RemoveTask(ref int task)
    {
      toDoList.RemoveAt(task);
      InputManager.mode = "";
      DrawToDoScreen.MainScreen();
    }

    public static void EmptyOptions()
    {
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine("do you wish to empty?:");
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine("t:todos");
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine("c:completed");
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine("a: all");
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine("n:nothing, get me out of here!");
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      string input = Console.ReadKey().KeyChar.ToString();
      switch (input)
      {
        case "t":
          toDoList.Clear();
          break;
        case "c":
          completedList.Clear();
          break;
        case "a":
          toDoList.Clear();
          completedList.Clear();
          break;
        case "n":
          break;
        default:
          Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
          Console.WriteLine("not an option");
          Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
          Console.ReadKey();
          break;
      }
      InputManager.mode = "";
      DrawToDoScreen.MainScreen();
    }


  }
}
