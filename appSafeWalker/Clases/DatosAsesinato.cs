using System;
using System.Collections.Generic;
using System.Text;

namespace appSafeWalker.Clases
{
    class DatosAsesinato
    {
        private string fecha;
        private string departamento;
        private string municipio;
        private string barrio;
        private string ubicacion;
        private string tipoLugar;

        public DatosAsesinato(string lineaArchivo)
        {
            string[] valores = lineaArchivo.Split(';');
            fecha = valores[0];
            departamento = valores[1];
            municipio = valores[2];
            barrio = valores[5];
            ubicacion = valores[5] + " " + valores[2] + " " + valores[1];
            tipoLugar = valores[7];
        }
        public string getFecha()
        {
            return fecha;
        }

        public string getDepartamento()
        {
            return departamento;
        }
        public string getMunicipio()
        {
            return municipio;
        }
        public string getBarrio()
        {
            return barrio;
        }
        public string getTipoLugar()
        {
            return tipoLugar;
        }
        public string getUbicacion()
        {
            return ubicacion;
        }
    }
}
