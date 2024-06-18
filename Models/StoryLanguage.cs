using System.ComponentModel.DataAnnotations;
using AkashicRecords.Models.DTOs;

namespace AkashicRecords.Models;

public class StoryLanguage
{
    public int Id { get; set; }

    [Required]
    public string StoriesLanguage { get; set; }
}
