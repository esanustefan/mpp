using System;
using System.Collections.Generic;
using System.Data;
using APP_BASCHET.repo;
using log4net;


namespace baschet.repo;


public class MatchDBRepo: IRepository<int, Match>
{
    private static readonly ILog log = LogManager.GetLogger("MatchDbRepository");

    IDictionary<String, string> props;
    public MatchDBRepo(IDictionary<String, string> props)
    {
        log.Info("Creating MatchDbRepository");
        this.props = props;
    }


    public Match findOne(int id)
    {
        log.InfoFormat("Entering findOne with value {0}", id);
        IDbConnection con = DBUtils.getConnection(props);
        using(var comm = con.CreateCommand())
        {
            comm.CommandText = "select id,teamA,teamB,ticketPrice,totalSeats, soldSeats from Matches where id=@id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    int idV = dataR.GetInt32(0);
                    String teamA = dataR.GetString(1);
                    String teamB = dataR.GetString(2);
                    double ticketPrice = dataR.GetDouble(3);
                    int totalSeats = dataR.GetInt32(4);
                    int soldSeats = dataR.GetInt32(5);
                    Match match = new Match(idV, teamA, teamB, ticketPrice, totalSeats, soldSeats);
                    log.InfoFormat("Exiting findOne with value {0}", match);
                    return match;
                }
            }
        }
        log.InfoFormat("Exiting findOne with value {0}", null);
        return null;
    }

    public IEnumerable<Match> findAll()
    {
        log.InfoFormat("Entering findAll");
        IDbConnection con = DBUtils.getConnection(props);
        IList<Match> matchesR = new List<Match>();
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select id,teamA,teamB,ticketPrice,totalSeats, soldSeats from Matches";

            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int idV = dataR.GetInt32(0);
                    String teamA = dataR.GetString(1);
                    String teamB = dataR.GetString(2);
                    int ticketPrice = dataR.GetInt32(3);
                    int totalSeats = dataR.GetInt32(4);
                    int soldSeats = dataR.GetInt32(5);
                    Match match = new Match(idV, teamA, teamB, ticketPrice, totalSeats, soldSeats);
                    matchesR.Add(match);
                }
            }
        }
        log.InfoFormat("Exiting findAll with value {0}", matchesR);
        return matchesR;
    }

    public Match add(Match entity)
    {
        var con = DBUtils.getConnection(props);
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "insert into Matches(teamA,teamB,ticketPrice,totalSeats, soldSeats) values (@teamA,@teamB,@ticketPrice,@totalSeats, @soldSeats)";
            var paramTeamA = comm.CreateParameter();
            paramTeamA.ParameterName = "@teamA";
            paramTeamA.Value = entity.TeamA;
            comm.Parameters.Add(paramTeamA);

            var paramTeamB = comm.CreateParameter();
            paramTeamB.ParameterName = "@teamB";
            paramTeamB.Value = entity.TeamB;
            comm.Parameters.Add(paramTeamB);

            var paramTicketPrice = comm.CreateParameter();
            paramTicketPrice.ParameterName = "@ticketPrice";
            paramTicketPrice.Value = entity.TicketPrice;
            comm.Parameters.Add(paramTicketPrice);

            var paramTotalSeats = comm.CreateParameter();
            paramTotalSeats.ParameterName = "@totalSeats";
            paramTotalSeats.Value = entity.TotalSeats;
            comm.Parameters.Add(paramTotalSeats);

            var paramSoldSeats = comm.CreateParameter();
            paramSoldSeats.ParameterName = "@soldSeats";
            paramSoldSeats.Value = entity.SoldSeats;
            comm.Parameters.Add(paramSoldSeats);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new RepositoryException("No match added !");
        }
        return null;
    }

    public Match delete(int id)
    {
        var con = DBUtils.getConnection(props);
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "delete from Matches where id=@id";
            var paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new RepositoryException("No match deleted !");
        }
        return null;
    }

    public void update(Match entity)
    {
        throw new NotImplementedException();
    }
}