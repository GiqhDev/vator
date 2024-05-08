using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vator
{
	internal class Usuario
	{
		public static List<int> list = new List<int>();
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
	}
}
