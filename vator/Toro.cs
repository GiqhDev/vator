using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vator
{
	internal class Toro
	{
		public static string cantToros(string toro, string intentos)
		{
			if (toro == "1")
			{
				return($"Hay {toro} toro \n intento numero {intentos}");
			}
			else if (toro == "2")
			{
				return($"Hay {toro} toros \n intento numero {intentos}");
			}
			else if (toro == "3")
			{
				return ($"Hay {toro} toros \n intento numero {intentos}");
			}
			else if (toro == "4")
			{
				return ($"Hay {toro} toros, Felicidades ganaste \n intento numero {intentos}");
			}
			return "";
		}
	}
}
