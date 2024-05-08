using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vator
{
	internal class Maquina
	{
		public static List<int>NumCompu()
		{
			Random rd = new();

			int num1 = rd.Next(1, 9);
			int num2 = rd.Next(1, 9);
			int num3 = rd.Next(1, 9);
			int num4 = rd.Next(1, 9);

			while (num1 == num2 || num1 == num3 || num1 == num4)
			{
				num1 = rd.Next(1, 9);
			}
			while (num2 == num1 || num2 == num3 || num2 == num4)
			{
				num2 = rd.Next(1, 9);
			}
			while (num3 == num1 || num3 == num2 || num3 == num4)
			{
				num3 = rd.Next(1, 9);
			}
			while (num4 == num1 || num4 == num2 || num4 == num3)
			{
				num4 = rd.Next(1, 9);
			}
			List<int> arrNumCompu = new() { num1, num2, num3, num4 };

			return arrNumCompu;
		}
	}
}
