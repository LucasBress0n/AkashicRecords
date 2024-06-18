using System.ComponentModel.DataAnnotations;
using AkashicRecords.Models.DTOs;

namespace AkashicRecords.Models;

public class StoryType
{
    public int Id { get; set; }

    [Required]
    public string StoriesType { get; set; }
}
