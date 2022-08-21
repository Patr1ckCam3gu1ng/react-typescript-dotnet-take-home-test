using Carepatron.DAL.Entities;

namespace Carepatron.DAL.Repositories.Interfaces;

public interface IClientRepository
{
    Task<Client[]> Get();

    Task Create(Client client);

    Task Update(Client client);

    Task<Client[]> GetByName(string search);
}