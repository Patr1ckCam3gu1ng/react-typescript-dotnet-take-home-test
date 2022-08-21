using Carepatron.DAL.Entities;

namespace Carepatron.DAL.Data;

public class DataSeeder
{
    private readonly DataContext _dataContext;

    public DataSeeder(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void Seed()
    {
        var client = new Client("xosiosiosdhad", "John", "Smith", "john@gmail.com", "+18202820232");

        _dataContext.Add(client);
        _dataContext.SaveChanges();
    }
}