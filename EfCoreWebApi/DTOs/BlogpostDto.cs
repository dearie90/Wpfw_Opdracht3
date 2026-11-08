using System;
using System.ComponentModel.DataAnnotations;

namespace EfCoreWebApi.DTOs;

public class BlogpostDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "De titel is verplicht.")]
    [StringLength(50, ErrorMessage = "De titel mag maximaal 50 karakters lang zijn.")]
    public string Titel { get; set; } = string.Empty;

    [Required(ErrorMessage = "De inhoud van de blogpost is verplicht.")]
    public string Inhoud { get; set; } = string.Empty;

    [Required(ErrorMessage = "De datum is verplicht.")]
    public DateTime? Publicatiedatum { get; set; }
}