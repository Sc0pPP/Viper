using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Viper.Api.Dtos.Auth;

public record RegisterRequest(
    [Required, StringLength(32, MinimumLength = 3)] string Login,
    [Required, StringLength(64, MinimumLength = 6)] string Password,
    [Required] string ConfirmPassword);

public record LoginRequest(
    [Required] string Login,
    [Required] string Password);

public record UserDto(int Id, string Login, string Role);

public record AuthResponse(string Token, DateTime ExpiresAtUtc, UserDto User);
