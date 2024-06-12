using AkashicRecords.Data;
using AkashicRecords.Models;
using AkashicRecords.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AkashicRecords.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class StoryChapterController : ControllerBase
{
    private AkashicRecordsDbContext db;

    public StoryChapterController(AkashicRecordsDbContext context)
    {
        db = context;
    }

    [HttpDelete("{ChapterId}")]
    [Authorize]
    public IActionResult DeleteChapter(int ChapterId)
    {
        StoryChapter storyChapter = db.StoryChapters.FirstOrDefault(sc => sc.Id == ChapterId);

        db.Remove(storyChapter);
        db.SaveChanges();
        return Ok();
    }
}
