using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElObrador
{
    public class Persona
    {
        //Propiedades
        public string Nombre { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidMat { get; set; }
        public string TipoDocument { get; set; }
        public string Correo { get; set; }
        public bool Vigencia { get; set; }
        //Asgingar el constructor por
        //defecto para que no genere error
        //de argumentos
        public Persona()
        {
        }
        //Constructor que recibe parametro del mismo clase
        public Persona(Persona Add)
        {
            Nombre = Add.Nombre;
            ApellidoPat = Add.ApellidoPat;
            ApellidMat = Add.ApellidMat;
            TipoDocument = Add.TipoDocument;
            Correo = Add.Correo;
            Vigencia = Add.Vigencia;
        }

    }
}

