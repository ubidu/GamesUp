using GamesUp.Models;

namespace GamesUp.Domain.Services.Communication;

public class ReviewResponse : BaseResponse
{
    public Review Review { get; private set; }
    
    public ReviewResponse(bool success, string message, Review review) : base(success, message)
    {
        Review = review;
    }
    
    /// <summary>
    /// Creates a success response.
    /// </summary>
    /// <param name="review">Saved review.</param>
    /// <returns>Response.</returns>
    public ReviewResponse(Review review) : this(true, string.Empty, review)
    {}

    /// <summary>
    /// Creates an error response.
    /// </summary>
    /// <param name="message">Error message.</param>
    /// <returns>Response.</returns>
    public ReviewResponse(string message) : this(false, message, null)
    {}
}