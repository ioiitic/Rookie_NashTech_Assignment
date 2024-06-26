﻿using R2EShop.Domain.Common;
using R2EShop.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace R2EShop.Domain.Entities
{
    public class PhoneCase : Entity
    {
        public string PhoneCaseName { get; set; } = string.Empty;
        public double PhoneCasePrice { get; set; } = 0;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        public virtual Guid DeviceId { get; set; }
        public virtual Guid CaseTypeId { get; set; }
        public virtual Guid CaseColorId { get; set; }
        public virtual Guid ArtworkId { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();

        public PhoneCase()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
