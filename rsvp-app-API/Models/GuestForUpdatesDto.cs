using System;
namespace rsvpappAPI.Models
{
    public class GuestForUpdatesDto
    {
        public bool IsConfirmed { get; set; } = false;

        public bool IsEditing { get; set; } = false;

        public string Name { get; set; }
    }
}
