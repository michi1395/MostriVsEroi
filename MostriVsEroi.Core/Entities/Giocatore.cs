using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Entities
{
    public class Giocatore
    {
        public string Nome { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }
        public int Id { get; set; }

        public Giocatore()
        {
        }
        public Giocatore(string nome, string password, bool isAdmin, int id, bool isAuthenticated)
        {
            Nome = nome;
            Password = password;
            IsAdmin = isAdmin;
            Id = id;
            IsAuthenticated = isAuthenticated;
        }
        public Giocatore(string nome, string password, bool isAdmin)
        {
            Nome = nome;
            Password = password;
            IsAdmin = isAdmin;
        }
        public Giocatore(string nome, string password)
        {
            Nome = nome;
            Password = password;
            IsAdmin = false;
            IsAuthenticated = false;
        }
    }
}
