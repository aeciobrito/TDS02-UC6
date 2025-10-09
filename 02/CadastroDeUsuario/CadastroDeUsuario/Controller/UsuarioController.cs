using CadastroDeUsuario.Data;
using CadastroDeUsuario.Models;

namespace CadastroDeUsuario.Controller
{
    internal class UsuarioController
    {
        private AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar()
        {
            #region Pedir_Dados
            Console.Write("Primeiro Nome: ");
            string primeiroNome = Console.ReadLine();

            Console.Write("Sobrenome: ");
            string sobrenome = Console.ReadLine();

            Console.Write("Data de Nascimento: ");
            DateOnly nascimento = DateOnly.Parse(Console.ReadLine());
            #endregion

            var novoUsuario = new Usuario()
            {
                DataNascimento = nascimento,
                PrimeiroNome = primeiroNome,
                Sobrenome = sobrenome
            };

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

            Console.WriteLine("Usuário Cadastrado");
            Console.ReadKey();
        }

        public void Listar()
        {
            var usuarios = _context.Usuarios.ToList();

            if (usuarios.Count() == 0)
            {
                Console.WriteLine("Nenum usuário cadastrado!");
            }
            else
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"ID: {usuario.Id} | Nome: {usuario.PrimeiroNome}");
                }
            }

            Console.WriteLine("\nPressione qualquer telca para voltar.");
            Console.ReadKey();
        }
    }
}
