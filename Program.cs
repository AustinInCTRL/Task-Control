using System;
using System.IO;

namespace ControlTask
{
    class Program
    {
        List<string> task = new List<string>();
        List<string> desc = new List<string>();
        int count;
        static void Main (string[] args)
        {
            // Creating an instance for non static methods 
            Program p = new Program ();
            // Bool to control the programs runtime 
            bool runProgram = true;
            do
            {
                Console.WriteLine("Welcome to Control Task, input an option from below");
                Console.WriteLine("1. Create Task\n" +
                    "2. Delete Task\n" +
                    "3. List Task\n" +
                    "4. Exit Program\n" +
                    "Input: ");
                try
                {
                    // Get user input
                    string userInput = Console.ReadLine();
                    // Make sure user input is not empty
                    while (string.IsNullOrEmpty(userInput))
                    {
                        Console.WriteLine("Input can not be empty");
                        userInput = Console.ReadLine();
                    }
                    // Switch statements for control of program
                    switch (userInput)
                    {
                        case "1":
                            p.CreateTask();
                            break;
                        case "2":
                            p.DeleteTask();
                            break;
                        case "3":
                            p.ListAllTask();
                            break;
                        case "4":
                            Console.WriteLine("Goodbye");
                            runProgram = false;
                            break;
                        default:
                            Console.WriteLine("Select a valid option 1-4");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An unknown error occurred - {ex.Message}");
                }


            } while (runProgram);
        }
        // Create a task 
        void CreateTask()
        {
            Console.WriteLine("Enter the name of the task");
            string taskName = Console.ReadLine();
            Console.WriteLine("Enter the description of the task");
            string taskDesc = Console.ReadLine();
            // Make sure task name and description is not empty
            while(string.IsNullOrEmpty(taskName) || string.IsNullOrEmpty(taskDesc))
            {
                if (string.IsNullOrEmpty(taskName))
                {
                    Console.WriteLine("Task name can not be empty");
                    taskName = Console.ReadLine();
                }
                if (string.IsNullOrEmpty(taskDesc))
                {
                    Console.WriteLine("Task description can not be empty");
                    taskDesc = Console.ReadLine();
                }
            }
            // Add task name to the list
            task.Add(taskName);
            // Add task description to the list
            desc.Add(taskDesc);
            Console.WriteLine("Task has been successfully added, to add another task just input to create another task");
        }
        // Delete a task
        void DeleteTask()
        {
            count = -1;
            // List each task in the list
            foreach (string taskName in task)
            {
                count++;
                Console.WriteLine($"{count}. {taskName}");
            }
            Console.WriteLine("Enter the number of the task that you want to delete");
            string userDelete = Console.ReadLine();
            // make sure user input is not blank 
            while (string.IsNullOrEmpty(userDelete))
            {
                Console.WriteLine("Input can not be blank");
                userDelete = Console.ReadLine();
            }
            // Convert user input to int 
            int taskToDelete = Convert.ToInt32(userDelete);
            if (task.Count < taskToDelete || desc.Count < taskToDelete)
            {
                Console.WriteLine("That number does not exist for task, try again.");
            }
            else
            {
                task.Remove(task[taskToDelete]);
                desc.Remove(desc[taskToDelete]);
            }
                Console.WriteLine("Task has been removed from the task list");
        }
        // List all task
        void ListAllTask()
        {
            count = -1;
            foreach (string taskName in task)
            {
                count++;
                Console.WriteLine($"{taskName} - {desc[count]}");
            }
        }

    }


}