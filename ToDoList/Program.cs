using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ToDoList
{
  public class Program
  {
    static void Main()
    {
      ToDoFileManager.Load();
      DrawToDoScreen.MainScreen();
    }

    public static void End()
    {
      string exitOptions = "Want to Save First?(y,n,c:cancel)";
      Console.SetCursorPosition((Console.WindowWidth - exitOptions.Length) / 2, Console.CursorTop);
      Console.WriteLine(exitOptions);
      Console.SetCursorPosition((Console.WindowWidth - DrawToDoScreen.viewWidth.Length) / 2, Console.CursorTop);
      string input = Console.ReadKey().KeyChar.ToString();
      switch (input)
      {
        case "y":
          ToDoFileManager.Save();
          break;
        case "n":
          Exit();
          break;
        case "c":
          DrawToDoScreen.MainScreen();
          break;
        default:
          Console.Clear();
          DrawToDoScreen.DrawTopMenu();
          DrawToDoScreen.DrawToDoList();
          if (InputManager.showCompleted)
          {
            DrawToDoScreen.DrawCompletedList();
          }
          End();
          break;
      }
    }

    public static void Exit()
    {
      string shutDownScreen = "Cya Next Time";
      Console.Clear();
      Console.Write("\n\n\n\n\n\n");
      Console.SetCursorPosition((Console.WindowWidth - shutDownScreen.Length) / 2, Console.CursorTop);
      Console.WriteLine(shutDownScreen);
      Thread.Sleep(500);
    }
  }
}
