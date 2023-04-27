using System;
using Microsoft.Data.SqlClient;
using PackAPI.Models;
using PackAPI.Interfaces;

public class ListRepository : IListRepository
{
    private readonly SqlConnection _dbConnection;

    public ListRepository(string connectionString)
    {
        _dbConnection = new SqlConnection(connectionString);
    }

    public async Task<IEnumerable<List>> GetAllAsync(string username)
    {
        var lists = new List<List>();

        await using var cmd = new SqlCommand("SELECT * FROM [List] WHERE Username = @username", _dbConnection);
        cmd.Parameters.AddWithValue("@username", username);

        await _dbConnection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var list = new List
            {
                ListId = reader.GetGuid(reader.GetOrdinal("Id")),
                ListName = reader.GetString(reader.GetOrdinal("Name")),
                //Description = reader.GetString(reader.GetOrdinal("Description")), future feature
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                //UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt")), future implementation
                UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
            };

            lists.Add(list);
        }

        await _dbConnection.CloseAsync();
        return lists;
    }

    public async Task<List> GetByIdAsync(Guid id)
    {
        await using var cmd = new SqlCommand("SELECT * FROM [List] WHERE ListId = @id", _dbConnection);
        cmd.Parameters.AddWithValue("@id", id);

        await _dbConnection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();

        if (!reader.HasRows)
        {
            await _dbConnection.CloseAsync();
            return null;
        }

        await reader.ReadAsync();

        var list = new List
        {
            ListId = reader.GetGuid(reader.GetOrdinal("ListId")),
            UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
            ListName = reader.GetString(reader.GetOrdinal("ListName")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
        };

        await _dbConnection.CloseAsync();
        return list;
    }

    public async Task<IEnumerable<List>> GetByUserIdAsync(Guid userId)
    {
        var lists = new List<List>();

        await using var cmd = new SqlCommand("SELECT * FROM [List] WHERE UserId = @userId", _dbConnection);
        cmd.Parameters.AddWithValue("@userId", userId);

        await _dbConnection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var list = new List
            {
                ListId = reader.GetGuid(reader.GetOrdinal("ListId")),
                UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                ListName = reader.GetString(reader.GetOrdinal("ListName")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            };

            lists.Add(list);
        }

        await _dbConnection.CloseAsync();
        return lists;
    }

    public async Task AddAsync(List list)
    {
        await using var cmd = new SqlCommand("INSERT INTO [List] (UserId, ListName) VALUES (@userId, @listName)", _dbConnection);
        cmd.Parameters.AddWithValue("@userId", list.UserId);
        cmd.Parameters.AddWithValue("@listName", list.ListName);

        await _dbConnection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await _dbConnection.CloseAsync();
    }

    public async Task UpdateAsync(List list)
    {
        await using var cmd = new SqlCommand("UPDATE [List] SET UserId = @userId, ListName = @listName, CreatedAt = @createdAt WHERE ListId = @listId", _dbConnection);
        cmd.Parameters.AddWithValue("@listId", list.ListId);
        cmd.Parameters.AddWithValue("@userId", list.UserId);
        cmd.Parameters.AddWithValue("@listName", list.ListName);
        cmd.Parameters.AddWithValue("@createdAt", list.CreatedAt);

        await _dbConnection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await _dbConnection.CloseAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await using var cmd = new SqlCommand("DELETE FROM [List] WHERE ListId = @id", _dbConnection);
        cmd.Parameters.AddWithValue("@id", id);

        await _dbConnection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await _dbConnection.CloseAsync();
    }

}


