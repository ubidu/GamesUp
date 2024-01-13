using GamesUp.Contracts.Review;
using GamesUp.Models;
using GamesUp.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesUp.Controllers;

[Authorize]
[ApiController]
public class ReviewController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly GamesUpDbContext _context;
    
    public ReviewController(UserManager<User> userManager, GamesUpDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    
    [HttpPost("AddReview")]
    public async Task<IActionResult> AddReview([FromBody] ReviewAddModel reviewModel)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var game = await _context.Games.FindAsync(reviewModel.GameId);
        if (game == null || user == null)
        {
            return NotFound();
        }
        
        if(_context.Reviews.Any(r => r.GameId == reviewModel.GameId && r.UserId == user.Id))
        {
            return BadRequest("You already reviewed this game");
        }
        
        var review = new Review
        {
            Content = reviewModel.Content,
            Rating = reviewModel.Rating,
            CreatedAt = DateTime.UtcNow,
            UserId = user.Id,
            GameId = reviewModel.GameId
        };
        
        await _context.Reviews.AddAsync(review);
        await _context.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpGet("GetReview/{reviewId:guid}")]
    public async Task<IActionResult> GetReview(Guid reviewId)
    {
        var review = await _context.Reviews.FindAsync(reviewId);
        if (review == null)
        {
            return NotFound();
        }
        
        return Ok(MapReviewResponse(review));
    }
    
    [HttpGet("GetUserReviews")]
    public async Task<IActionResult> GetUserReviews()
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        if (user == null)
        {
            return NotFound();
        }
        
        var reviews = await _context.Reviews
            .Where(r => r.UserId == user.Id)
            .ToListAsync();
        
        return Ok(reviews.Select(review => MapReviewResponse(review)));
    }
    
    [HttpGet("GetGameReviews/{gameId:guid}")]
    public async Task<IActionResult> GetGameReviews(Guid gameId)
    {
        var game = await _context.Games.FindAsync(gameId);
        if (game == null)
        {
            return NotFound();
        }
        
        var reviews = await _context.Reviews
            .Where(r => r.GameId == gameId)
            .ToListAsync();
        
        return Ok(reviews.Select(review => MapReviewResponse(review)));
    }
    
    [HttpDelete("DeleteReview/{reviewId:guid}")]
    public async Task<IActionResult> DeleteReview(Guid reviewId)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var review = await _context.Reviews.FindAsync(reviewId);
        if (review == null || user == null)
        {
            return NotFound();
        }
        
        if (review.UserId != user.Id)
        {
            return BadRequest("You can only delete your own reviews");
        }
        
        _context.Reviews.Remove(review);
        await _context.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpPut("UpdateReview/{reviewId:guid}")]
    public async Task<IActionResult> UpdateReview(Guid reviewId, [FromBody] ReviewEditModel reviewModel)
    {
        var user = await _userManager.GetUserAsync(HttpContext.User);
        var review = await _context.Reviews.FindAsync(reviewId);
        if (review == null || user == null)
        {
            return NotFound();
        }
        
        if (review.UserId != user.Id)
        {
            return BadRequest("You can only update your own reviews");
        }
        
        review.Content = reviewModel.Content;
        review.Rating = reviewModel.Rating;
        
        _context.Reviews.Update(review);
        await _context.SaveChangesAsync();
        
        return Ok();
    }
    
    private static ReviewResponse MapReviewResponse(Review review)
    {
        return new ReviewResponse
        {
            Id = review.Id,
            Content = review.Content,
            Rating = review.Rating,
            CreatedAt = review.CreatedAt,
            UserId = review.UserId,
            GameId = review.GameId
        };
    }

}