﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ST.Domain.Commons
{
    public class AuditEntity : IAuditInfo
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}