using MVCArchitecture.Models;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers;

public class JobController
{
    private readonly Job _jobModel;
    private readonly VJob _jobView;

    public JobController(Job jobModel, VJob jobView)
    {
        _jobModel = jobModel;
        _jobView = jobView;
    }

    public void GetAll()
    {
        var regionResult = _jobModel.GetAll();
        if (regionResult.Count() is 0)
            _jobView.DataEmpty();
        else
            _jobView.GetAll(regionResult);
    }

    public void Insert()
    {
        var region = _jobView.InsertMenu();

        var result = _jobModel.Insert(region);
        switch (result)
        {
            case -1:
                _jobView.DataEmpty();
                break;
            case 0:
                _jobView.Fail();
                break;
            default:
                _jobView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _jobView.UpdateMenu();
        var result = _jobModel.Update(region);

        switch (result)
        {
            case -1:
                _jobView.DataEmpty();
                break;
            case 0:
                _jobView.Fail();
                break;
            default:
                _jobView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _jobView.DeleteMenu();
        var result = _jobModel.Delete(region);

        switch (result)
        {
            case -1:
                _jobView.DataEmpty();
                break;
            case 0:
                _jobView.Fail();
                break;
            default:
                _jobView.Success();
                break;
        }
    }

    public void SearchById()
    {
        var id = _jobView.GetJobId();
        var result = _jobModel.GetById(id);
        if (result == null)
            _jobView.DataEmpty();
        else
            _jobView.GetById(result);
    }
}
