using api_dependency_injection.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_dependency_injection
{
    public interface IDb
    {
        int Id { get; set; }
        List<Pessoa> Pessoas { get; set; }

        List<Pessoa> FindAll();

        Pessoa? Find(int id);

        List<Pessoa> FindAge(int idade);

        Pessoa Create(string nome, int idade);

        Pessoa? Delete(int id);

        Pessoa? Update(Pessoa pessoa);

    }
}
