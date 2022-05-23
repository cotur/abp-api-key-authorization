using System;
using System.ComponentModel.DataAnnotations;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyUpdateDto
{
    [Required]
    [MaxLength(ApiKeyConsts.MaxNameLength)]
    public string Name { get; set; }
    
    public bool Active { get; set; }
    
    public DateTime? ExpireAt { get; set; }
}