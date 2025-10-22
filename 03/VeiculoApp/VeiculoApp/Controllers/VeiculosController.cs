using VeiculoApp.Data;
using VeiculoApp.Models;

namespace VeiculoApp.Controllers
{
    internal class VeiculosController
    {
        private AppDbContext _context;

        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        public void Adicionar()
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Veículo ===");
            Console.Write("Marca: ");
            string marca = Console.ReadLine() ?? string.Empty;

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine() ?? string.Empty;

            var veiculo = new Veiculo
            {
                Marca = marca,
                Modelo = modelo
            };

            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
        }
    }
}
