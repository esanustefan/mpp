using System;

namespace baschet.repo;

public interface MatchRepository: IRepository<int, Match>
{
    Boolean CheckAvailableSeats(Match match, int numberOfSeats);
}