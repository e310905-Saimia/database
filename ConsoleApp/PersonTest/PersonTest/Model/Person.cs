using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonTest.Model
{
    public partial class Person
    {
        public long Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string Sex { get; set; }
        [Column(TypeName = "nchar(10)")]
        public string EyeColor { get; set; }
        public int? ShoeSize { get; set; }
        public int? Height { get; set; }
    }
}
