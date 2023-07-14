using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VLocation
{
    public void GetAll(List<Location> locations)
    {
        foreach (var location in locations) GetById(location);
    }

    public void Menu()
    {
        Console.WriteLine("Pilih menu untuk masuk ke menunya");
        Console.WriteLine("1. Tambah location");
        Console.WriteLine("2. Update location");
        Console.WriteLine("3. Hapus location");
        Console.WriteLine("4. Search By Id location");
        Console.WriteLine("5. Get All location");
        Console.WriteLine("6. Main Menu");
        Console.WriteLine("Pilih: ");
    }

    public void GetById(Location location)
    {
        Console.WriteLine("Id: " + location.Id);
        Console.WriteLine("Street Address: " + location.Street_Address);
        Console.WriteLine("Postal Code: " + location.Postal_Code);
        Console.WriteLine("State Province:" + location.State_Province);
        Console.WriteLine("Country ID: " + location.Country_Id);
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

    public Location InsertMenu()
    {
        var inputStreetAddress = Console.ReadLine();
        Console.WriteLine("Tambah StreetAddress: ");
        var inputPostalCode = Console.ReadLine();
        Console.WriteLine("Tambah PostalCode: ");
        var inputCity = Console.ReadLine();
        Console.WriteLine("Tambah City: ");
        var inputStateProvince = Console.ReadLine();
        Console.WriteLine("Tambah inputStateProvince: ");
        return new Location {
            Id = 0,
            Street_Address = inputStreetAddress,
            Postal_Code = inputPostalCode,
            City = inputCity,
            State_Province = inputStateProvince
        };
    }

    public Location UpdateMenu()
    {
        var inputLocationId = int.Parse(Console.ReadLine());
        var inputStreetAddress = Console.ReadLine();
        Console.WriteLine("Update StreetAddress: ");
        var inputPostalCode = Console.ReadLine();
        Console.WriteLine("Update PostalCode: ");
        var inputCity = Console.ReadLine();
        Console.WriteLine("Update City: ");
        var inputStateProvince = Console.ReadLine();
        Console.WriteLine("Update StateProvince: ");

        return new Location {
            Id = inputLocationId,
            Street_Address = inputStreetAddress,
            Postal_Code = inputPostalCode,
            City = inputCity,
            State_Province = inputStateProvince
        };
    }

    public int DeleteMenu()
    {
        var inputId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Hapus Location Id: ");

        return inputId;
    }

    public int GetLocationId()
    {
        Console.WriteLine("Masukkan ID Location: ");
        var id = Convert.ToInt32(Console.ReadLine());
        return id;
    }
}
