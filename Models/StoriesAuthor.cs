
using System.ComponentModel.DataAnnotations;

namespace AkashicRecords.Models;

public class StoriesAuthor {
    public int Id {get;set;}
    [Required]

    public int UserId {get;set;}
    [Required]

    public int StoryId {get;set;}
    public bool IsAdmin {get;set;}
    public bool IsOwner {get;set;}
    [Required]

    public DateTime DateAdded {get;set;}
}