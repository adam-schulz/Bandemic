﻿using Bandemic.Data;
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

        public ArtistService() {}

        public ArtistDetail GetArtistDetailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var artist = ctx.Artists.Single(a => a.ArtistId == id);
                return new ArtistDetail
                {
                    ArtistId = artist.ArtistId,
                    ArtistName = artist.ArtistName,
                    Genre = artist.Genre
                };
            }
        }

        public bool CreateArtist(ArtistCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newArtist = new Artist()
                {
                    ArtistName = model.ArtistName,
                    Genre = model.Genre
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
                    ArtistId = a.ArtistId,
                    ArtistName = a.ArtistName,
                    Genre = a.Genre
                });

                return query.ToArray();
            }
        }

        public IEnumerable<Artist> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Artists.ToList();
            }
        }

        public bool UpdateArtist(ArtistEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var artist = ctx.Artists.Single(a => a.ArtistId == model.ArtistId);
                artist.ArtistName = model.ArtistName;
                artist.Genre = model.Genre;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArtist(int artistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(a => a.ArtistId == artistId);

                ctx.Artists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
