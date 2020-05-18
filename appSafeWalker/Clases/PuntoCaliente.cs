using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace appSafeWalker.Clases
{
    class PuntoCaliente
    {
        List<DatosAsesinato> listaHomicidios;
        List<DatosHurto> listaHurtos;
        List<DatosPuntos> datosPuntos;
        private class DatosPuntos
        {
            public DatosPuntos(string lugar)
            {
                this.lugar = lugar;
            }
            string lugar;
            int cantidad;
            public string getLugar()
            {
                return lugar;
            }
            public void setCantidad()
            {
                cantidad += 1;
            }
            public int getCantidad()
            {
                return cantidad;
            }
        }

        private void leerArchivos()
        {
            listaHomicidios = new List<DatosAsesinato>();
            listaHurtos = new List<DatosHurto>();
            Console.WriteLine("2");
            try
            {
                DatosAsesinato homicidios;
                string rutaArchivo = "../../../Clases/ArchivosHurtosHomicidios/homicidios-2019.csv";
                FileStream stream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string t;
                while (reader.Peek() > -1)
                {
                    t = reader.ReadLine();
                    homicidios = new DatosAsesinato(t);
                    listaHomicidios.Add(homicidios);

                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                DatosHurto datosHurto;
                string rutaArchivo = "../../../Clases/ArchivosHurtosHomicidios/hurto-personas-2019_-_Primera_Parte.csv";
                FileStream stream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string t;
                while (reader.Peek() > -1)
                {
                    t = reader.ReadLine();
                    datosHurto = new DatosHurto(t);
                    listaHurtos.Add(datosHurto);

                }
                reader.Close();
            }
            catch (Exception e)
            {

            }
            try
            {
                DatosHurto datosHurto;
                string rutaArchivo = "../../../Clases/ArchivosHurtosHomicidios/hurto-personas-2019_-_Segunda_Parte.csv";
                FileStream stream = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(stream);
                string t;
                while (reader.Peek() > -1)
                {
                    t = reader.ReadLine();
                    datosHurto = new DatosHurto(t);
                    listaHurtos.Add(datosHurto);

                }
                reader.Close();
            }
            catch (Exception e)
            {

            }
        }
        private void calcularPuntosCalientes()
        {
            datosPuntos = new List<DatosPuntos>();
            DatosPuntos t;

            foreach (DatosHurto element in listaHurtos)
            {
                if (!datosPuntos.Any(x => x.getLugar() == element.getUbicacion()))
                {
                    t = new DatosPuntos(element.getUbicacion());
                    foreach (DatosHurto a in listaHurtos)
                    {
                        if (element.getUbicacion().Equals(a.getUbicacion()))
                        {
                            t.setCantidad();
                        }
                    }
                    datosPuntos.Add(t);
                }
            }
            foreach (DatosPuntos element in datosPuntos)
            {
                if (listaHomicidios.Any(x => x.getUbicacion() == element.getLugar()))
                {
                    foreach (DatosAsesinato i in listaHomicidios)
                    {
                        if (i.getUbicacion() == element.getLugar())
                        {
                            element.setCantidad();
                        }
                    }
                }
            }
            foreach (DatosAsesinato a in listaHomicidios)
            {
                if (!datosPuntos.Any(x => x.getLugar() == a.getUbicacion()))
                {
                    t = new DatosPuntos(a.getUbicacion());
                    foreach (DatosAsesinato element in listaHomicidios)
                    {
                        if (element.getUbicacion() == (a.getUbicacion()))
                        {
                            t.setCantidad();
                        }
                    }
                    datosPuntos.Add(t);
                }
            }
        }
    }
}
