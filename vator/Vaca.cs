using System.Collections.Generic;

namespace vator
{
	internal class Vaca
	{
		public static int vaca = 0;
		public static string CantVacas(int vaca,int toro)
		{
			if (vaca == 1)
			{
				return ($"                                                                         Vacas: {vaca}");
			}
			else if (vaca == 2)
			{
				return ($"                                                                         Vacas: {vaca}");
			}
			else if (vaca == 3)
			{
				return ($"                                                                         Vacas:  {vaca}");
			}
			else if (vaca == 4)
			{
				return($"                                                                          Vacas:  {vaca}");
			}
			else if (toro == 0 && vaca == 0)
			{
				return($"No hay nada");
			}
			return "";
		}

		public static int ValidarVaca(List<int> list, List<int> numComp)
		{
			// vacas
			vaca = 0;

			//for (int i = 0; i < list.Count; i++)
			//{
			//	if (list[i] != numComp[i])
			//	{
			//		vaca += 1;
			//	}
			//}
			////foreach (int i in list)
			////{
			////	foreach(int j in numComp)
			////	{
			////		if(i == j)
			////		{
			////			vaca += 1;
			////		}
			////	}
			////}

			//// vacas
			if (list[0] == numComp[1])
			{
				vaca += 1;
			}
			if (list[0] == numComp[2])
			{
				vaca += 1;
			}
			if (list[0] == numComp[3])
			{
				vaca += 1;
			}
			if (list[1] == numComp[0])
			{
				vaca += 1;

			}
			if (list[1] == numComp[2])
			{
				vaca += 1;

			}
			if (list[1] == numComp[3])
			{
				vaca += 1;

			}
			if (list[2] == numComp[0])
			{
				vaca += 1;
			}
			if (list[2] == numComp[1])
			{
				vaca += 1;
			}
			if (list[2] == numComp[3])
			{
				vaca += 1;
			}
			if (list[3] == numComp[0])
			{
				vaca += 1;
			}
			if (list[3] == numComp[1])
			{
				vaca += 1;
			}
			if (list[3] == numComp[2])
			{
				vaca += 1;
			}
			return vaca;
		}
	}
}
