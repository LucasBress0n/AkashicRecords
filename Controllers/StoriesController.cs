using AkashicRecords.Data;
using AkashicRecords.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AkashicRecords.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class StoriesController : ControllerBase
{
    private AkashicRecordsDbContext db;

    public StoriesController(AkashicRecordsDbContext context)
    {
        db = context;
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetAllStories()
    {
        return Ok(
            db.Stories.Select(s => new StoryDTO
            {
                Id = s.Id,
                Title = s.Title,
                Summary = s.Summary,
                Image = s.Image,
                DateCreated = s.DateCreated,
                LastUpdated = s.LastUpdated
            })
        );
    }
}
