using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Post : IEntity
    {
        [Key]
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public DateTime CreateDate { get; set; }
        public bool PostStatus { get; set; }
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
