using System.ComponentModel.DataAnnotations;

namespace ProjectHub.Api.DTOs.Requests;

public record UserRegisterRequest(
    [Required, StringLength(256)] string Username,
    [Required] string Password,
    [Required, EmailAddress, StringLength(256)] string Email,
    [Required] string PasswordConfirm,
    [Required, StringLength(10000)] string DisplayName);
