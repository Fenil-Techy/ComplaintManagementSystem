# 🎓 Campus Complaint Management System

A comprehensive web-based complaint management system built with **ASP.NET Core MVC** that enables students to submit, track, and discuss campus-related issues while providing administrators with powerful tools to manage and resolve complaints efficiently.

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-blue)
![C#](https://img.shields.io/badge/C%23-12.0-purple)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-purple)
![License](https://img.shields.io/badge/License-MIT-green)

## 🌟 Features

### 👨‍🎓 Student Portal
- **Submit Complaints** - Easy-to-use form for reporting campus issues
- **Anonymous Submissions** - Optional privacy protection for sensitive complaints
- **Public View** - Real-time display of all submitted complaints
- **Like System** - Support complaints that matter to you
- **Comment & Discuss** - Engage with other students on issues
- **Filter & Search** - Find complaints by category or status
- **Track Status** - Monitor complaint progress (Pending → In Progress → Resolved)

### 👨‍💼 Admin Dashboard
- **Statistics Overview** - Real-time metrics and insights
- **Complaint Management** - Update status and resolve issues
- **Comprehensive View** - See all complaints with detailed information
- **Status Updates** - Mark complaints as Pending, In Progress, or Resolved
- **Engagement Metrics** - Track likes and comments

### 🎨 Design Features
- **Responsive Design** - Works seamlessly on desktop, tablet, and mobile
- **Modern UI** - Built with Bootstrap 5 and custom CSS
- **Interactive Elements** - AJAX-powered likes without page refresh
- **Role-Based Access** - Separate student and admin interfaces
- **Session Management** - Secure role-based authentication

## 📂 Project Structure

```
ComplaintManagementSystem/
├── Controllers/
│   ├── HomeController.cs          # Landing page & role selection
│   ├── ComplaintsController.cs    # Student complaint operations
│   └── AdminController.cs         # Admin dashboard & management
├── Models/
│   └── Complaint.cs               # Data models (Complaint, Comment, Status)
├── Services/
│   └── ComplaintService.cs        # Business logic & in-memory storage
├── Views/
│   ├── Home/
│   │   └── Index.cshtml          # Landing page with role selection
│   ├── Complaints/
│   │   ├── AdminDetails.cshtml
│   │   ├── Index.cshtml         # All complaints (public view)
│   │   ├── Create.cshtml         # Submit new complaint form
│   │   └── Details.cshtml        # Complaint details with comments
│   └── Admin/
│       └── Dashboard.cshtml       # Admin management interface
└── Program.cs                     # Application configuration
```

## 🚀 Getting Started

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) or later
- Visual Studio 2022 / VS Code / Rider (optional)
- Web browser (Chrome, Firefox, Edge, Safari)

### Installation

1. **Clone the repository**
```bash
git clone https://github.com/Fenil-Techy/ComplainManagementSystem.git
cd ComplaintManagementSystem
code .
```

2. **Restore dependencies**
```bash
dotnet restore
```

3. **Build the project**
```bash
dotnet build
```

4. **Run the application**
```bash
dotnet run
```


## 💡 Usage

### For Students

1. **Select Role** - Choose "Student" on the landing page
2. **Submit Complaint** - Click "Submit Complaint" button
3. **Fill Details** - Enter title, category, and description
4. **Anonymous Option** - Check the box for anonymous submission
5. **Track Progress** - View your complaint status in the public view
6. **Engage** - Like and comment on complaints

### For Administrators

1. **Select Role** - Choose "Admin" on the landing page
2. **View Dashboard** - See all statistics and complaints
3. **Manage Complaints** - Update status from dropdown menu
4. **Track Metrics** - Monitor total complaints, likes, and comments
5. **Resolve Issues** - Mark complaints as resolved when done

## 📋 Categories Supported

- 🏠 **Hostel** - Accommodation issues
- ⚡ **Electrical** - Power and electrical problems
- 📚 **Library** - Library facilities and resources
- 🍽️ **Canteen** - Food and dining services
- 🏛️ **Department** - Department-specific issues
- 🏗️ **Infrastructure** - Building and maintenance
- 🚌 **Transportation** - Campus transport services
- ⚽ **Sports Facilities** - Sports and recreation
- 📖 **Academic** - Academic-related concerns
- 📌 **Other** - Miscellaneous issues

## 🛠️ Technology Stack

- **Backend**: ASP.NET Core MVC 8.0
- **Language**: C# 12.0
- **Frontend**: Razor Views, HTML5, CSS3
- **Styling**: Bootstrap 5.3, Custom CSS
- **Icons**: Bootstrap Icons
- **Storage**: In-Memory (for demonstration)
- **Session**: ASP.NET Core Session Management


## 🚧 Future Enhancements

- [ ] Database integration (SQL Server/PostgreSQL)
- [ ] User authentication (ASP.NET Identity)
- [ ] Email notifications
- [ ] File upload support (images/documents)
- [ ] Advanced search and filtering
- [ ] Export reports to PDF/Excel
- [ ] Real-time notifications (SignalR)
- [ ] Mobile application
- [ ] Multi-language support
- [ ] Role-based permissions (Super Admin, Moderator)

## 📱 Screenshots

### Landing Page
<img width="1882" height="915" alt="Screenshot 2025-10-30 005820" src="https://github.com/user-attachments/assets/8a847441-fcce-4dd6-bdf4-2e582453d443" />

<img width="1888" height="922" alt="Screenshot 2025-10-30 005832" src="https://github.com/user-attachments/assets/b184d22f-957d-4090-a225-87a16335d8e4" />

### Student Dashboard
<img width="1903" height="914" alt="Screenshot 2025-10-30 005847" src="https://github.com/user-attachments/assets/0ca07d40-23eb-42bc-b27d-dd0e7e6cd7c9" />

### Admin Dashboard
<img width="1884" height="916" alt="Screenshot 2025-10-30 005903" src="https://github.com/user-attachments/assets/9a7f8d71-9102-4615-832e-43e7f9292213" />

### Complaint Details
<img width="1884" height="924" alt="Screenshot 2025-10-30 010622" src="https://github.com/user-attachments/assets/4391846e-76d7-4399-8439-69d5418ae7ad" />
<img width="1884" height="916" alt="Screenshot 2025-10-30 010556" src="https://github.com/user-attachments/assets/40c18595-d948-443a-8adf-b4a0638e67ef" />
<img width="1887" height="908" alt="Screenshot 2025-10-30 010539" src="https://github.com/user-attachments/assets/f0a87e00-1f84-47a6-ab41-19b41e0fd654" />

<img width="1881" height="916" alt="Screenshot 2025-10-30 010522" src="https://github.com/user-attachments/assets/84ca95b6-859f-420d-ac24-b183e48c9008" />




