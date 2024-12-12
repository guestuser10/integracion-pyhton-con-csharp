using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // Ruta del intérprete de Python
        string pythonPath = @"C:\Users\pc\anaconda3\python.exe";

        // Ruta del script de Python
        string scriptPath = @"C:\flutter_proj\aspy\main.py"; 

        //ejecutar el script de Python
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = pythonPath,
            Arguments = $"\"{scriptPath}\"", // Pasar la ruta del script como argumento
            RedirectStandardOutput = true, // Redirigir la salida estándar
            RedirectStandardError = true, // Redirigir los errores
            UseShellExecute = false, // No usar la shell del sistema
            CreateNoWindow = true    // No mostrar la ventana del terminal
        };

        try
        {
            // Ejecutar el proceso
            using (Process process = Process.Start(psi))
            {
                // Leer la salida del script de Python
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                process.WaitForExit(); // Esperar a que el proceso termine

                // Mostrar resultados
                Console.WriteLine("=== Output ===");
                Console.WriteLine(output);

                if (!string.IsNullOrEmpty(errors))
                {
                    Console.WriteLine("=== Errors ===");
                    Console.WriteLine(errors);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al ejecutar el script de Python: {ex.Message}");
        }

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
