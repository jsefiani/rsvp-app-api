using System;
using System.Collections.Generic;
using rsvpappAPI.Models;
namespace rsvpappAPI
{
    public class GuestsDataStore
    {
        public static GuestsDataStore Current { get; } = new GuestsDataStore();

        public List<GuestDto> Guests { get; set; }

        public GuestsDataStore() 
        {
            // Init dummy data
            Guests = new List<GuestDto>()
            {
                new GuestDto() 
                {
                    Name = "John",
                },
                new GuestDto()
                {
                    Name = "Jean",
                },
                new GuestDto()
                {
                    Name = "Ann",
                },
                new GuestDto()
                {
                    Name = "Koen",
                },
                new GuestDto()
                {
                    Name = "Joepu",
                },
                new GuestDto()
                {
                    Name = "Naruto",
                },
                new GuestDto()
                {
                    Name = "Sasuke",
                },
            };
        }
    }
}
