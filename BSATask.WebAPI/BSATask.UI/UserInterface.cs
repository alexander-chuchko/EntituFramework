using BSATask.DAL.Entities;
using BSATask.UI.Interfaces;

namespace BSATask.UI
{
    public class UserInterface
    {
        private readonly IApiService _apiService;
        private string key;
        private Dictionary<int, Action> methodDictionary;

        public UserInterface(IApiService apiService)
        {
            _apiService = apiService;
            methodDictionary = GetInitializedMenuItems();
        }

        private Dictionary<int, Action> GetInitializedMenuItems()
        {
            return new Dictionary<int, Action>()
            {
                {1, DisplayProjects},
                {2, DisplayProjectById},
                {3, DeleteProject},

                {4, DisplayTasks},
                {5, DisplayTaskById},
                {6, DeleteTask},

                {7, DisplayTeams},
                {8, DisplayTeamById},
                {9, DeleteTeam},

                {10, DisplayUsers},
                {11, DisplayUserById},
                {12, DeleteUser},
            };
        }

        private void DeleteUser()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter user number");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                _apiService.DeleteUserAsync(id).GetAwaiter().GetResult();
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        private void DisplayUserById()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter user ID:");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                var user = _apiService.GetByIdUserAsync(id).GetAwaiter().GetResult();
                if (user != null)
                {
                    Console.WriteLine($"\t{nameof(user.Id)} : {user.Id}\n\t" +
                        $"{nameof(user.FirstName)} : {user.FirstName}\n\t" +
                        $"{nameof(user.LastName)} : {user.LastName}\n\t" +
                        $"{nameof(user.Email)} : {user.Email}\n\t"+
                        $"{nameof(user.BirthDay)} : {user.BirthDay}\n\t" +
                        $"{nameof(user.RegisteredAt)} : {user.RegisteredAt.ToString("yyyy-MM-dd")}\n\t");
                }
                else
                {
                    Console.WriteLine($"\tProject ID {id} has no tasks");
                }
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        private void DisplayUsers()
        {
            ClearConsole();
            DisplayInfo();

            var result = _apiService.GetAllUsersAsync().GetAwaiter().GetResult().ToList();
            if (result.Count != 0)
            {
                Console.WriteLine("\tList of users:");

                result.ForEach(users =>
                {
                    Console.WriteLine("\tList of users:");
                    Console.WriteLine($"\t{nameof(users.Id)} : {users.Id}\n\t" +
                        $"{nameof(users.FirstName)} : {users.FirstName}\n\t" +
                        $"{nameof(users.LastName)} : {users.LastName}\n\t" +
                        $"{nameof(users.Email)} : {users.Email}\n\t" +
                        $"{nameof(users.BirthDay)} : {users.BirthDay}\n\t" +
                        $"{nameof(users.RegisteredAt)} : {users.RegisteredAt.ToString("yyyy-MM-dd")}\n\t");
                });
            }
            else
            {
                Console.WriteLine($"\tNo projects");
            }
        }

        private void DeleteTeam()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter team number");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                _apiService.DeleteTeamAsync(id).GetAwaiter().GetResult();
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        private void DisplayTeamById()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter team ID:");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                var team = _apiService.GetByIdTaskAsync(id).GetAwaiter().GetResult();
                if (team != null)
                {
                    Console.WriteLine($"\t{nameof(team.Id)} : {team.Id}\n\t" +
                        $"{nameof(team.Name)} : {team.Name}\n\t" +
                        $"{nameof(team.CreatedAt)} : {team.CreatedAt.ToString("yyyy-MM-dd")}\n\t");
                }
                else
                {
                    Console.WriteLine($"\tProject ID {id} has no tasks");
                }
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        private void DisplayTeams()
        {
            ClearConsole();
            DisplayInfo();

            var result = _apiService.GetAllTeamsAsync().GetAwaiter().GetResult().ToList();
            if (result.Count != 0)
            {
                Console.WriteLine("\tList of teams:");

                result.ForEach(teams =>
                {
                    Console.WriteLine($"\t{nameof(teams.Id)} : {teams.Id}\n\t" +
                        $"{nameof(teams.Name)} : {teams.Name}\n\t" +
                        $"{nameof(teams.Name)} : {teams.Name}\n\t" +
                        $"{nameof(teams.CreatedAt)} : {teams.CreatedAt.ToString("yyyy-MM-dd")}\n\t");
                });
            }
            else
            {
                Console.WriteLine($"\tNo projects");
            }
        }

