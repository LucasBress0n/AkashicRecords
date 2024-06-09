using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AkashicRecords.Models.DTOs;

public class UserProfileDTO
{
    public int Id { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string LastName { get; set; }

    [StringLength(30, MinimumLength = 1)]
    public string Address { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string UserName { get; set; }
    public List<string> Roles { get; set; }

    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }
}
