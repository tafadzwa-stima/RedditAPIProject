# RedditAPISolution


This is a RESTful API built with ASP.NET Core that provides functionality for managing posts and users.

## Getting Started

To get started with the project, follow these instructions:

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) installed on your machine.

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/yourprojectname.git
2.Change Database Connection String your local one

3. Run initial Database Migration and Update Database
4. dotnet restore dependenices   
5. Run the API  locally on http://localhost:5000

Usage
Endpoints

POST /api/users: Create a new user.

POST /api/posts: Create a new post.

PUT /api/posts/{postId}: Update an existing post.

DELETE /api/posts/{postId}: Delete a post.

POST /api/posts/{postId}/upvote: Upvote a post.

POST /api/posts/{postId}/downvote: Downvote a post.

GET /api/posts/user/{username}: Get all posts by a user.
GET /api/posts/{postId}: Get details of a post, including comments and vote counts.
