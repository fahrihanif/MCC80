using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VJob
{
    public void GetAll(List<Job> jobs)
    {
        foreach (var job in jobs) GetById(job);
    }

    public void Menu()
    {
        Console.WriteLine("Pilih menu untuk masuk ke menunya");
        Console.WriteLine("1. Tambah job");
        Console.WriteLine("2. Update job");
        Console.WriteLine("3. Hapus job");
        Console.WriteLine("4. Search By Id job");
        Console.WriteLine("5. Get All job");
        Console.WriteLine("6. Main Menu");
        Console.WriteLine("Pilih: ");
    }

    public void GetById(Job job)
    {
        Console.WriteLine("Id: " + job.Id);
        Console.WriteLine("Title: " + job.Title);
        Console.WriteLine("Min Salary: " + job.Min_Salary);
        Console.WriteLine("Max Salary: " + job.Max_Salary);
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

    public Job InsertMenu()
    {
        var inputTitle = Console.ReadLine();
        Console.WriteLine("Tambah Title: ");
        var inputMinSalary = int.Parse(Console.ReadLine());
        Console.WriteLine("Tambah Min Salary: ");
        var inputMaxSalary = int.Parse(Console.ReadLine());
        Console.WriteLine("Tambah MaxSalary: ");
        return new Job {
            Id = "",
            Title = inputTitle,
            Min_Salary = inputMinSalary,
            Max_Salary = inputMaxSalary
        };
    }

    public Job UpdateMenu()
    {
        var inputJobId = Console.ReadLine();
        Console.WriteLine("Update Id");
        var inputTitle = Console.ReadLine();
        Console.WriteLine("Update Title: ");
        var inputMinSalary = int.Parse(Console.ReadLine());
        Console.WriteLine("Update Min Salary: ");
        var inputMaxSalary = int.Parse(Console.ReadLine());
        Console.WriteLine("Update MaxSalary: ");

        return new Job {
            Id = inputJobId,
            Title = inputTitle,
            Min_Salary = inputMinSalary,
            Max_Salary = inputMaxSalary
        };
    }

    public string DeleteMenu()
    {
        Console.WriteLine("Hapus Job Id: ");
        var inputId = Console.ReadLine();

        return inputId;
    }

    public string GetByIdMenu()
    {
        Console.WriteLine("Cari Job Id: ");
        var inputId = Console.ReadLine();


        return inputId;
    }

    public string GetJobId()
    {
        Console.WriteLine("Masukkan ID Job: ");
        var id = Console.ReadLine();
        return id;
    }
}
