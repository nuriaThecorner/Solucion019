using Datos.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Class1
    {
        //declarar
        private static UnaTablaDbContext _dbContext = null;

        //constructor
        public Class1()
        {
            if (_dbContext == null)
            {
                _dbContext = new UnaTablaDbContext();
            }
        }

        //metodo
        public bool Create(persona persona)
        {

            _dbContext.persona.Add(persona);
            return true;
        }



        //metodo
        public bool GuardarCambios()
        {
            bool ok = false;

            try
            {
                int respuesta = 0;
                respuesta = _dbContext.SaveChanges();
                if (respuesta > 0)
                {
                    ok = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return ok;
        }



        public IList<persona> Read(string texto)
        {

            IList<persona> personas = null;
            personas = _dbContext.persona.ToList();

            if (texto != null && texto != "")
            {
               


                int id = 0;
                if (int.TryParse(texto, out id) == true)
                {
                    id = int.Parse(texto);

                    if (id > 0)
                    {
                        personas = personas.Where(x => x.id == id).ToList();
                    }
                }

                else
                {
                    personas = personas.Where(x => x.nombre == texto).ToList();

                }
            }





            return personas;

        }


        public bool Delete(IList<persona> personas)
        {
            bool ok = false;
            foreach (persona persona in personas)
            {
                _dbContext.persona.Remove(persona);
                ok = true;
            }

            return ok;
        }




















        }
}
