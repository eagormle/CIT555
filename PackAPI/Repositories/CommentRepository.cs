using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PackAPI.Interfaces;
using PackAPI.Models;
using PackAPI.Settings;

namespace PackAPI.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly SqlConnection _dbConnection;

        public CommentRepository(DatabaseSettings settings)
        {
            _dbConnection = new SqlConnection(settings.ConnectionString);
        }

        public async Task<Comment> GetByIdAsync(Guid id)
        {
            await using var cmd = new SqlCommand("SELECT * FROM [Comment] WHERE CommentId = @id", _dbConnection);
            cmd.Parameters.AddWithValue("@id", id);

            await _dbConnection.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                await _dbConnection.CloseAsync();
                return null;
            }

            await reader.ReadAsync();

            var comment = new Comment
            {
                CommentId = reader.GetGuid(reader.GetOrdinal("CommentId")),
                ListId = reader.GetGuid(reader.GetOrdinal("ListId")),
                UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                ListBodyId = reader.GetGuid(reader.GetOrdinal("ListBodyId")),
                CommentText = reader.GetString(reader.GetOrdinal("CommentText")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
            };

            await _dbConnection.CloseAsync();
            return comment;
        }

        public async Task<IEnumerable<Comment>> GetByListIdAsync(Guid listId)
        {
            var comments = new List<Comment>();

            await using var cmd = new SqlCommand("SELECT * FROM [Comment] WHERE ListId = @listId", _dbConnection);
            cmd.Parameters.AddWithValue("@listId", listId);

            await _dbConnection.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var comment = new Comment
                {
                    CommentId = reader.GetGuid(reader.GetOrdinal("CommentId")),
                    ListId = reader.GetGuid(reader.GetOrdinal("ListId")),
                    UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                    ListBodyId = reader.GetGuid(reader.GetOrdinal("ListBodyId")),
                    CommentText = reader.GetString(reader.GetOrdinal("CommentText")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                };

                comments.Add(comment);
            }

            await _dbConnection.CloseAsync();
            return comments;
        }

        public async Task AddAsync(Comment comment)
        {
            await using var cmd = new SqlCommand("INSERT INTO [Comment] (CommentId, ListId, UserId, ListBodyId, CommentText, CreatedAt) VALUES (@commentId, @listId, @userId, @listBodyId, @commentText, @createdAt)", _dbConnection);
            cmd.Parameters.AddWithValue("@commentId", comment.CommentId);
            cmd.Parameters.AddWithValue("@listId", comment.ListId);
            cmd.Parameters.AddWithValue("@userId", comment.UserId);
            cmd.Parameters.AddWithValue("@listBodyId", comment.ListBodyId);
            cmd.Parameters.AddWithValue("@commentText", comment.CommentText);
            cmd.Parameters.AddWithValue("@createdAt", comment.CreatedAt);

            await _dbConnection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await _dbConnection.CloseAsync();
        }
        public async Task UpdateAsync(Comment comment)
        {
            await using var cmd = new SqlCommand("UPDATE [Comment] SET ListId = @listId, UserId = @userId, ListBodyId = @listBodyId, CommentText = @commentText, CreatedAt = @createdAt WHERE CommentId = @commentId", _dbConnection);
            cmd.Parameters.AddWithValue("@commentId", comment.CommentId);
            cmd.Parameters.AddWithValue("@listId", comment.ListId);
            cmd.Parameters.AddWithValue("@userId", comment.UserId);
            cmd.Parameters.AddWithValue("@listBodyId", comment.ListBodyId);
            cmd.Parameters.AddWithValue("@commentText", comment.CommentText);
            cmd.Parameters.AddWithValue("@createdAt", comment.CreatedAt);

            await _dbConnection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await _dbConnection.CloseAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            await using var cmd = new SqlCommand("DELETE FROM [Comment] WHERE CommentId = @id", _dbConnection);
            cmd.Parameters.AddWithValue("@id", id);

            await _dbConnection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await _dbConnection.CloseAsync();
        }
    }
}