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
                .Where(sa => sa.IsInvite == false)
                .Select(sa => new StoriesAuthorDTO
                {
                    Id = sa.Id,
                    UserId = sa.UserId,
                    StoryId = sa.StoryId,
                    IsAdmin = sa.IsAdmin,
                    IsOwner = sa.IsOwner,
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

    [HttpGet("{StoryId}/story")]
    [Authorize]
    public IActionResult GetAllUsersForStory(int StoryId)
    {
        List<StoriesAuthorDTO> storiesAuthors = db
            .StoriesAuthors.Include(sa => sa.Story)
            .Include(sa => sa.UserProfile)
            .Where(sa => sa.StoryId == StoryId && sa.IsInvite == false)
            .Select(sa => new StoriesAuthorDTO
            {
                Id = sa.Id,
                UserId = sa.UserId,
                StoryId = sa.StoryId,
                IsAdmin = sa.IsAdmin,
                IsOwner = sa.IsOwner,
                DateAdded = sa.DateAdded,
                IsInvite = sa.IsInvite,
                Story =
                    sa.Story == null
                        ? null
                        : new StoryDTO
                        {
                            Id = sa.Story.Id,
                            Title = sa.Story.Title,
                            Summary = sa.Story.Summary,
                            Image = sa.Story.Image,
                            DateCreated = sa.Story.DateCreated,
                            LastUpdated = sa.Story.LastUpdated
                        },
                UserProfile =
                    sa.UserProfile == null
                        ? null
                        : new UserProfileDTO
                        {
                            Id = sa.UserProfile.Id,
                            FirstName = sa.UserProfile.FirstName,
                            LastName = sa.UserProfile.LastName,
                            Address = sa.UserProfile.Address,
                            Email = sa.UserProfile.IdentityUser.Email,
                            UserName = sa.UserProfile.IdentityUser.UserName
                        },
            })
            .ToList();

        return Ok(storiesAuthors);
    }

    [HttpGet("{StoryId}/invited")]
    [Authorize]
    public IActionResult GetAllInvitedUsersForStory(int StoryId)
    {
        List<StoriesAuthorDTO> storiesAuthors = db
            .StoriesAuthors.Include(sa => sa.Story)
            .Include(sa => sa.UserProfile)
            .Where(sa => sa.StoryId == StoryId && sa.IsInvite == true)
            .Select(sa => new StoriesAuthorDTO
            {
                Id = sa.Id,
                UserId = sa.UserId,
                StoryId = sa.StoryId,
                IsAdmin = sa.IsAdmin,
                IsOwner = sa.IsOwner,
                DateAdded = sa.DateAdded,
                IsInvite = sa.IsInvite,
                Story =
                    sa.Story == null
                        ? null
                        : new StoryDTO
                        {
                            Id = sa.Story.Id,
                            Title = sa.Story.Title,
                            Summary = sa.Story.Summary,
                            Image = sa.Story.Image,
                            DateCreated = sa.Story.DateCreated,
                            LastUpdated = sa.Story.LastUpdated
                        },
                UserProfile =
                    sa.UserProfile == null
                        ? null
                        : new UserProfileDTO
                        {
                            Id = sa.UserProfile.Id,
                            FirstName = sa.UserProfile.FirstName,
                            LastName = sa.UserProfile.LastName,
                            Address = sa.UserProfile.Address,
                            Email = sa.UserProfile.IdentityUser.Email,
                            UserName = sa.UserProfile.IdentityUser.UserName
                        },
            })
            .ToList();

        return Ok(storiesAuthors);
    }

    [HttpPost]
    [Authorize]
    public IActionResult CreateInviteToAUser(StoriesAuthor NewStoryAuthor, string UsersNameSearched)
    {
        UserProfile FoundUser = db
            .UserProfiles.Include(up => up.IdentityUser)
            .FirstOrDefault(up => up.IdentityUser.UserName == UsersNameSearched);

        if (FoundUser == null)
        {
            return NotFound();
        }

        StoriesAuthor InviteExists = db.StoriesAuthors.FirstOrDefault(sa =>
            sa.UserId == FoundUser.Id && sa.StoryId == NewStoryAuthor.StoryId
        );

        if (InviteExists != null)
        {
            return NoContent();
        }

        db.StoriesAuthors.Add(
            new StoriesAuthor
            {
                UserId = FoundUser.Id,
                StoryId = NewStoryAuthor.StoryId,
                IsAdmin = NewStoryAuthor.IsAdmin,
                IsOwner = NewStoryAuthor.IsOwner,
                IsInvite = NewStoryAuthor.IsInvite,
            }
        );

        db.SaveChanges();

        return Created();
    }

    [HttpGet("{UserId}/myinvites")]
    [Authorize]
    public IActionResult GetAllInvitedBelongingToAUser(int UserId)
    {
        return Ok(
            db.StoriesAuthors.Include(sa => sa.Story)
                .Include(sa => sa.UserProfile)
                .Where(sa => sa.UserId == UserId && sa.IsInvite == true)
                .Select(sa => new StoriesAuthorDTO
                {
                    Id = sa.Id,
                    UserId = sa.UserId,
                    StoryId = sa.StoryId,
                    IsAdmin = sa.IsAdmin,
                    IsOwner = sa.IsOwner,
                    DateAdded = sa.DateAdded,
                    IsInvite = sa.IsInvite,
                    Story =
                        sa.Story == null
                            ? null
                            : new StoryDTO
                            {
                                Id = sa.Story.Id,
                                Title = sa.Story.Title,
                                Summary = sa.Story.Summary,
                                Image = sa.Story.Image,
                                DateCreated = sa.Story.DateCreated,
                                LastUpdated = sa.Story.LastUpdated
                            },
                    UserProfile =
                        sa.UserProfile == null
                            ? null
                            : new UserProfileDTO
                            {
                                Id = sa.UserProfile.Id,
                                FirstName = sa.UserProfile.FirstName,
                                LastName = sa.UserProfile.LastName,
                                Address = sa.UserProfile.Address,
                                Email = sa.UserProfile.IdentityUser.Email,
                                UserName = sa.UserProfile.IdentityUser.UserName
                            },
                })
                .ToList()
        );
    }

    [HttpPut("accept")]
    [Authorize]
    public IActionResult AcceptInvite(StoriesAuthor CurrentInvite)
    {
        StoriesAuthor InviteToUpdate = db.StoriesAuthors.FirstOrDefault(sa =>
            sa.Id == CurrentInvite.Id
        );

        if (InviteToUpdate == null)
        {
            return NoContent();
        }

        InviteToUpdate.IsInvite = false;

        db.SaveChanges();

        return Ok();
    }

    [HttpDelete("decline")]
    [Authorize]
    public IActionResult DeclineInvite(StoriesAuthor CurrentInvite)
    {
        StoriesAuthor InviteToDelete = db.StoriesAuthors.FirstOrDefault(sa =>
            sa.Id == CurrentInvite.Id
        );

        if (InviteToDelete == null)
        {
            return NotFound();
        }

        db.StoriesAuthors.Remove(InviteToDelete);
        db.SaveChanges();

        return Ok();
    }
}
