namespace vator
{
	internal class Toro
	{
		public static int toro = 0;
		public static string CantToros(int toro, int intentos)
		{
			if (toro == 1)
			{
				return($"Hay {toro} toro \n intento numero {intentos}");
			}
			else if (toro == 2)
			{
				return($"Hay {toro} toros \n intento numero {intentos}");
			}
			else if (toro == 3)
			{
				return ($"Hay {toro} toros \n intento numero {intentos}");
			}
			else if (toro == 4)
			{
				return ($"Hay {toro} toros, Felicidades ganaste \nintento numero {intentos}");
			}
			return "";
		}

		public static int ValidarToros(List<int> list, List<int> numComp) 
		{
			toro = 0;
			if (list[0] == numComp[0] && list[1] == numComp[1] && list[2] == numComp[2] && list[3] == numComp[3])
			{
				return toro += 4;				
			}
			if (list[0] == numComp[0])
			{
				 toro += 1;
			}
			if (list[1] == numComp[1])
			{
				 toro += 1;
			}
			if (list[2] == numComp[2])
			{
				toro += 1;
			}
			if (list[3] == numComp[3])
			{
				toro += 1;
			}
			return toro;
		}
	}
}
