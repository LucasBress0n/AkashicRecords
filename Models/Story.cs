using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AkashicRecords.Models.DTOs;

namespace AkashicRecords.Models;

public class Story
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public string Summary { get; set; }
    public string Image { get; set; }

    [ForeignKey("StoryLanguage")]
    public int? StoryLanguageId { get; set; }

    [ForeignKey("StoryType")]
    public int? StoryTypeId { get; set; }

    [Required]
    public DateTime DateCreated { get; set; }
    public DateTime LastUpdated { get; set; }
    public List<StoryChapter> StoryChapters { get; set; }
    public StoryLanguage StoryLanguage { get; set; }
    public StoryType StoryType { get; set; }
}
