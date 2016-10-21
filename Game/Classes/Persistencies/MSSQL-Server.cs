using Game.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Game.Classes.Cells;

namespace Game.Classes.Persistencies
{
    class MSSQL_Server : IMap
    {
        string connString;
        SqlCommand command;
        SqlConnection SQLcon;
        SqlDataReader reader;
        
        // ----
        private void Connect()
        {
            this.connString = "Server=mssql.fhict.local;Database=dbi327544;User Id=dbi327544;Password=PTS16;";
            SQLcon = new SqlConnection(connString);
            SQLcon.Open();
        }
        private void Close()
        {
            SQLcon.Close();
            SQLcon.Dispose();
        }

        public bool CheckIfMapNameExists(string mapname)
        {
            bool mapExists = false;
            string query = "SELECT MapName FROM Cells WHERE Mapname = @Mapname";
            using (command = new SqlCommand(query, SQLcon))
            {
                command.Parameters.Add(new SqlParameter("@MapName", mapname));
                reader = command.ExecuteReader();

                while (reader.Read())
                { 
                    if(reader["MapName"].ToString() != null)
                    {
                        mapExists = true;
                    }
                    else
                    {
                        mapExists = false;
                        break;
                    }
                }
            }
            return mapExists;
        }

        public string GetRandomMap()
        {
            Random rand = new Random();
            List<string> mapList = new List<string>();

            string query = "SELECT DISTINCT(MapName) FROM Cells";
            using (command = new SqlCommand(query, SQLcon))
            {
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    mapList.Add(reader["MapName"].ToString());
                }
            }

            return mapList[rand.Next(0, mapList.Count)];
        }

        public List<WallCell> GetWallCells(string mapName, Size cellSize)
        {
            List<WallCell> wallCellList = new List<WallCell>();

            Connect();
            string query = "SELECT * FROM Cells WHERE MapName = @MapName AND Wallcell = 1";
            using (command = new SqlCommand(query, SQLcon))
            {
                command.Parameters.Add(new SqlParameter("@MapName", GetRandomMap()));
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    WallCell wc = new WallCell(ConvertDataToPoint(reader["Coordinaten"].ToString()),cellSize);
                    wallCellList.Add(wc);
                }
            }
            Close();

            return wallCellList;
        }

        public List<NormalCell> GetNormalCells(string mapName, Size cellSize)
        {
            List<NormalCell> normalCellList = new List<NormalCell>();

            Connect();
            string query = "SELECT * FROM Cells WHERE MapName = @MapName AND NormalCell = 1";
            using (command = new SqlCommand(query, SQLcon))
            {
                command.Parameters.Add(new SqlParameter("@MapName", GetRandomMap()));
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    NormalCell wc = new NormalCell(ConvertDataToPoint(reader["Coordinaten"].ToString()), cellSize);
                    normalCellList.Add(wc);
                }
            }
            Close();

            return normalCellList;
        }

        private Point ConvertDataToPoint(string line)
        {
            string[] Punt = line.Split(',');
            // Integers zoeken in de gesplitte string
            string p1 = Regex.Match(Punt[0], @"\d+").Value;
            string p2 = Regex.Match(Punt[1], @"\d+").Value;
            // string omzetten naar echte ints.
            int x = Int32.Parse(p1);
            int y = Int32.Parse(p2);

            return new Point(x, y);
        }
    }
}
