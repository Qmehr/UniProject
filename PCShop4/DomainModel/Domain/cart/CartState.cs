using System;

namespace DomainModel
{
    public abstract class CartState
    {
        public Guid StateId = Guid.NewGuid();
        public DateTime PlaceState = DateTime.Now; 
        public virtual void Created(){}
        public virtual void Removed(){}
        public virtual void Installment(){}
        public virtual void ChecedOut(){}
        public virtual void Compeleted(){}
    }
}