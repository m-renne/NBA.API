using NBA.API.Configurations;
using NBA.API.DomainModels.PlayerModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NBA.API.Repositories.PlayerRepository
{
    public class PlayerRepository : IPlayerRepository
    {
        IConfiguration Configuration { get; set; }

        public PlayerRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Player Get(int id)
        {
            using (var conn = new SqlConnection(Configuration.ConnectionString))
            using (var cmd = new SqlCommand("dbo.GetPlayerById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                conn.Open();

                var reader = cmd.ExecuteReader();

                Player player = null;

                while (reader.Read())
                {
                    player = new Player
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        JerseyNumber = int.Parse(reader["JerseyNumber"].ToString())
                    };
                }

                return player;
            }
        }
    }
}