using System;
using System.Collections.Generic;

class Program
{
    static string[] palabras = {
        "MANZANA",
        "COMPUTADORA",
        "PROGRAMACION",
        "ESCUELA",
        "ELEFANTE",
        "GUITARRA",
        "TELEFONO"
    };

    static void MostrarPalabra(string palabra, bool[] descubiertas)
    {
        for (int i = 0; i < palabra.Length; i++)
        {
            if (descubiertas[i])
            {
                Console.Write(palabra[i] + " ");
            }
            else
            {
                Console.Write("_ ");
            }
        }

        Console.WriteLine();
    }

    static bool TodasDescubiertas(bool[] descubiertas)
    {
        for (int i = 0; i < descubiertas.Length; i++)
        {
            if (!descubiertas[i])
            {
                return false;
            }
        }

        return true;
    }

    static void Main()
    {
        Random aleatorio = new Random();

        string palabra = palabras[aleatorio.Next(palabras.Length)];

        bool[] descubiertas = new bool[palabra.Length];

        List<char> utilizadas = new List<char>();

        int vidas = 6;

        Console.WriteLine("================================");
        Console.WriteLine("       JUEGO DEL AHORCADO");
        Console.WriteLine("================================");

        while (vidas > 0 && !TodasDescubiertas(descubiertas))
        {
            Console.WriteLine("\nPalabra:");
            MostrarPalabra(palabra, descubiertas);

            Console.WriteLine("\nVidas restantes: " + vidas);

            Console.Write("Letras utilizadas: ");

            foreach (char letra in utilizadas)
            {
                Console.Write(letra + " ");
            }

            Console.Write("\nIngresa una letra: ");

            string entrada = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("No puedes dejar el espacio vacio.");
                continue;
            }

            entrada = entrada.Trim();

            if (entrada.Length != 1 || !char.IsLetter(entrada[0]))
            {
                Console.WriteLine("Ingresa solamente una letra.");
                continue;
            }

            char letraIngresada = char.ToUpper(entrada[0]);

            if (utilizadas.Contains(letraIngresada))
            {
                Console.WriteLine("Esa letra ya fue utilizada.");
                continue;
            }

            utilizadas.Add(letraIngresada);

            bool encontrada = false;

            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] == letraIngresada)
                {
                    descubiertas[i] = true;
                    encontrada = true;
                }
            }

            if (encontrada)
            {
                Console.WriteLine("¡Correcto! La letra existe.");
            }
            else
            {
                vidas--;
                Console.WriteLine("Letra incorrecta. Pierdes una vida.");
            }
        }

        Console.WriteLine("\n================================");

        if (TodasDescubiertas(descubiertas))
        {
            Console.WriteLine("¡FELICIDADES! GANASTE.");
        }
        else
        {
            Console.WriteLine("¡PERDISTE! Te quedaste sin vidas.");
        }

        Console.WriteLine("La palabra era: " + palabra);

        Console.WriteLine("================================");
        Console.WriteLine("       FIN DEL JUEGO");
    }
}