namespace Atm.Models.Contracts
{
    public interface ICardAccount
    {
        int Id { get; set; }

        string CardNumber { get; set; }

        string CardPin { get; set; }

        decimal CardCash { get; set; }

        int CardHolderId { get; set; }
    }
}