using System.Globalization;

public class Central_911
{
    private static Central_911 _instance;
    private static readonly object _lock = new object();

    public string Central { get; private set; }

    private Central_911()
    {
        Central = "Central 911";

    }
    public static Central_911 Obtener_Instancia()
    {
        if (_instance ==null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Central_911();
                }
            }
        }
        return _instance;
    }

    public void ConectarLlamada(Operador operador, string tipoEmergencia)
    {
        Console.WriteLine("\nLlamada conectada con el operador " + operador.Nombre);
        operador.AtiendeEmergencia(tipoEmergencia);
    }

    public class Operador
    {
        public int Id_Operador { get; set; }

        public string Nombre { get; set; }

        public Operador(int id, string nombre)
        {
            Id_Operador = id;
            Nombre = nombre;
        }

        public void AtiendeEmergencia(string tipoEmergencia)
        {
            Console.WriteLine($"Operador {Nombre} atendiendo emergencia de tipo: {tipoEmergencia}");

            switch (tipoEmergencia)
            {
                case "Intento de suicidio":
                    Console.WriteLine("Enviando unidades de apoyo y rescate");
                    break;

                case "Incendio":
                    Console.WriteLine("Enviando Bomberos");
                    break;

                case "Accidente":
                    Console.WriteLine("Enviando paramedicos y oficiales");
                    break;

                case "Violeta":
                    Console.WriteLine("Enviando una patrulla");
                    break;

                    //Emergencias nuevas
                case "Robo":
                    Console.WriteLine("Enviando patrullas");
                    break;

                case "Ataque Cardiaco":
                    Console.WriteLine("Enviando ambulancia");
                    break;

                case "Persona atrapada":
                    Console.WriteLine("Enviando equipo de rescate");
                    break;

                case "Derrumbe":
                    Console.WriteLine("Enviando Equipo de busqueda y rescate");
                    break;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Central_911 Llamada1 = Central_911.Obtener_Instancia();
            Central_911 Llamada2 = Central_911.Obtener_Instancia();
            //nueva llamada
            Central_911 Llamada3 = Central_911.Obtener_Instancia();
            Central_911 Llamada4 = Central_911.Obtener_Instancia();

            Operador op1 = new Operador(1, "Laura");
            Operador op2 = new Operador(2, "Carlos");
            //Nuevo operador
            Operador op3 = new Operador(3, "Tiana");
            Operador op4 = new Operador(4, "Nyra");

            Llamada1.ConectarLlamada(op1, "Incendio");
            Llamada2.ConectarLlamada(op2, "Violeta");
            Llamada1.ConectarLlamada(op1, "Accidente");
            Llamada2.ConectarLlamada(op2, "Intento de suicidio");
            //Ingreso de nuevas llamadas
            Llamada3.ConectarLlamada(op3, "Robo");
            Llamada4.ConectarLlamada(op4, "Ataque Cardiaco");
            Llamada3.ConectarLlamada(op3, "Persona atrapada");
            Llamada4.ConectarLlamada(op4, "Derrumbe");

            // Verificación del patrón Singleton
            Console.WriteLine("\nVerificando si todas las llamadas usan la misma instancia:");

            if (ReferenceEquals(Llamada1, Llamada2) &&
                ReferenceEquals(Llamada1, Llamada3) &&
                ReferenceEquals(Llamada1, Llamada4))
            {
                Console.WriteLine("Todas las llamadas pertenecen a la misma instancia de Central_911.");
            }
            else
            {
                Console.WriteLine("Existen múltiples instancias de Central_911.");
            }

            Console.ReadKey();
        }
    }
}
