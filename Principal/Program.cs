using Datos;
using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Principal
{
    internal class Program
    {
        //declarar atributo
        public static Class1 _class1 = null;

        static void Main(string[] args)
        {

            //objeto
            Program program = null;
            program = new Program();

            //inicializar atributo
            _class1 = new Class1();

            //CRUD

            //llamar metodo
            program.Create();
            program.Read();
            program.Update();
            program.Read();
            program.Delete();
            program.Read();
            //program.ExperimentoconObejtosIguales();


        }

        //Metodo
        private void Create()
        {

            bool ok = false;

            Console.WriteLine("Dime el nombre de la persona del nuevo registro");
            string texto = Console.ReadLine();
            if (texto != null && texto != "")
            {
                persona persona = null;
                persona = new persona();
                persona.nombre = texto;


                Console.WriteLine("Dime el 1r apellido de la persona del nuevo registro");
                texto = Console.ReadLine();
                if (texto != null && texto != "")
                {
                    persona.apellido01 = texto;

                   
                    ok = _class1.Create(persona);

                    if (ok == true)
                    {
                        ok = _class1.GuardarCambios();
                    }
                }

                

            }

            Console.WriteLine("El resultado de create a sido: " + ok);

            Console.ReadLine();
        }




        private void Read()
        {


            Console.WriteLine("Dime el nombre o el id de la persona a mostrar");
            string texto = Console.ReadLine();

             IList<persona> personas = null;
            personas = _class1.Read(texto);
            

            foreach (persona persona in personas)
            {
                Console.WriteLine(persona.id + " " + persona.nombre + " " + persona.apellido01 + " " + persona.apellido02);
            }
            Console.ReadLine();
        }





        private void Update()
        {


            Console.WriteLine("Dime el nombre o ID de la persona a modificar");
            string texto = Console.ReadLine();

            IList<persona> personas = null;
            if (texto != null && texto != "")
            { 
              personas = _class1.Read(texto);

            Console.WriteLine("Dime el Nombre de la persona a modificar");
            texto = Console.ReadLine();

            bool ok = false;
            if (texto != null && texto != "")
            {
                for (int i = 0; i < personas.Count; i++)
                {
                    personas[i].nombre = texto;
                    ok = true;
               }

                if (ok== true)
                {
                    _class1.GuardarCambios();
                }

                }
            }
              

            
            Console.ReadLine();
        }






        private void Delete()
        {


            Console.WriteLine("Dime el nombre o ID de la persona a eliminar");
            string texto = Console.ReadLine();

            IList<persona> personas = null;
            if (texto != null && texto != "")
            {
                personas = _class1.Read(texto);


                bool ok = false;
                ok= _class1.Delete(personas);

                if (ok == true)
                    {
                        _class1.GuardarCambios();
                    }
                Console.WriteLine("El resultado de Delete a sido: " + ok);
            }
            
                Console.ReadLine();
            

        }



        private void ExperimentoconObejtosIguales()
        {
            //Creamos un objeto de la clase Fruta llamado: frutaOriginal
            //cuyos atributos valdrán: Amarillo, Plátano, Alargado y blando
            Fruta frutaOriginal = null;
            frutaOriginal = new Fruta();
            frutaOriginal.name = "Plátano";
            frutaOriginal.color = "Amarillo";
            frutaOriginal.description = "Alargado y blando";

            Console.WriteLine("Valores de frutaOriginal: ");
            Console.WriteLine(frutaOriginal.name + ", " + frutaOriginal.color + " y " + frutaOriginal.description);
            Console.ReadLine();

            Fruta frutaModificada = null;
            frutaModificada = frutaOriginal;

            frutaModificada.name = "Pera";
            frutaModificada.color = "Verde";
            frutaModificada.description = "Con forma de pera";

            Console.WriteLine("Valores de frutaOriginal: ");
            Console.WriteLine(frutaOriginal.name + ", " + frutaOriginal.color + " y " + frutaOriginal.description);
            Console.ReadLine();

            frutaOriginal.name = "Plátano";
            frutaOriginal.color = "Amarillo";
            frutaOriginal.description = "Alargado y blando";

            Console.WriteLine("Valores de frutaOriginal: ");
            Console.WriteLine(frutaOriginal.name + ", " + frutaOriginal.color + " y " + frutaOriginal.description);
            Console.ReadLine();

            Console.WriteLine("Valores de frutaModificada: ");
            Console.WriteLine(frutaModificada.name + ", " + frutaModificada.color + " y " + frutaModificada.description);
            Console.ReadLine();


        }







    }
}
