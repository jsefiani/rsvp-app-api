using System;
using System.ComponentModel.DataAnnotations;
namespace rsvpappAPI.controllers
{
    public class GuestForCreationDto
    {
            public bool IsConfirmed { get; set; } = false;

            public bool IsEditing { get; set; } = false;

            public string Name { get; set; }
    }
}
