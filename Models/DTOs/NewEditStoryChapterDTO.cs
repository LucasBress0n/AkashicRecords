using System.ComponentModel.DataAnnotations;

namespace AkashicRecords.Models.DTOs;

public class NewEditStoryChapterDTO
{
    public int Id { get; set; }
    public int StoryId { get; set; }
    public int ChapterIndexId { get; set; }
    public string ChapterTitle { get; set; }
    public string AuthorNotes { get; set; }
    public string StoryContent { get; set; }
    public DateTime DateCreated { get; set; }
    public bool IsNew { get; set; }
}
