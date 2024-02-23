using GamesUp.Models;

namespace GamesUp.Domain.Repositories;

public interface IReviewRepository
{
    Task<Review> GetReviewByIdAsync(Guid id);
    Task<IEnumerable<Review>> GetReviewsByGameIdAsync(Guid gameId);
    Task<IEnumerable<Review>> GetReviewsByUserIdAsync(Guid userId);
    Task AddReviewAsync(Review review);
    void UpdateReview(Review review);
    void DeleteReview(Review review);
}