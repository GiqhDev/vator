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
		public static List<int> numUser(string numUsuario)
		{	
			for (int i = 0; i < numUsuario.Length; i++)
			{				
				list.Add(Convert.ToInt32(numUsuario[i].ToString()));
			}

			return list;
		}
	}
}
