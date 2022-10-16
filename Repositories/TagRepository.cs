using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class TagRepository : Repository<Tag>
    {
        private readonly SqlConnection _connection;

        public TagRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public List<Tag> GetTagsWithPost()
        {
            var sql = @"
                SELECT
                    [Tag].*,
                    [Post].*,
                    [PostTag].*
                FROM
                    [Tag]
                LEFT JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
                LEFT JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]";

            var tags = new List<Tag>();
            var items = _connection.Query<Tag, Post, Tag>(
                sql,
                (tag, post) =>
                {
                    var tg = tags.FirstOrDefault<Tag>(x => x.Id == tag.Id);
                    if (tg == null)
                    {
                        tg = tag;
                        if (post != null)
                        {
                            tg.Posts.Add(post);
                        }
                        tags.Add(tg);
                    }
                    else
                    {
                        tg.Posts.Add(post);
                    }
                    return tag;
                });

            return tags;
        }
    }
}
