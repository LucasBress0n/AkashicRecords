
using System.ComponentModel.DataAnnotations;

namespace AkashicRecords.Models;

public class Story {
    public int Id {get;set;}
    [Required]

    public string Title {get;set;}
    [Required]

    public string Summary {get;set;}
    public string Image {get;set;}
    [Required]

    public DateTime DateCreated {get;set;}
    public DateTime LastUpdated {get;set;}
}