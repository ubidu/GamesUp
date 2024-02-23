using GamesUp.Domain.Services.Communication;
using GamesUp.Models;

namespace GamesUp.Services;

public interface IReviewService
{
    Task<ReviewResponse> GetReviewByIdAsync(Guid id);
    Task<IEnumerable<Review>> GetReviewsByGameIdAsync(Guid gameId);
    Task<IEnumerable<Review>> GetReviewsByUserIdAsync(Guid userId);
    Task<ReviewResponse> AddReviewAsync(Review review);
    Task<ReviewResponse> UpdateReviewAsync(Guid id, Review review);
    Task<ReviewResponse> DeleteReviewAsync(Guid id);
}