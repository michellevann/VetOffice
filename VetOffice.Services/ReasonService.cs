using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetOffice.Data;
using VetOffice.Models;

namespace VetOffice.Services
{
    public class ReasonService
    {
        private readonly Guid _userId;
        public ReasonService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReason(ReasonCreate model)
        {
            var entity = new Reason()
            {
                OwnerId = _userId,
                ReasonForVisit = model.ReasonForVisit
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reasons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReasonListItem> GetReasons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Reasons
                    .Where(e => e.OwnerId == _userId)
                    .Select(e => new ReasonListItem
                    {
                        ReasonId = e.ReasonId,
                        ReasonForVisit = e.ReasonForVisit
                    });
                return query.ToArray();
            }
        }

        public ReasonDetail GetReasonById(int reasonId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Reasons
                    .Single(e => e.ReasonId == reasonId && e.OwnerId == _userId);
                return new ReasonDetail
                {
                    ReasonId = entity.ReasonId,
                    ReasonForVisit = entity.ReasonForVisit
                };
            }
        }
    }
}
