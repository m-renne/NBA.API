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
                        TeamId = int.Parse(reader["NBATeamId"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        JerseyNumber = int.Parse(reader["JerseyNumber"].ToString()),
                        Position = reader["Position"].ToString(),
                        Height = reader["Height"].ToString(),
                        Weight = reader["Weight"].ToString(),
                        BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                        Age = int.Parse(reader["Age"].ToString()),
                        BirthCity = reader["BirthCity"].ToString(),
                        BirthCountry = reader["BirthCountry"].ToString(),
                        IsRookie = bool.Parse(reader["Rookie"].ToString())
                    };

                    break;
                }
                return player;
            }
        }

        public List<Player> Get(PlayerSearchCriteria criteria)
        {
            using (var conn = new SqlConnection(Configuration.ConnectionString))
            using (var cmd = new SqlCommand("dbo.GetPlayers", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@NBATeamId", SqlDbType.Int).Value = criteria.TeamId;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = criteria.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = criteria.LastName;
                cmd.Parameters.Add("@JerseyNumber", SqlDbType.Int).Value = criteria.JerseyNumber;
                cmd.Parameters.Add("@Position", SqlDbType.VarChar).Value = criteria.Position;
                cmd.Parameters.Add("@Height", SqlDbType.VarChar).Value = criteria.Height;
                cmd.Parameters.Add("@Weight", SqlDbType.VarChar).Value = criteria.FirstName;
                cmd.Parameters.Add("@BirthDate", SqlDbType.Date).Value = criteria.BirthDate;
                cmd.Parameters.Add("@Age", SqlDbType.Int).Value = criteria.Age;
                cmd.Parameters.Add("@BirthCity", SqlDbType.VarChar).Value = criteria.BirthCity;
                cmd.Parameters.Add("@BirthCountry", SqlDbType.VarChar).Value = criteria.BirthCountry;
                cmd.Parameters.Add("@Rookie", SqlDbType.Bit).Value = criteria.IsRookie;

                conn.Open();

                var reader = cmd.ExecuteReader();

                List<Player> players = new List<Player>();

                while (reader.Read())
                {
                    players.Add(
                        new Player
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        TeamId = int.Parse(reader["NBATeamId"].ToString()),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        JerseyNumber = int.Parse(reader["JerseyNumber"].ToString()),
                        Position = reader["Position"].ToString(),
                        Height = reader["Height"].ToString(),
                        Weight = reader["Weight"].ToString(),
                        BirthDate = DateTime.Parse(reader["BirthDate"].ToString()),
                        Age = int.Parse(reader["Age"].ToString()),
                        BirthCity = reader["BirthCity"].ToString(),
                        BirthCountry = reader["BirthCountry"].ToString(),
                        IsRookie = bool.Parse(reader["Rookie"].ToString())
                    });
                }
                return players;
            }
        }
    }
}