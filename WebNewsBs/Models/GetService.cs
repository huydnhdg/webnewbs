using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNewsBs.Models
{
    public class GetService
    {
        public static List<Service> dichvu = service();
        
        static List<Service> service()
        {
            Entities db = new Entities();
            var data = (from d in db.Services
                        orderby d.service_id
                        select d).ToList();
            if (data.Count > 0)
            {
                return data;
            }
            return null;
        }
        
    }
}