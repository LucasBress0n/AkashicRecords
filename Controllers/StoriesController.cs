using AkashicRecords.Data;
using AkashicRecords.Models;
using AkashicRecords.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet("{Id}")]
    [Authorize]
    public IActionResult GetStoryWithChapters(int Id)
    {
        return Ok(
            db.Stories.Include(s => s.StoryChapters)
                .Select(s => new StoryWithChaptersDTO
                {
                    Id = s.Id,
                    Title = s.Title,
                    Summary = s.Summary,
                    Image = s.Image,
                    DateCreated = s.DateCreated,
                    LastUpdated = s.LastUpdated,
                    StoryChapters = s
                        .StoryChapters.OrderBy(sc => sc.ChapterIndexId)
                        .Select(sc => new StoryChapterDTO
                        {
                            Id = sc.Id,
                            StoryId = sc.StoryId,
                            ChapterIndexId = sc.ChapterIndexId,
                            ChapterTitle = sc.ChapterTitle,
                            AuthorNotes = sc.AuthorNotes,
                            StoryContent = sc.StoryContent,
                            DateCreated = sc.DateCreated
                        })
                        .ToList()
                })
                .Single(i => i.Id == Id)
        );
    }

    [HttpPost]
    [Authorize]
    public IActionResult PostNewStoryInitial(StoriesAuthor StoriesAuthorData)
    {
        Story NewStory = new Story
        {
            Title = StoriesAuthorData.Story.Title,
            Summary = StoriesAuthorData.Story.Summary,
            Image = StoriesAuthorData.Story.Image,
            DateCreated = DateTime.Now,
            LastUpdated = DateTime.Now
        };

        db.Stories.Add(NewStory);
        db.SaveChanges();

        StoriesAuthor NewStoryAuthor = new StoriesAuthor
        {
            UserId = StoriesAuthorData.UserId,
            StoryId = NewStory.Id,
            IsAdmin = StoriesAuthorData.IsAdmin,
            IsOwner = StoriesAuthorData.IsOwner,
            DateAdded = DateTime.Now
        };

        db.StoriesAuthors.Add(NewStoryAuthor);
        db.SaveChanges();

        List<StoryChapter> NewStoryChapter = StoriesAuthorData
            .Story.StoryChapters.Select(sc => new StoryChapter
            {
                StoryId = NewStory.Id,
                ChapterIndexId = sc.ChapterIndexId,
                ChapterTitle = sc.ChapterTitle,
                AuthorNotes = sc.AuthorNotes,
                StoryContent = sc.StoryContent,
                DateCreated = DateTime.Now
            })
            .ToList();

        foreach (StoryChapter newTempStoryChapter in NewStoryChapter)
        {
            db.StoryChapters.Add(newTempStoryChapter);
            db.SaveChanges();
        }

        return Ok();
    }

    [HttpPut]
    [Authorize]
    public IActionResult UpdateStory(NewEditStoryDTO EditedStory)
    {
        StoryDTO StoryData = new StoryDTO
        {
            Id = EditedStory.Id,
            Title = EditedStory.Title,
            Summary = EditedStory.Summary,
            Image = EditedStory.Image,
            DateCreated = EditedStory.DateCreated,
            LastUpdated = EditedStory.LastUpdated
        };

        Story StoryFound = db.Stories.FirstOrDefault(i => i.Id == StoryData.Id);

        if (StoryFound == null)
        {
            return NoContent();
        }

        StoryFound.Title = StoryData.Title;
        StoryFound.Summary = StoryData.Summary;
        StoryFound.Image = StoryData.Image;
        StoryFound.LastUpdated = DateTime.Now;

        db.SaveChanges();

        List<NewEditStoryChapterDTO> StoryChapterData = EditedStory
            .StoryChapters.Select(sc => new NewEditStoryChapterDTO
            {
                Id = sc.Id,
                StoryId = sc.StoryId,
                ChapterIndexId = sc.ChapterIndexId,
                ChapterTitle = sc.ChapterTitle,
                AuthorNotes = sc.AuthorNotes,
                StoryContent = sc.StoryContent,
                IsNew = sc.IsNew
            })
            .ToList();

        foreach (NewEditStoryChapterDTO storyChapterEdited in StoryChapterData)
        {
            if (storyChapterEdited.IsNew == false)
            {
                StoryChapter StoryChapterToEdit = db.StoryChapters.SingleOrDefault(i =>
                    i.Id == storyChapterEdited.Id
                );

                StoryChapterToEdit.StoryId = StoryFound.Id;
                StoryChapterToEdit.ChapterIndexId = storyChapterEdited.ChapterIndexId;
                StoryChapterToEdit.ChapterTitle = storyChapterEdited.ChapterTitle;
                StoryChapterToEdit.AuthorNotes = storyChapterEdited.AuthorNotes;
                StoryChapterToEdit.StoryContent = storyChapterEdited.StoryContent;

                db.SaveChanges();
            }
            else if (storyChapterEdited.IsNew == true)
            {
                db.StoryChapters.Add(
                    new StoryChapter
                    {
                        StoryId = StoryFound.Id,
                        ChapterIndexId = storyChapterEdited.ChapterIndexId,
                        ChapterTitle = storyChapterEdited.ChapterTitle,
                        AuthorNotes = storyChapterEdited.AuthorNotes,
                        StoryContent = storyChapterEdited.StoryContent,
                        DateCreated = DateTime.Now
                    }
                );
                db.SaveChanges();
            }
        }

        return Ok();
    }
}
