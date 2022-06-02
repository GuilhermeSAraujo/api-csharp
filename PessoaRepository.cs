using api_dependency_injection.Models;

namespace api_dependency_injection
{
    public class PessoaRepository : IDb
    {
        private readonly DatabaseContext _context;

        public int Id { get; set; }
        public List<Pessoa> Pessoas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PessoaRepository(DatabaseContext databaseContext)
        {
            Id = 0;
            _context = databaseContext;
        }

        public Pessoa? Delete(int id)
        {
            try
            {
                var pessoaASerExcluida = _context.Pessoa.Where(pessoa => pessoa.Id == id).First();
                _context.Pessoa.Remove(pessoaASerExcluida);
                _context.SaveChanges();
                return pessoaASerExcluida;
            }
            catch (SystemException e)
            {
                return null;
            }

            /*for (int i = 0; i < Pessoas.Count; i++)
            {
                if (Pessoas[i].Id == id)
                {
                    var pessoaRemovida = Pessoas[i];
                    Pessoas.RemoveAt(i);
                    return pessoaRemovida;
                }
            }
            return null;*/
        }

        public List<Pessoa> FindAll()
        {
            return _context.Pessoa.ToList<Pessoa>();
        }

        public Pessoa? Find(int id)
        {
            var pessoa = _context.Pessoa.Find(id);
            if (pessoa != null)
            {
                return pessoa;
            }
            return null;
            /*foreach (var pessoa in Pessoas)
            {
                if (pessoa.Id == id)
                {
                    return pessoa;
                }
            }
            return null;*/
        }

        public Pessoa Create(string nome, int idade)
        {
            var novaPessoa = new Pessoa(Id, nome, idade);
            _context.Add(novaPessoa);
            _context.SaveChanges();
            Id++;
            return novaPessoa;
            /*var novaPessoa = new Pessoa(Id, nome, idade);
            Pessoas.Add(novaPessoa);
            Id++;
            return novaPessoa;*/
        }

        public List<Pessoa> FindAge(int idade)
        {
            var pessoasAcimaDaIdade = from pessoa in _context.Pessoa
                                      where pessoa.Idade >= idade
                                      select pessoa;
            return pessoasAcimaDaIdade.ToList();
        }

        public Pessoa? Update(Pessoa pessoaAtualizada)
        {
            try
            {
                var pessoaASerAtualizada = _context.Pessoa.Where(pessoa => pessoa.Id == pessoaAtualizada.Id).First();
                _context.Update(pessoaAtualizada);
                _context.SaveChanges();
                return pessoaAtualizada;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }

            /*var pessoa = _context.Update(pessoaAtualizada);
            return pessoa;*/


            /*foreach (var pessoa in Pessoas)
            {
                if (pessoa.Id == pessoaAtualizada.Id)
                {
                    pessoa.Nome = pessoaAtualizada.Nome;
                    pessoa.Idade = pessoaAtualizada.Idade;
                    return pessoa;
                }
            }
            return null;
            */
        }
    }
}
