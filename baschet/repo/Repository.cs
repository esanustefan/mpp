
using baschet.domain;

namespace baschet.repo;

using System.Collections.Generic;
using System;

public class RepositoryException:ApplicationException{
    public RepositoryException() { }
    public RepositoryException(String mess) : base(mess){}
    public RepositoryException(String mess, Exception e) : base(mess, e) { }
}

public interface IRepository<TId, TE> where TE : Entity<TId> {
    TE findOne(TId id);

    IEnumerable<TE> findAll();


    TE add(TE entity);


    TE delete(TId id);

    void update(TE entity);
}