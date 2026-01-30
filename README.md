# Task Management Service API

### Project information
- Project name: Task Management Service
- Student Name: Archiben Maheshkumar Patel
- Student Number: 8873472


### Project Description: 
Task Management Service - A Web API application with a complete CRUD inteface for managing task items in a task management system. It also includes comprehensive validation, error handling, and follows RESTful priniciples.

### Domain Model Description:
The core domain model represents a task with the following properties:
Property - type, description, validation
- Id - int, unique identifier
- Title - string, task titile, required, 3-150 chars
- Description - string, task description, required, 3-150 chars
- Priority - TaskPriority, Priority level (Low/Medium/High/Critical), required
- Status - TaskStatus, Current status, required
- DueDate - DateTime?, due date for completion, required, future date
- EstimatedHours - int, estimated hours to cimplete, range: 1-100
- CreatedAt - DateTime, Creation timestamp, Auto-set
- UpdatedAt - DateTime?, last updated timestamp, auto-updated

# enums
TaskPriority - low, medium, high, critical,
TaskStatus - Pending, InProgress, Completed, Cancelled

# Base URL to get data from database: http://localhost:5071/api/TaskItems

# URL to run on swagger: http://localhost:5071/swagger

# API endpoints:
* Method, Endpoint, Description, Status Code
1. GET, /api/TaskItems, get akk tasks, 200
2. GET, /api/TaskItems/{id}, get task by ID, 200, 404
3. POST, /api/TaskItems, create new task, 201, 400
4. PUT, api/TaskItems/{id}, update existing task, 200, 400, 404, 409
5. DELETE, /api/TaskItems/{id}, delete task, 204, 404

# Installation, Setup & Run
1. Clone repository [URL: https://github.com/ArchiPatel09/TaskManagementService] or download the submitted zip file
2. write donet restore to restore the dependencies 
3. write dotnet run to run the app
4. When the application runs, go to google or edge and type url: http://localhost:PORT/swagger to check swagger endpoints
5. If you want to see the data from the database, type this url: http://localhost:PORT/api/TaskItems