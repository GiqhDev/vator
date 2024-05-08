namespace vator
{
	internal class Usuario
	{
		public static List<int> list = new();
		public static List<int> NumUser(string numUsuario)
		{
			for (int i = 0; i < numUsuario.Length; i++)
			{
				list.Add(Convert.ToInt32(numUsuario[i].ToString()));
			}

			return list;
		}
		public static bool ValidarUsuario(string numUsuario, out string msg)
		{
			msg = null;
			bool IguaaCuatro = numUsuario.Count() >= 5 || numUsuario.Count() <= 3;
			bool contieneCero = numUsuario.Contains('0');
			bool todosUnicos = numUsuario.Distinct().Count() == numUsuario.Length;
			if (IguaaCuatro || contieneCero || !todosUnicos)
			{
				msg = "Digite un numero de 4 digitos, que no contenga ceros (0) y sin repetir los digitos.";
				return false;
			}
			return true;
		}
		public static bool GuardarDatos(DataUser dataUser)
		{
			// Directorio donde se ejecuta el programa
			string directorioBase = AppDomain.CurrentDomain.BaseDirectory;

			// Nombre del directorio donde se guardará el archivo
			string nombreDirectorio = "Data";

			// Nombre del archivo
			string nombreArchivo = "dataUser.txt";

			// Ruta completa del directorio
			string rutaDirectorio = Path.Combine(directorioBase, nombreDirectorio);

			// Ruta completa del archivo
			string rutaArchivo = Path.Combine(rutaDirectorio, nombreArchivo);

			// Datos que deseas escribir en el archivo
			string datos = $"{dataUser.Nombre},{dataUser.Intentos}";

			try
			{
				// Crear el directorio si no existe
				if (!Directory.Exists(rutaDirectorio))
				{
					Directory.CreateDirectory(rutaDirectorio);
				}

				// Crear un objeto StreamWriter y pasarle la ruta del archivo
				using (StreamWriter escritor = new StreamWriter(rutaArchivo,true))
				{
					// Escribir los datos en el archivo
					escritor.WriteLine(datos);
				}

				return true;
			}
			catch (Exception ex)
			{
				// Manejar cualquier error que pueda ocurrir				
				return false;
			}
		}

		// Método para leer los datos del archivo y mostrarlos en una tabla
		public static bool MostrarDatos(out string str1, out string str2, out List<string> str3, out string str4)
		{
			str1 = null;
			str2 = null;
			str3 = new List<string>();
			str4 = null;
			// Directorio donde se ejecuta el programa
			string directorioBase = AppDomain.CurrentDomain.BaseDirectory;

			// Ruta del archivo
			string rutaArchivo = Path.Combine(directorioBase, "Data", "dataUser.txt");

			try
			{
				// Verificar si el archivo existe
				if (File.Exists(rutaArchivo))
				{
					str1 = "Nombre\t\tIntentos";
					str2 = "------\t\t--------";
					// Leer todas las líneas del archivo
					string[] lineas = File.ReadAllLines(rutaArchivo);

					// Leer y mostrar cada línea del archivo						
					foreach (string linea in lineas)
					{
						// Dividir la línea en nombre e intentos
						string[] partes = linea.Split(',');

						// Mostrar los datos en una tabla
						str3.Add($"{partes[0]}\t\t{partes[1]}");
					}
					str3.Sort((a, b) => Convert.ToInt32(a.Split("\t\t")[1]).CompareTo(Convert.ToInt32(b.Split("\t\t")[1])));
					return true;
				}
				else
				{
					Console.WriteLine("El archivo no existe.");
					return false;
				}
			}
			catch (Exception ex)
			{
				// Manejar cualquier error que pueda ocurrir
				str4 = $"Ocurrió un error: {ex.Message}";
				return false;
			}
		}
	}
}
