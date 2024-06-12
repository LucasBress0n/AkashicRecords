using System.ComponentModel.DataAnnotations;

namespace AkashicRecords.Models.DTOs;

public class StoriesAuthorDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int StoryId { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsOwner { get; set; }
    public DateTime DateAdded { get; set; }
    public StoryDTO Story { get; set; }
}
