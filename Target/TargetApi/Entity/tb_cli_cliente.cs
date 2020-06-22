using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetApi.Entity
{
    public class tb_cli_cliente
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
    }
}
