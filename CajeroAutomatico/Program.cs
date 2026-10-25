using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajeroAutomatico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nomCliente = "Carlos Sanchez";
            string numCuenta = "9609904351";
            string tipoCuenta = "Ahorro";
            decimal saldoDisponible = 32850;
            decimal montoOperación;
            int opcion;
            

            do
            {
                Console.WriteLine("==========================================");
                Console.WriteLine($"Bienvenido {nomCliente}");
                Console.WriteLine($"Cuenta: {numCuenta}");
                Console.WriteLine($"Tipo de cuenta: {tipoCuenta}");
                Console.WriteLine($"Saldo disponible: {saldoDisponible}");
                Console.WriteLine("==========================================");

                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Elija la opcion acorde a lo que desea realizar:");
                Console.WriteLine("===============================================");
                Console.WriteLine("No. 1 - Consultar su saldo");
                Console.WriteLine("    2 - Realizar un deposito");
                Console.WriteLine("    3 - Realizar un retiro de efectivo");
                Console.WriteLine("    4 - Salir");
                Console.WriteLine("===============================================");

                Console.WriteLine("");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("");

                        Console.WriteLine($"Cuenta: {numCuenta}");
                        Console.WriteLine($"Tipo de cuenta: {tipoCuenta}");
                        Console.WriteLine($"Saldo disponible: {saldoDisponible}");
                        Console.WriteLine("Gracias por preferirnos");

                        Console.WriteLine("");

                        break;

                    case 2:
                        Console.WriteLine("Ingrese el monto que desea depositar");
                        while (!decimal.TryParse(Console.ReadLine(), out montoOperación))
                        {
                            Console.WriteLine("Ingresar un valor valido");
                        }
                        if (montoOperación == 0)
                        {
                            Console.WriteLine("CANTIDAD INVALIDA, SALDO SIN CAMBIOS");
                        }
                        else
                        {
                            Console.WriteLine($"Su monto depositado es de {montoOperación}");
                            saldoDisponible = (saldoDisponible + montoOperación);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Ingrese el monto que desea retirar");

                        while (!decimal.TryParse(Console.ReadLine(), out montoOperación))
                        {
                            Console.WriteLine("Ingresar un valor valido");
                        }
                        if (montoOperación >= saldoDisponible)
                        {
                            Console.WriteLine("Saldo insuficiente");
                        }
                        else
                        {
                            Console.WriteLine($"Su monto retirado es de {montoOperación}");
                            saldoDisponible = (saldoDisponible - montoOperación);
                        }
                        break;

                    case 4:
                        Console.WriteLine("Gracias por utilizar nuestros servicios");
                        break;

                    default:
                        Console.WriteLine("Favor de ingresar una  opcion valida");
                        break;
                }

            } while (opcion != 4);



        }
    }
}
