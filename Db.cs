using api_dependency_injection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace api_dependency_injection
{
    public class Db : IDb
    {
        public int Id { get; set; }
        public List<Pessoa> Pessoas { get; set; }

        public Db()
        {
            Id = 4;
            Pessoas = new() {
                new Pessoa(1, "Guilherme", 20),
                new Pessoa(2, "Samuel", 21),
                new Pessoa(3, "Vinicius", 22)
            };
        }

        public Pessoa? Delete(int id)
        {
            for (int i = 0; i < Pessoas.Count; i++)
            {
                if (Pessoas[i].Id == id)
                {
                    var pessoaRemovida = Pessoas[i];
                    Pessoas.RemoveAt(i);
                    return pessoaRemovida;
                }
            }
            return null;
        }

        public List<Pessoa> FindAll()
        {
            return Pessoas;
        }

        public Pessoa? Find(int id)
        {
            foreach (var pessoa in Pessoas)
            {
                if (pessoa.Id == id)
                {
                    return pessoa;
                }
            }
            return null;
        }

        public Pessoa Create(string nome, int idade)
        {
            var novaPessoa = new Pessoa(Id, nome, idade);
            Pessoas.Add(novaPessoa);
            Id++;
            return novaPessoa;
        }

        public List<Pessoa> FindAge(int idade)
        {
            var pessoasAcimaDaIdade = from pessoa in Pessoas
                                      where pessoa.Idade >= idade
                                      select pessoa;
            return pessoasAcimaDaIdade.ToList();
        }

        public Pessoa? Update(Pessoa pessoaAtualizada)
        {
            foreach(var pessoa in Pessoas)
            {
                if(pessoa.Id == pessoaAtualizada.Id)
                {
                    pessoa.Nome = pessoaAtualizada.Nome;
                    pessoa.Idade = pessoaAtualizada.Idade;
                    return pessoa;
                }
            }
            return null;
        }
    }
}