        private void DeleteTask()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter task number");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                _apiService.DeleteTaskAsync(id).GetAwaiter().GetResult();
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        private void DisplayTaskById()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter task ID:");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                var task = _apiService.GetByIdTaskAsync(id).GetAwaiter().GetResult();
                if (task != null)
                {
                    Console.WriteLine($"\t{nameof(task.Id)} : {task.Id}\n\t" +
                        $"{nameof(task.ProjectId)} : {task.ProjectId}\n\t" +
                        $"{nameof(task.PerformerId)} : {task.PerformerId}" +
                        $"{nameof(task.Name)} : {task.Name}\n\t" +
                        $"{nameof(task.Description)} : {task.Description}\n\t" +
                        $"{nameof(task.State)} : {task.State}\n\t" +
                        $"{nameof(task.CreatedAt)} : {task.CreatedAt.ToString("yyyy-MM-dd")}\n\t" +
                        $"{nameof(task.FinishedAt)} : {task.FinishedAt?.ToString("yyyy-MM-dd")}\n\t");
                }
                else
                {
                    Console.WriteLine($"\tProject ID {id} has no tasks");
                }
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        private void DisplayTasks()
        {
            ClearConsole();
            DisplayInfo();

            var result = _apiService.GetAllTasksAsync().GetAwaiter().GetResult().ToList();
            if (result.Count != 0)
            {
                Console.WriteLine("\tList of tasks:");

                result.ForEach(tasks =>
                {
                    Console.WriteLine($"\t{nameof(tasks.Id)} : {tasks.Id}\n\t" +
                        $"{nameof(tasks.ProjectId)} : {tasks.ProjectId}\n\t" +
                        $"{nameof(tasks.PerformerId)} : {tasks.PerformerId}" +
                        $"{nameof(tasks.Name)} : {tasks.Name}\n\t" +
                        $"{nameof(tasks.Description)} : {tasks.Description}\n\t" +
                        $"{nameof(tasks.State)} : {tasks.State}\n\t"+
                        $"{nameof(tasks.CreatedAt)} : {tasks.CreatedAt.ToString("yyyy-MM-dd")}\n\t"+
                        $"{nameof(tasks.FinishedAt)} : {tasks.FinishedAt?.ToString("yyyy-MM-dd")}\n\t");
                });
            }
            else
            {
                Console.WriteLine($"\tNo projects");
            }
        }

        private void DisplayProjects()
        {
            ClearConsole();
            DisplayInfo();

            var result = _apiService.GetAllProjectsAsync().GetAwaiter().GetResult().ToList();
            if (result.Count != 0)
            {
                Console.WriteLine("\tList of projects:");

                result.ForEach(projects =>
                {
                    Console.WriteLine($"\t{nameof(projects.Id)} : {projects.Id}\n\t" +
                        $"{nameof(projects.TeamId)} : {projects.TeamId}\n\t" +
                        $"{nameof(projects.Name)} : {projects.Name}" +
                        $"{nameof(projects.Description)} : {projects.Description}\n\t" +
                        $"{nameof(projects.CreatedAt)} : {projects.CreatedAt}\n\t" +
                        $"{nameof(projects.Deadline)} : {projects.Deadline}\n\t");
                });
            }
            else
            {
                Console.WriteLine($"\tNo projects");
            }
        }

        private void DisplayProjectById()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter user ID:");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                var project = _apiService.GetByIdProjectAsync(id).GetAwaiter().GetResult();
                if (project != null)
                {
                    Console.WriteLine($"\t{nameof(project.Id)} : {project.Id}\n\t" +
                    $"{nameof(project.TeamId)} : {project.TeamId}\n\t" +
                    $"{nameof(project.Name)} : {project.Name}" +
                    $"{nameof(project.Description)} : {project.Description}\n\t" +
                    $"{nameof(project.CreatedAt)} : {project.CreatedAt}\n\t" +
                    $"{nameof(project.Deadline)} : {project.Deadline}\n\t");
                }
                else
                {
                    Console.WriteLine($"\tProject ID {id} has no tasks");
                }
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        private void DeleteProject()
        {
            ClearConsole();
            DisplayInfo();

            Console.WriteLine("\tEnter project number");
            string? id = Console.ReadLine();

            if (Validation.IsValidNumber(id))
            {
                _apiService.DeleteProjectAsync(id).GetAwaiter().GetResult();
            }
            else
            {
                Console.WriteLine("\tEnter incorrect data");
            }
        }

        private void ClearConsole()
        {
            Console.Clear();
        }

        private void ChangedColor(ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
        }

        private void DisplayInfo()
        {
            ClearConsole();
            ChangedColor(ConsoleColor.Red);

            Console.WriteLine("\n\t\t\t\tProject Structutre");
            ChangedColor(ConsoleColor.Yellow);

            Console.WriteLine("\n\tMENU");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\n\t" +
                "1 - Display Projects \n\t" +
                "2 - Display Project By Id\n\t" +
                "3 - Delete Id\n\t" +
                "4 - Display Tasks\n\t" +
                "5 - Display Task By Id\n\t" +
                "6 - Delete Task\n\t" +
                "7 - Display Teams\n\t"+
                "8 - Display Team By Id\n\t" +
                "9 - Delete Team\n\t"+
                "10 - Display Users\n\t" +
                "11 - Display User By Id\n\t" +
                "12 - Delete User\n\t");

            ChangedColor(ConsoleColor.Yellow);
            Console.WriteLine("\n\tSelect the desired item:\n");
            ChangedColor(ConsoleColor.White);
        }

        public void RunApplication()
        {
            DisplayInfo();

            do
            {
                key = Console.ReadLine();

                if (Validation.IsValidMenuItem(key, methodDictionary.Count))
                {
                    methodDictionary[int.Parse(key)].Invoke();
                }
                else if (key != "e")
                {
                    Console.WriteLine("Invalid value specified!");
                }

                ChangedColor(ConsoleColor.Red);
                Console.WriteLine("\n\tEXIT THE APPLICATION - 'e'\n");
                ChangedColor(ConsoleColor.White);

            } while (key != "e");
        }
    }
}
