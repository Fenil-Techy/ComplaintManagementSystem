using Microsoft.AspNetCore.Mvc;
using ComplaintManagementSystem.Models;
using ComplaintManagementSystem.Services;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http; 

namespace ComplaintManagementSystem.Controllers
{
    /// <summary>
    /// Main controller for handling complaint operations
    /// </summary>
    public class ComplaintsController : Controller
    {
        private readonly ComplaintService _complaintService;

        public ComplaintsController()
        {
            _complaintService = new ComplaintService();
        }

        /// <summary>
        /// Display all complaints (Public View)
        /// </summary>
        [HttpGet]
        public IActionResult Index(string? category = null, string? status = null)
        {
            List<Complaint> complaints;

            // Filter by category or status if provided
            if (!string.IsNullOrEmpty(category))
            {
                complaints = _complaintService.GetComplaintsByCategory(category);
            }
            else if (!string.IsNullOrEmpty(status) && Enum.TryParse<ComplaintStatus>(status, out var statusEnum))
            {
                complaints = _complaintService.GetComplaintsByStatus(statusEnum);
            }
            else
            {
                complaints = _complaintService.GetAllComplaints();
            }

            ViewBag.CurrentUser = GetCurrentUser();
            ViewBag.Categories = ComplaintCategories.Categories;
            ViewBag.SelectedCategory = category;
            ViewBag.SelectedStatus = status;

            return View(complaints);
        }

        /// <summary>
        /// Show complaint details with comments (Public View)
        /// </summary>
        [HttpGet]
        public IActionResult Details(int id)
        {
            var complaint = _complaintService.GetComplaintById(id);
            if (complaint == null)
            {
                return NotFound();
            }

            ViewBag.CurrentUser = GetCurrentUser();
            ViewBag.HasLiked = _complaintService.HasUserLiked(id, GetCurrentUser());
            return View(complaint);
        }

        /// <summary>
        /// Show complaint details for administrative review (NEW ADMIN ACTION)
        /// </summary>
        [HttpGet]
        public IActionResult AdminDetails(int id)
        {
            var complaint = _complaintService.GetComplaintById(id);
            if (complaint == null)
            {
                return NotFound();
            }
            
            ViewBag.CurrentUser = GetCurrentUser();
            // This will render Views/Complaints/AdminDetails.cshtml
            return View(complaint); 
        }

        /// <summary>
        /// Display form to create new complaint
        /// </summary>
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = ComplaintCategories.Categories;
            return View();
        }

        /// <summary>
        /// Handle complaint submission
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                if (complaint.IsAnonymous)
                {
                    complaint.StudentName = "Anonymous";
                }
                else if (string.IsNullOrWhiteSpace(complaint.StudentName))
                {
                    complaint.StudentName = "Student";
                }

                _complaintService.CreateComplaint(complaint);
                TempData["SuccessMessage"] = "Complaint submitted successfully!";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Categories = ComplaintCategories.Categories;
            return View(complaint);
        }

        /// <summary>
        /// Toggle like on a complaint (AJAX endpoint) - Uses cumulative counter logic
        /// </summary>
        [HttpPost]
        public IActionResult ToggleLike(int id)
        {
            _complaintService.IncrementLikeCount(id); 
            
            var complaint = _complaintService.GetComplaintById(id);

            return Json(new
            {
                success = true,
                isLiked = true, 
                likesCount = complaint?.LikesCount ?? 0
            });
        }
        
        /// <summary>
        /// Update complaint status (NEW POST ACTION FOR ADMIN DASHBOARD)
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, ComplaintStatus status)
        {
            var success = _complaintService.UpdateComplaintStatus(id, status);
            
            if (success)
            {
                TempData["SuccessMessage"] = $"Complaint ID {id} status updated to {status}.";
            }
            else
            {
                TempData["ErrorMessage"] = $"Failed to update status for Complaint ID {id}.";
            }

            // Redirect back to the Admin Dashboard (Index action that serves the admin view)
            return RedirectToAction("Index", "Admin"); 
        }

        /// <summary>
        /// Add a comment to a complaint
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddComment(int complaintId, string commentText, string userName)
        {
            if (string.IsNullOrWhiteSpace(commentText))
            {
                TempData["ErrorMessage"] = "Comment cannot be empty.";
                return RedirectToAction(nameof(Details), new { id = complaintId });
            }

            var comment = new Comment
            {
                Text = commentText,
                UserName = string.IsNullOrWhiteSpace(userName) ? "Anonymous" : userName
            };

            var success = _complaintService.AddComment(complaintId, comment);
            
            if (success)
            {
                TempData["SuccessMessage"] = "Comment added successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to add comment.";
            }

            return RedirectToAction(nameof(Details), new { id = complaintId });
        }

        /// <summary>
        /// Get or create a unique user identifier for session tracking
        /// </summary>
        private string GetCurrentUser()
        {
            var userId = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                userId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("UserId", userId);
            }
            return userId;
        }
    }
}