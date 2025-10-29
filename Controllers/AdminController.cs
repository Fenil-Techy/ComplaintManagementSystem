using Microsoft.AspNetCore.Mvc;
using ComplaintManagementSystem.Models;
using ComplaintManagementSystem.Services;

namespace ComplaintManagementSystem.Controllers
{
    /// <summary>
    /// Admin controller for managing complaint status and viewing statistics
    /// </summary>
    public class AdminController : Controller
    {
        private readonly ComplaintService _complaintService;

        public AdminController()
        {
            _complaintService = new ComplaintService();
        }

        /// <summary>
        /// Admin dashboard showing statistics and all complaints
        /// </summary>
        [HttpGet]
        public IActionResult Dashboard()
        {
            var stats = _complaintService.GetStats();
            var complaints = _complaintService.GetAllComplaints();

            ViewBag.Stats = stats;
            // Assumes the corresponding view file is Views/Admin/Dashboard.cshtml
            return View(complaints); 
        }

        /// <summary>
        /// Update complaint status (Resolve, Mark In Progress, etc.)
        /// This is the primary endpoint used by the Admin Dashboard table.
        /// </summary>
        [HttpPost]
        public IActionResult UpdateStatus(int id, ComplaintStatus status)
        {
            var success = _complaintService.UpdateComplaintStatus(id, status);
            
            if (success)
            {
                TempData["SuccessMessage"] = $"Complaint status updated to {status}.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to update complaint status.";
            }

            // FIX: Redirects back to the Dashboard action within the AdminController.
            return RedirectToAction(nameof(Dashboard)); 
        }
    }
}