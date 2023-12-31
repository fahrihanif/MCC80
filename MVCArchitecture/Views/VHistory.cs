﻿using MVCArchitecture.Models;

namespace MVCArchitecture.Views;

public class VHistory
{
    public void GetAll(List<History> histories)
    {
        foreach (var history in histories) GetById(history);
    }

    public void Menu()
    {
        Console.WriteLine("Pilih menu untuk masuk ke menunya");
        Console.WriteLine("1. Tambah history");
        Console.WriteLine("2. Update history");
        Console.WriteLine("3. Hapus history");
        Console.WriteLine("4. Search By Id history");
        Console.WriteLine("5. Get All history");
        Console.WriteLine("6. Main Menu");
        Console.WriteLine("Pilih: ");
    }

    public void GetById(History history)
    {
        Console.WriteLine("Start Date: " + history.Start_Date);
        Console.WriteLine("Employee ID: " + history.Employee_Id);
        Console.WriteLine("End Date: " + history.End_Date);
        Console.WriteLine("Department ID:" + history.Department_Id);
        Console.WriteLine("Job ID" + history.Job_Id);
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


    public History InsertMenu()
    {
        var inputStartDate = Helper.DateValidation();
        Console.Write("StartDate : ");
        var inputEndDate = Helper.DateValidation();
        Console.Write("EndDate : ");
        return new History {
            Start_Date = inputStartDate,
            End_Date = inputEndDate
        };
    }

    public History UpdateMenu()
    {
        var inputStartDate = Helper.DateValidation();
        Console.Write("StartDate : ");
        var inputEndDate = Helper.DateValidation();
        Console.Write("EndDate : ");

        return new History {
            Start_Date = inputStartDate,
            End_Date = inputEndDate
        };
    }

    public DateTime DeleteMenu()
    {
        var inputId = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Hapus Start Date: ");

        return inputId;
    }

    public DateTime GetHistoryId()
    {
        Console.WriteLine("Cari Start Date Id: ");
        var inputId = Convert.ToDateTime(Console.ReadLine());


        return inputId;
    }
}
