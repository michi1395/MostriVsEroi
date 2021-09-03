using MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.DbRepository
{
    public class EroeRepository
    {
        static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Demo8;Trusted_Connection=True;";

        public List<Eroe> FetchByID(Giocatore giocatore)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                if (conn.State != ConnectionState.Open)
                    Console.WriteLine("Can't establish connection!!!");
                DataSet dsGioco = new DataSet();
                SqlDataAdapter userAdapter = new();
                SqlCommand selectUser = new SqlCommand("SELECT * FROM EroiConProprieta", conn);
                userAdapter.SelectCommand = selectUser;
                userAdapter.Fill(dsGioco, "Eroi");
                List<Eroe> myList = new List<Eroe>();

                foreach (DataRow row in dsGioco.Tables["Eroi"].Rows)
                {
                    if (giocatore.Id == (int)row["IdGiocatore"])
                    {
                        Eroe eroe = new();
                        Arma arma = new();
                        Categoria categoria = new();
                        eroe.Id = (int)row["Id"];
                        eroe.Nome = (string)row["Nome"];
                        arma.Nome = (string)row["ArmaNome"];
                        arma.PuntiDanno = (int)row["PuntiDanno"];
                        eroe.Arma = arma;
                        eroe.PuntiVita = (int)row["PuntiVita"];
                        categoria.Nome = (string)row["Classe"];
                        eroe.Categoria = categoria;
                        eroe.Livello = (int)row["Livello"];
                        eroe.PuntiAccumulati = (int)row["PuntiAccumulati"];

                        myList.Add(eroe);
                    }

                }

                conn.Close();
                return myList;
            }
        }

        public static void EliminaEroe(Eroe eroeScelto)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();

                if (conn.State != ConnectionState.Open)
                    Console.WriteLine("Can't establish connection !!!");

                DataSet dsGioco = new DataSet();
                SqlDataAdapter userAdapter = new();

                userAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;   

                SqlCommand selectUser = new SqlCommand("SELECT * FROM Eroe", conn);

                userAdapter.SelectCommand = selectUser;

                userAdapter.DeleteCommand = GetAutoreDeleteCommand(conn);

                //

                userAdapter.Fill(dsGioco, "Eroe");

                conn.Close();

                DataRow rowToChange = dsGioco.Tables["Eroe"].Rows.Find(eroeScelto.Id);   

                if (rowToChange != null)
                {
                    rowToChange.Delete();

                    userAdapter.Update(dsGioco, "Eroe");
                }
            }
        }

        private static SqlCommand GetAutoreDeleteCommand(SqlConnection conn)
        {
            SqlCommand deleteCommand = new SqlCommand();

            deleteCommand.Connection = conn;
            deleteCommand.CommandText = "DELETE FROM Eroe " +
                "WHERE Id = @id";

            deleteCommand.CommandType = System.Data.CommandType.Text;

            deleteCommand.Parameters.Add(
                new SqlParameter(
                    "@id",
                    SqlDbType.Int,
                    100,
                    "Id"
                )
            );

            return deleteCommand;
        }

        public static List<Categoria> MostraCategorie()
        {

            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                if (conn.State != ConnectionState.Open)
                    Console.WriteLine("Can't establish connection!!!");
                DataSet dsGioco = new DataSet();
                SqlDataAdapter userAdapter = new();
                SqlCommand selectUser = new SqlCommand("SELECT * FROM Classe WHERE IdTipo=1", conn);
                userAdapter.SelectCommand = selectUser;
                userAdapter.Fill(dsGioco, "Categoria");

                List<Categoria> categorie = new List<Categoria>();


                foreach (DataRow row in dsGioco.Tables["Categoria"].Rows)
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)row["ID"];
                    categoria.Nome = (string)row["Name"];
                    categorie.Add(categoria);

                }


                conn.Close();
                return categorie;

            }
        }

        public static void AggiungiEroe(Giocatore giocatore, Eroe newEroe)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                if (conn.State != ConnectionState.Open)
                    Console.WriteLine("Can't establish connection!!!");

                DataSet dsGioco = new DataSet();
                SqlDataAdapter userAdapter = new();
                SqlCommand selectUser = new SqlCommand("SELECT * FROM Eroe", conn);
                userAdapter.SelectCommand = selectUser;
                userAdapter.InsertCommand = GetUserInsertCommand(conn);
                userAdapter.Fill(dsGioco, "User");

                conn.Close();
                DataRow newRow = dsGioco.Tables["User"].NewRow();

                newRow["Nome"] = newEroe.Nome;
                newRow["IdClasse"] = newEroe.Categoria.Id;
                newRow["IdArma"] = newEroe.Arma.Id;
                newRow["Livello"] = 1;
                newRow["IdGiocatore"] = giocatore.Id;
                newRow["PuntiAccumulati"] = 0;



                dsGioco.Tables["User"].Rows.Add(newRow);


                userAdapter.Update(dsGioco, "User");
            }
        }


        private static SqlCommand GetUserInsertCommand(SqlConnection conn)
        {
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = conn;
            insertCommand.CommandText = "INSERT INTO Eroe VALUES(@nome, @idClasse, @idArma, @livello, @idGiocatore, @puntiAccumulati)";

            insertCommand.CommandType = System.Data.CommandType.Text;

            insertCommand.Parameters.Add(
                new SqlParameter(
                "@idGiocatore",
                SqlDbType.Int,
                100,
                "IdGiocatore"
                )
              );
            insertCommand.Parameters.Add(
                new SqlParameter(
                "@nome",
                SqlDbType.NVarChar,
                30,
                "Nome"
                )
              );

            insertCommand.Parameters.Add(
                new SqlParameter(
                "@puntiAccumulati",
                SqlDbType.Int,
                100,
                "PuntiAccumulati"
                )
              );

            insertCommand.Parameters.Add(
                new SqlParameter(
                "@idArma",
                SqlDbType.Int,
                100,
                "IdArma"
                )
              );

            insertCommand.Parameters.Add(
                new SqlParameter(
                "@livello",
                SqlDbType.Int,
                100,
                "Livello"
                )
              );
            insertCommand.Parameters.Add(
                new SqlParameter(
                "@idClasse",
                SqlDbType.Int,
                100,
                "IdClasse"
                )
              );


            return insertCommand;
        }

        public static List<Arma> MostraArma(Categoria categoria)
        {

            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                if (conn.State != ConnectionState.Open)
                    Console.WriteLine("Can't establish connection!!!");

                DataSet dsGioco = new DataSet();

                List<Arma> armi = new List<Arma>();

                if (categoria.Nome == "Guerriero")
                {
                    SqlDataAdapter userAdapter = new();
                    SqlCommand selectUser = new SqlCommand("SELECT * FROM Arma WHERE IdClasse=1", conn);
                    userAdapter.SelectCommand = selectUser;
                    userAdapter.Fill(dsGioco, "Arma");

                    foreach (DataRow row in dsGioco.Tables["Arma"].Rows)
                    {
                        Arma newArma = new Arma();
                        newArma.Id = (int)row["ID"];
                        newArma.Nome = (string)row["Nome"];
                        newArma.PuntiDanno = (int)row["PuntiDanno"];
                        armi.Add(newArma);

                    }

                }
                else
                {
                    SqlDataAdapter userAdapter = new();
                    SqlCommand selectUser = new SqlCommand("SELECT * FROM Arma WHERE IdClasse=2", conn);
                    userAdapter.SelectCommand = selectUser;
                    userAdapter.Fill(dsGioco, "Arma");

                    foreach (DataRow row in dsGioco.Tables["Arma"].Rows)
                    {
                        Arma newArma = new Arma();
                        newArma.Id = (int)row["ID"];
                        newArma.Nome = (string)row["Nome"];
                        newArma.PuntiDanno = (int)row["PuntiDanno"];
                        armi.Add(newArma);

                    }

                }
                conn.Close();
                return armi;




            }
        }
    }
}
