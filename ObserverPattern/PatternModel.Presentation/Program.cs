using PatternModel.AccessData;
using PatternModel.AccessData.BuilderPattern;
using PatternModel.Shared.Models;
using System;

namespace PatternModel.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeRegistry registry = EmployeeRegistry.GetInstance();
            EmployeeBuilder builder = new EmployeeBuilder();

            registry.Subscribe(builder);
            IDisposable unsubscriber = registry.Subscribe(builder);

            Console.WriteLine("Bienvenido al sistema de registro de empleados");
            Console.WriteLine("Digite el nombre del empleado: ");
            var name = Console.ReadLine();
            Console.WriteLine("Digite el apellido del empleado: ");
            var lastName = Console.ReadLine();
            Console.WriteLine("Digite la identificacion del empleado: ");
            var identification = Console.ReadLine();
            Console.WriteLine("Digite el cargo del empleado: ");
            var position = Console.ReadLine();

            builder.SetName(name!);
            builder.SetLastName(lastName!);
            builder.SetIdentification(identification!);
            builder.SetPosition(position!);
            Employee newEmployee = builder.Build();

            registry.InsertEmployee(newEmployee);

            Console.WriteLine($"Se insertó correctamente a {newEmployee.Name} {newEmployee.LastName} Identificación# {newEmployee.Identification} para el cargo de {newEmployee.Position}");

            Console.WriteLine("Presione cualquier tecla para cancelar la suscripción");
            Console.ReadKey();
            unsubscriber.Dispose();
            Console.WriteLine("Se canceló la suscripción del observador");


            Console.ReadLine();
        }
    }
}
