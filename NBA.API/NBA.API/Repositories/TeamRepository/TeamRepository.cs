using NBA.API.Configurations;
using NBA.API.DomainModels.TeamModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NBA.API.Repositories.TeamRepository
{
    public class TeamRepository : ITeamRepository
    {
        IConfiguration Configuration { get; set; }

        public TeamRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Team Get(int id)
        {
            using (var conn = new SqlConnection(Configuration.ConnectionString))
            using (var cmd = new SqlCommand("dbo.GetTeamById", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                conn.Open();

                var reader = cmd.ExecuteReader();

                Team team = null;

                while (reader.Read())
                {
                    team = new Team
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        City = reader["City"].ToString(),
                        Name = reader["Name"].ToString(),
                        Abbrev = reader["Abbrev"].ToString()
                    };
                }

                return team;
            }
        }

        public List<Team> Get()
        {
            using (var conn = new SqlConnection(Configuration.ConnectionString))
            using (var cmd = new SqlCommand("dbo.GetTeams", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                var reader = cmd.ExecuteReader();

                List<Team> teams = new List<Team>();

                while (reader.Read())
                {
                    teams.Add(
                        new Team
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            City = reader["City"].ToString(),
                            Name = reader["Name"].ToString(),
                            Abbrev = reader["Abbrev"].ToString()
                    });
                }

                return teams;
            }
        }
    }
}