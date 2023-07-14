using MVCArchitecture.Models;

namespace MVCArchitecture.Controllers;

public class LinqController
{
    private Employee _employee;
    private Country _country;
    private Region _region;
    private Location _location;

    public LinqController(Employee employee, Country country, Region region, Location location)
    {
        _employee = employee;
        _country = country;
        _region = region;
        _location = location;
    }

    public void EmployeeByLastName()
    {
        var getEmployee = _employee.GetAll();
        var filtered = getEmployee.Select(e => new {
                                       FirstName = e.First_Name,
                                       LastName = e.Last_Name,
                                       Email = e.Email
                                   }).FirstOrDefault(emp => emp.LastName.Contains("Walker"));

        var filteredQuery = (from e in getEmployee
                            where e.Last_Name.Contains("Walker")
                            select new {
                                e.First_Name,
                                e.Last_Name,
                            }).ToList();
        
        Console.WriteLine($"{filtered.FirstName} {filtered.LastName}");

        foreach (var employee in filteredQuery)
        {
            Console.WriteLine($"{employee.First_Name} {employee.Last_Name}");
            //Console.WriteLine($"{employee.Email}");
        }
    }

    public void DetailCountry()
    {
        var getRegion = _region.GetAll();
        var getCountry = _country.GetAll();
        var getLocation = _location.GetAll();
        

        var detailCountry = getCountry.Join(getRegion,
                                            c => c.Region_Id,
                                            r => r.Id,
                                            (c, r) => new {c, r})
                                      .Join(getLocation,
                                            cr => cr.c.Id,
                                            l => l.Country_Id,
                                            (cr, l) => new {
                                                Id = cr.c.Id,
                                                City = l.City,
                                                Country = cr.c.Name,
                                                Region = cr.r.Name
                                            });
        
        var detailCountryByQuery = (from c in getCountry
                                    join r in getRegion on c.Region_Id equals r.Id
                                    join l in getLocation on c.Id equals l.Country_Id
                                    select new {
                                        Id = c.Id,
                                        City = l.City,
                                        Country = c.Name,
                                        Region = r.Name
                                    }).ToList();

        foreach (var country in detailCountry)
        {
            Console.WriteLine($"{country.Id} {country.City} {country.Country} {country.Region}");            
        }
    }
}
