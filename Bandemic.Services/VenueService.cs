﻿using Bandemic.Data;
using Bandemic.Models.Venue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandemic.Services
{
    public class VenueService
    {
        private Guid userId;

        public bool CreateVenue(VenueCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newVenue = new Venue()
                {
                    VenueName = model.VenueName,
                    VenueAddress = model.VenueAddress,
                    VenueLocation = model.VenueLocation
                };

                ctx.Venues.Add(newVenue);
                return ctx.SaveChanges() == 1;
            }
        }

        public VenueService() { }

        public VenueService(Guid userId)
        {
            this.userId = userId;
        }

        public VenueDetail GetVenueDetailById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var venue = ctx.Venues.Single(v => v.VenueId == id);
                return new VenueDetail
                {
                    VenueId = venue.VenueId,
                    VenueName = venue.VenueName,
                    VenueAddress = venue.VenueAddress,
                    VenueLocation = venue.VenueLocation
                };
            }
        }

        public IEnumerable<VenueListItem> GetVenueList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Venues.Select(v => new VenueListItem
                {
                    VenueId = v.VenueId,
                    VenueName = v.VenueName,
                    VenueAddress = v.VenueAddress,
                    VenueLocation = v.VenueLocation
                });

                return query.ToArray();
            }
        }

        public IEnumerable<Venue> GetVenues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Venues.ToList();
            }
        }

        public bool UpdateVenue(VenueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var venue = ctx.Venues.Single(v => v.VenueId == model.VenueId);
                venue.VenueName = model.VenueName;
                venue.VenueAddress = model.VenueAddress;
                venue.VenueLocation = model.VenueLocation;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVenue(int venueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Venues
                        .Single(v => v.VenueId == venueId);

                ctx.Venues.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
