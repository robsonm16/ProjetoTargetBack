using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetApi.Entity;

namespace TargetApi.Interfaces.Repository
{
    public interface IClienteRepository : IRepositoryBase<tb_cli_cliente>
    {
        IEnumerable<tb_cli_cliente> GetTodos();
        tb_cli_cliente GetCliente(Guid id);
    }
}
