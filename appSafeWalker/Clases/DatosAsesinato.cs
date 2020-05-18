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
        private string tipoLugar;

        public DatosAsesinato(string lineaArchivo)
        {
            string[] valores = lineaArchivo.Split(',');
            fecha = valores[0];
            departamento = valores[1];
            municipio = valores[2];
            barrio = valores[5];
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
    }
}
