using Carepatron.DAL.Data;
using Carepatron.DAL.Entities;
using Carepatron.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Carepatron.DAL.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly DataContext _dataContext;

    public ClientRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task Create(Client client)
    {
        await _dataContext.AddAsync(client);
        await _dataContext.SaveChangesAsync();
    }

    public Task<Client[]> Get()
    {
        return _dataContext.Clients.ToArrayAsync();
    }

    public async Task Update(Client client)
    {
        var existingClient = await _dataContext.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
    
        if (existingClient == null)
            return;
    
        existingClient.FirstName = client.FirstName;
        existingClient.LastName = client.LastName;
        existingClient.Email = client.Email;
        existingClient.PhoneNumber = client.PhoneNumber;
    
        await _dataContext.SaveChangesAsync();
    }

    public Task<Client[]> GetByName(string search)
    {
        return _dataContext.Clients.Where(c => c.FirstName.Contains(search) || c.LastName.Contains(search))
            .ToArrayAsync();
    }
}