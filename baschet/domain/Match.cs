using System;
using baschet.domain;

public class Match : Entity<int>
{
    private string _teamA;
    private string _teamB;
    private double _ticketPrice;
    private int _totalSeats;
    private int _soldSeats;

    public Match(int id, string teamA, string teamB, double ticketPrice, int totalSeats, int soldSeats) : base(id)
    {
        this._teamA = teamA;
        this._teamB = teamB;
        this._ticketPrice = ticketPrice;
        this._totalSeats = totalSeats;
        this._soldSeats = soldSeats;
    }

    public string TeamA
    {
        get { return _teamA; }
        set { _teamA = value; }
    }

    public string TeamB
    {
        get { return _teamB; }
        set { _teamB = value; }
    }

    public double TicketPrice
    {
        get { return _ticketPrice; }
        set { _ticketPrice = value; }
    }

    public int TotalSeats
    {
        get { return _totalSeats; }
        set { _totalSeats = value; }
    }

    public int SoldSeats
    {
        get { return _soldSeats; }
        set { _soldSeats = value; }
    }

    public override string ToString()
    {
        return $"Match{{ teamA='{_teamA}', teamB='{_teamB}', ticketPrice={_ticketPrice}, totalSeats={_totalSeats}, soldSeats={_soldSeats} }}";
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    protected bool Equals(Match other)
    {
        return base.Equals(other) && _teamA == other._teamA && _teamB == other._teamB && _ticketPrice.Equals(other._ticketPrice) && _totalSeats == other._totalSeats && _soldSeats == other._soldSeats;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), _teamA, _teamB, _ticketPrice, _totalSeats, _soldSeats);
    }
}