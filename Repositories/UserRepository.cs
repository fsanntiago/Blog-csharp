using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*,
                    [UserRole].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault<User>(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        if (role != null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                    {
                        usr.Roles.Add(role);
                    }
                    return user;
                }, splitOn: "Id");

            return users;
        }

        public User GetByEmail(string email)
        {
            var query = "SELECT [Email] FROM [User] WHERE [Email] = @email";
            var pars = new { email };

            var user = _connection.QueryFirstOrDefault<User>(query, pars);

            return user;
        }

        public bool LinkUserToARole(int userId, int roleId)
        {
            var query = "INSERT INTO [UserRole] VALUES(@userId, roleId)";
            var pars = new { userId, roleId };

            var rows = _connection.Execute(query, pars);
            return rows != 0;
        }
    }
}
