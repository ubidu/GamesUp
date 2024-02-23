using GamesUp.Domain.Repositories;
using GamesUp.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesUp.Persistence.Repositories;

public class ReviewRepository : BaseRepository, IReviewRepository
{
    public ReviewRepository(GamesUpDbContext context) : base(context)
    {
    }

    public async Task<Review> GetReviewByIdAsync(Guid id)
    {
        return await _context.Reviews.FindAsync(id);
    }

    public async Task<IEnumerable<Review>> GetReviewsByGameIdAsync(Guid gameId)
    {
        return await _context.Reviews.Where(r => r.GameId == gameId).ToListAsync();
    }

    public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(Guid userId)
    {
        return await _context.Reviews.Where(r => r.UserId == userId).ToListAsync();
    }

    public async Task AddReviewAsync(Review review)
    {
        await _context.Reviews.AddAsync(review);
    }

    public void UpdateReview(Review review)
    {
        _context.Reviews.Update(review);
    }

    public void DeleteReview(Review review)
    {
        _context.Reviews.Remove(review);
    }
}