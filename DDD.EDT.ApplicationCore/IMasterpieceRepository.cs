using System;
using DDD.EDT.Domain;

namespace DDD.EDT.ApplicationCore
{
    public interface IMasterpieceRepository
    {
        Masterpiece GetMasterpiece(Guid masterpieceId);
    }
}