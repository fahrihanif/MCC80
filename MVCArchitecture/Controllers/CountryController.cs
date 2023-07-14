using MVCArchitecture.Models;
using MVCArchitecture.Views;

namespace MVCArchitecture.Controllers;

public class CountryController
{
    private readonly Country _country;
    private readonly VCountry _countryView;

    public CountryController(Country country, VCountry countryView)
    {
        _country = country;
        _countryView = countryView;
    }

    public void GetAll()
    {
        var regionResult = _country.GetAll();
        if (regionResult.Count() is 0)
            _countryView.DataEmpty();
        else
            _countryView.GetAll(regionResult);
    }

    public void Insert()
    {
        var region = _countryView.InsertMenu();

        var result = _country.Insert(region);
        switch (result)
        {
            case -1:
                _countryView.DataEmpty();
                break;
            case 0:
                _countryView.Fail();
                break;
            default:
                _countryView.Success();
                break;
        }
    }

    public void Update()
    {
        var region = _countryView.UpdateMenu();
        var result = _country.Update(region);

        switch (result)
        {
            case -1:
                _countryView.DataEmpty();
                break;
            case 0:
                _countryView.Fail();
                break;
            default:
                _countryView.Success();
                break;
        }
    }

    public void Delete()
    {
        var region = _countryView.DeleteMenu();
        var result = _country.Delete(region);

        switch (result)
        {
            case -1:
                _countryView.DataEmpty();
                break;
            case 0:
                _countryView.Fail();
                break;
            default:
                _countryView.Success();
                break;
        }
    }

    public void SearchById()
    {
        var id = _countryView.GetCountryId();
        var result = _country.GetById(id);
        if (result == null)
            _countryView.DataEmpty();
        else
            _countryView.GetById(result);
    }
}
