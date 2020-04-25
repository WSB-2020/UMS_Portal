using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMS_Portal.Models
{
    public class LectureModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ApplicationUser Teacher { get; set; }

    }
}