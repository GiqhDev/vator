namespace vator
{
	internal class Vaca
	{
		public static int vaca = 0;
		public static string CantVacas(int vaca,int toro, int intentos)
		{
			if (vaca == 1)
			{
				return($"Hay {vaca} vaca \nintento numero {intentos}");
			}
			else if (vaca == 2)
			{
				return ($"Hay {vaca} vaca \nintento numero {intentos}");
			}
			else if (vaca == 3)
			{
				return ($"Hay {vaca} vaca \nintento numero {intentos}");
			}
			else if (vaca == 4)
			{
				return($"Hay {vaca} vaca \nintento numero {intentos}");
			}
			else if (toro == 0 && vaca == 0)
			{
				return($"No hay nada \nintento numero {intentos}");
			}
			return "";
		}

		public static int ValidarVaca(List<int> list, List<int> numComp)
		{
			// vacas
			vaca = 0;
			foreach (int i in list)
			{
				foreach(int j in numComp)
				{
					if(i == j)
					{
						vaca += 1;
					}
				}
			}				
			return vaca;
		}
	}
}
