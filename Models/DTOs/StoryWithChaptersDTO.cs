using System.ComponentModel.DataAnnotations;

namespace AkashicRecords.Models.DTOs;

public class StoryWithChaptersDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Image { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime LastUpdated { get; set; }
    public List<StoryChapterDTO> StoryChapters { get; set; }
}
