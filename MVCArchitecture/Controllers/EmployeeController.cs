using MVCArchitecture.Models;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers;

public class EmployeeController
{
    private readonly Employee _employeeModel;
    private readonly VEmployee _employeeView;

    public EmployeeController(Employee historyModel, VEmployee historyView)
    {
        _employeeModel = historyModel;
        _employeeView = historyView;
    }

    public void GetAll()
    {
        var regionResult = _employeeModel.GetAll();
        if (regionResult.Count() is 0)
            _employeeView.DataEmpty();
        else
            _employeeView.GetAll(regionResult);
    }

    public void Insert()
    {
        var region = _employeeView.InsertMenu();

        var result = _employeeModel.Insert(region);
        switch (result)
        {
            case -1:
                _employeeView.DataEmpty();
                break;
            case 0:
                _employeeView.Fail();
                break;
            default:
                _employeeView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _employeeView.UpdateMenu();
        var result = _employeeModel.Update(region);

        switch (result)
        {
            case -1:
                _employeeView.DataEmpty();
                break;
            case 0:
                _employeeView.Fail();
                break;
            default:
                _employeeView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _employeeView.DeleteMenu();
        var result = _employeeModel.Delete(region);

        switch (result)
        {
            case -1:
                _employeeView.DataEmpty();
                break;
            case 0:
                _employeeView.Fail();
                break;
            default:
                _employeeView.Success();
                break;
        }
    }

    public void SearchById()
    {
        var id = _employeeView.GetEmployeeId();
        var result = _employeeModel.GetById(id);
        if (result == null)
            _employeeView.DataEmpty();
        else
            _employeeView.GetById(result);
    }
}
