# Music Platform

A music platform akin to Spotify, allowing users to stream their favorite songs anytime and create personalized playlists.

## Features

- **Stream Music:** Users can listen to their favorite songs anytime.
- **Personalized Playlists:** Create and manage custom playlists.
- **User Authentication:** Secure login and user management.
- **Search Functionality:** Easily find songs, artists, and albums.

## Technologies Used

- **Server-side:** C#
- **Client-side:** React
- **Database:** SQL Server

## Getting Started

### Prerequisites

- .NET Core SDK
- Node.js and npm
- SQL Server

### Installation

1. **Clone the repository:**
    ```bash
    git clone https://github.com/yourusername/music-platform.git
    cd music-platform
    ```

2. **Backend Setup:**
    - Navigate to the server directory and restore dependencies:
        ```bash
        cd server
        dotnet restore
        ```
    - Configure the SQL Server connection string in `appsettings.json`.
    - Run the server:
        ```bash
        dotnet run
        ```

3. **Frontend Setup:**
    - Navigate to the client directory and install dependencies:
        ```bash
        cd ../client
        npm install
        ```
    - Start the development server:
        ```bash
        npm start
        ```

4. **Database Setup:**
    - Ensure SQL Server is running.
    - Run database migrations if applicable:
        ```bash
        dotnet ef database update
        ```

## Usage

1. Open your browser and navigate to `http://localhost:3000`.
2. Register a new account or log in with existing credentials.
3. Start streaming music and creating playlists!

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Contact

For any questions or feedback, please contact [your-email@example.com](mailto:your-email@example.com).
