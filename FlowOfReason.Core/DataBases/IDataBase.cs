using System.Collections;
using FlowOfReason.Core.DataModels;
using Microsoft.EntityFrameworkCore;

namespace FlowOfReason.Core.DataBases;

public interface IDataBase<T> where T : ITrackableData
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetAllAsync();
}

public class SqLiteDataBase<T>: DbContext, IDataBase<T>
    where T : TrackableData
{
    public DbSet<T> Entities { get; set; }
    private string DbPath { get; }

    public SqLiteDataBase(string dbPath)
    {
        DbPath = dbPath;
        Database.EnsureCreated();

    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    public async Task AddAsync(T entity)
    {
        Entities.Add(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        Entities.Update(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var matches = from entity in Entities where entity.Id == id select entity;
        Entities.Remove(matches.Single());
        await SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(string id)
    {
        var matches = from entity in Entities where entity.Id == id select entity;
        return await matches.SingleAsync();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await Entities.ToListAsync();
    }
}

public interface ILogicGraphDataBase : IDataBase<LogicGraph>;
public interface ILogicGraphNodeDataBase : IDataBase<LogicGraphNode>;
public interface ILeadCommentDataBase : IDataBase<LeadComment>;
public interface IDiscussionCommentDataBase : IDataBase<DiscussionComment>;
public interface ILogicGraphNodeRelationshipDataBase : IDataBase<LogicGraphNodeRelationship>;
public interface IUserDataBase : IDataBase<User>;

public class LogicGraphSqLiteDataBase(string dbPath) : SqLiteDataBase<LogicGraph>(dbPath), ILogicGraphDataBase;
public class LogicGraphSqLiteNodeDataBase(string dbPath) : SqLiteDataBase<LogicGraphNode>(dbPath), ILogicGraphNodeDataBase;
public class LeadCommentSqLiteDataBase(string dbPath) : SqLiteDataBase<LeadComment>(dbPath), ILeadCommentDataBase;
public class DiscussionCommentSqLiteDataBase(string dbPath) : SqLiteDataBase<DiscussionComment>(dbPath), IDiscussionCommentDataBase;
public class LogicGraphNodeRelationshipSqLiteDataBase(string dbPath) : SqLiteDataBase<LogicGraphNodeRelationship>(dbPath), ILogicGraphNodeRelationshipDataBase;
public class UserSqLiteDataBase(string dbPath) : SqLiteDataBase<User>(dbPath), IUserDataBase;

