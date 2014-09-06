namespace Atm.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Atm.Models.Contracts;

    public class CardAccount : ICardAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(10, MinimumLength = 10)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(4)]
        public string CardPin { get; set; }

        [DataType(DataType.Currency)]
        public decimal CardCash { get; set; }

        public int CardHolderId { get; set; }

        [ForeignKey("CardHolderId")]
        public virtual CardHolder CardHolder { get; set; }
    }
}