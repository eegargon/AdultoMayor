using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProyectoAdultoMayor
{
    public static class Utilities
    {

        public static class Comandos
        {
            public static string Listar { get { return "listar"; } }
            public static string Editar { get { return "editar"; } }
            public static string Eliminar { get { return "eliminar"; } }
            public static string Agregar { get { return "agregar"; } }
        }

        private static string _connString;

        private static string ConnString
        {
            get {
                if (string.IsNullOrEmpty(_connString))
                {
                    _connString = ConfigurationManager.ConnectionStrings["odbcAdultoMayor2"].ConnectionString;
                }
                return _connString;
            }
        }

        public static string ObtenerCadenaConexion()
        {
            return ConnString;
        }

        public static string ObtenerComandoActual(string cmd)
        {
            if (cmd == "edit")
            {
                return Comandos.Editar;
            }
            if (cmd == "add")
            {
                return Comandos.Agregar;
            }
            return Comandos.Listar;
        }
    }
}