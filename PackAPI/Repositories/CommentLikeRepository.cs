using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PackAPI.Interfaces;
using PackAPI.Models;
using PackAPI.Settings;

namespace PackAPI.Repositories
{
    public class CommentLikeRepository : ICommentLikeRepository
    {
        private readonly SqlConnection _dbConnection;

        public CommentLikeRepository(DatabaseSettings settings)
        {
            _dbConnection = new SqlConnection(settings.ConnectionString);
        }

        public async Task<CommentLike> GetByIdAsync(Guid id)
        {
            await using var cmd = new SqlCommand("SELECT * FROM CommentLikes WHERE CommentLikeId = @id", _dbConnection);
            cmd.Parameters.AddWithValue("@id", id);

            await _dbConnection.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                await _dbConnection.CloseAsync();
                return null;
            }

            await reader.ReadAsync();

            var commentLike = new CommentLike
            {
                CommentLikeId = reader.GetGuid(reader.GetOrdinal("CommentLikeId")),
                CommentId = reader.GetGuid(reader.GetOrdinal("CommentId")),
                UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            };

            await _dbConnection.CloseAsync();
            return commentLike;
        }

        public async Task<IEnumerable<CommentLike>> GetByCommentIdAsync(Guid commentId)
        {
            var commentLikes = new List<CommentLike>();

            await using var cmd = new SqlCommand("SELECT * FROM CommentLikes WHERE CommentId = @commentId", _dbConnection);
            cmd.Parameters.AddWithValue("@commentId", commentId);

            await _dbConnection.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var commentLike = new CommentLike
                {
                    CommentLikeId = reader.GetGuid(reader.GetOrdinal("CommentLikeId")),
                    CommentId = reader.GetGuid(reader.GetOrdinal("CommentId")),
                    UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                };

                commentLikes.Add(commentLike);
            }

            await _dbConnection.CloseAsync();
            return commentLikes;
        }

        public async Task AddAsync(CommentLike commentLike)
        {
            await using var cmd = new SqlCommand("INSERT INTO CommentLikes (CommentLikeId, CommentId, UserId, CreatedAt) VALUES (@commentLikeId, @commentId, @userId, @createdAt)", _dbConnection);
            cmd.Parameters.AddWithValue("@commentLikeId", commentLike.CommentLikeId);
            cmd.Parameters.AddWithValue("@commentId", commentLike.CommentId);
            cmd.Parameters.AddWithValue("@userId", commentLike.UserId);
            cmd.Parameters.AddWithValue("@createdAt", commentLike.CreatedAt);

            await _dbConnection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await _dbConnection.CloseAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await using var cmd = new SqlCommand("DELETE FROM CommentLikes WHERE CommentLikeId = @id", _dbConnection);
            cmd.Parameters.AddWithValue("@id", id);

            await _dbConnection.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
            await _dbConnection.CloseAsync();
        }
    }
}
