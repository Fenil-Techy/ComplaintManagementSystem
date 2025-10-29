using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplaintManagementSystem.Models
{
    /// <summary>
    /// Represents a complaint submitted by a student
    /// </summary>
    public class Complaint
    {
        public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Category is required")]
    public string Category { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
    public string Description { get; set; } = string.Empty;

    public string StudentName { get; set; } = string.Empty;
        
        public bool IsAnonymous { get; set; }
        
        public ComplaintStatus Status { get; set; } = ComplaintStatus.Pending;
        
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
        
        public int LikesCount { get; set; } = 0;
        
        // Track which users have liked this complaint
        public List<string> LikedByUsers { get; set; } = new List<string>();
        
        // Comments associated with this complaint
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }

    /// <summary>
    /// Status of the complaint
    /// </summary>
    public enum ComplaintStatus
    {
        Pending,
        InProgress,
        Resolved
    }

    /// <summary>
    /// Represents a comment on a complaint
    /// </summary>
        public class Comment
    {
        public int Id { get; set; }
        
        public int ComplaintId { get; set; }
        
        [Required(ErrorMessage = "Comment text is required")]
        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
        public string Text { get; set; } = string.Empty;
        
        public string UserName { get; set; } = string.Empty;
        
        public DateTime PostedAt { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// Categories available for complaints
    /// </summary>
    public static class ComplaintCategories
    {
        public static readonly List<string> Categories = new List<string>
        {
            "Hostel",
            "Electrical",
            "Library",
            "Canteen",
            "Department",
            "Infrastructure",
            "Transportation",
            "Sports Facilities",
            "Academic",
            "Other"
        };
    }
}