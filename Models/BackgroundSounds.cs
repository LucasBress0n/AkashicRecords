using System.ComponentModel.DataAnnotations;
using AkashicRecords.Models.DTOs;

namespace AkashicRecords.Models;

public class BackgroundSound
{
    public int Id { get; set; }

    [Required]
    [Url]
    public string Sound { get; set; }
}
