using System;
using System.Collections.Generic;

class Program
{
    // Lista de palabras que pueden aparecer durante el juego.
    static string[] palabras = {
        "MANZANA",
        "COMPUTADORA",
        "PROGRAMACION",
        "ESCUELA",
        "ELEFANTE",
        "GUITARRA",
        "TELEFONO"
    };

    // Muestra las letras descubiertas y oculta las que faltan.
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

    // Comprueba si todas las letras de la palabra fueron descubiertas.
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
        // Selecciona una palabra aleatoria de la lista.
        Random aleatorio = new Random();
        string palabra = palabras[aleatorio.Next(palabras.Length)];

        // Guarda cuáles letras ya fueron descubiertas.
        bool[] descubiertas = new bool[palabra.Length];

        // Guarda las letras que el jugador ya utilizó.
        List<char> utilizadas = new List<char>();

        // El jugador comienza con seis vidas.
        int vidas = 6;

        Console.WriteLine("================================");
        Console.WriteLine("       JUEGO DEL AHORCADO");
        Console.WriteLine("================================");

        // El juego continúa mientras haya vidas y falten letras.
        while (vidas > 0 && !TodasDescubiertas(descubiertas))
        {
            Console.WriteLine("\nPalabra:");
            MostrarPalabra(palabra, descubiertas);

            Console.WriteLine("\nVidas restantes: " + vidas);

            // Muestra las letras que ya se utilizaron.
            Console.Write("Letras utilizadas: ");

            foreach (char letra in utilizadas)
            {
                Console.Write(letra + " ");
            }

            // Solicita una letra al jugador.
            Console.Write("\nIngresa una letra: ");

            string entrada = Console.ReadLine();

            // Evita que el jugador deje la entrada vacía.
            if (string.IsNullOrWhiteSpace(entrada))
            {
                Console.WriteLine("No puedes dejar el espacio vacio.");
                continue;
            }

            entrada = entrada.Trim();

            // Comprueba que solamente se ingrese una letra.
            if (entrada.Length != 1 || !char.IsLetter(entrada[0]))
            {
                Console.WriteLine("Ingresa solamente una letra.");
                continue;
            }

            // Convierte la letra ingresada a mayúscula.
            char letraIngresada = char.ToUpper(entrada[0]);

            // Comprueba que la letra no haya sido utilizada antes.
            if (utilizadas.Contains(letraIngresada))
            {
                Console.WriteLine("Esa letra ya fue utilizada.");
                continue;
            }

            utilizadas.Add(letraIngresada);

            // Indica si la letra ingresada existe en la palabra.
            bool encontrada = false;

            // Recorre la palabra para buscar coincidencias.
            for (int i = 0; i < palabra.Length; i++)
            {
                if (palabra[i] == letraIngresada)
                {
                    descubiertas[i] = true;
                    encontrada = true;
                }
            }

            // Si la letra no existe, se pierde una vida.
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

        // Determina si el jugador ganó o perdió.
        if (TodasDescubiertas(descubiertas))
        {
            Console.WriteLine("¡FELICIDADES! GANASTE.");
        }
        else
        {
            Console.WriteLine("¡PERDISTE! Te quedaste sin vidas.");
        }

        // Revela la palabra secreta al finalizar.
        Console.WriteLine("La palabra era: " + palabra);

        Console.WriteLine("================================");
        Console.WriteLine("       FIN DEL JUEGO");
    }
}