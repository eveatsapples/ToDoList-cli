using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList
{
  class DrawToDoScreen
  {
    public static string viewWidth = "=========================================================";

    public static void MainScreen()
    {
      DrawScreen();
      InputManager.GetInput();
    }

    public static void DrawScreen()
    {
      Console.Clear();
      DrawTopMenu();
      DrawToDoList();
      if (InputManager.showCompleted)
      {
        DrawCompletedList();
      }
    }

    public static void DrawTopMenu()
    {

      if (InputManager.showCompleted)
      {
        InputManager.showOrHide = "Hide";
      }
      else
      {
        InputManager.showOrHide = "Show";
      }

      bool addMode = InputManager.mode.Equals("add", StringComparison.OrdinalIgnoreCase);
      bool completeMode = InputManager.mode.Equals("complete", StringComparison.OrdinalIgnoreCase);
      bool removeMode = InputManager.mode.Equals("remove", StringComparison.OrdinalIgnoreCase);
      bool emptyMode = InputManager.mode.Equals("empty", StringComparison.OrdinalIgnoreCase);
      if (addMode)
      {
        Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("a:Add|");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("c:Complete|r:Remove|e:Empty|s:" + InputManager.showOrHide + "-Completed|q:Quit\n");
      }
      else if (completeMode)
      {
        Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
        Console.Write("a:Add");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("|c:Complete|");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("r:Remove|e:Empty|s:" + InputManager.showOrHide + "-Completed|q:Quit\n");
      }
      else if (removeMode)
      {
        Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
        Console.Write("a:Add|c:Complete");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("|r:Remove|");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("e:Empty|s:" + InputManager.showOrHide + "-Completed|q:Quit\n");
      }
      else if (emptyMode)
      {
        Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
        Console.Write("a:Add|c:Complete|r:Remove");
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("|e:Empty|");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("s:" + InputManager.showOrHide + "-Completed|q:Quit\n");

      }
      else
      {
        Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
        Console.Write("a:Add|c:Complete|r:Remove|e:Empty|s:" + InputManager.showOrHide + "-Completed|q:Quit\n");
      }
    }

    public static void DrawToDoList()
    {
      string title = "ToDo List";
      Console.ForegroundColor = ConsoleColor.Red;
      Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine(viewWidth);
      Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
      Console.WriteLine(title);
      Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine(viewWidth);
      Console.ForegroundColor = ConsoleColor.White;

      int i = 0;
      foreach (var task in ToDoManager.toDoList)
      {
        Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
        Console.WriteLine(i + ": " + task);
        Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
        Console.WriteLine(viewWidth);
        i++;
      }
    }

    public static void DrawCompletedList()
    {
      string title = "Completed List";
      Console.ForegroundColor = ConsoleColor.Green;
      Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine(viewWidth);
      Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
      Console.WriteLine(title);
      Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
      Console.WriteLine(viewWidth);
      Console.ForegroundColor = ConsoleColor.White;

      int i = 0;
      foreach (var task in ToDoManager.completedList)
      {
        Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
        Console.WriteLine(i + ": " + task);
        Console.SetCursorPosition((Console.WindowWidth - viewWidth.Length) / 2, Console.CursorTop);
        Console.WriteLine(viewWidth);
        i++;
      }
    }

  }
}
