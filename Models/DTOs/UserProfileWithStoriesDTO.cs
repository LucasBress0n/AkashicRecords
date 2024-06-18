using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace AkashicRecords.Models.DTOs;

public class UserProfileWithStoriesDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string IdentityUserId { get; set; }

    public IdentityUser IdentityUser { get; set; }

    public string FullName
    {
        get { return FirstName + " " + LastName; }
    }

    public List<StoriesAuthorDTO> StoriesAuthors { get; set; }
}
