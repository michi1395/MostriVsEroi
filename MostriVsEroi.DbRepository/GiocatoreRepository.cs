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
    public class GiocatoreRepository : IGiocatoreRepository
    {
        static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Demo8;Trusted_Connection=True;";
        static DataSet dsGioco = new DataSet();
        public Giocatore GetPlayerByUserPsw(Giocatore giocatore)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                if (conn.State != ConnectionState.Open)
                    Console.WriteLine("Can't establish connection!!!");

                SqlDataAdapter userAdapter = new();
                SqlCommand selectUser = new SqlCommand("SELECT * FROM Giocatore", conn);
                userAdapter.SelectCommand = selectUser;
                userAdapter.Fill(dsGioco, "User");

                foreach (DataRow row in dsGioco.Tables["User"].Rows)
                {
                    if (giocatore.Nome == (string)row["Nome"] && giocatore.Password == (string)row["Password"])
                    {
                        giocatore.Id = (int)row["ID"];
                        giocatore.IsAuthenticated = true;
                    }
                }
                conn.Close();

            }
            return giocatore;

        }

        public Giocatore AddUserPsw(Giocatore giocatore)
        {
            using (SqlConnection conn = new(connectionString))
            {
                conn.Open();
                if (conn.State != ConnectionState.Open)
                    Console.WriteLine("Can't establish connection!!!");

                SqlDataAdapter userAdapter = new();
                SqlCommand selectUser = new SqlCommand("SELECT * FROM Giocatore", conn);
                userAdapter.SelectCommand = selectUser;
                userAdapter.Fill(dsGioco, "User");

                int count = 0;
                foreach (DataRow row in dsGioco.Tables["User"].Rows)
                {
                    if (giocatore.Nome == (string)row["Nome"])
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    SqlDataAdapter userAdapter2 = new();
                    SqlCommand selectUser2 = new SqlCommand("SELECT * FROM Giocatore", conn);
                    userAdapter2.SelectCommand = selectUser;
                    userAdapter2.InsertCommand = GetUserInsertCommand(conn);
                    userAdapter2.Fill(dsGioco, "User");


                    conn.Close();
                    DataRow newRow = dsGioco.Tables["User"].NewRow();
                    bool isAdmin = false;

                    //...
                    newRow["Nome"] = giocatore.Nome;
                    newRow["Password"] = giocatore.Password;
                    newRow["IsAdmin"] = isAdmin;

                    dsGioco.Tables["User"].Rows.Add(newRow);


                    userAdapter2.Update(dsGioco, "User");
                    giocatore.IsAuthenticated = true;
                }

                else
                {
                    Console.WriteLine("Non puoi inserire questo nickname, è già presente nel nostro sistema");
                    giocatore.Nome = null;
                }


                conn.Close();

                return giocatore;
            }
        }

            private static SqlCommand GetUserInsertCommand(SqlConnection conn)
            {
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = conn;
                insertCommand.CommandText = "INSERT INTO Giocatore VALUES(@nome, @password, @isAdmin)";

                insertCommand.CommandType = System.Data.CommandType.Text;

                insertCommand.Parameters.Add(
                    new SqlParameter(
                    "@nome",
                    SqlDbType.NVarChar,
                    20,
                    "Nome"
                    )
                  );
                insertCommand.Parameters.Add(
                    new SqlParameter(
                    "@password",
                    SqlDbType.NVarChar,
                    10,
                    "Password"
                    )
                  );
                insertCommand.Parameters.Add(
                    new SqlParameter(
                    "@isAdmin",
                    SqlDbType.Bit,
                    10,
                    "isAdmin"
                    )
                  );
                return insertCommand;
            }
        }
    }

