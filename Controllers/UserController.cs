using AkashicRecords.Data;
using AkashicRecords.Models;
using AkashicRecords.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AkashicRecords.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserController : ControllerBase
{
    private AkashicRecordsDbContext db;

    public UserController(AkashicRecordsDbContext context)
    {
        db = context;
    }

    [HttpGet("{UserId}")]
    [Authorize]
    public IActionResult GetUserByIdWithStories(int UserId)
    {
        return Ok(
            db.UserProfiles.Include(up => up.IdentityUser)
                .Include(up => up.StoriesAuthors.Where(su => su.IsOwner == true))
                .ThenInclude(su => su.Story)
                .Select(up => new UserProfileWithStoriesDTO
                {
                    Id = up.Id,
                    FirstName = up.FirstName,
                    LastName = up.LastName,
                    Address = up.Address,
                    Email = up.IdentityUser.Email,
                    UserName = up.IdentityUser.Email,
                    StoriesAuthors = up
                        .StoriesAuthors.Select(sa => new StoriesAuthorDTO
                        {
                            Id = sa.Id,
                            UserId = sa.Id,
                            StoryId = sa.StoryId,
                            IsAdmin = sa.IsAdmin,
                            IsOwner = sa.IsAdmin,
                            IsInvite = sa.IsInvite,
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
                        .ToList()
                })
                .Single(i => i.Id == UserId)
        );
    }
}
