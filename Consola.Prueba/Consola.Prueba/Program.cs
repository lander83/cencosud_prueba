using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Consola.Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Inputs inputs; // Instanciamiento del modelo donde cargara el Json
            string _path = ConfigurationManager.AppSettings["pjson"].ToString(); //camino donde se guarda el json desde el webconfig

             using (StreamReader jsonStream = File.OpenText(_path))  // abrir el archivo json en el camino indicado
            {
                var json = jsonStream.ReadToEnd();  // realizar un stream de la lectura
                inputs  = JsonConvert.DeserializeObject<Inputs>(json); // deserealizar el stream con el modelo 

                foreach(String i in inputs.inputs.ToList()) //navegar por toda la lista para realizar la comparacion
                {
                    var c = i.ToCharArray(); // se convierte el archivo string a CHar

                    //se considera Char ya que este objeto de forma nativa contiene metodos de reconocimiento de caracteres
                    //Para este caso usamos el metodo IsLetter dentro de una validacion ya que nos retornara un valor bool
                    if (Char.IsLetter(c[0]))
                    {
                        Console.WriteLine(i + "  -  " + "Si es una palabra");
                    }
                    else
                    {
                        Console.WriteLine(i + "  -  "+ "No es una palabra");
                    }

                }
                Console.ReadKey();
            }
        }
    }
}
