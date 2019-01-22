using CanchitaServices.Models.Repositories;
using Domain;
using System;
using System.Linq;

namespace CanchitaServices.Models.Repositories
{
    public interface IClienteRepository
    {
        IQueryable<TCliente> Clientes { get; }
        void SaveClient(TCliente cliente);
        TCliente DeleteCliente(Guid ClienteID);
    }
}
