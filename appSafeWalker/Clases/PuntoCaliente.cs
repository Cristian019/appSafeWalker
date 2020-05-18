using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace appSafeWalker.Clases
{
    class PuntoCaliente
    {
        List<DatosAsesinato> listaHomicidios;
        private void leerArchivos()
        {
            try
            {
                DatosAsesinato homicidios;
                string rutaArchivo = "ArchivosHurtosHomicidios/homicidios-2019.xls";
                FileStream stream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string t;
                while (reader.Peek() > -1)
                {
                    t = reader.ReadLine();
                    homicidios = new DatosAsesinato(t);
                    listaHomicidios.Add(homicidios);
                    Console.WriteLine(t);
                }
                reader.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
