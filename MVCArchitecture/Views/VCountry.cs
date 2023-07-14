﻿using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VCountry
{
    public void GetAll(List<Country> countries)
    {
        foreach (var country in countries) GetById(country);
    }

    public void Menu()
    {
        Console.WriteLine("Pilih menu untuk masuk ke menunya");
        Console.WriteLine("1. Tambah country");
        Console.WriteLine("2. Update country");
        Console.WriteLine("3. Hapus country");
        Console.WriteLine("4. Search By Id country");
        Console.WriteLine("5. Get All country");
        Console.WriteLine("6. Main Menu");
        Console.WriteLine("Pilih: ");
    }

    public void GetById(Country country)
    {
        Console.WriteLine("Id: " + country.Id);
        Console.WriteLine("Name: " + country.Name);
        Console.WriteLine("Region Id: " + country.Region_Id);
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

    public Country InsertMenu()
    {
        Console.WriteLine("Masukkan Nama: ");

        var inputName = Console.ReadLine();
        return new Country {
            Id = "",
            Name = inputName
        };
    }

    public Country UpdateMenu()
    {
        Console.WriteLine("Input Id untuk diubah: ");
        var id = Console.ReadLine();
        Console.WriteLine("Nama: ");
        var name = Console.ReadLine();

        return new Country {
            Id = id,
            Name = name
        };
    }

    public string DeleteMenu()
    {
        Console.WriteLine("Hapus Country Id: ");
        var inputId = Console.ReadLine();

        return inputId;
    }

    public string GetCountryId()
    {
        Console.WriteLine("Masukkan ID Country: ");
        var id = Console.ReadLine();
        return id;
    }
}
