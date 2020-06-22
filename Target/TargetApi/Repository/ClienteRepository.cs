using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetApi.Entity;
using TargetApi.Interfaces.Repository;

namespace TargetApi.Repository
{
    public class ClienteRepository : RepositoryBase<tb_cli_cliente>, IClienteRepository
    {
        public tb_cli_cliente GetCliente(Guid id)
        {
            return db.tb_cli_cliente.Find(id);
        }

        public IEnumerable<tb_cli_cliente> GetTodos()
        {
            return db.tb_cli_cliente.AsEnumerable();
        }
    }
}
