using System;
using System.Collections.Generic;

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
            int opcion;

            // Lista para almacenar los movimientos bancarios
            List<string> historialMovimientos = new List<string>();

            Console.WriteLine("Ingrese su nombre");
            nomCliente = Console.ReadLine();

            Console.WriteLine("Ingrese su numero de cuenta");
            numCuenta = Console.ReadLine();

            Console.WriteLine("Ingrese el estado de la cuenta");
            estadoCuenta = Console.ReadLine().Trim();

            // Validar el saldo inicial
            saldoDisponible = LeerSaldoInicial();

            do
            {
                Console.WriteLine("==========================================");
                Console.WriteLine($"Bienvenido {nomCliente}");
                Console.WriteLine($"Cuenta: {numCuenta}");
                Console.WriteLine($"Tipo de cuenta: {tipoCuenta}");
                Console.WriteLine($"Estado de cuenta: {estadoCuenta}");
                Console.WriteLine($"Saldo disponible: RD$ {saldoDisponible:N2}");
                Console.WriteLine("==========================================");

                MostrarMenu();

                while (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Ingrese un valor valido");
                }

                switch (opcion)
                {
                    case 1:
                        ConsultarSaldo(numCuenta, tipoCuenta, saldoDisponible);
                        break;

                    case 2:
                        if (CuentaInactiva(estadoCuenta))
                        {
                            Console.WriteLine("Su cuenta está inactiva, no puede depositar");
                            break;
                        }

                        Deposito(ref saldoDisponible, historialMovimientos);
                        break;

                    case 3:
                        if (CuentaInactiva(estadoCuenta))
                        {
                            Console.WriteLine("Su cuenta está inactiva, no puede retirar");
                            break;
                        }

                        Retiro(ref saldoDisponible, historialMovimientos);
                        break;

                    case 4:
                        ConsultarHistorial(historialMovimientos);
                        break;

                    case 5:
                        Console.WriteLine("Gracias por utilizar nuestros servicios");
                        break;

                    default:
                        Console.WriteLine("Favor de ingresar una opcion valida");
                        break;
                }

                Console.WriteLine("");

            } while (opcion != 5);
        }

        // Método para mostrar el menú
        private static void MostrarMenu()
        {
            Console.WriteLine("Elija la opcion acorde a lo que desea realizar:");
            Console.WriteLine("===============================================");
            Console.WriteLine("No. 1 - Consultar su saldo");
            Console.WriteLine("    2 - Realizar un deposito");
            Console.WriteLine("    3 - Realizar un retiro de efectivo");
            Console.WriteLine("    4 - Consultar historial de movimientos");
            Console.WriteLine("    5 - Salir");
            Console.WriteLine("===============================================");
        }

        // Método para validar el saldo inicial
        private static decimal LeerSaldoInicial()
        {
            decimal saldo;

            Console.WriteLine("Ingrese el saldo disponible en la cuenta");

            while (!decimal.TryParse(Console.ReadLine(), out saldo) || saldo < 0)
            {
                Console.WriteLine("Ingrese un saldo valido (no puede ser negativo)");
            }

            return saldo;
        }

        // Método para comprobar si la cuenta está inactiva
        private static bool CuentaInactiva(string estadoCuenta)
        {
            return estadoCuenta.Equals("inactiva", StringComparison.OrdinalIgnoreCase);
        }

        // Método para consultar el saldo
        private static void ConsultarSaldo(string numCuenta, string tipoCuenta, decimal saldoDisponible)
        {
            Console.WriteLine("");
            Console.WriteLine($"Cuenta: {numCuenta}");
            Console.WriteLine($"Tipo de cuenta: {tipoCuenta}");
            Console.WriteLine($"Saldo disponible: RD$ {saldoDisponible:N2}");
            Console.WriteLine("Gracias por preferirnos");
            Console.WriteLine("");
        }

        // Método para realizar depósitos
        private static void Deposito(ref decimal saldoDisponible, List<string> historialMovimientos)
        {
            decimal montoOperacion;

            Console.WriteLine("Ingrese el monto que desea depositar");

            while (!decimal.TryParse(Console.ReadLine(), out montoOperacion) || montoOperacion <= 0)
            {
                Console.WriteLine("Ingrese un monto valido mayor que cero");
            }

            saldoDisponible = saldoDisponible + montoOperacion;

            Console.WriteLine($"Su monto depositado es de RD$ {montoOperacion:N2}");

            // Registrar el depósito exitoso
            historialMovimientos.Add(
                $"Depósito: RD$ {montoOperacion:N2} | Saldo: RD$ {saldoDisponible:N2} | Fecha: {DateTime.Now}"
            );
        }

        // Método para realizar retiros
        private static void Retiro(ref decimal saldoDisponible, List<string> historialMovimientos)
        {
            decimal montoOperacion;

            Console.WriteLine("Ingrese el monto que desea retirar");

            while (!decimal.TryParse(Console.ReadLine(), out montoOperacion) || montoOperacion <= 0)
            {
                Console.WriteLine("Ingrese un monto valido mayor que cero");
            }

            if (montoOperacion >= saldoDisponible)
            {
                Console.WriteLine("Saldo insuficiente");
            }
            else
            {
                saldoDisponible = saldoDisponible - montoOperacion;

                Console.WriteLine($"Su monto retirado es de RD$ {montoOperacion:N2}");

                // Registrar el retiro exitoso
                historialMovimientos.Add(
                    $"Retiro: RD$ {montoOperacion:N2} | Saldo: RD$ {saldoDisponible:N2} | Fecha: {DateTime.Now}"
                );
            }
        }

        // Método para consultar el historial de movimientos
        private static void ConsultarHistorial(List<string> historialMovimientos)
        {
            Console.WriteLine("");
            Console.WriteLine("===== HISTORIAL DE MOVIMIENTOS =====");

            if (historialMovimientos.Count == 0)
            {
                Console.WriteLine("No existen movimientos registrados.");
            }
            else
            {
                for (int i = 0; i < historialMovimientos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {historialMovimientos[i]}");
                }
            }

            Console.WriteLine("====================================");
            Console.WriteLine("");
        }
    }
}
