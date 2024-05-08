namespace vator
{
	public class Program
	{
		public static int toro = 0;
		public static int vaca = 0;
		public static int intentos = 0;
		public static List<int> list = new();

		//private string Encabezado;
		//private string? Sangria;
		//private string Datos;
		//private string error;


		static void Main(string[] args)
		{
			DataUser du;
			var numComp = Maquina.NumCompu();

			var saludo = DateTime.UtcNow;

			if (saludo < DateTime.Parse("12:00:00"))
			{
				Console.WriteLine("Buenos dias");
			}
			else if (saludo > DateTime.Parse("12:00:00"))
			{
				Console.WriteLine("Buenos tarde");
			}
			else if (saludo > DateTime.Parse("17:00:00"))
			{
				Console.WriteLine("Buenos noches");
			}
			string Encabezado;
			string? Sangria;
			List<string> Datos;
			string error;
			Console.WriteLine("Hola Bienvenidos al juego COW-BULL");
			Console.WriteLine("El juego conciste en adivinar el numero que piensa la PC");
			Console.WriteLine("El numero es de cuatro digitos, no se repite ninguno y no contiene Ceros");
			Console.WriteLine("Si adivinas un digito en la misma pocicion que el numero de la PC pues es Un TORO, si adivinas un numero pero no en la posicion que el del numero de la PC pues es una VACA.\n");

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
						datos = Usuario.MostrarDatos(out Encabezado, out Sangria, out Datos, out error);
						if (datos)
						{							
							Console.ForegroundColor = ConsoleColor.Gray;
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
					else
					{
						Console.WriteLine("Error al guardar los datos");
					}
				}
				Console.ResetColor();
				intentos++;

				//var cantVacas = Vaca.CantVacas(vaca, toro);
				//Console.WriteLine(cantVacas);

				//var cantToros = Toro.CantToros(toro, intentos);
				//Console.WriteLine(cantToros);
			}
		}
	}
}