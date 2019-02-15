using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;



namespace ToDoList
{
    class ToDoFileManager
    {
      public static void Save()
      {
        string tempDir = Path.GetTempPath();
        string toDoFileName = "ToDoList.txt";
        string toDoPath = tempDir + toDoFileName;
        string completedFileName = "CompletedList.txt";
        string completedPath = tempDir + completedFileName;

        File.Delete(toDoPath);
        File.Delete(completedPath);

        using (StreamWriter sw = File.AppendText(toDoPath)) 
        {
          foreach (var todo in ToDoManager.toDoList)
          {
            sw.WriteLine(todo);
          }
        }

        using (StreamWriter sw = File.AppendText(completedPath)) 
        {
          foreach (var completedTodo in ToDoManager.completedList)
          {
            sw.WriteLine(completedTodo);
          }
        }
      }

      public static void Load()
      {
        string tempDir = Path.GetTempPath();
        string toDoFileName = "ToDoList.txt";
        string toDoPath = tempDir + toDoFileName;

        if (File.Exists(toDoPath))
        {
          // Open the file to read from.
          List<string> toDoLogFile = File.ReadAllLines(toDoPath).ToList();
          ToDoManager.toDoList = new List<string>(toDoLogFile);
        }

        string completedFileName = "CompletedList.txt";
        string completedPath = tempDir + completedFileName;

        if (File.Exists(completedPath))
        {
          // Open the file to read from.
          List<string> completedLogFile = File.ReadAllLines(completedPath).ToList();
          ToDoManager.completedList = new List<string>(completedLogFile);
        }
      }


    }
}
