﻿using MVCArchitecture.Models;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers;

public class HistoryController
{
    private readonly History _historyModel;
    private readonly VHistory _historyView;

    public HistoryController(History historyModel, VHistory historyView)
    {
        _historyModel = historyModel;
        _historyView = historyView;
    }

    public void GetAll()
    {
        var regionResult = _historyModel.GetAll();
        if (regionResult.Count() is 0)
            _historyView.DataEmpty();
        else
            _historyView.GetAll(regionResult);
    }

    public void Insert()
    {
        var region = _historyView.InsertMenu();

        var result = _historyModel.Insert(region);
        switch (result)
        {
            case -1:
                _historyView.DataEmpty();
                break;
            case 0:
                _historyView.Fail();
                break;
            default:
                _historyView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _historyView.UpdateMenu();
        var result = _historyModel.Update(region);

        switch (result)
        {
            case -1:
                _historyView.DataEmpty();
                break;
            case 0:
                _historyView.Fail();
                break;
            default:
                _historyView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _historyView.DeleteMenu();
        var result = _historyModel.Delete(region);

        switch (result)
        {
            case -1:
                _historyView.DataEmpty();
                break;
            case 0:
                _historyView.Fail();
                break;
            default:
                _historyView.Success();
                break;
        }
    }

    public void SearchById()
    {
        var id = _historyView.GetHistoryId();
        var result = _historyModel.GetById(id);
        if (result == null)
            _historyView.DataEmpty();
        else
            _historyView.GetById(result);
    }
}
