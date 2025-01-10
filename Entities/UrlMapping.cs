using System;
using System.ComponentModel.DataAnnotations;

namespace Entities;

public class UrlMapping
{
    public Guid Id { get; set; }
    public required string LongUrl { get; set; }
    public required string ShortUrl { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
}
