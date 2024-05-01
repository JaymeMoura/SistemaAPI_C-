using SistemaTeste.Camadas.Domain.Models;

namespace SistemaTeste.Camadas.Application.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adcionar(UsuarioModel usuario);
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);


    }
}
