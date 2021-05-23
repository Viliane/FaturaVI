using FVI.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FVI.Funcionarios.API.Models
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        void Adicionar(Funcionario funcionario);

        Task<IEnumerable<Funcionario>> ObterTodos();

        Task<Funcionario> ObterPorCpf(string cpf);
    }
}
