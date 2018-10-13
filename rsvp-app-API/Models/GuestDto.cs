using System;
using System.ComponentModel.DataAnnotations;
namespace rsvpappAPI.Models
{
    public class GuestDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public bool IsConfirmed { get; set; } = false;

        public bool IsEditing { get; set; } = false;

        [Required(ErrorMessage = "Please provide a name value.")]
        public string Name { get; set; }
    }
}
