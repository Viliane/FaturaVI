using FVI.Core.Data;
using FVI.Funcionarios.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FVI.Funcionarios.API.Data.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly FuncionariosContext _context;

        public FuncionarioRepository(FuncionariosContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Funcionario>> ObterTodos()
        {
            return await _context.Funcionarios.AsNoTracking().ToListAsync();
        }

        public void Adicionar(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
        }

        public Task<Funcionario> ObterPorCpf(string cpf)
        {
            return _context.Funcionarios.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
