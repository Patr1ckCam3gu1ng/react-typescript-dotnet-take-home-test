using AutoMapper;
using Carepatron.BLL.Services.Interfaces;
using Carepatron.DAL.Entities;
using Carepatron.DAL.Models;
using Carepatron.DAL.Repositories.Interfaces;
using Microsoft.Extensions.Primitives;

namespace Carepatron.BLL.Services;

public class ClientService : IClientService
{
    private const string KeyValue = "clients_all";
    private readonly ICacheRepository _cache;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public ClientService(IMapper mapper, IClientRepository clientRepository, ICacheRepository cache)
    {
        _mapper = mapper;
        _clientRepository = clientRepository;
        _cache = cache;
    }

    public async Task<ClientModel[]> GetAll(string search = null)
    {
        if (string.IsNullOrEmpty(search) == false)
        {
            var result = await _clientRepository.GetByName(search);

            return _mapper.Map<ClientModel[]>(result);
        }

        var cacheResult = _cache.GetCache(KeyValue);

        if (cacheResult is List<object> cacheObjects)
        {
            var cache = cacheObjects.Select(cache => cache as Client).ToArray();

            return _mapper.Map<ClientModel[]>(cache);
        }

        var clients = await GetClient();

        return _mapper.Map<ClientModel[]>(clients);
    }

    private async Task<Client[]> GetClient()
    {
        var clients = await _clientRepository.Get();

        var clientsObject = clients.Cast<object>().ToList();

        var ct = new CancellationTokenSource(TimeSpan.FromSeconds(30));

        await _cache.CreateAsync(KeyValue, clientsObject, new CancellationChangeToken(ct.Token))
            .ConfigureAwait(false);

        return clients;
    }

    public async Task<Client[]> Create(ClientModel clientModel)
    {
        var client = _mapper.Map<Client>(clientModel);

        if (string.IsNullOrEmpty(clientModel.Id)) client.Id = Guid.NewGuid().ToString();

        await _clientRepository.Create(client);

        if (string.IsNullOrEmpty(client.Id) == false)
        {
            return await GetClient();
        }

        return null;
    }
}