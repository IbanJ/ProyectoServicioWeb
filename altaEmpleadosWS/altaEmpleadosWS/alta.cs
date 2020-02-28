using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace altaEmpleadosWS
{
    public class alta
    {
        private int _Codigo;
        private string _Nombre;
        private string _LastName;
        private string _Country;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
    }
}