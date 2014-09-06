namespace Atm.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Atm.Models.Contracts;

    public class CardHolder : ICardHolder
    {
        private ICollection<CardAccount> cardAccounts;

        public CardHolder()
        {
            this.cardAccounts = new HashSet<CardAccount>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal Balance
        {
            get
            {
                return this.CardAccounts.Select(ca => ca.CardCash).Sum();
            }
        }
        
        public virtual ICollection<CardAccount> CardAccounts 
        { 
            get
            {
                return this.cardAccounts;
            }

            private set
            {
                this.cardAccounts = value;
            } 
        }
    }
}