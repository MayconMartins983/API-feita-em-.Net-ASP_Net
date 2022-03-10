using CRUD_back.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using CRUD_back.Context;
using Microsoft.EntityFrameworkCore;

namespace CRUD_back.Services
{
    public class ClientesService : IClientesService  
        {
        private readonly AppDbContext _context;

        public ClientesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Clientes>> GetClientes()
        {
            try
            {
                return await _context.Clientes.ToListAsync();
            }
            catch 
            {
                throw;
            }
        }        

        public async Task<IEnumerable<Clientes>> GetClientesByName(string name)
        {
            IEnumerable<Clientes> clientes;
            if (!string.IsNullOrWhiteSpace(name))
            {
                clientes = await _context.Clientes.Where(n => n.Name.Contains(name)).ToListAsync();
            }
            else 
            { 
                clientes = await GetClientes();
            }
            return clientes;
        }

        public async Task<Clientes> GetClientes(int Id)
        {
            var clientes = await _context.Clientes.FindAsync(Id);
            return clientes;
        }

        public async Task CreateClientes(Clientes clientes)
        {
            _context.Clientes.Add(clientes);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientes(Clientes clientes)
        {
            _context.Entry(clientes).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClientes(Clientes clientes)
        {
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
        }
       
    }

}
