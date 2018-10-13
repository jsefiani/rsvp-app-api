using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using rsvpappAPI.Models;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Identity.UI.Pages;

namespace rsvpappAPI.controllers
{
    [Route("api/guests")]
    [Produces("application/json")]
    public class GuestsController : Controller
    {
        /// <summary>
        /// Gets the guests.
        /// </summary>
        /// <returns>The guests.</returns>
        [HttpGet()]
        public IActionResult GetGuests()
        {
            // Status code 200
            return Ok(GuestsDataStore.Current.Guests);
        }


        /// <summary>
        /// Get guest
        /// </summary>
        /// <returns>The guest.</returns>
        /// <param id="guestId">Guest identifier.</param>
        [HttpGet("{guestId}", Name = "GetGuest")]
        public IActionResult GetGuest(Guid guestId) 
        {
            var guest = GuestsDataStore.Current.Guests.FirstOrDefault(g => g.Id == guestId);

            if(guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }


        /// <summary>
        /// Adds the guest.
        /// </summary>
        /// <returns>The guest.</returns>
        /// <param name="guest">Guest.</param>
        [HttpPost()]
        public IActionResult AddGuest([FromBody] GuestForUpdateDto guest)
        {
            if(guest.Name == null) 
            {
                return BadRequest();
            }

            var newGuest = new GuestDto() 
            { 
                Name = guest.Name,
            };

            GuestsDataStore.Current.Guests.Add(newGuest);

            var id = Guid.NewGuid();

            // Return response
            return CreatedAtRoute("GetGuest", new {
                guestId = id
            }, newGuest);
        }


        /// <summary>
        /// Removes the guest.
        /// </summary>
        /// <returns>No content</returns>
        /// <param name="guestId">Guest identifier.</param>
        [HttpDelete("{guestId}")]
        public IActionResult RemoveGuest(Guid guestId)
        {
            var guest = GuestsDataStore.Current.Guests.FirstOrDefault(g => g.Id == guestId);

            if (guest == null)
            {
                return NotFound("Guest is null");
            }

            GuestsDataStore.Current.Guests.Remove(guest);

            return NoContent();
        }

        /// <summary>
        /// Updates the guest.
        /// User can update the name of the guest and/or the isConfirmed property
        /// </summary>
        /// <returns>No content</returns>
        /// <param name="guestId">Guest identifier.</param>
        /// <param name="updates">Updated guest.</param>
        [HttpPut("{guestId}")]
        public IActionResult UpdateGuest(Guid guestId, [FromBody] GuestForUpdatesDto updates) 
        {


            if(updates == null)
            {
                return BadRequest();
            }

            var guest = GuestsDataStore.Current.Guests.FirstOrDefault(g => g.Id == guestId);

            if (guest == null)
            {
                return NotFound();
            }

            // Update guest
            guest.Name = updates.Name;
            guest.IsConfirmed = updates.IsConfirmed;

            // Nothing to return 
            return NoContent();

        }
    }
}
