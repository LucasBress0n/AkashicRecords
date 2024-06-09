using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace AkashicRecords.Models;

public class UserProfile
{
    public int Id { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string LastName { get; set; }

    [StringLength(50, MinimumLength = 5)]
    public string Address { get; set; }

    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }
    public DateTime DateCreated { get; set; }
}
