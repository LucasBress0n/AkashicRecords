using System.ComponentModel.DataAnnotations;

namespace AkashicRecords.Models;

public class StoryChapter
{
    public int Id { get; set; }

    [Required]
    public int StoryId { get; set; }

    [Required]
    public int ChapterIndexId { get; set; }

    [Required]
    public string ChapterTitle { get; set; }
    public string AuthorNotes { get; set; }

    [Required]
    public string StoryContent { get; set; }

    [Required]
    public DateTime DateCreated { get; set; }
}
