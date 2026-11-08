using System;
using System.ComponentModel.DataAnnotations;

namespace EfCoreWebApi.DTOs;

public class ProjectDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "De projecttitel is verplicht.")]
    [StringLength(50, ErrorMessage = "De projecttitel mag maximaal 50 karakters lang zijn.")]
    public string Titel { get; set; } = string.Empty;

    [Required(ErrorMessage = "De projectbeschrijving is verplicht.")]
    public string Beschrijving { get; set; } = string.Empty;

    [Required(ErrorMessage = "De categorie is verplicht.")]
    [StringLength(25, ErrorMessage = "De categorie mag maximaal 25 karakters lang zijn.")]
    public string Categorie { get; set; } = string.Empty;

    [Required(ErrorMessage = "De GitHub URL is verplicht.")]
    [Url(ErrorMessage = "Vul een geldige URL in.")]
    [StringLength(2048, ErrorMessage = "De GitHub URL mag maximaal 2048 karakters lang zijn.")]
    public string GitHubUrl { get; set; } = string.Empty;

    [Required(ErrorMessage = "De datum is verplicht.")]
    public DateTime? Datum { get; set; }
}
