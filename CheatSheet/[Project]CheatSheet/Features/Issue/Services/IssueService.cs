namespace _Project_CheatSheet.Features.Issue.Services;

using _Project_CheatSheet.Infrastructure.Data.SQL;
using _Project_CheatSheet.Infrastructure.Data.SQL.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Common.Exceptions;
using Common.Pagination;
using Common.UserService.Interfaces;
using Constants.GlobalConstants.Issue;
using Enums;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq;

public class IssueService : IIssueService
{
    private readonly CheatSheetDbContext context;
    private readonly IMapper mapper;
    private readonly ICurrentUser userService;

    public IssueService(
        CheatSheetDbContext context,
        IMapper mapper,
        ICurrentUser userService)
    {
        this.context = context;
        this.mapper = mapper;
        this.userService = userService;
    }

    public async Task<ICollection<IssueRespondModel>> GetIssues(IssueQuery? query)
    {
        IQueryable<Issue> issues = context.Issues
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.SearchString))
        {
            string wildcard = $"%{query.SearchString.ToLower()}%";

            issues = issues
                .Where(i => EF.Functions.Like(i.Title.ToLower(), wildcard));
        }

        if (!string.IsNullOrWhiteSpace(query.TopicId))
        {
            issues = issues.Where(it => it.TopicId.ToString() == query.TopicId);
        }

        issues = query.IssueSorting switch
        {
            IssueSorting.Deleted => issues.OrderBy(i => i.IsDeleted),
            IssueSorting.Newest => issues.OrderByDescending(i => i.CreatedOn),
            IssueSorting.Oldest => issues.OrderBy(i => i.CreatedOn),
        };

        var filteredIssues = issues.ProjectTo<IssueRespondModel>(mapper.ConfigurationProvider);

        return await Pagination<IssueRespondModel>.CreateAsync(filteredIssues, query.CurrentPage, 6);
    }

    public async Task<ICollection<IssueCategoryModel>> GetIssuesCategories() 
        => await context.CategoriesIssues
            .ProjectTo<IssueCategoryModel>(mapper.ConfigurationProvider)
            .ToArrayAsync();

    public async Task<string> WithdrawIssue(string issueId)
    {
        var userId = userService.GetUserId();
        var findIssue = await context.Issues.FindAsync(issueId);

        if (findIssue == null)
        {
            throw new ServiceException(IssueMessages.NotFound);
        }

        if (findIssue.UserId != userId)
        {
            throw new ServiceException(IssueMessages.UnAuthorized);
        }

        try
        {
            context.Remove(findIssue);
            await context.SaveChangesAsync();
            return IssueMessages.SuccessfullyDeletedIssue;
        }
        catch (Exception)
        {
            return IssueMessages.UnSuccessfullyDeletedIssue;
        }
    }

    public Task<ICollection<IssueRespondModel>> GetIssuesByTopicId(string topicId)
    {
        throw new NotImplementedException();
    }

    public async Task<string> CreateIssue(IssueRequestModel issue)
    {

        var userId = userService.GetUserId();

        var userNotInCourse = await context.UserCourses.AllAsync(uc => uc.UserId != userId);
        if (userNotInCourse)
        {
            throw new ServiceException(IssueMessages.NotInCourse);
        }

        if (await context.Topics.FindAsync(issue.TopicId) == null)
        {
            throw new ServiceException(IssueMessages.TopicDoesNotExist);
        }

        var mappedIssue = mapper.Map<Issue>(issue);
        mappedIssue.UserId = userId;
        await context.AddAsync(mappedIssue);
        await context.SaveChangesAsync();

        return IssueMessages.SuccessfullyAddedIssue;

    }
}