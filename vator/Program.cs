namespace vator
{
	public class Program
  {
    public static int toro = 0;
    public static int vaca = 0;
    public static int intentos = 0;
    public static List<int> list = new();

    static void Main(string[] args)
    {
      var numComp = Maquina.NumCompu();
			
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
            
      while (toro<4)
      {
        if (toro == 4)
        {
            break;
        }                
        toro = 0;
        vaca = 0;
        list.Clear();
				string numUsuario;
				bool todoOk;
				do
				{
					Console.WriteLine("Digite un numero de 4 digitos");
					numUsuario = Console.ReadLine();
					string msg;
					todoOk = Usuario.ValidarUsuario(numUsuario, out msg);
					Console.WriteLine(msg);

				}
				while (!todoOk);

				list = Usuario.NumUser(numUsuario);

				//Toros
				toro = Toro.ValidarToros(list, numComp);
				if (toro == 4)
				{
					Console.WriteLine($"felicidades ganaste el numero es {list[0]} {list[1]} {list[2]} {list[3]}");
					Console.WriteLine($"Intento numero es {intentos}");
				}

				// vacas
				vaca = Vaca.ValidarVaca(list, numComp);

				intentos++;

				var cantVacas = Vaca.CantVacas(vaca, toro, intentos);
				Console.WriteLine(cantVacas);

				var cantToros = Toro.CantToros(toro, intentos);
				Console.WriteLine(cantToros);
			}
    }
  }
}