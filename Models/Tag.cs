using System.ComponentModel.DataAnnotations;
using AkashicRecords.Models.DTOs;

namespace AkashicRecords.Models;

public class Tag
{
    public int Id { get; set; }

    [Required]
    public string TagName { get; set; }
}
