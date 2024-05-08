using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace vator
{
	internal class Jugar
	{
		public static int toro = 0;
		public static int vaca = 0;
		public static int intentos = 0;
		public static List<int> list = new();
		public static void Start()
		{

			DataUser du;
			var numComp = Maquina.NumCompu();			
			Console.ResetColor();
			Console.WriteLine("Comencemos");
			Console.WriteLine("Nombre:");
			string userName = Console.ReadLine();
			while (toro < 4)
			{
				if (toro == 4) break;

				if (intentos != 0)
				{
					string usernumber = $"{list[0]} {list[1]} {list[2]} {list[3]}";
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"Intento: {intentos} --- #: {usernumber} --- Vacas: {vaca} --- Toros: {toro} \n");
					Console.ResetColor();
				}
				toro = 0;
				vaca = 0;
				list.Clear();
				string numUsuario;
				bool Ok;

				do
				{
					Console.WriteLine("Digite un numero de 4 digitos");
					numUsuario = Console.ReadLine();
					string msg;
					Ok = Usuario.ValidarUsuario(numUsuario, out msg);
					Console.WriteLine(msg);

				}
				while (!Ok);

				list = Usuario.NumUser(numUsuario);
				// vacas
				vaca = Vaca.ValidarVaca(list, numComp);
				//Toros
				toro = Toro.ValidarToros(list, numComp);
				if (toro == 4)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine($"felicidades ganaste el numero es {list[0]} {list[1]} {list[2]} {list[3]}");
					du = new DataUser(userName, intentos);
					bool save = Usuario.GuardarDatos(du);
					if (save)
					{
						Console.WriteLine("Datos guardados");
						TablaPosicion();
					}
					else
					{
						Console.WriteLine("Error al guardar los datos");
					}
					Presentacion();
				}
				Console.ResetColor();
				intentos++;

				//var cantVacas = Vaca.CantVacas(vaca, toro);
				//Console.WriteLine(cantVacas);

				//var cantToros = Toro.CantToros(toro, intentos);
				//Console.WriteLine(cantToros);
			}
		}

		public static void TablaPosicion()
		{

			string Encabezado;
			string? Sangria;
			List<string> Datos;
			string error;
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine("Tabla de posiciones");
			bool datos = Usuario.MostrarDatos(out Encabezado, out Sangria, out Datos, out error);
			if (datos)
			{

				Console.WriteLine(Encabezado);
				Console.WriteLine(Sangria);
				foreach (var dato in Datos)
				{
					Console.WriteLine(dato);
				}

				Console.WriteLine(Sangria);
			}
			else
			{
				Console.WriteLine(error);
			}
		}

		public static void Presentacion()
		{
			Console.WriteLine("BIEMVENIDOS A CROW-BULL");
			Console.WriteLine();
			Console.CursorSize = 18;
			Console.WriteLine("Menu de opciones");
			Console.WriteLine();
			Console.WriteLine("[0] - Jugar | [1] - Tabla de Posiciones  | [2] - Reglas  | [5] - Salir");
			string select = Console.ReadLine();
			switch (select)
			{
				case "0":
					Console.Clear();
					Jugar.Start();
					break;
				case "1":
					Console.Clear();
					Jugar.TablaPosicion();
					break;
				case "2":
					Console.Clear();
					Jugar.Reglas();
					break;
				case "5":
					Environment.Exit(0);
					break;
			}
		}

		public static void Reglas()
		{
			Console.WriteLine("El juego conciste en adivinar el numero del Computador, \n las reglas del mismo son:\n" + "1. Se digita un numero de cuatro cifras.\n" + "2. No se puede repetir ninguno.\n" + "3. No puede contener ceros.\n" + "\n" + "Como se juega: Si adivinas un digito en la misma pocicion que el numero del Computador,\n es Un TORO, si adivinas un numero pero no en la posicion que el numero del es una VACA.\n" + "");
		}
	}
}
