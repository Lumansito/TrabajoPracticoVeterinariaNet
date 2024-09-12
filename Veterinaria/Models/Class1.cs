using Models.Data; // Asegúrate de que este es el espacio de nombres correcto
using System;
using System.Linq;

namespace Models
{
    public class Class1
    {
        
     
        // Método que realiza la operación con VeterinariaContext
        public void DoSomething()
        {
            using (var context = new VeterinariaContext())
            {
                Console.WriteLine("Hello World!");

                var clientes = context.Clientes.ToList(); // Asegúrate de que Clientes existe en el contexto

                foreach (var cliente in clientes)
                {
                    Console.WriteLine(cliente.Nombre); // Asegúrate de que Nombre es un campo de Cliente
                }
            }
        }
    }
}
