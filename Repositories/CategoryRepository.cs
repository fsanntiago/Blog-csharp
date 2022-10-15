using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class CategoryRepository : Repository<Category>
    {
        private readonly SqlConnection _connection;

        public CategoryRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public List<Category> GetWithPost()
        {
            var sql = @"
                SELECT 
                    [Category].[Id], 
                    [Category].[Name], 
                    [Post].[CategoryId], 
                    [Post].[Title] 
                FROM
                    [Category] 
                LEFT JOIN
                    [Post] ON [Category].[Id] = [Post].[CategoryId]";

            var categories = new List<Category>();
            var items = _connection.Query<Category, Post, Category>(
                sql,
                (category, post) =>
                {
                    var categor = categories.FirstOrDefault<Category>(x => x.Id == category.Id);
                    if (categor == null)
                    {
                        categor = category;
                        if (post != null)
                        {
                            categor.Posts.Add(post);
                        }

                        categories.Add(categor);
                    }
                    else
                    {
                        categor.Posts.Add(post);
                    }
                    return category;
                }, splitOn: "CategoryId");

            return categories;
        }

    }
}
