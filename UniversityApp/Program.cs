using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UniversityApp.Domain.DataContext;
using UniversityApp.Scenarios;
using UniversityApp.Scenarios.MenuScenarios;
using UniversityApp.Services;
using UniversityApp.ServicesContracts;

namespace UniversityApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var scenarios = ConfigureServices();

            while (true)
            {
                try
                {
                    await StartMenu(scenarios);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }          
        }

        static Dictionary<string, IMenuScenario> ConfigureServices()
        {
            var studentService = new StudentService();
            var instructorService = new InstructorService();
            var courseService = new CourseService();
            var gradeService = new GradeService();
            var scenarios = new Dictionary<string, IMenuScenario>()
            {
                { "1", new StudentMenuScenario(studentService) },
                { "2", new InstructorMenuScenario(instructorService) },
                { "3", new CourseMenuScenario(courseService) },
                { "4", new GradeMenuScenario(gradeService) }
            };

            return scenarios;
        }

        static async Task StartMenu(Dictionary<string, IMenuScenario> scenarios)
        {
            Console.WriteLine("1. Student Menu");
            Console.WriteLine("2. Instructor Menu");
            Console.WriteLine("3. Course Menu");
            Console.WriteLine("4. Grade Menu");
            Console.WriteLine("5. Exit");

            var option = Console.ReadLine();

            if (option == null)
            {
                throw new ArgumentNullException(nameof(Options));
            }

            if (option == "5")
            {
                Environment.Exit(0);
            }

            if (scenarios.TryGetValue(option, out var scenario))
            {
                await scenario.Execute();
            }
        }
    }
}
