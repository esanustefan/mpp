using System;
using System.Collections.Generic;
using APP_BASCHET.domain;
using baschet.domain;
using baschet.repo;

namespace baschet.Service;

public class Service
{
    private TicketRepository ticketRepo;
    private IUserRepository userRepo;
    private MatchRepository matchRepo;
    
    public Service(IUserRepository userRepo, MatchRepository matchRepo, TicketRepository ticketRepo)
    {
        this.userRepo = userRepo;
        this.matchRepo = matchRepo;
        this.ticketRepo = ticketRepo;
    }
    

    public void addTicket(int id, string clientName, int numberOfSeats)
    {
        Ticket ticket = new Ticket(id, clientName, numberOfSeats);
        ticketRepo.add(ticket);
    }
    
    public void addUser(int id, string username, string password)
    {
        User user = new User(id, username, password);
        userRepo.add(user);
    }
    
    public void addMatch(int id, string team1, string team2, double ticketPrice,  int soldSeats)
    {
        Match match = new Match(id, team1, team2, ticketPrice, soldSeats);
        matchRepo.add(match);
    }
  
    
    
    public IEnumerable<Ticket> getAllTickets()
    {
        return ticketRepo.findAll();
    }
    
    public IEnumerable<User> getAllUsers()
    {
        return userRepo.findAll();
    }
    
    public IEnumerable<Match> getAllMatches()
    {
        return matchRepo.findAll();
    }
    
    public void deleteTicket(int id)
    {
        ticketRepo.delete(id);
    }
    
    public void deleteUser(int id)
    {
        userRepo.delete(id);
    }
    
    public void deleteMatch(int id)
    {
        matchRepo.delete(id);
    }
    
   
    
    public void updateMatch(int id, string team1, string team2, double ticketPrice, int soldSeats)
    {
        Match match = new Match(id, team1, team2,  ticketPrice, soldSeats);
        matchRepo.update(match);
    }
  
    public Ticket findOneTicket(int id)
    {
        return ticketRepo.findOne(id);
    }
    
    
    public User findOneUser(int id)
    {
        return userRepo.findOne(id);
    }
    
    public Match findOneMatch(int id)
    {
        return matchRepo.findOne(id);
    }
    
    public Boolean CheckifUserExists(string username, string password)
    {
        return userRepo.CheckifUserExists(username, password);
    }
    
    public Boolean CheckAvailableSeats(Match match, int numberOfSeats)
    {
        return matchRepo.CheckAvailableSeats(match, numberOfSeats);
    }
    
    
    
}