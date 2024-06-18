using System.ComponentModel.DataAnnotations;
using AkashicRecords.Models.DTOs;

namespace AkashicRecords.Models;

public class StoryTag
{
    public int Id { get; set; }

    [Required]
    public int StoryId { get; set; }

    [Required]
    public int TagId { get; set; }
}
