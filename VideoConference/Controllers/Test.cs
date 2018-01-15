using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Concrete;

namespace VideoConference.Controllers
{
    class Test
    {
        private readonly EFDbContext db = new EFDbContext();

        public void TestRequest()
        {
            var tmp = db.conference.ToList();
        }
    }
}
