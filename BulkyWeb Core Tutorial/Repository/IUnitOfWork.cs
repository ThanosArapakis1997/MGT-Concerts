﻿namespace MGTConcerts.Repository
{
    public interface IUnitOfWork
    {
        IMusicVenueRepository MusicVenue { get; }
        IArtistRepository Artist { get; }
        IConcertRepository Concert { get; }
        IOrderRepository Order { get; }

        void Save();
    }
}
