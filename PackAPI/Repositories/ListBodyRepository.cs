using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PackAPI.Interfaces;
using PackAPI.Models;
using PackAPI.Settings;

public class ListBodyRepository : IListBodyRepository
{
    private readonly SqlConnection _dbConnection;

    public ListBodyRepository(DatabaseSettings settings)
    {
        _dbConnection = new SqlConnection(settings.ConnectionString);
    }

    public async Task<ListBody> GetByIdAsync(Guid id)
    {
        await using var cmd = new SqlCommand("SELECT * FROM ListBodies WHERE ListBodyId = @id", _dbConnection);
        cmd.Parameters.AddWithValue("@id", id);

        await _dbConnection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();

        if (!reader.HasRows)
        {
            await _dbConnection.CloseAsync();
            return null;
        }

        await reader.ReadAsync();

        var listBody = new ListBody
        {
            ListBodyId = reader.GetGuid(reader.GetOrdinal("ListBodyId")),
            ListId = reader.GetGuid(reader.GetOrdinal("ListId")),
            ListBodyText = reader.GetString(reader.GetOrdinal("Body")),
            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
        };

        await _dbConnection.CloseAsync();
        return listBody;
    }

    public async Task<IEnumerable<ListBody>> GetByListIdAsync(Guid listId)
    {
        var listBodies = new List<ListBody>();

        await using var cmd = new SqlCommand("SELECT * FROM ListBodies WHERE ListId = @listId", _dbConnection);
        cmd.Parameters.AddWithValue("@listId", listId);

        await _dbConnection.OpenAsync();
        var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var listBody = new ListBody
            {
                ListBodyId = reader.GetGuid(reader.GetOrdinal("ListBodyId")),
                ListId = reader.GetGuid(reader.GetOrdinal("ListId")),
                ListBodyText = reader.GetString(reader.GetOrdinal("Body")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
            };

            listBodies.Add(listBody);
        }

        await _dbConnection.CloseAsync();
        return listBodies;
    }

    public async Task AddAsync(ListBody listBody)
    {
        await using var cmd = new SqlCommand("INSERT INTO ListBodies (ListBodyId, ListId, Body, CreatedAt) VALUES (@listBodyId, @listId, @body, @createdAt)", _dbConnection);
        cmd.Parameters.AddWithValue("@listBodyId", listBody.ListBodyId);
        cmd.Parameters.AddWithValue("@listId", listBody.ListId);
        cmd.Parameters.AddWithValue("@body", listBody.ListBodyText);
        cmd.Parameters.AddWithValue("@createdAt", listBody.CreatedAt);

        await _dbConnection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await _dbConnection.CloseAsync();
    }

    public async Task UpdateAsync(ListBody listBody)
    {
        await using var cmd = new SqlCommand("UPDATE ListBodies SET ListId = @listId, Body = @body, CreatedAt = @createdAt WHERE ListBodyId = @listBodyId", _dbConnection);
        cmd.Parameters.AddWithValue("@listBodyId", listBody.ListBodyId);
        cmd.Parameters.AddWithValue("@listId", listBody.ListId);
        cmd.Parameters.AddWithValue("@body", listBody.ListBodyText);
        cmd.Parameters.AddWithValue("@createdAt", listBody.CreatedAt);

        await _dbConnection.OpenAsync();
        await cmd.ExecuteNonQueryAsync();
        await _dbConnection.CloseAsync();
    }
    public async Task DeleteAsync(Guid id)
{
    await using var cmd = new SqlCommand("DELETE FROM ListBodies WHERE ListBodyId = @id", _dbConnection);
    cmd.Parameters.AddWithValue("@id", id);

    await _dbConnection.OpenAsync();
    await cmd.ExecuteNonQueryAsync();
    await _dbConnection.CloseAsync();
}
}
