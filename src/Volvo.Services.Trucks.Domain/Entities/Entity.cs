using System;
namespace Volvo.Services.Trucks.Domain.Entities
{
    public abstract class Entity
    {
        public long Id { get; protected set; }
        public DateTime InsertDate { get; protected set; }
        public DateTime UpdateDate { get; protected set; }
    }
}