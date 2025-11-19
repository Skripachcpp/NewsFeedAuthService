using System.Data;
using Dapper;
using Domain;
using Infrastructure.Data;

namespace Infrastructure;

public class AuthRepository(DpContext dpContext) : IAuthRepository {
}