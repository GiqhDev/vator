using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vator
{
	internal class DataUser
	{
		// Propiedad Nombre
		public string Nombre { get; set; }

		// Propiedad Intentos
		public int Intentos { get; set; }

		// Constructor para inicializar las propiedades
		public DataUser(string nombre, int intentos)
		{
			Nombre = nombre;
			Intentos = intentos;
		}
	}
}
