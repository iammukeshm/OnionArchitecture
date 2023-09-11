using Application.Interfaces;
using JwtProducer;
using JwtProducer.Builder;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.AuthFeatures.Queries.UserLoginQuery;

public class LoginHandler : IRequestHandler<LoginRequest, LoginResponse>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IJwtBuilder _jwtBuilder;

    public LoginHandler(IApplicationDbContext dbContext, IJwtBuilder jwtBuilder)
    {
        _dbContext = dbContext;
        _jwtBuilder = jwtBuilder;
    }

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var existUser = await _dbContext.Users
                        .Where(user => user.Email == request.Email && user.Password == request.Password)
                        .Include(user => user.Role)
                        .SingleOrDefaultAsync();
        if (existUser == null)
        {
            return new LoginResponse
            {
                Success = false,
                Token = null
            };
        }


        var accessToken = _jwtBuilder.GenerateAccessToken(new TokenRequest(existUser.Email, null, existUser.Role.RoleName, null, null), ExpireType.Hour, 1);
        var refreshToken = _jwtBuilder.GenerateRefreshToken(ExpireType.Hour, 2);

        existUser.Token = refreshToken.Token;
        existUser.TokenExpireDate = refreshToken.ExpireDate;

        return new LoginResponse
        {
            Success = true,
            Token = new Token
            {
                AccessToken = accessToken.Token,
                TokenExpireDate = (System.DateTime)accessToken.ExpireDate
            }
        };
    }
}
