using MVCArchitecture.Models;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers;

public class RegionController
{
    private readonly Region _regionModel;
    private readonly VRegion _regionView;

    public RegionController(Region regionModel, VRegion regionView)
    {
        _regionModel = regionModel;
        _regionView = regionView;
    }

    public void GetAll()
    {
        var regionResult = _regionModel.GetAll();
        if (regionResult.Count() is 0)
            _regionView.DataEmpty();
        else
            _regionView.GetAll(regionResult);
    }

    public void Insert()
    {
        var region = _regionView.InsertMenu();

        var result = _regionModel.Insert(region);
        switch (result)
        {
            case -1:
                _regionView.DataEmpty();
                break;
            case 0:
                _regionView.Fail();
                break;
            default:
                _regionView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _regionView.UpdateMenu();
        var result = _regionModel.Update(region);

        switch (result)
        {
            case -1:
                _regionView.DataEmpty();
                break;
            case 0:
                _regionView.Fail();
                break;
            default:
                _regionView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _regionView.DeleteMenu();
        var result = _regionModel.Delete(region);

        switch (result)
        {
            case -1:
                _regionView.DataEmpty();
                break;
            case 0:
                _regionView.Fail();
                break;
            default:
                _regionView.Success();
                break;
        }
    }

    public void SearchById()
    {
        var id = _regionView.GetRegionId();
        var result = _regionModel.GetById(id);
        if (result == null)
            _regionView.DataEmpty();
        else
            _regionView.GetById(result);
    }
}
