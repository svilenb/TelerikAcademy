namespace ATM.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TransactionsHistory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string CardNumber { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Ammount { get; set; }
    }
}
