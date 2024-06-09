using System.ComponentModel.DataAnnotations;

namespace AkashicRecords.Models.DTOs;

public class RegistrationDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string UserName { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string FirstName { get; set; }
    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string LastName { get; set; }
    [Required]
    public string Address { get; set; }

}