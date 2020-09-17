using Bandemic.Data;
using Bandemic.Models.TourDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Services
{
    public class TourDateService
    {
        private Guid userId;

        public TourDateService(Guid userId)
        {
            this.userId = userId;
        }

        public TourDateService()
        {
        }

        public TourDateDetail GetTourDateDetailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var tourDate = ctx.TourDates.Single(t => t.TourDateId == id);
                return new TourDateDetail
                {
                    TourDateId = tourDate.TourDateId,
                    DateOfShow = tourDate.DateOfShow,
                    ArtistName = tourDate.Artist.ArtistName,
                    VenueName = tourDate.Venue.VenueName
                };
            }
        }
        public bool CreateTourDate(TourDateCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newTourDate = new TourDate()
                {
                    DateOfShow = model.DateOfShow,
                    ArtistId = model.ArtistId,
                    VenueId = model.VenueId

                };

                ctx.TourDates.Add(newTourDate);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<TourDateListItem> GetTourDateList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.TourDates.Select(t => new TourDateListItem
                {
                    TourDateId = t.TourDateId,
                    DateOfShow = t.DateOfShow,
                    ArtistId = t.ArtistId,
                    VenueId = t.VenueId,
                    
                });

                return query.ToArray();
            }
        }
        public bool UpdateTourDate(TourDateEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var tourDate = ctx.TourDates.Single(t => t.TourDateId == model.TourDateId);
                tourDate.DateOfShow = model.DateOfShow;
                tourDate.ArtistId = model.ArtistId;
                tourDate.VenueId = model.VenueId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTourDate(int tourDateId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TourDates
                        .Single(t => t.TourDateId == tourDateId);

                ctx.TourDates.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
