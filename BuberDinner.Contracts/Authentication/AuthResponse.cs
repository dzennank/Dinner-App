namespace BuberDinner.Contracts.Authentication;

public record AuthResponse(Guid Id, string FirstName, string LastName, string Email, string Token);