using CarShow.Data;
using CarShow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShow.Services
{
    public class VoteService
    {
        private readonly Guid _userId;

        public VoteService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateVote(VoteCreate model)
        {
            var entity =
                new Vote()
                {
                    OwnerId = _userId,
                    Paint = model.Paint,
                    Engine = model.Engine,
                    Interior = model.Interior,
                    BestOfShow = model.BestOfShow,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Votes.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<VoteListItems> Getvotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                 ctx
                     .Votes
                     .Where(e => e.OwnerId == _userId)
                     .Select
                     (e =>
                     new VoteListItems
                     {
                         OwnerId = _userId,
                         Paint = e.Paint,
                         Engine = e.Engine,
                         Interior = e.Interior,
                         BestOfShow = e.BestOfShow,
                         CreatedUtc = DateTimeOffset.Now,
                     }
                     );
                return query.ToArray();
            }
        }
        public VoteDetail GetVoteById(int voteId)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Votes.Single(e => e.CarId == voteId && e.OwnerId == _userId);

                return new VoteDetail
                {
                    OwnerId = _userId,
                    Paint = entity.Paint,
                    Engine = entity.Engine,
                    Interior = entity.Interior,
                    BestOfShow = entity.BestOfShow,
                    CreatedUtc = DateTimeOffset.Now,
                };

            }
        }
        public bool UpdateVote(VoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Votes.Single(e => e.OwnerId == _userId);

                entity.CarId = model.CarId;
                entity.OwnerId = model.OwnerId;
                entity.Paint = model.Paint;
                entity.Engine = model.Engine;
                entity.Interior = model.Interior;
                entity.BestOfShow = model.BestOfShow;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }


        }
    }
}
   



          

