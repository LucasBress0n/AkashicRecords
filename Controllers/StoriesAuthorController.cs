using AkashicRecords.Data;
using AkashicRecords.Models;
using AkashicRecords.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AkashicRecords.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class StoriesAuthorController : ControllerBase
{
    private AkashicRecordsDbContext db;

    public StoriesAuthorController(AkashicRecordsDbContext context)
    {
        db = context;
    }

    [HttpGet("{UserId}")]
    [Authorize]
    public IActionResult GetAllUsersStories(int UserId)
    {
        return Ok(
            db.StoriesAuthors.Where(sa => sa.UserId == UserId)
                .Include(sa => sa.Story)
                .Select(sa => new StoriesAuthorDTO
                {
                    Id = sa.Id,
                    UserId = sa.UserId,
                    StoryId = sa.StoryId,
                    IsAdmin = sa.IsAdmin,
                    IsOwner = sa.IsOwner,
                    DateAdded = sa.DateAdded,
                    Story = new StoryDTO
                    {
                        Id = sa.Story.Id,
                        Title = sa.Story.Title,
                        Summary = sa.Story.Summary,
                        Image = sa.Story.Image,
                        DateCreated = sa.Story.DateCreated,
                        LastUpdated = sa.Story.LastUpdated
                    }
                })
        );
    }

    [HttpGet]
    [Authorize]
    public IActionResult GetStoryAuthorByObject(int? UserId, int StoryId)
    {
        StoriesAuthor foundAuthor = db
            .StoriesAuthors.Where(sa => sa.StoryId == StoryId && sa.UserId == UserId)
            .FirstOrDefault();

        if (foundAuthor != null)
        {
            return Ok(foundAuthor);
        }

        return NotFound();
    }
}
