using MediatR;

namespace Application.Features.AuthFeatures.Queries.UserLoginQuery;

public class LoginRequest : IRequest<LoginResponse>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
