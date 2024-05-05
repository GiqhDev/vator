using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vator
{
	internal class Vaca
	{
		public static string cantVacas(string vaca,string toro, string intentos)
		{
			if (vaca == "1")
			{
				return($"Hay {vaca} vaca \n intento numero {intentos}");
			}
			else if (vaca == "2")
			{
				return ($"Hay {vaca} vaca \n intento numero {intentos}");
			}
			else if (vaca == "3")
			{
				return ($"Hay {vaca} vaca \n intento numero {intentos}");
			}
			else if (vaca == "4")
			{
				return($"Hay {vaca} vaca \n intento numero {intentos}");
			}
			else if (toro == "0" && vaca == "0")
			{
				return($"No hay nada \n intento numero {intentos}");
			}
			return "";
		}
	}
}
