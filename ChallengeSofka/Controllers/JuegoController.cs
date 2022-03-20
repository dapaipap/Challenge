using DataAcces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChallengeSofka.Controllers
{
    public class JuegoController
    {
        private JuegoMillonarioContext context;
          
        public int SolicitarInfoUsuario()
        {

            Usuario usuario = new Usuario();

            usuario.Nick = Console.ReadLine().Trim().ToLower();
            usuario.FechaRegistro = DateTime.Now;

            bool validacion = true;

            while (validacion)
            {
                if (!string.IsNullOrEmpty(usuario.Nick))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Favor ingresa un Nick valido.");
            
                }
                usuario.Nick = Console.ReadLine();

            }

            return GuardarUsuario(usuario);

        }

        public int GuardarUsuario(Usuario usuario)
        {
            try
            {
                using (context = new JuegoMillonarioContext())
                {
                    Usuario consulta = context.Usuarios.Where(x => x.Nick.ToLower() == usuario.Nick).FirstOrDefault();

                    if (consulta == null)
                    {
                        context.Usuarios.Add(usuario);
                        context.SaveChanges();
                        Console.WriteLine("");
                        return usuario.IdUsuario;

                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Bienvenido de nuevo " + usuario.Nick);
                        Console.WriteLine("");
                        return consulta.IdUsuario;
                    }
                   
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error, por favor intentalo mas tarde.");
                return 0;
                throw;
            }
        }

        public void Instrucciones(int nivel)
        {

            if (nivel == 1)
            {
                Console.WriteLine("Preparado para inciar el Juego. Nivel " + nivel.ToString() + " en proceso:");
            }
            else
            {
                Console.WriteLine(" Nivel " + nivel.ToString() + " en proceso:");
            }

            Console.WriteLine("");
            Console.WriteLine("Instrucciones:");
            Console.WriteLine("");
            Console.WriteLine("Ingresa un numero del 1 al 4 de acuerdo a la respuesta que creeas que es correcta.");
            Console.WriteLine("");
        }

        public List<Pregunta> ObtenerPreguntasByNivel(int nivel)
        {
            using (context = new JuegoMillonarioContext())
            {

                return context.Preguntas.Where(x => x.IdNivel == nivel).ToList();
            }

        }

        public List<Respuesta> ObtenerRespuestasByIdPregunta(int idPregunta)
        {
            using (context = new JuegoMillonarioContext())
            {
                var query = (from res in context.Respuestas
                             join preres in context.PreguntasRespuestas on res.IdRespuesta equals preres.IdRespuesta
                             where preres.IdPregunta == idPregunta
                             select res);

                return query.ToList();
            }

        }

        public Respuesta SolicitarRespuesta(List<Respuesta> lstRespuestas, string seleccion)
        {
            Regex regex = new Regex("[0-9]");
            int indexSeleccionado = 0;
            bool validacion = true;

            while (validacion)
            {

                if (regex.IsMatch(seleccion))
                {
                    indexSeleccionado = Convert.ToInt32(seleccion) - 1;

                

                    if (indexSeleccionado >= 0 && indexSeleccionado < 4)
                    {                
                    validacion = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No ha seleccionado una respuesta valida.");
                    }
                }
                else
                {
                    Console.WriteLine("No ha seleccionado una respuesta valida.");
                }

                seleccion = Console.ReadLine();
            }

            Respuesta result = ValidarRespuestCorrecta(lstRespuestas, indexSeleccionado);          

            return result;

        }

        private Respuesta ValidarRespuestCorrecta(List<Respuesta> respuestas, int indexSeleccionado)
        {
            Respuesta resultado = respuestas.ElementAt(indexSeleccionado);
            return resultado;
        }

        public int ConsultarPremioByNivel(int nivel)
        {

            using (context = new JuegoMillonarioContext())
            {
                Nivel result = context.Nivels.Where(x => x.IdNivel == nivel).FirstOrDefault();

                return Convert.ToInt32(result.Premio);
            }
        }

        public int GuardarDatosJuego(Juego juego)
        {

            using (context = new JuegoMillonarioContext())
            {

                int id;               

                if (juego.IdJuego == 0)
                {                    
                    context.Juegos.Add(juego);
                    context.SaveChanges();
                    id = juego.IdJuego;
                }
                else
                {
                    context.Juegos.Update(juego);
                    context.SaveChanges();
                    id = juego.IdJuego;
                }            

                return id;
            }
        }

        public bool ConsultarContinuarJuego(int acumulado)
        {

            Console.WriteLine("Desea continuar el juego? o terminar con el acumulado actual de $" + acumulado.ToString());
            Console.WriteLine("Ingrese (Si) en caso afirmativo de lo contrario ingrese (No) para finalizar con el acumulado.");
            Console.WriteLine("");

            string respuesta = Console.ReadLine();
            bool result = false;
            bool validacion = true;
          

            while (validacion)
            {
                if (respuesta == "Si" || respuesta == "No")
                {
                    result = respuesta == "Si" ? true : false;
                    break;
                }
                else
                {
                    Console.WriteLine("No ha seleccionado una respuesta valida.");
                }
                respuesta = Console.ReadLine();

            }

            return result;
        }

        public void GuardarRondaJuego(RondaJuego ronda ) {

            using (context = new JuegoMillonarioContext()) {
                
                ronda.FechaCreacion = DateTime.Now;
                context.RondaJuegos.Add(ronda);
                context.SaveChanges();
            }        
        }
    }
}
