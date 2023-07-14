using MVCArchitecture.Controllers;
using MVCArchitecture.Models;
using MVCArchitecture.Views;

public class Program
{
    public static void Main()
    {
        MainMenu();
    }

    public static void MainMenu()
    {
        Console.WriteLine("Pilih menu untuk masuk ke menunya");
        Console.WriteLine("1. Employees");
        Console.WriteLine("2. Departments");
        Console.WriteLine("3. Jobs");
        Console.WriteLine("4. Histories");
        Console.WriteLine("5. Locations");
        Console.WriteLine("6. Countries");
        Console.WriteLine("7. Regions");
        Console.WriteLine("8. LINQ");
        Console.WriteLine("9. Exit");
        Console.WriteLine("Pilih: ");

        try
        {
            var pilihMenu = int.Parse(Console.ReadLine());

            switch (pilihMenu)
            {
                case 1:
                    Console.WriteLine("1. Employees");
                    Console.Clear();
                    MenuEmployees();
                    break;
                case 2:
                    Console.WriteLine("2. Departments");
                    Console.Clear();
                    MenuDepartment();
                    MainMenu();
                    break;
                case 3:
                    Console.WriteLine("3. Jobs");
                    Console.Clear();
                    MenuJob();
                    MainMenu();
                    break;
                case 4:
                    Console.WriteLine("4. Histories");
                    Console.Clear();
                    MenuHistory();
                    MainMenu();
                    break;
                case 5:
                    Console.WriteLine("5. Locations");
                    Console.Clear();
                    MenuLocation();
                    MainMenu();
                    break;
                case 6:
                    Console.WriteLine("6. Countries");
                    Console.Clear();
                    MenuCountry();
                    MainMenu();
                    break;
                case 7:
                    Console.WriteLine("7. Regions");
                    Console.Clear();
                    MenuRegion();
                    MainMenu();
                    break;
                case 8:
                    Console.WriteLine("8. LINQ");
                    Console.Clear();
                    MenuLinq();
                    MainMenu();
                    break;
                case 9:
                    Console.WriteLine("8. Exit");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Silahkan Pilih Nomor 1-7");
                    MainMenu();
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Input Hanya diantara 1-7!");
            MainMenu();
        }
    }

    public static void MenuLinq()
    {
        var employee = new Employee();
        var region = new Region();
        var country = new Country();
        var location = new Location();
        var linq = new LinqController(employee, country, region, location);
        
        linq.DetailCountry();
    }

    public static void MenuRegion()
    {
        var region = new Region();
        var vRegion = new VRegion();
        var regionController = new RegionController(region, vRegion);
        
        try
        {
            vRegion.Menu();
            var pilihMenu = int.Parse(Console.ReadLine());

            switch (pilihMenu)
            {
                case 1:
                    regionController.Insert();
                    MenuRegion();
                    break;
                case 2:
                    regionController.Update();
                    MenuRegion();
                    break;
                case 3:
                    regionController.Delete();
                    MenuRegion();
                    break;
                case 4:
                    regionController.SearchById();
                    MenuRegion();
                    break;
                case 5:
                    regionController.GetAll();
                    MenuRegion();
                    break;
                case 6:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Silahkan Pilih Nomor 1-6");
                    MenuRegion();
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Input Hanya diantara 1-6!");
            MenuRegion();
        }
    }


    public static void MenuCountry()
    {
        var country = new Country();
        var vCountry = new VCountry();
        var countryController = new CountryController(country, vCountry);


        try
        {
            vCountry.Menu();
            var pilihMenu = int.Parse(Console.ReadLine());

            switch (pilihMenu)
            {
                case 1:
                    countryController.Insert();
                    MenuCountry();
                    break;
                case 2:
                    countryController.Update();
                    MenuCountry();
                    break;
                case 3:
                    countryController.Delete();
                    MenuCountry();
                    break;
                case 4:
                    countryController.SearchById();
                    MenuCountry();
                    break;
                case 5:
                    countryController.GetAll();
                    MenuCountry();
                    break;
                case 6:
                    Console.WriteLine("MainMenu");
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Silahkan Pilih Nomor 1-6");
                    MenuCountry();
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Input Hanya diantara 1-6!");
            MenuCountry();
        }
    }

    public static void MenuLocation()
    {
        var location = new Location();
        var vLocation = new VLocation();
        var locationController = new LocationController(location, vLocation);


        try
        {
            vLocation.Menu();
            var pilihMenu = int.Parse(Console.ReadLine());

            switch (pilihMenu)
            {
                case 1:
                    locationController.Insert();
                    MenuLocation();
                    break;
                case 2:
                    locationController.Update();
                    MenuLocation();
                    break;
                case 3:
                    locationController.Delete();
                    MenuLocation();
                    break;
                case 4:
                    locationController.SearchById();
                    MenuLocation();
                    break;
                case 5:
                    locationController.GetAll();
                    MenuLocation();
                    break;
                case 6:
                    Console.WriteLine("MainMenu");
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Silahkan Pilih Nomor 1-6");
                    MenuLocation();
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Input Hanya diantara 1-6!");
            MenuLocation();
        }
    }

    public static void MenuDepartment()
    {
        var department = new Department();
        var vDepartment = new VDepartment();
        var departmentController = new DepartmentController(department, vDepartment);


        try
        {
            vDepartment.Menu();
            var pilihMenu = int.Parse(Console.ReadLine());

            switch (pilihMenu)
            {
                case 1:
                    departmentController.Insert();
                    MenuDepartment();
                    break;
                case 2:
                    departmentController.Update();
                    MenuDepartment();
                    break;
                case 3:
                    departmentController.Delete();
                    MenuDepartment();
                    break;
                case 4:
                    departmentController.SearchById();
                    MenuDepartment();
                    break;
                case 5:
                    departmentController.GetAll();
                    MenuDepartment();
                    break;
                case 6:
                    Console.WriteLine("MainMenu");
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Silahkan Pilih Nomor 1-6");
                    MenuDepartment();
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Input Hanya diantara 1-6!");
            MenuDepartment();
        }
    }

    public static void MenuJob()
    {
        var job = new Job();
        var vJob = new VJob();
        var jobController = new JobController(job, vJob);


        try
        {
            vJob.Menu();
            var pilihMenu = int.Parse(Console.ReadLine());

            switch (pilihMenu)
            {
                case 1:
                    jobController.Insert();
                    MenuJob();
                    break;
                case 2:
                    jobController.Update();
                    MenuJob();
                    break;
                case 3:
                    jobController.Delete();
                    MenuJob();
                    break;
                case 4:
                    jobController.SearchById();
                    MenuJob();
                    break;
                case 5:
                    jobController.GetAll();
                    MenuJob();
                    break;
                case 6:
                    Console.WriteLine("MainMenu");
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Silahkan Pilih Nomor 1-6");
                    MenuJob();
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Input Hanya diantara 1-6!");
            MenuJob();
        }
    }

    public static void MenuHistory()
    {
        var history = new History();
        var vHistory = new VHistory();
        var historyController = new HistoryController(history, vHistory);


        try
        {
            vHistory.Menu();
            var pilihMenu = int.Parse(Console.ReadLine());

            switch (pilihMenu)
            {
                case 1:
                    historyController.Insert();
                    MenuHistory();
                    break;
                case 2:
                    historyController.Update();
                    MenuHistory();
                    break;
                case 3:
                    historyController.Delete();
                    MenuHistory();
                    break;
                case 4:
                    historyController.SearchById();
                    MenuHistory();
                    break;
                case 5:
                    historyController.GetAll();
                    MenuHistory();
                    break;
                case 6:
                    Console.WriteLine("MainMenu");
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Silahkan Pilih Nomor 1-6");
                    MenuHistory();
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Input Hanya diantara 1-6!");
            MenuHistory();
        }
    }

    public static void MenuEmployees()
    {
        var employee = new Employee();
        var vEmployee = new VEmployee();
        var employeeController = new EmployeeController(employee, vEmployee);


        try
        {
            vEmployee.Menu();
            var pilihMenu = int.Parse(Console.ReadLine());

            switch (pilihMenu)
            {
                case 1:
                    employeeController.Insert();
                    MenuEmployees();
                    break;
                case 2:
                    employeeController.Update();
                    MenuEmployees();
                    break;
                case 3:
                    employeeController.Delete();
                    MenuEmployees();
                    break;
                case 4:
                    employeeController.SearchById();
                    MenuEmployees();
                    break;
                case 5:
                    employeeController.GetAll();
                    MenuEmployees();
                    break;
                case 6:
                    Console.WriteLine("MainMenu");
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Silahkan Pilih Nomor 1-6");
                    MenuEmployees();
                    break;
            }
        }
        catch
        {
            Console.WriteLine("Input Hanya diantara 1-6!");
            MenuEmployees();
        }
    }
}
