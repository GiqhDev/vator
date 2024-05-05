using System.Runtime.CompilerServices;

namespace vator
{
  public class Program
  {
    public static int toro = 0;
    public static int vaca = 0;
    public static int intentos = 0;
    public static List<int> list = new List<int>();

    static void Main(string[] args)
    {
      var numComp = Maquina.numCompu();

      var saludo = DateTime.UtcNow;            

      if (saludo < DateTime.Parse("12:00:00"))
      {
          Console.WriteLine("Buenos dias");
      }
      else if (saludo > DateTime.Parse("12:00:00"))
      {
          Console.WriteLine("Buenos tarde");
      }
      else if (saludo > DateTime.Parse("17:00:00"))
      {
          Console.WriteLine("Buenos noches");
      }      

      Console.WriteLine("Hola Bienvenidos al juego Vator");
      Console.WriteLine("El juego conciste en adivinar el numero que piensa la PC");
      Console.WriteLine("El numero es de cuatro digitos, no se repite ninguno y no contiene Ceros");
      Console.WriteLine("Si adivinas un digito en la misma pocicion que el numero de la PC pues es Un TORO, si adivinas un numero pero no en la posicion que el del numero de la PC pues es una VACA.");
      Console.WriteLine("Comencemos");


      string? numUsuario = "";
      do
      {
        Console.WriteLine("Digite un numero de 4 digitos");
        numUsuario = Console.ReadLine();
      }
      while (numUsuario.Length > 4 || numUsuario.Length < 4);

			for (int i = 0; i < numUsuario.Length; i++)
			{
				if (numUsuario[i].ToString() == "0")
				{
					Console.WriteLine("Digite un numero de 4 digitos sin cero (0)");
					numUsuario = Console.ReadLine();
				}				
			}
			list = Usuario.numUser(numUsuario);

      //Toros
      if (list[0] == numComp[0] && list[1] == numComp[1] && list[2] == numComp[2] && list[3] == numComp[3])
      {
        toro = toro + 4;
        intentos++;
        Console.WriteLine($"felicidades ganaste el numero es {list[0]} {list[1]} {list[2]} {list[3]}");
        Console.WriteLine($"Intento numero es {intentos}");
      }
      if (list[0] == numComp[0])
      {
        toro +=1;                
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

      // vacas
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

      intentos++;
      
      var cantVacas = Vaca.cantVacas(vaca.ToString(),toro.ToString(),intentos.ToString());
      Console.WriteLine(cantVacas);

      var cantToros = Toro.cantToros(toro.ToString(), intentos.ToString());    
      Console.WriteLine(cantToros);
            
      while (toro<4)
      {
        if (toro == 4)
        {
            break;
        }
                
        toro = 0;
        vaca = 0;
        list.Clear();
				do
				{
					Console.WriteLine("Digite un numero de 4 digitos");
					numUsuario = Console.ReadLine();
				}
				while (numUsuario.Length > 4 || numUsuario.Length < 4);

				for (int i = 0; i < numUsuario.Length; i++)
				{
					if (numUsuario[i].ToString() == "0")
					{
						Console.WriteLine("Digite un numero de 4 digitos sin cero (0)");
						numUsuario = Console.ReadLine();
					}
				}
				list = Usuario.numUser(numUsuario);
				//Toros
				if (list[0] == numComp[0] && list[1] == numComp[1] && list[2] == numComp[2] && list[3] == numComp[3])
        {
          toro = toro + 4;
          intentos++;
          Console.WriteLine($"felicidades ganaste, el numero es {list[0]} {list[1]} {list[2]} {list[3]}");
          Console.WriteLine($"Intento numero es {intentos}");
          break;
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

        // vacas
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

        intentos++;

				 cantVacas = Vaca.cantVacas(vaca.ToString(), toro.ToString(), intentos.ToString());
				Console.WriteLine(cantVacas);

				cantToros = Toro.cantToros(toro.ToString(), intentos.ToString());
				Console.WriteLine(cantToros);
			}
    }

    public static void cantToros(int toro, int intentos)
    {
      if (toro == 1)
      {
          Console.WriteLine($"Hay {toro} toro \n intento numero {intentos}");
      }
      else if (toro == 2)
      {
          Console.WriteLine($"Hay {toro} toros \n intento numero {intentos}");
      }
      else if (toro == 3)
      {
          Console.WriteLine($"Hay {toro} toros \n intento numero {intentos}");
      }
      else if (toro == 4)
      {
                
          Console.WriteLine($"Hay {toro} toros, Felicidades ganaste \n intento numero {intentos}");
      }
    }

    public static void cantVacas(int vaca, int intentos)
    {
      if (vaca == 1)
      {
          Console.WriteLine($"Hay {vaca} vaca \n intento numero {intentos}");
      }
      else if (vaca == 2)
      {
          Console.WriteLine($"Hay {vaca} vaca \n intento numero {intentos}");
      }
      else if (vaca == 3)
      {
          Console.WriteLine($"Hay {vaca} vaca \n intento numero {intentos}");
      }
      else if (vaca == 4)
      {
          Console.WriteLine($"Hay {vaca} vaca \n intento numero {intentos}");
      }
      else if (toro == 0 && vaca == 0)
      {
          Console.WriteLine($"No hay nada \n intento numero {intentos}");
      }
    }

    public static List<int> numUser()
    {
      Console.WriteLine(" \n Digite un numero de 4 digitos");
      string? numUsuario = Console.ReadLine();

      while (numUsuario.Length > 4 || numUsuario.Length < 4)
      {
          Console.WriteLine("Digite un numero de 4 digitos");
          numUsuario = Console.ReadLine();
      }

      for (int i = 0; i < numUsuario.Length; i++)
      {
          if (numUsuario[i].ToString() == "0")
          {
              Console.WriteLine("Digite un numero de 4 digitos sin cero (0)");
              numUsuario = Console.ReadLine();
          }
          list.Add(Convert.ToInt32(numUsuario[i].ToString()));
      }

      return list;
    }

    public static int[] numCompu()
    {
      Random rd = new Random();
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


      int[] arrNumCompu = {num1, num2, num3, num4};

      return arrNumCompu;
    }
  }
}