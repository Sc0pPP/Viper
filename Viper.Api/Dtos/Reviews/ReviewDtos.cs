using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viper.Api.Dtos.Reviews;

public record ReviewDto(
    int Id,
    int ProductId,
    int UserId,
    string UserLogin,
    int Rating,
    string? Text,
    DateTime CreatedAtUtc);

public record CreateReviewRequest(
    [Range(1, 5)] int Rating,
    [StringLength(2000)] string? Text);
