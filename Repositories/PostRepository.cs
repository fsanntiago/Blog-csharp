using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class PostRepository : Repository<Post>
    {
        private readonly SqlConnection _connection;

        public PostRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public Dictionary<Post, Category> GetWithCategory()
        {
            var sql = @"
                SELECT
                    [Post].*, 
                    [Category].*
                FROM
                    [Post] 
                INNER JOIN
                    [Category] ON [Post].[CategoryId] = [Category].[Id]";

            var postCategory = new Dictionary<Post, Category>();

            var items = _connection.Query<Post, Category, Post>(
                sql,
                (post, category) =>
                {
                    if (post.CategoryId == category.Id)
                    {
                        postCategory.Add(post, category);
                    }
                    return post;
                }, splitOn: "Id");

            return postCategory;
        }

        public List<Post> GetWithTag()
        {
            var sql = @"
                SELECT
                    [Post].*,
                    [Tag].*,
                    [PostTag].*
                FROM
                    [Post]
                LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
                LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]";

            var posts = new List<Post>();

            var items = _connection.Query<Post, Tag, Post>(
                sql,
                (post, tag) =>
                {
                    var pos = posts.FirstOrDefault<Post>(x => x.Id == post.Id);
                    if (pos == null)
                    {
                        pos = post;
                        if (tag != null)
                            pos.Tags.Add(tag);

                        posts.Add(pos);
                    }
                    else
                    {
                        pos.Tags.Add(tag);
                    }
                    return post;
                }, splitOn: "Id");
            return posts;
        }

        public void LinkPostToTag(int postId, int tagId)
        {
            var sql = "INSERT INTO [PostTag] VALUES(@tagId, @postId)";
            var parms = new { tagId, postId };

            _connection.Execute(sql, parms);
        }
    }
}
