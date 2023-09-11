using System;

namespace Application.Features.AuthFeatures.Queries.UserLoginQuery;

public class LoginResponse
{
    public Token? Token { get; set; }
    public bool Success { get; set; } = true;

}

public class Token
{
    public string AccessToken { get; set; }
    public DateTime TokenExpireDate { get; set; }
}
