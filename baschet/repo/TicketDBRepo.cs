using System;
using System.Collections.Generic;
using System.Data;
using APP_BASCHET.domain;
using APP_BASCHET.repo;
using baschet.repo;
using log4net;

namespace baschet.repo;

public class TicketDBRepo: TicketRepository
{
    private static readonly ILog log = LogManager.GetLogger("TicketDbRepository");

    IDictionary<String, string> props;
    public TicketDBRepo(IDictionary<String, string> props)
    {
        log.Info("Creating TicketDbRepository ");
        this.props = props;
    }

    public Ticket findOne(int id)
    {
        log.InfoFormat("Entering findOne with value {0}", id);
        IDbConnection con = DBUtils.getConnection(props);
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select id,clientName,numberOfSeats from Tickets where id=@id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    int idV = dataR.GetInt32(0);
                    String clientName = dataR.GetString(1);
                    int numberOfSeats = dataR.GetInt32(2);
                    Ticket ticket = new Ticket(idV, clientName, numberOfSeats);
                    log.InfoFormat("Exiting findOne with value {0}", ticket);
                    return ticket;
                }
            }
        }
        log.InfoFormat("Exiting findOne with value {0}", null);
        return null;
    }

    public IEnumerable<Ticket> findAll()
    {
        log.InfoFormat("Entering findAll");
        IDbConnection con = DBUtils.getConnection(props);
        IList<Ticket> ticketsR = new List<Ticket>();
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select id,clientName,numberOfSeats from Tickets";

            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int idV = dataR.GetInt32(0);
                    String clientName = dataR.GetString(1);
                    int numberOfSeats = dataR.GetInt32(2);
                    Ticket ticket = new Ticket(idV, clientName, numberOfSeats);
                    ticketsR.Add(ticket);
                }
            }
        }
        log.InfoFormat("Exiting findAll with value {0}", ticketsR);
        return ticketsR;
    }

    public Ticket add(Ticket entity)
    {
        var con = DBUtils.getConnection(props);
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "insert into Tickets(clientName,numberOfSeats) values (@clientName,@numberOfSeats)";
            var paramClientName = comm.CreateParameter();
            paramClientName.ParameterName = "@clientName";
            paramClientName.Value = entity.ClientName;
            comm.Parameters.Add(paramClientName);
            var paramNumberOfSeats = comm.CreateParameter();
            paramNumberOfSeats.ParameterName = "@numberOfSeats";
            paramNumberOfSeats.Value = entity.NumberOfSeats;
            comm.Parameters.Add(paramNumberOfSeats);
            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new RepositoryException("No ticket added !");
        }
        return null;
    }

    public Ticket delete(int id)
    {
        throw new NotImplementedException();
    }

    public void update(Ticket entity)
    {
        throw new NotImplementedException();
    }
}