﻿using MVCArchitecture.Models;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers;

public class LocationController
{
    private readonly Location _locationModel;
    private readonly VLocation _locationView;

    public LocationController(Location locationModel, VLocation locationView)
    {
        _locationModel = locationModel;
        _locationView = locationView;
    }

    public void GetAll()
    {
        var regionResult = _locationModel.GetAll();
        if (regionResult.Count() is 0)
            _locationView.DataEmpty();
        else
            _locationView.GetAll(regionResult);
    }

    public void Insert()
    {
        var region = _locationView.InsertMenu();

        var result = _locationModel.Insert(region);
        switch (result)
        {
            case -1:
                _locationView.DataEmpty();
                break;
            case 0:
                _locationView.Fail();
                break;
            default:
                _locationView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _locationView.UpdateMenu();
        var result = _locationModel.Update(region);

        switch (result)
        {
            case -1:
                _locationView.DataEmpty();
                break;
            case 0:
                _locationView.Fail();
                break;
            default:
                _locationView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _locationView.DeleteMenu();
        var result = _locationModel.Delete(region);

        switch (result)
        {
            case -1:
                _locationView.DataEmpty();
                break;
            case 0:
                _locationView.Fail();
                break;
            default:
                _locationView.Success();
                break;
        }
    }

    public void SearchById()
    {
        var id = _locationView.GetLocationId();
        var result = _locationModel.GetById(id);
        if (result == null)
            _locationView.DataEmpty();
        else
            _locationView.GetById(result);
    }
}
