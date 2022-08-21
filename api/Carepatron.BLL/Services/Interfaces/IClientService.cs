using Carepatron.DAL.Entities;
using Carepatron.DAL.Models;

namespace Carepatron.BLL.Services.Interfaces;

public interface IClientService
{
    Task<ClientModel[]> GetAll(string search = null);

    Task<Client[]> Create(ClientModel clientModel);
}