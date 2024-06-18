using AkashicRecords.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AkashicRecords.Data;

public class AkashicRecordsDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;

    public AkashicRecordsDbContext(
        DbContextOptions<AkashicRecordsDbContext> context,
        IConfiguration config
    )
        : base(context)
    {
        _configuration = config;
    }

    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Story> Stories { get; set; }
    public DbSet<StoriesAuthor> StoriesAuthors { get; set; }
    public DbSet<StoryChapter> StoryChapters { get; set; }
    public DbSet<StoryLanguage> StoryLanguages { get; set; }
    public DbSet<StoryType> StoryTypes { get; set; }
    public DbSet<BackgroundSound> BackgroundSounds { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    Name = "Admin",
                    NormalizedName = "admin"
                }
            );

        modelBuilder
            .Entity<IdentityUser>()
            .HasData(
                new IdentityUser[]
                {
                    new IdentityUser
                    {
                        Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                        UserName = "Administrator",
                        Email = "admina@strator.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                    new IdentityUser
                    {
                        Id = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                        UserName = "JohnDoe",
                        Email = "john@doe.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                    new IdentityUser
                    {
                        Id = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                        UserName = "JaneSmith",
                        Email = "jane@smith.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                    new IdentityUser
                    {
                        Id = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                        UserName = "AliceJohnson",
                        Email = "alice@johnson.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                    new IdentityUser
                    {
                        Id = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                        UserName = "BobWilliams",
                        Email = "bob@williams.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                    new IdentityUser
                    {
                        Id = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                        UserName = "EveDavis",
                        Email = "Eve@Davis.comx",
                        PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                            null,
                            _configuration["AdminPassword"]
                        )
                    },
                }
            );

        modelBuilder
            .Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>[]
                {
                    new IdentityUserRole<string>
                    {
                        RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                        UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                        UserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df"
                    },
                }
            );
        modelBuilder
            .Entity<UserProfile>()
            .HasData(
                new UserProfile[]
                {
                    new UserProfile
                    {
                        Id = 1,
                        IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                        FirstName = "Admina",
                        LastName = "Strator",
                        DateCreated = new DateTime(2022, 1, 25),
                    },
                    new UserProfile
                    {
                        Id = 2,
                        FirstName = "John",
                        LastName = "Doe",
                        DateCreated = new DateTime(2023, 2, 2),
                        IdentityUserId = "d8d76512-74f1-43bb-b1fd-87d3a8aa36df",
                    },
                    new UserProfile
                    {
                        Id = 3,
                        FirstName = "Jane",
                        LastName = "Smith",
                        DateCreated = new DateTime(2022, 3, 15),
                        IdentityUserId = "a7d21fac-3b21-454a-a747-075f072d0cf3",
                    },
                    new UserProfile
                    {
                        Id = 4,
                        FirstName = "Alice",
                        LastName = "Johnson",
                        DateCreated = new DateTime(2023, 6, 10),
                        IdentityUserId = "c806cfae-bda9-47c5-8473-dd52fd056a9b",
                    },
                    new UserProfile
                    {
                        Id = 5,
                        FirstName = "Bob",
                        LastName = "Williams",
                        DateCreated = new DateTime(2023, 5, 15),
                        IdentityUserId = "9ce89d88-75da-4a80-9b0d-3fe58582b8e2",
                    },
                    new UserProfile
                    {
                        Id = 6,
                        FirstName = "Eve",
                        LastName = "Davis",
                        DateCreated = new DateTime(2022, 10, 18),
                        IdentityUserId = "d224a03d-bf0c-4a05-b728-e3521e45d74d",
                    }
                }
            );
        modelBuilder
            .Entity<Story>()
            .HasData(
                new Story[]
                {
                    new()
                    {
                        Id = 1,
                        Title = "Mastering ASP.NET Core",
                        Summary = "Comprehensive guide to ASP.NET Core.",
                        DateCreated = new DateTime(2024, 4, 20),
                        LastUpdated = new DateTime(2024, 5, 15)
                    },
                    new()
                    {
                        Id = 2,
                        Title = "Advanced Entity Framework Core",
                        Summary = "In-depth exploration of Entity Framework Core features.",
                        StoryLanguageId = 1,
                        DateCreated = new DateTime(2024, 5, 10),
                        LastUpdated = new DateTime(2024, 8, 5)
                    },
                }
            );
        modelBuilder
            .Entity<StoriesAuthor>()
            .HasData(
                new StoriesAuthor[]
                {
                    new()
                    {
                        Id = 1,
                        UserId = 3,
                        StoryId = 1,
                        IsAdmin = false,
                        IsOwner = true,
                        IsInvite = false,
                        DateAdded = DateTime.Now,
                    },
                    new()
                    {
                        Id = 2,
                        UserId = 1,
                        StoryId = 2,
                        IsAdmin = false,
                        IsOwner = true,
                        IsInvite = false,
                        DateAdded = DateTime.Now,
                    }
                }
            );
        modelBuilder
            .Entity<StoryChapter>()
            .HasData(
                new StoryChapter[]
                {
                    new()
                    {
                        Id = 1,
                        StoryId = 1,
                        ChapterIndexId = 1,
                        ChapterTitle = "Wake to Weep",
                        AuthorNotes = "Rushed lowkey tbhh",
                        StoryContent =
                            @"
                        'Tis the last rose of summer,
                            Left blooming alone;
                        All her lovely companions
                            Are faded and gone;
                        No flower of her kindred,
                            No rose-bud is nigh,
                        To reflect back her blushes
                            Or give sigh for sigh!

                        I'll not leave thee, thou lone one.
                            To pine on the stem;
                        Since the lovely are sleeping,
                            Go, sleep thou with them;
                        Thus kindly I scatter
                            Thy leaves o'er the bed,
                        Where thy mates of the garden
                            Lie scentless and dead.

                        So soon may I follow,
                            When friendships decay,
                        And from love's shining circle
                            The gems drop away!
                        When true hearts lie withered,
                            And fond ones are flown,
                        Oh! who would inhabit
                            This bleak world alone?
    ",
                        DateCreated = new DateTime(2024, 4, 20)
                    },
                    new()
                    {
                        Id = 2,
                        StoryId = 2,
                        ChapterIndexId = 1,
                        ChapterTitle = "Heart Stopping Kill Shot",
                        AuthorNotes = "Meow Meow meow. Meow meow meow meow",
                        StoryContent = "Woof woof woof",
                        DateCreated = new DateTime(2024, 8, 5)
                    },
                    new()
                    {
                        Id = 3,
                        StoryId = 1,
                        ChapterIndexId = 2,
                        ChapterTitle = "A Streak of red",
                        StoryContent =
                            @"
                        I wish to mourn the departed.
                        Weeping like rain... to swell the crossing streams,
                        I guide the souls departed till the tide arrives.. leading you back home.",
                        DateCreated = new DateTime(2024, 5, 15)
                    }
                }
            );

        modelBuilder
            .Entity<StoryLanguage>()
            .HasData(
                new StoryLanguage[]
                {
                    new() { Id = 1, StoriesLanguage = "English" },
                    new() { Id = 2, StoriesLanguage = "Français" },
                    new() { Id = 3, StoriesLanguage = "Español" },
                    new() { Id = 4, StoriesLanguage = "Deutsch" },
                    new() { Id = 5, StoriesLanguage = "日本語" }, // Japanese
                    new() { Id = 6, StoriesLanguage = "中文" }, // Chinese
                    new() { Id = 7, StoriesLanguage = "Русский" }, // Russian
                    new() { Id = 8, StoriesLanguage = "Português" }, // Portuguese
                    new() { Id = 9, StoriesLanguage = "عربى" }, // Arabic
                    new() { Id = 10, StoriesLanguage = "हिंदी" }, // Hindi
                    new() { Id = 11, StoriesLanguage = "한국어" }, // Korean
                    new() { Id = 12, StoriesLanguage = "Italiano" }, // Italian
                    new() { Id = 13, StoriesLanguage = "Türkçe" }, // Turkish
                    new() { Id = 14, StoriesLanguage = "Nederlands" }, // Dutch
                    new() { Id = 15, StoriesLanguage = "Ελληνικά" }, // Greek
                    new() { Id = 16, StoriesLanguage = "Magyar" }, // Hungarian
                    new() { Id = 17, StoriesLanguage = "Polski" }, // Polish
                    new() { Id = 18, StoriesLanguage = "Svenska" }, // Swedish
                    new() { Id = 19, StoriesLanguage = "Dansk" }, // Danish
                    new() { Id = 20, StoriesLanguage = "ไทย" }, // Thai
                }
            );
    }
}
