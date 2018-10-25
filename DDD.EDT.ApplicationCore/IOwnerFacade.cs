using System;
using DDD.EDT.Domain;

namespace DDD.EDT.ApplicationCore
{
    public interface IOwnerFacade
    {
        OwnerSnapshot GetOwner(Guid ownerId);
    }
}