using System;

namespace DesignPatterns.AbstractFactory
{
    public interface IFactory
    {
        DTOAbstract CreateDTOObject();

        DAOAbstract CreateDAOObject();
    }

    class SupervisorFactory : IFactory
    {
        public DTOAbstract CreateDTOObject()
        {
            return new DTOSupervisor();
        }

        public DAOAbstract CreateDAOObject()
        {
            return new DAOSupervisor();
        }
    }

    class StudentFactory : IFactory
    {
        public DTOAbstract CreateDTOObject()
        {
            return new DTOStudent();
        }

        public DAOAbstract CreateDAOObject()
        {
            return new DAOStudent();
        }
    }

    public interface DTOAbstract
    {
        string UsefulFunction();
    }

    class DTOSupervisor : DTOAbstract
    {
        public string UsefulFunction()
        {
            return "The result of the DTOSupervisor.";
        }
    }

    class DTOStudent : DTOAbstract
    {
        public string UsefulFunction()
        {
            return "The result of the product DTOStudent.";
        }
    }

    public interface DAOAbstract
    {
        string UsefulFunction();

        string AnotherUsefulFunction(DTOAbstract collaborator);
    }

    class DAOSupervisor : DAOAbstract
    {
        public string UsefulFunction()
        {
            return "The result of the DAOSupervisor.";
        }

        public string AnotherUsefulFunction(DTOAbstract collaborator)
        {
            var result = collaborator.UsefulFunction();

            return $"The result of the DAOSupervisor collaborating with the ({result})";
        }
    }

    class DAOStudent : DAOAbstract
    {
        public string UsefulFunction()
        {
            return "The result of the DAOStudent.";
        }

        public string AnotherUsefulFunction(DTOAbstract collaborator)
        {
            var result = collaborator.UsefulFunction();

            return $"The result of the DAOStudent collaborating with the ({result})";
        }
    }

    class IFactoryProgram
    {
        private static void SupportMethod(IFactory factory)
        {
            var daoObject = factory.CreateDAOObject();
            var dtoObject = factory.CreateDTOObject();

            Console.WriteLine(daoObject.UsefulFunction());
            Console.WriteLine(daoObject.AnotherUsefulFunction(dtoObject));
        }

        public static void Run()
        {
            Console.WriteLine("Client: Testing client code with the StudentFactory type...");
            SupportMethod(new StudentFactory());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the SupervisorFactory type...");
            SupportMethod(new SupervisorFactory());
        }
    }
}