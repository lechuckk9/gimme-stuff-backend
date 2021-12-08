# gimme-stuff-to-do-api
Create a web application based on ASP.NET Core (v3+) as backend and Angular as frontend. This is the Backend part of the task.

# Idealization
Company Init X is on the market for an easier-to-use, Jira-esque straight-to-the-case task managment website. They offered to pay nice bucks for the solution and it's completely up to the developer, how the site is going to look and behave. Still, a set of rules or guidelines has to be followed; it's available below, under Instructions.

The app is reachable at: gimme-stuff.com.

# Frontend
  • Login page,
  • Main page with:
    o Kanban board, with modifiable table (cells represent tasks and can be horizontally moved across statuses),
    o Add new task modal,
    o Delete task (archive),
    o Assign task,
    o Add existing task to a group modal,
    o Sign out.

# Backend
  • Single entry point - GimmeStuff.API:
    o Controllers,
    o Authentication,
    o Model - policy authorization.
  • Coupled Tests project.
  • Seperate Lib projects, decoupled business logic (can latter be dissected into seperate microservices):
    o Tasks,
    o Data (Persistence and caching),
    o Users.

# Instructions
TASK: C# backend with SPA frontend
Create a web application based on ASP.NET Core (v3+) as backend and Angular as frontend.
The application should have the following features:

  • Underlying model can be anything (books/tasks/movies etc)
  • Front end should be able to get some data from backend
  • Backend should be able to accept data sent from frontend
  • Backend should be connected to a DB
  • Frontend and backend should validate data (at least date, number and
  required types should be used)
  • Backend should allow a pageable »list« and CRUD operations, a search
  functionality is a plus
  • Individual components should be loosely coupled using DI (any framework)
  • Unit tests
  • A version control is used to share the code
  • A concept how to achieve and maintain internationalization, with at least 2
  supported languages/locales
  • Several API endpoints should have an authentication challenge (users can be
  fake/hardcoded)
  • At least one API endpoint should have an authorization challenge
  (roles/permissions can be fake/hardcoded)
  • Authentication and authorization strategy also on frontend
  • Different configurations for different enviroments
  • Caching of data
  • Exception handling strategy
  • Simulate a branching strategy
  • Bonus points:
    o Application should be deployed and reachable from internet
    o Usage of containers

Please provide a list of used tools, the source code and instructions how to compile/run the
code.
