using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using RestHaber.Model;

namespace RestHaber.Connector
{
    public class Conn
    {
        private string connstring;
        public Conn()
        {
            //connstring = @"server=sql12.freemysqlhosting.net;userid=;password=;database=sql12174637";
            connstring = @"server=localhost;userid=root;password=12345678;database=Haberler";
        }

        public List<HaberFormat> HaberFormatList()
        {
            List<HaberFormat> allHaber = new List<HaberFormat>();
            using (MySqlConnection connMysql = new MySqlConnection(connstring))
            {
                using (MySqlCommand cmdd = connMysql.CreateCommand())
                {

                    cmdd.CommandText = "Select * from Haber";
                    cmdd.CommandType = System.Data.CommandType.Text;

                    cmdd.Connection = connMysql;

                    connMysql.Open();
                    using (MySqlDataReader reader = cmdd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            allHaber.Add(new HaberFormat
                            {
                                idHaber = reader.GetInt32(reader.GetOrdinal("idHaber")),
                                HaberBaslik = reader.GetString(reader.GetOrdinal("HaberBaslik")),
                                HaberIcerik = reader.GetString(reader.GetOrdinal("HaberIcerik")),
                                HaberTuru = reader.GetString(reader.GetOrdinal("HaberTuru")),
                                BegenmeSayisi = reader.GetInt32(reader.GetOrdinal("BegenmeSayisi"))


                            });
                        }
                    }
                }
                connMysql.Close();
            }


                return allHaber;
        }

    }

}

