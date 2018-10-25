using System;
using System.ComponentModel.DataAnnotations;
using DDD.EDT.Commons;

namespace DDD.EDT.Domain
{
    public class Masterpiece : AggregateRootBase
    {
        public Guid Id { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }
    }
}