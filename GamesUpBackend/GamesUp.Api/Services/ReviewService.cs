using GamesUp.Domain.Repositories;
using GamesUp.Domain.Services.Communication;
using GamesUp.Models;

namespace GamesUp.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<ReviewResponse> GetReviewByIdAsync(Guid id)
    {
        var review = await _reviewRepository.GetReviewByIdAsync(id);
        
        if (review == null)
        {
            return new ReviewResponse("Review not found.");
        }
        
        return new ReviewResponse(review);
    }

    public async Task<IEnumerable<Review>> GetReviewsByGameIdAsync(Guid gameId)
    {
        var reviews = await _reviewRepository.GetReviewsByGameIdAsync(gameId);
        
        return reviews;
    }

    public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(Guid userId)
    {
        var reviews = await _reviewRepository.GetReviewsByUserIdAsync(userId);
        
        return reviews;
    }

    public async Task<ReviewResponse> AddReviewAsync(Review review)
    {
        try
        {
            await _reviewRepository.AddReviewAsync(review);
            return new ReviewResponse(review);
        }
        catch (Exception ex)
        {
            return new ReviewResponse($"An error occurred when adding the review: {ex.Message}");
        }
    }

    public async Task<ReviewResponse> UpdateReviewAsync(Guid id, Review review)
    {
        var existingReview = await _reviewRepository.GetReviewByIdAsync(id);
        
        if (existingReview == null)
        {
            return new ReviewResponse("Review not found.");
        }
        
        existingReview.Content = review.Content;
        existingReview.Rating = review.Rating;
        
        try
        {
            _reviewRepository.UpdateReview(existingReview);
            return new ReviewResponse(existingReview);
        }
        catch (Exception ex)
        {
            return new ReviewResponse($"An error occurred when updating the review: {ex.Message}");
        }
    }

    public async Task<ReviewResponse> DeleteReviewAsync(Guid id)
    {
        var existingReview = await _reviewRepository.GetReviewByIdAsync(id);
        
        if (existingReview == null)
        {
            return new ReviewResponse("Review not found.");
        }
        
        try
        {
            _reviewRepository.DeleteReview(existingReview);
            return new ReviewResponse(existingReview);
        }
        catch (Exception ex)
        {
            return new ReviewResponse($"An error occurred when deleting the review: {ex.Message}");
        }
    }
}