using System;
using Microsoft.Data.SqlClient;
using PackAPI.Models;

public class UserRepository : IUserRepository
{
    private readonly SqlConnection _dbConnection;

    public UserRepository(string connectionString)
    {
        _dbConnection = new SqlConnection(connectionString);
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        await using var cmd = new SqlCommand("SELECT * FROM Users WHERE UserId = @id", _dbConnection);
        cmd.Parameters.AddWithValue("@id", id);

        await _dbConnection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();

        if (!reader.HasRows)
        {
            await _dbConnection.CloseAsync();
            return null;
        }

        await reader.ReadAsync();

        var user = new User
        {
            UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
            Username = reader.GetString(reader.GetOrdinal("Username")),
            PasswordSalt = (byte[])reader["PasswordSalt"],
            PasswordHash = (byte[])reader["PasswordHash"],
            IsAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
        };

        await _dbConnection.CloseAsync();
        return user;
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        await using var cmd = new SqlCommand("SELECT * FROM Users WHERE Username = @username", _dbConnection);
        cmd.Parameters.AddWithValue("@username", username);

        await _dbConnection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();

        if (!reader.HasRows)
        {
            await _dbConnection.CloseAsync();
            return null;
        }

        await reader.ReadAsync();

        var user = new User
        {
            UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
            Username = reader.GetString(reader.GetOrdinal("Username")),
            PasswordSalt = (byte[])reader["PasswordSalt"],
            PasswordHash = (byte[])reader["PasswordHash"],
            IsAdmin = reader.GetBoolean(reader.GetOrdinal("IsAdmin")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
        };

        await _dbConnection.CloseAsync();
        return user;
    }

    public async Task AddAsync(User user)
    {
        await using var cmd = new SqlCommand("INSERT INTO Users (UserId, Username, PasswordSalt, PasswordHash, IsAdmin, CreatedAt) VALUES (@userId, @username, @passwordSalt, @passwordHash, @isAdmin, @createdAt)", _dbConnection);
        cmd.Parameters.AddWithValue("@userId", user.UserId);
        cmd.Parameters.AddWithValue("@username", user.Username);
        cmd.Parameters.AddWithValue("@passwordSalt", user.PasswordSalt);
        cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
        cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
        cmd.Parameters.AddWithValue("@createdAt", user.CreatedAt);

        await _dbConnection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await _dbConnection.CloseAsync();
    }

    public async Task UpdateAsync(User user)
    {
        await using var cmd = new SqlCommand("UPDATE Users SET Username = @username, PasswordSalt = @passwordSalt, PasswordHash = @passwordHash, IsAdmin = @isAdmin, CreatedAt = @createdAt WHERE UserId = @userId", _dbConnection);
        cmd.Parameters.AddWithValue("@userId", user.UserId);
        cmd.Parameters.AddWithValue("@username", user.Username);
        cmd.Parameters.AddWithValue("@passwordSalt", user.PasswordSalt);
        cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
        cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
        cmd.Parameters.AddWithValue("@createdAt", user.CreatedAt);

        await _dbConnection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await _dbConnection.CloseAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var cmd = new SqlCommand("DELETE FROM Users WHERE UserId = @id", _dbConnection);
        cmd.Parameters.AddWithValue("@id", id);

        await _dbConnection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await _dbConnection.CloseAsync();
    }
}
