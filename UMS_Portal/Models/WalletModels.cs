using Microsoft.AspNetCore.JsonPatch.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UMS_Portal.Models
{
    public class WalletModel
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }
        public bool IsBlocked { get; set; }

        public virtual ICollection<AccountOperation> Operations { get; set; }
        public virtual ApplicationUser User { get; set; }

        [NotMapped]
        public double WalletValue
        {
            get
            {
                if (Operations != null && Operations.Count() > 0)
                {
                    return Operations.Sum(o => o.Amount);
                }

                return 0D;
            }
        }
    }


    public class AccountOperation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime OperationDate { get; set; }
        public bool IsPosted { get; set; }

        [ForeignKey("Wallet")]
        public string WalletId { get; set; }
        public virtual WalletModel Wallet { get; set; }

        [ForeignKey("CourseFee")]
        public int? CourseFeeId { get; set; }
        public virtual CourseModel CourseFee { get; set; }
    }
}