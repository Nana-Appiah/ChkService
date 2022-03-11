﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChequeBookService.Models
{
    [Table("ChequeBook")]
    public partial class ChequeBook
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ChqOrderDate { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string AccountNumber { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string AccountName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string AccountClass { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string ChequeType { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Notes { get; set; }
        public int? Leaves { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string ChequeNumber { get; set; }
        [Column("ReferenceID")]
        [StringLength(60)]
        [Unicode(false)]
        public string ReferenceId { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string ReferenceNo { get; set; }
        public int? BranchCode { get; set; }
        [StringLength(60)]
        [Unicode(false)]
        public string TelephoneNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateUpload { get; set; }
    }
}