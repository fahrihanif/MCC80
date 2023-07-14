using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VEmployee
{
    private Employee _employeeModel;

    public void GetAll(List<Employee> employees)
    {
        foreach (var employee in employees) GetById(employee);
    }

    public void Menu()
    {
        Console.WriteLine("Pilih menu untuk masuk ke menunya");
        Console.WriteLine("1. Tambah employee");
        Console.WriteLine("2. Update employee");
        Console.WriteLine("3. Hapus employee");
        Console.WriteLine("4. Search By Id employee");
        Console.WriteLine("5. Get All employee");
        Console.WriteLine("6. Main Menu");
        Console.WriteLine("Pilih: ");
    }

    public void GetById(Employee employee)
    {
        Console.WriteLine("Id: " + employee.Id);
        Console.WriteLine("First Name: " + employee.First_Name);
        Console.WriteLine("Last Name: " + employee.Last_Name);
        Console.WriteLine("Email:" + employee.Email);
        Console.WriteLine("Phone Number: " + employee.Phone_Number);
        Console.WriteLine("Hire Date: " + employee.Hire_Date);
        Console.WriteLine("Salary: " + employee.Salary);
        Console.WriteLine("Comission PCT: " + employee.Comission_Pct);
        Console.WriteLine("Manager ID: " + employee.Manager_Id);
        Console.WriteLine("Job ID: " + employee.Job_Id);
        Console.WriteLine("Department ID: " + employee.Department_Id);
    }

    public void DataEmpty()
    {
        Console.WriteLine("Tidak ada data");
    }

    public void Fail()
    {
        Console.WriteLine("Gagal");
    }

    public void Success()
    {
        Console.WriteLine("Berhasil");
    }

    public Employee InsertMenu()
    {
        var inputFirstName = Console.ReadLine();
        Console.WriteLine("Tambah First Name: ");
        var inputLastName = Console.ReadLine();
        Console.WriteLine("Tambah Last Name: ");
        var inputEmail = Console.ReadLine();
        Console.WriteLine("Tambah Email: ");
        var inputPhone = Console.ReadLine();
        Console.WriteLine("Tambah Nomor HP: ");
        var inputHireDate = Helper.DateValidation();
        Console.Write("Tambah Hire Date: ");
        var inputSalary = int.Parse(Console.ReadLine());
        Console.WriteLine("Tambah Salary: ");
        var inputComission = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Tambah Commision PCT: ");

        return new Employee {
            First_Name = inputFirstName,
            Last_Name = inputLastName,
            Email = inputEmail,
            Phone_Number = inputPhone,
            Hire_Date = inputHireDate,
            Salary = inputSalary,
            Comission_Pct = inputComission
        };
    }

    public Employee UpdateMenu()
    {
        var inputEmployeeId = int.Parse(Console.ReadLine());
        Console.WriteLine("Update Id");
        var inputFirstName = Console.ReadLine();
        Console.WriteLine("Tambah First Name: ");
        var inputLastName = Console.ReadLine();
        Console.WriteLine("Tambah Last Name: ");
        var inputEmail = Console.ReadLine();
        Console.WriteLine("Tambah Email: ");
        var inputPhone = Console.ReadLine();
        Console.WriteLine("Tambah Nomor HP: ");
        var inputHireDate = Helper.DateValidation();
        Console.Write("Tambah Hire Date: ");
        var inputSalary = int.Parse(Console.ReadLine());
        Console.WriteLine("Tambah Salary: ");
        var inputComission = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Tambah Commision PCT: ");

        return new Employee {
            Id = inputEmployeeId,
            First_Name = inputFirstName,
            Last_Name = inputLastName,
            Email = inputEmail,
            Phone_Number = inputPhone,
            Hire_Date = inputHireDate,
            Salary = inputSalary,
            Comission_Pct = inputComission
        };
    }

    public int DeleteMenu()
    {
        var inputId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Hapus Employee Id: ");

        return inputId;
    }

    public int GetEmployeeId()
    {
        Console.WriteLine("Masukkan ID Employee: ");
        var id = Convert.ToInt32(Console.ReadLine());
        return id;
    }
}
