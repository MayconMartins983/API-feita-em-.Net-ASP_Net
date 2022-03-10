using CRUD_back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD_back.Services
{
    public interface IClientesService
    {
        Task<IEnumerable<Clientes>> GetClientes();

        Task<Clientes> GetClientes(int Id);

        Task<IEnumerable<Clientes>> GetClientesByName(string name);

        Task CreateClientes (Clientes clientes);

        Task UpdateClientes(Clientes clientes);

        Task DeleteClientes(Clientes clientes);
    }
}
