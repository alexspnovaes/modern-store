using MordenStore.Share.Commands;

namespace ModernStore.Domain.Commands.Inputs
{
    public class UpdateCustomerCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public  string Documment { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
