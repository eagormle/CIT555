using System;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using PackAPI.Interfaces;
using PackAPI.Models;
using PackAPI.Settings;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(DatabaseSettings settings)
    {
        _connectionString = settings.ConnectionString;
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("SELECT * FROM [User] WHERE UserId = @id", connection);
        cmd.Parameters.AddWithValue("@id", id);

        await connection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();

        if (!reader.HasRows)
        {
            await connection.CloseAsync();
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
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
        };

        await connection.CloseAsync();

        return user;
    }
    public async Task<User> GetByUsernameAsync(string username)
    {
        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("SELECT * FROM [User] WHERE Username = @username", connection);
        cmd.Parameters.AddWithValue("@username", username);

        await connection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();

        if (!reader.HasRows)
        {
            await connection.CloseAsync();
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

        await connection.CloseAsync();
        return user;
    }

    public async Task AddAsync(User user)
    {
        // Generate a new GUID for the UserId
        user.UserId = Guid.NewGuid();

        // Set the CreatedAt date to the current datetime
        user.CreatedAt = DateTime.UtcNow;

        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("INSERT INTO [User] (UserId, Username, PasswordSalt, PasswordHash, IsAdmin, CreatedAt) VALUES (@userId, @username, @passwordSalt, @passwordHash, @isAdmin, @createdAt)", connection);
        cmd.Parameters.AddWithValue("@userId", user.UserId);
        cmd.Parameters.AddWithValue("@username", user.Username);
        cmd.Parameters.AddWithValue("@passwordSalt", user.PasswordSalt);
        cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
        cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
        cmd.Parameters.AddWithValue("@createdAt", user.CreatedAt);

        await connection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await connection.CloseAsync();
    }

    public async Task UpdateAsync(User user)
    {
        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("UPDATE [User] SET Username = @username, PasswordSalt = @passwordSalt, PasswordHash = @passwordHash, IsAdmin = @isAdmin, CreatedAt = @createdAt WHERE UserId = @userId", connection);
        cmd.Parameters.AddWithValue("@userId", user.UserId);
        cmd.Parameters.AddWithValue("@username", user.Username);
        cmd.Parameters.AddWithValue("@passwordSalt", user.PasswordSalt);
        cmd.Parameters.AddWithValue("@passwordHash", user.PasswordHash);
        cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
        cmd.Parameters.AddWithValue("@createdAt", user.CreatedAt);

        await connection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await connection.CloseAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        using var connection = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand("DELETE FROM [User] WHERE UserId = @id", connection);
        cmd.Parameters.AddWithValue("@id", id);

        await connection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await connection.CloseAsync();
    }
}
