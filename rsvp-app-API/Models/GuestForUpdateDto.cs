using System;
using System.ComponentModel.DataAnnotations;
namespace rsvpappAPI.controllers
{
    public class GuestForUpdateDto
    {
            public bool IsConfirmed { get; set; } = false;

            public bool IsEditing { get; set; } = false;

            public string Name { get; set; }
    }
}
