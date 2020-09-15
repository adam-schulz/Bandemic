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
        public TourDateDetail GetTourDateDetailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var tourDate = ctx.TourDates.Single(t => t.TourDateId == id);
                return new TourDateDetail
                {
                    TourDateId = tourDate.TourDateId,
                    DateOfShow = tourDate.DateOfShow
                };
            }
        }
        public bool CreateTourDate(TourDateCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newTourDate = new TourDate()
                {
                    DateOfShow = model.DateOfShow
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
                    DateOfShow = t.DateOfShow
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

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
