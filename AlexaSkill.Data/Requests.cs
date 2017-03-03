using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkill.Data
{
    public class Requests
    {
        public Request Create(Request request)
        {
            using (var db = new monsalexa_dbEntities())
            {
                var member = db.Members.FirstOrDefault(m => m.AlexaUserId == request.UserId);

                if (member == null)
                {
                    request.Member = new Member()
                    {
                        AlexaUserId = request.UserId,
                        CreatedDate = DateTime.UtcNow,
                        LastRequestDate = DateTime.UtcNow,
                        RequestCount = 1
                    };
                }
                else
                {
                    member.Requests.Add(request);
                }

                db.SaveChanges();
            }

            return request;
        }
    }
}
