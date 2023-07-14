using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VRegion
{
    private Region _regionModel;
    private VRegion _regionView;

    public void GetAll(List<Region> regions)
    {
        foreach (var region in regions) GetById(region);
    }


    public void Menu()
    {
        Console.WriteLine("Pilih menu untuk masuk ke menunya");
        Console.WriteLine("1. Tambah Region");
        Console.WriteLine("2. Update Region");
        Console.WriteLine("3. Hapus Region");
        Console.WriteLine("4. Search By Id Region");
        Console.WriteLine("5. Get All Regions");
        Console.WriteLine("6. Main Menu");
        Console.WriteLine("Pilih: ");
    }

    public void GetById(Region region)
    {
        Console.WriteLine("Id: " + region.Id);
        Console.WriteLine("Name: " + region.Name);
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


    public Region InsertMenu()
    {
        Console.WriteLine("Masukkan Nama: ");

        var inputName = Console.ReadLine();
        return new Region {
            Id = 0,
            Name = inputName
        };
    }

    public Region UpdateMenu()
    {
        Console.WriteLine("Input Id untuk diubah: ");
        var id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nama: ");
        var name = Console.ReadLine();

        return new Region {
            Id = id,
            Name = name
        };
    }

    public int DeleteMenu()
    {
        Console.WriteLine("Hapus region Id: ");
        var inputId = Convert.ToInt32(Console.ReadLine());

        return inputId;
    }

    public int GetRegionId()
    {
        Console.WriteLine("Masukkan ID Region: ");
        var id = Convert.ToInt32(Console.ReadLine());
        return id;
    }
}
