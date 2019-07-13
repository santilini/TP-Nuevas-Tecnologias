using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TPMascotas.Models;

namespace TPMascotas.ViewModels
{
    public class PerfilViewModel
    {
        public List<Adoptado> Adoptados { get; set; }
        public List<Perdido> Perdidos { get; set; }
        public List<Encontrado> Encontrados { get; set; }
        public List<Notificacion> Notificaciones { get; set; }
        PerdidoContext dB = new PerdidoContext();


        public PerfilViewModel(List<Adoptado> adoptados, List<Perdido> perdidos, List<Encontrado> encontrados, List<Notificacion> notificaciones)
        {
            Adoptados = adoptados;
            Perdidos = perdidos;
            Encontrados = encontrados;
            Notificaciones = notificaciones;
        }

        public int ContarPublicaciones()
        {
            int c = 0;
            c += Adoptados.Count();
            c += Encontrados.Count();
            c += Perdidos.Count();
            return c;
        }
        public List<NotifViewModel> NotificacionesParaMostrar()
        {
            
            List<NotifViewModel> lista = new List<NotifViewModel>();
            foreach (var item in Notificaciones)
            {
                var user = dB.Users.ToList().Find(m => m.Id.Equals(item.UsuarioInteresadoID));
                if (user != null)
                {
                    
                    AppUser Usuario = (AppUser)user;
                    NotifViewModel notif = new NotifViewModel(Usuario.NombreCompleto, Usuario.Email, Usuario.NumeroCelular);
                    if (item.Tipo == 'a')
                    {
                        var query = Adoptados.ToList().Find(m => m.Id == item.PubID);
                        if (query != null)
                        {
                            Adoptado a = (Adoptado)query;
                            notif.Publicacion = a.Nombre;
                        }
                    }
                    else if (item.Tipo == 'e')
                    {
                        var query = Encontrados.ToList().Find(m => m.Id == item.PubID);
                        if (query != null)
                        {
                            Encontrado e = (Encontrado)query;
                            notif.Publicacion = e.Nombre;
                        }
                    }
                    else
                    {
                        var query = Perdidos.ToList().Find(m => m.Id == item.PubID);
                        if (query != null)
                        {
                            Perdido p = (Perdido)query;
                            notif.Publicacion = p.Raza;
                        }
                    }
                    lista.Add(notif);
                }
            }
            return lista;
            
        }
    }
}