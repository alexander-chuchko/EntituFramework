// See https://aka.ms/new-console-template for more information

using BSATask.UI.Services;
using BSATask.UI;

UserInterface userInterface = new UserInterface(new ApiService());
userInterface.RunApplication();

