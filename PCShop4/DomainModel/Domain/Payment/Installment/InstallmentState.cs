using System;

namespace DomainModel
{
    public abstract class InstallmentState
    {
        public Guid InstallmentId = Guid.NewGuid();
        private DateTime __datetime = DateTime.Now;
        public virtual void SetCreatedState() { }
        public virtual void SetSuccessState() { }
    }
}