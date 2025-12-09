# Task & Project Tracking System - TaskPro

A C# console application designed to help small teams organize their work through task management, tracking, and reporting.

## Purpose

This system allows teams to:
- Create and manage tasks with unique IDs, due dates, priorities, and assignees
- Update task statuses (To-Do, In Progress, Done)
- Search and sort tasks by various criteria
- Generate reports for overdue and upcoming tasks
- Persist data between sessions using JSON
- Maintain activity logs for auditing

## Features

- **Task Management**: Create, update, and view tasks
- **Persistence**: Automatic saving to `tasks.json`
- **Logging**: Activity tracking in `activity_log.txt`
- **Search**: Find tasks by assignee name
- **Sorting**: Sort by priority or due date using custom algorithms
- **Reporting**: View overdue tasks at a glance

## How to Run

### Prerequisites
- .NET 4.8 SDK or later 
- Visual Studio 2022 

### Getting Started from GitHub

#### Step 1: Clone the Repository

**Option A: Using Visual Studio 2022**
1. Open **Visual Studio 2022**
2. Click on **Clone a repository** on the start screen
3. Enter the repository URL: `https://github.com/sandeepcheema875/TaskPro` 
4. Choose a local path (e.g., `C:\Projects\TaskPro`)
5. Click **Clone**

**Option B: Using Git Command Line**
```bash
git clone https://github.com/sandeepcheema875/TaskPro.git
cd TaskPro
```

#### Step 2: Open the Project in Visual Studio 2022

1. If not already open, launch **Visual Studio 2022**
2. Click **File** → **Open** → **Project/Solution**
3. Navigate to the cloned repository folder
4. Select `TaskPro.sln` (or `TaskPro.csproj` if no solution file exists)
5. Click **Open**

#### Step 3: Restore NuGet Packages

Visual Studio should automatically restore packages. If not:
1. Right-click on the **Solution** in Solution Explorer
2. Select **Restore NuGet Packages**
3. Wait for the restore to complete

#### Step 4: Build the Project

1. Click **Build** → **Build Solution** (or press `Ctrl+Shift+B`)
2. Check the **Output** window for any build errors
3. Ensure you see "Build succeeded" message

#### Step 5: Run the Application

**With Debugging:**
- Press **F5** or click the green **Start** button
- This allows you to use breakpoints and debugging tools

**Without Debugging:**
- Press **Ctrl+F5** or click **Debug** → **Start Without Debugging**
- Runs faster, no debugging overhead

### Alternative: Running from Command Line

```bash
cd "path\to\TaskPro"
dotnet restore
dotnet build
dotnet run
```


### Using the Application

Once running, you'll see a menu with the following options:
1. **Create Task** - Add a new task with title, description, due date, priority, and assignee
2. **View All Tasks** - Display all tasks in the system
3. **Update Task Status** - Change a task's status (To-Do → In Progress → Done)
4. **Search Tasks** - Find tasks by assignee name
5. **Sort Tasks** - Sort by priority (High to Low) or due date (earliest first)
6. **View Overdue Tasks** - See tasks past their due date
7. **Exit** - Close the application

## Design Choices

### Architecture
The application follows a **layered architecture** pattern:
- **Models**: Data entities (`TaskItem`, `Priority`, `Status`)
- **Data Layer**: File I/O and persistence (`JsonRepository`, `Logger`)
- **Services Layer**: Business logic (`TaskManager`, sorting, searching)
- **UI Layer**: User interaction (`MenuHandler`, `Program`)

### Design Patterns

#### 1. Singleton Pattern
**Class**: `Logger`

**Rationale**: Ensures a single point of access for logging throughout the application, preventing file access conflicts and maintaining consistency.

#### 2. Repository Pattern
**Interface**: `ITaskRepository`  
**Implementation**: `JsonRepository`

**Rationale**: Abstracts data access logic, making it easy to swap storage mechanisms (e.g., from JSON to database) without changing business logic.

#### 3. Strategy Pattern
**Interface**: `ISortStrategy`  
**Implementations**: `BubbleSortByPriority`, `BubbleSortByDate`

**Rationale**: Allows dynamic selection of sorting algorithms at runtime, demonstrating polymorphism and the Open/Closed Principle.

### Algorithms

#### Sorting
- **Manual Implementation**: Bubble Sort (O(n²))
- **Criteria**: Priority (High→Low) and Due Date (Earliest→Latest)
- **Justification**: Demonstrates understanding of sorting algorithms; suitable for small datasets typical in team task management

#### Searching
- **Linear Search**: Used for finding tasks by assignee or ID
- **Binary Search**: Implemented for ID search (requires sorted list)
- **Justification**: Linear search is appropriate for unsorted data; binary search demonstrates optimization for sorted datasets

### Error Handling

The application implements robust error handling:
- **File I/O**: Try-catch blocks prevent crashes from missing or corrupted files
- **User Input**: Validation for dates, enums, and GUIDs with user-friendly error messages
- **Graceful Degradation**: Returns empty lists instead of null to prevent null reference exceptions

### Data Persistence

**Format**: JSON  
**File**: `tasks.json`

**Rationale**: JSON is human-readable, widely supported, and easy to debug. The `System.Text.Json` library provides efficient serialization with minimal dependencies.

### Logging

**Format**: Plain text  
**File**: `activity_log.txt`

**Rationale**: Simple append-only logging ensures chronological order and easy troubleshooting. Each entry includes a timestamp for audit trails.

## Project Structure

```
TaskPro/
├── Model/
│   ├── TaskItem.cs          # Core task entity
│   ├── Priority.cs          # Priority enum
│   └── Status.cs            # Status enum
├── Data/
│   ├── ITaskRepository.cs   # Repository interface
│   ├── JsonRepository.cs    # JSON persistence
│   └── Logger.cs            # Singleton logger
├── Services/
│   ├── TaskManager.cs       # Business logic facade
│   ├── Sorting/
│   │   ├── ISortStrategy.cs
│   │   ├── BubbleSortByPriority.cs
│   │   └── BubbleSortByDate.cs
│   └── Searching/
│       └── SearchService.cs
├── UI/
│   └── MenuHandler.cs       # Console interface
└── Program.cs               # Entry point
```

## Technologies Used

- **Language**: C# 
- **Framework**: .NET 4.8
- **Serialization**: System.Text.Json
- **Architecture**: Layered Architecture
- **Patterns**: Singleton, Repository, Strategy

## License

This project was created by [@sandeepcheema875](https://github.com/sandeepcheema875) for educational purpose.
