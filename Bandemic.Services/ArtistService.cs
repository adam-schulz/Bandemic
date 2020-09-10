using Bandemic.Data;
using Bandemic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Services
{
    public class ArtistService
    {
        private readonly Guid _userId;

        public ArtistService(Guid userId)
        {
            _userId = userId;
        }

        public ArtistDetail GetArtistDetailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var artist = ctx.Artists.Single(a => a.Id == id);
                return new ArtistDetail
                {
                    ArtistId = artist.Id,
                    ArtistName = artist.ArtistName
                };
            }
        }

        public bool CreateArtist(ArtistCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newArtist = new Artist()
                {
                    ArtistName = model.ArtistName
                };

                ctx.Artists.Add(newArtist);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistListItem> GetArtistList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Artists.Select(a => new ArtistListItem
                {
                    ArtistId = a.Id,
                    ArtistName = a.ArtistName
                });

                return query.ToArray();
            }
        }

        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var artist = ctx.Artists.Single(a => a.Id == model.ArtistId);
                artist.ArtistName = model.ArtistName;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
