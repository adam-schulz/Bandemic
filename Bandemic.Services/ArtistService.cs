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
    }
}
