using System;
using System.ComponentModel.DataAnnotations;

namespace Cotur.Abp.ApiKeyAuthorization.ApiKeys;

public class ApiKeyCreateDto
{
    [Required]
    [MaxLength(ApiKeyConsts.MaxNameLength)]
    public string Name { get; set; }
    
    [Required]
    [MaxLength(ApiKeyConsts.MaxKeyLength)]
    public string Key { get; set; }
    
    public bool Active { get; set; }

    public DateTime? ExpireAt { get; set; }
}