using System;
using System.Collections.Generic;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            int menuChoice = 0;

            Console.WriteLine("******** The Task Tracker - A Task Management App ********");

            while (menuChoice != 4)
            {
                Console.WriteLine("\nSelect one item from the menu:");
                Console.WriteLine("1. Add Task\n" +
                                  "2. View Tasks\n" +
                                  "3. Remove Task\n" +
                                  "4. Exit\n");

                //Read User Input
                menuChoice = GetInput(menuChoice);

                switch (menuChoice)
                {
    
                    case 1:
                    {
                        Console.Write("Enter the name of the task: ");
                        string taskName = Console.ReadLine();
                        AddTask(tasks, taskName);
                    }
                        continue;

                    case 2:
                    {
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("The list is empty!");
                            continue;
                        }
                        ShowTask(tasks);
                    }
                        continue;

                    case 3:
                    {
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks to remove! The list is empty.");
                            continue;
                        }
                        Console.Write("Enter the task number you want to delete: ");

                        int taskIndex;
                        while (!int.TryParse(Console.ReadLine(), out taskIndex))
                        {
                            Console.Write("Invalid input! Please enter a number again: ");
                        }

                        RemoveTask(tasks, taskIndex);
                    }
                        continue;

                    case 4:
                        Console.WriteLine("Exiting the app. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                Console.WriteLine();

            }
        }

        static int GetInput(int menuChoice)
        {
            while ((!int.TryParse(Console.ReadLine(), out menuChoice)) || (menuChoice < 1 || menuChoice > 4))
            {
                Console.Write("\nInvalid input. Please enter a number between 1 and 4: ");
            }

            return menuChoice;


        }
        static void AddTask(List<Task> _tasks, string taskName)
        {
            _tasks.Add(new Task { name = taskName });
            Console.WriteLine("Task added!");
        }

        static void ShowTask(List<Task> tasks)
        {
            Console.WriteLine("\n**** Tasks in the list ****");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i].name}");
            }
            Console.WriteLine("****************************");
        }

        static void RemoveTask(List<Task> tasks, int index)
        {
            if(index > 0 && index <= tasks.Count)
            {
                tasks.Remove(tasks[index-1]);
                Console.WriteLine("Task removed!");
            }
            else
            {
                Console.WriteLine("Invalid input! No task removed.");
            }

        }
    }

}



/*
     
    ******** Research Question (Include in your PR) Why is it better to use a List 
    instead of an Array (string[]) for this specific project? ********
  

    List is better than an array (string[]) for this project because the number of tasks changes dynamically.

    In a To-Do app:

    users can add tasks
    remove tasks
    update tasks anytime

    A List can grow and shrink automatically, while an array has a fixed size once created.

    Example:

    string[] tasks = new string[3]; → only 3 tasks allowed
    List<string> tasks = new List<string>(); → unlimited tasks can be added

    List also provides built-in methods like:

    Add()
    Remove()
    Find()
    Count

    which make task management much easier compared to arrays.

 */
