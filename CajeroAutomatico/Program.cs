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
            string nomCliente;
            string numCuenta;
            string tipoCuenta = "Ahorro";
            string estadoCuenta;
            decimal saldoDisponible;
            decimal montoOperación;
            int opcion;

            Console.WriteLine("Ingrese su nombre");
            nomCliente = Console.ReadLine();

            Console.WriteLine("Ingrese su numero de cuenta");
            numCuenta = Console.ReadLine();

            Console.WriteLine("Ingrese el estado de la cuenta");
            estadoCuenta = Console.ReadLine();

            Console.WriteLine("Ingrese el saldo disponible en la cuenta");
            while (!decimal.TryParse(Console.ReadLine(), out saldoDisponible))
            {
                Console.WriteLine("Ingresa un valor valido");
            }

            do
            {

                Console.WriteLine("==========================================");
                Console.WriteLine($"Bienvenido {nomCliente}");
                Console.WriteLine($"Cuenta: {numCuenta}");
                Console.WriteLine($"Tipo de cuenta: {tipoCuenta}");
                Console.WriteLine($"Estado de cuenta: {estadoCuenta}");
                Console.WriteLine($"Saldo disponible: {saldoDisponible}");
                Console.WriteLine("==========================================");

                Console.WriteLine("");
                Console.WriteLine("");

                MostrarMenu();

                Console.WriteLine("");

                while (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese un valor valido");
                }
                ;


                switch (opcion)
                {
                    case 1:
                        ConsultarSaldo(numCuenta, tipoCuenta, saldoDisponible);
                        break;

                    case 2:
                        if (estadoCuenta == "inactiva" || estadoCuenta == "Inactiva")
                        {
                            Console.WriteLine("Su cuenta está inactiva, no puede depositar");
                            break;
                        }

                        montoOperación = Deposito(ref saldoDisponible);
                        break;

                    case 3:
                        if (estadoCuenta == "inactiva" || estadoCuenta == "Inactiva")
                        {
                            Console.WriteLine("Su cuenta está inactiva, no puede retirar");
                            break;
                        }

                        montoOperación = Retiro(ref saldoDisponible);
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

        private static void MostrarMenu()
        {
            Console.WriteLine("Elija la opcion acorde a lo que desea realizar:");
            Console.WriteLine("===============================================");
            Console.WriteLine("No. 1 - Consultar su saldo");
            Console.WriteLine("    2 - Realizar un deposito");
            Console.WriteLine("    3 - Realizar un retiro de efectivo");
            Console.WriteLine("    4 - Salir");
            Console.WriteLine("===============================================");
        }

        private static void ConsultarSaldo(string numCuenta, string tipoCuenta, decimal saldoDisponible)
        {
            Console.WriteLine("");

            Console.WriteLine($"Cuenta: {numCuenta}");
            Console.WriteLine($"Tipo de cuenta: {tipoCuenta}");
            Console.WriteLine($"Saldo disponible: {saldoDisponible}");
            Console.WriteLine("Gracias por preferirnos");

            Console.WriteLine("");
        }

        private static decimal Deposito(ref decimal saldoDisponible)
        {
            decimal montoOperación;
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

            return montoOperación;
        }


        private static decimal Retiro(ref decimal saldoDisponible)
        {
            decimal montoOperación;
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

            return montoOperación;
        }

    }
}
