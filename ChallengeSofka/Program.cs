using ChallengeSofka.Controllers;
using DataAcces;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ChallengeSofka
{
    class Program
    {
        static void Main(string[] args)
        {

            int nivelactual = 1;
            int PremioActual = 0;
            bool ContinuarSiguienteNivel = true;
            int idPregunta = 0;
            int idRespuesta = 0;
            Juego juego = new Juego();

            JuegoController juegoController = new JuegoController();


            Console.WriteLine("");
            Console.WriteLine("Bienvenido al Juego Millonario");
            Console.WriteLine("Esperamos te diviertas mucho y ganes muchos premios.");
            Console.WriteLine("====================================================");
            Console.WriteLine("");
            Console.WriteLine("Para continuar favor ingresa tu Nick y presiona enter para continuar.");
            Console.WriteLine("Nick: ");
            Console.WriteLine("");

            int idJugador = juegoController.SolicitarInfoUsuario();

            if (idJugador == 0)
            {
                Console.ReadKey();
            }
            else
            {

                juego.IdUsuario = idJugador;
                juego.IdNivelAlcanzado = nivelactual;

                // Se inicializa el datos del juego.
                juegoController.Instrucciones(nivelactual);

                while (ContinuarSiguienteNivel && nivelactual <= 5)
                {
                    RondaJuego rondaJuego = new RondaJuego();
                    //Se obtienen las preguntas y se selecciona una al azar de acuerdo a nivel

                    List<Pregunta> lstPreguntas = juegoController.ObtenerPreguntasByNivel(nivelactual);
                    Random r = new Random();

                    if (lstPreguntas.Count > 0)
                    {
                        int rInt = r.Next(0, (lstPreguntas.Count));
                        Console.WriteLine("Pregunta " + nivelactual.ToString() + " - " + lstPreguntas[rInt].Descripcion);
                        idPregunta = lstPreguntas[rInt].IdPregunta;

                        // Se obtienen las respuestas de acuerdo a la pregunta seleccionada
                        List<Respuesta> lstRespuestas = juegoController.ObtenerRespuestasByIdPregunta(idPregunta);

                        if (lstRespuestas.Count > 0)
                        {

                            for (int i = 0; i < lstRespuestas.Count; i++)
                            {
                                Console.WriteLine((i + 1).ToString() + ". " + lstRespuestas[i].Descipcion);
                            }
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("Selecciona tu respuesta:");

                            var seleccion = Console.ReadLine();

                            //Se valida la opcion seleccionada por el jugador.
                            Respuesta respuesta = juegoController.SolicitarRespuesta(lstRespuestas, seleccion);

                            ContinuarSiguienteNivel = respuesta.EsCorrecta;
                            idRespuesta = respuesta.IdRespuesta;
                            PremioActual = juegoController.ConsultarPremioByNivel(nivelactual);

                            rondaJuego.IdNivel = nivelactual;
                            rondaJuego.IdPregunta = idPregunta;
                            rondaJuego.IdRespuesta = idRespuesta;
                            rondaJuego.PremioObtenido = PremioActual;
                            rondaJuego.RespuestaCorrecta = ContinuarSiguienteNivel;

                            juego.IdNivelAlcanzado = nivelactual;
                            juego.PremioAcumulado = PremioActual;
                            juego.FechaCreacion = juego.IdJuego == 0 ? DateTime.Now : juego.FechaCreacion;

                            if (ContinuarSiguienteNivel)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Respuesta Correcta... Felicitaciones!!! ");
                                Console.WriteLine("");
                                if (nivelactual < 5)
                                    ContinuarSiguienteNivel = juegoController.ConsultarContinuarJuego(PremioActual);

                                if (ContinuarSiguienteNivel)
                                {
                                    if (nivelactual < 5)
                                    {
                                        nivelactual = nivelactual + 1;
                                        Console.Clear();

                                        juegoController.Instrucciones(nivelactual);
                                        Console.WriteLine("");
                                        Console.WriteLine("Pasaste al nivel " + nivelactual.ToString());
                                        Console.WriteLine("Premio acumulado............................ $" + PremioActual.ToString());
                                        Console.WriteLine("");

                                        juegoController.GuardarDatosJuego(juego);
                                        rondaJuego.IdJuego = juego.IdJuego;
                                        juegoController.GuardarRondaJuego(rondaJuego);
                                    }
                                    else
                                    {
                                        //JuegoFinalizado

                                        Console.Clear();
                                        Console.WriteLine("");
                                
                                        Console.WriteLine("JUEGO FINALIZADO");
                                        Console.WriteLine("Alcanzaste  el nivel " + nivelactual.ToString());
                                        Console.WriteLine("Premio acumulado............................ $" + PremioActual.ToString());
                                        Console.WriteLine("Gracias por jugar.");                             

                                        juego.IdTipoFinalizacion = 2;
                                        juego.FechaFinalizacion = DateTime.Now;
                                        juego.IdJuego = juegoController.GuardarDatosJuego(juego);
                                        rondaJuego.IdJuego = juego.IdJuego;
                                        juegoController.GuardarRondaJuego(rondaJuego);       

                                        break;
                                    }

                                }
                                else
                                {
                                    juego.IdTipoFinalizacion = 1; //Retiro Voluntario
                                    juego.FechaFinalizacion = DateTime.Now;
                                    Console.Clear();
                                    Console.WriteLine("JUEGO FINALIZADO");
                                    Console.WriteLine("Alcanzaste  el nivel " + nivelactual.ToString());
                                    Console.WriteLine("Premio acumulado............................ $" + PremioActual.ToString());
                                    Console.WriteLine("Gracias por jugar.");
                                    juegoController.GuardarDatosJuego(juego);
                                    rondaJuego.IdJuego = juego.IdJuego;
                                    juegoController.GuardarRondaJuego(rondaJuego);
                                }
                            }
                            else
                            {
                                juego.PremioAcumulado = 0;
                                juego.IdTipoFinalizacion = 3;
                                juego.FechaFinalizacion = DateTime.Now;

                                juegoController.GuardarDatosJuego(juego);
                                rondaJuego.IdJuego = juego.IdJuego;
                                rondaJuego.PremioObtenido = 0;
                                juegoController.GuardarRondaJuego(rondaJuego);

                                Console.WriteLine("Lo sentimos la respuesta fue incorrecta has perdido el juego.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No tenemos mas preguntas lo sentimos, Premio Acumulado: $" + PremioActual.ToString());
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("No tenemos mas preguntas lo sentimos, Premio Acumulado: $" + PremioActual.ToString());
                        break;
                    }
                }

                Console.ReadKey();
            }

        }
    }
}
