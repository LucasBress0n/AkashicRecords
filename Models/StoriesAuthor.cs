using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AkashicRecords.Models;

public class StoriesAuthor
{
    public int Id { get; set; }

    [Required]
    [ForeignKey("UserProfile")]
    public int UserId { get; set; }

    [Required]
    public int StoryId { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsOwner { get; set; }
    public bool IsInvite { get; set; }
    public DateTime DateAdded { get; set; }
    public Story Story { get; set; }
    public UserProfile UserProfile { get; set; }
}
