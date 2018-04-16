﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankApp.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
        }

        public Transaction(decimal amount, DateTime timeStamp)
        {
            Amount = amount;
            TimeStamp = timeStamp;
        }

        public long Id { get; set; }
        [Required]
        [Column("IBAN", TypeName = "nchar(20)")]
        public string Iban { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime TimeStamp { get; set; }

        [ForeignKey("Iban")]
        [InverseProperty("Transaction")]
        public Account IbanNavigation { get; set; }

        public override string ToString()
        {
            return $"\t{Amount}\t{TimeStamp}";
        }
    }
}
