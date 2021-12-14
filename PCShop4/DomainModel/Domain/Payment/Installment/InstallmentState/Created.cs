namespace DomainModel
{
    public class Created : InstallmentState
    {
        private readonly Installment _installment;
        public Created(Installment installment)
        {
            _installment = installment;
        }
        public override void SetCreatedState()
        {
            _installment.AddState((InstallmentState)new Created(_installment));
        }

       

        public override void SetSuccessState()
        {
            _installment.AddState(new Paid());
        }
    }
}