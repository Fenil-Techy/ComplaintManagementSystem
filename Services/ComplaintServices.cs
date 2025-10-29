using System;
using System.Collections.Generic;
using System.Linq;
using ComplaintManagementSystem.Models;

namespace ComplaintManagementSystem.Services
{
    /// <summary>
    /// Service class to manage complaints in-memory
    /// This uses static storage for demonstration purposes
    /// </summary>
    public class ComplaintService
    {
        // In-memory storage for complaints
        private static List<Complaint> _complaints = new List<Complaint>();
        private static int _nextId = 1;
        private static int _nextCommentId = 1;

        /// <summary>
        /// Get all complaints, ordered by submission date (newest first)
        /// </summary>
        public List<Complaint> GetAllComplaints()
        {
            return _complaints.OrderByDescending(c => c.SubmittedAt).ToList();
        }

        /// <summary>
        /// Get a specific complaint by ID
        /// </summary>
        public Complaint? GetComplaintById(int id)
        {
            return _complaints.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Create a new complaint
        /// </summary>
        public void CreateComplaint(Complaint complaint)
        {
            complaint.Id = _nextId++;
            complaint.SubmittedAt = DateTime.Now;
            _complaints.Add(complaint);
        }

        // ------------------------------------------------------------------
        // FIX IMPLEMENTED: New method for cumulative counting (always increments)
        // ------------------------------------------------------------------
        /// <summary>
        /// Increments the like count for a complaint (cumulative counter logic).
        /// </summary>
        public bool IncrementLikeCount(int complaintId)
        {
            var complaint = GetComplaintById(complaintId);
            if (complaint == null) return false;

            // Simple increment: This ignores user identity and previous state.
            complaint.LikesCount++;
            return true;
        }
        
        /// <summary>
        /// Toggle like on a complaint by a user (Original logic, retained for reference)
        /// </summary>
        public bool ToggleLike(int complaintId, string userName)
        {
            var complaint = GetComplaintById(complaintId);
            if (complaint == null) return false;

            // Check if user already liked this complaint
            if (complaint.LikedByUsers.Contains(userName))
            {
                // Unlike
                complaint.LikedByUsers.Remove(userName);
                complaint.LikesCount--;
                return false;
            }
            else
            {
                // Like
                complaint.LikedByUsers.Add(userName);
                complaint.LikesCount++;
                return true;
            }
        }

        /// <summary>
        /// Check if a user has liked a complaint
        /// </summary>
        public bool HasUserLiked(int complaintId, string userName)
        {
            var complaint = GetComplaintById(complaintId);
            return complaint?.LikedByUsers.Contains(userName) ?? false;
        }

        /// <summary>
        /// Update complaint status (Admin function)
        /// </summary>
        public bool UpdateComplaintStatus(int complaintId, ComplaintStatus status)
        {
            var complaint = GetComplaintById(complaintId);
            if (complaint == null) return false;

            complaint.Status = status;
            return true;
        }

        /// <summary>
        /// Add a comment to a complaint
        /// </summary>
        public bool AddComment(int complaintId, Comment comment)
        {
            var complaint = GetComplaintById(complaintId);
            if (complaint == null) return false;

            comment.Id = _nextCommentId++;
            comment.ComplaintId = complaintId;
            comment.PostedAt = DateTime.Now;
            complaint.Comments.Add(comment);
            return true;
        }

        /// <summary>
        /// Get complaints by category
        /// </summary>
        public List<Complaint> GetComplaintsByCategory(string category)
        {
            return _complaints
                .Where(c => c.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(c => c.SubmittedAt)
                .ToList();
        }

        /// <summary>
        /// Get complaints by status
        /// </summary>
        public List<Complaint> GetComplaintsByStatus(ComplaintStatus status)
        {
            return _complaints
                .Where(c => c.Status == status)
                .OrderByDescending(c => c.SubmittedAt)
                .ToList();
        }

        /// <summary>
        /// Get complaint statistics
        /// </summary>
        public ComplaintStats GetStats()
        {
            return new ComplaintStats
            {
                TotalComplaints = _complaints.Count,
                PendingComplaints = _complaints.Count(c => c.Status == ComplaintStatus.Pending),
                InProgressComplaints = _complaints.Count(c => c.Status == ComplaintStatus.InProgress),
                ResolvedComplaints = _complaints.Count(c => c.Status == ComplaintStatus.Resolved),
                TotalLikes = _complaints.Sum(c => c.LikesCount),
                TotalComments = _complaints.Sum(c => c.Comments.Count)
            };
        }
    }

    /// <summary>
    /// Statistics model for dashboard
    /// </summary>
    public class ComplaintStats
    {
        public int TotalComplaints { get; set; }
        public int PendingComplaints { get; set; }
        public int InProgressComplaints { get; set; }
        public int ResolvedComplaints { get; set; }
        public int TotalLikes { get; set; }
        public int TotalComments { get; set; }
    }
}