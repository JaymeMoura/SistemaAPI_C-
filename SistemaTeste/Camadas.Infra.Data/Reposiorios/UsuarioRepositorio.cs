using Microsoft.EntityFrameworkCore;
using SistemaTeste.Camadas.Application.Interfaces;
using SistemaTeste.Camadas.Domain.Models;
using SistemaTeste.Camadas.Infra.Data.Data;

namespace SistemaTeste.Camadas.Infra.Data.Reposiorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {


        private readonly SistemaTarefasDBContex _dbContex;
        public UsuarioRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContex = sistemaTarefasDBContex;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContex.usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContex.usuarios.ToListAsync();
        }


        public async Task<UsuarioModel> Adcionar(UsuarioModel usuario)
        {
            await _dbContex.AddAsync(usuario);
            await _dbContex.SaveChangesAsync();

            return usuario;
        }


        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID:{id} nao foi encontrado");
            }
            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContex.usuarios.Update(usuarioPorId);
            await _dbContex.SaveChangesAsync();

            return usuarioPorId;
        }


        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID:{id} nao foi encontrado");
            }
            _dbContex.usuarios.Remove(usuarioPorId);
            await _dbContex.SaveChangesAsync();

            return true;
        }




    }
}
