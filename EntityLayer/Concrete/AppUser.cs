using EntityLayer.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>,IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Post> Posts { get; set; }

        //comment i bağla
        //users tablosuna imageurl ekle ve yorumlar tarafında image tarafında appuser.imageurl olarak çek
        //wwwroot tarafındaki image klasörünün yolunu ver
    }
}
