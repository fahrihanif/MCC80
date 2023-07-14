using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VDepartment
{
    public void GetAll(List<Department> departments)
    {
        foreach (var department in departments) GetById(department);
    }

    public void Menu()
    {
        Console.WriteLine("Pilih menu untuk masuk ke menunya");
        Console.WriteLine("1. Tambah department");
        Console.WriteLine("2. Update department");
        Console.WriteLine("3. Hapus department");
        Console.WriteLine("4. Search By Id department");
        Console.WriteLine("5. Get All department");
        Console.WriteLine("6. Main Menu");
        Console.WriteLine("Pilih: ");
    }

    public void GetById(Department department)
    {
        Console.WriteLine("Id: " + department.Id);
        Console.WriteLine("Name: " + department.Name);
        Console.WriteLine("Location ID: " + department.Location_Id);
        Console.WriteLine("Manager ID:" + department.Manager_Id);
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

    public Department InsertMenu()
    {
        var inputName = Console.ReadLine();
        Console.WriteLine("Tambah Department: ");
        return new Department {
            Id = 0,
            Name = inputName
        };
    }

    public Department UpdateMenu()
    {
        var inputName = Console.ReadLine();
        Console.WriteLine("Ganti Nama: ");
        var inputId = int.Parse(Console.ReadLine());
        Console.WriteLine("Ganti ID: ");

        return new Department {
            Id = inputId,
            Name = inputName
        };
    }

    public int DeleteMenu()
    {
        var inputId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Hapus Department Id: ");

        return inputId;
    }

    public int GetDepartmentId()
    {
        Console.WriteLine("Masukkan ID Department: ");
        var id = Convert.ToInt32(Console.ReadLine());
        return id;
    }
}
