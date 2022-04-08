using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapikuldeep.connect;

namespace webapikuldeep.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values

        [HttpGet]
        [Route("emp/getemployee")]
        public List<my_table> Kuldeep()
        {
            kuldeepEntities obj = new kuldeepEntities();
            var res = obj.my_table.ToList();
            return res;

        }
        [HttpPost]
        [Route("emp/saveemployee")]
        public HttpResponseMessage SaveEmp(my_table Obj)
        {

            kuldeepEntities Dbcon = new kuldeepEntities();

            my_table tblEmp = new my_table();

            if (Obj.id == 0)
            {
                Dbcon.my_table.Add(Obj);
                Dbcon.SaveChanges();

            }

            else
            {
                Dbcon.Entry(Obj).State = System.Data.Entity.EntityState.Modified;
                Dbcon.SaveChanges();

            }

            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);

            return res;
        }
    }
}
