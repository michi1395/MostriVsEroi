using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    public class MostroRepository : IMostroRepository
    {
        static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Demo8;Trusted_Connection=True;";
        public List<Mostro> GetByEroeLevel(Eroe eroe)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                if (conn.State != ConnectionState.Open)
                    Console.WriteLine("Can't establish connection!!!");
                DataSet dsGioco = new DataSet();
                SqlDataAdapter userAdapter = new();
                SqlCommand selectUser = new SqlCommand("SELECT * FROM MostriConProprieta", conn);
                userAdapter.SelectCommand = selectUser;
                userAdapter.Fill(dsGioco, "Mostri");
                List<Mostro> myList = new List<Mostro>();

                foreach (DataRow row in dsGioco.Tables["Mostri"].Rows)
                {
                    if (eroe.Livello >= (int)row["Livello"])
                    {
                        Mostro mostro = new();
                        Arma arma = new();
                        Categoria categoria = new();

                        mostro.Nome = (string)row["Nome"];
                        arma.Nome = (string)row["ArmaNome"];
                        arma.PuntiDanno = (int)row["PuntiDanno"];
                        mostro.Arma = arma;
                        mostro.PuntiVita = (int)row["PuntiVita"];
                        categoria.Nome = (string)row["Classe"];
                        mostro.Categoria = categoria;
                        mostro.Livello = (int)row["Livello"];


                        myList.Add(mostro);
                    }

                }

                conn.Close();
                return myList;
            }
        }
    }
}
