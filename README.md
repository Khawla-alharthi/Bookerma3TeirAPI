# Bookerma3TeirAPI

A comprehensive 3-tier booking management API built with modern web technologies, featuring a robust architecture with presentation, business logic, and data access layers.

## 🏗️ Architecture Overview

This API follows a 3-tier architecture pattern:

- **Presentation Tier**: RESTful API endpoints and request/response handling
- **Business Logic Tier**: Core booking logic, validation, and business rules
- **Data Access Tier**: Database operations and data persistence

## 🚀 Features

- **Booking Management**: Create, read, update, and delete bookings
- **User Authentication**: Secure user registration and login
- **Resource Management**: Manage bookable resources (rooms, services, etc.)
- **Availability Checking**: Real-time availability verification
- **Booking Conflicts Prevention**: Automated conflict detection
- **Status Tracking**: Comprehensive booking status management
- **API Documentation**: Interactive API documentation with Swagger/OpenAPI

## 🛠️ Tech Stack

- **Backend Framework**: [Your framework - e.g., Node.js/Express, .NET Core, Spring Boot]
- **Database**: [Your database - e.g., PostgreSQL, MySQL, MongoDB]
- **Authentication**: JWT (JSON Web Tokens)
- **Documentation**: Swagger/OpenAPI
- **Testing**: [Your testing framework]
- **Deployment**: [Your deployment platform]

## 📋 Prerequisites

Before running this application, make sure you have the following installed:

- [Runtime/SDK version - e.g., Node.js 18+, .NET 6+, Java 17+]
- [Database - e.g., PostgreSQL 13+, MySQL 8+]
- [Package Manager - e.g., npm, yarn, Maven, NuGet]

## 🔧 Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Khawla-alharthi/Bookerma3TeirAPI.git
   cd Bookerma3TeirAPI
   ```

2. **Install dependencies**
   ```bash
   # For Node.js
   npm install
   
   # For .NET
   dotnet restore
   
   # For Java/Maven
   mvn install
   ```

3. **Set up environment variables**
   ```bash
   cp .env.example .env
   ```
   
   Configure the following variables in `.env`:
   ```env
   DATABASE_URL=your_database_connection_string
   JWT_SECRET=your_jwt_secret_key
   API_PORT=3000
   NODE_ENV=development
   ```

4. **Set up the database**
   ```bash
   # Run database migrations
   npm run migrate
   
   # Seed initial data (optional)
   npm run seed
   ```

5. **Start the application**
   ```bash
   # Development mode
   npm run dev
   
   # Production mode
   npm start
   ```

## 📡 API Endpoints

### Authentication
- `POST /api/auth/register` - Register a new user
- `POST /api/auth/login` - User login
- `POST /api/auth/refresh` - Refresh access token

### Bookings
- `GET /api/bookings` - Get all bookings
- `GET /api/bookings/:id` - Get booking by ID
- `POST /api/bookings` - Create a new booking
- `PUT /api/bookings/:id` - Update booking
- `DELETE /api/bookings/:id` - Cancel/delete booking

### Resources
- `GET /api/resources` - Get all bookable resources
- `GET /api/resources/:id` - Get resource by ID
- `GET /api/resources/:id/availability` - Check resource availability

### Users
- `GET /api/users/profile` - Get user profile
- `PUT /api/users/profile` - Update user profile
- `GET /api/users/bookings` - Get user's bookings

## 📖 API Documentation

Once the server is running, you can access the interactive API documentation at:
```
http://localhost:3000/api-docs
```

## 🧪 Testing

Run the test suite:

```bash
# Run all tests
npm test

# Run tests with coverage
npm run test:coverage

# Run tests in watch mode
npm run test:watch
```

## 🏗️ Project Structure

```
Bookerma3TeirAPI/
├── src/
│   ├── controllers/          # Presentation tier - API controllers
│   ├── services/            # Business logic tier - Service layer
│   ├── repositories/        # Data access tier - Repository pattern
│   ├── models/              # Data models and schemas
│   ├── middleware/          # Custom middleware
│   ├── routes/              # API route definitions
│   ├── utils/               # Utility functions
│   └── config/              # Configuration files
├── tests/                   # Test files
├── docs/                    # Additional documentation
├── migrations/              # Database migrations
└── seeds/                   # Database seed files
```

## 🔐 Authentication

This API uses JWT (JSON Web Tokens) for authentication. Include the token in your requests:

```http
Authorization: Bearer <your-jwt-token>
```

## 📝 Usage Examples

### Create a Booking
```javascript
const booking = {
  resourceId: "12345",
  userId: "67890",
  startTime: "2024-01-15T10:00:00Z",
  endTime: "2024-01-15T12:00:00Z",
  notes: "Team meeting"
};

const response = await fetch('/api/bookings', {
  method: 'POST',
  headers: {
    'Content-Type': 'application/json',
    'Authorization': 'Bearer your-jwt-token'
  },
  body: JSON.stringify(booking)
});
```

### Check Availability
```javascript
const availability = await fetch('/api/resources/12345/availability?date=2024-01-15');
const data = await availability.json();
```

## 🚀 Deployment

### Using Docker
```bash
# Build the Docker image
docker build -t bookerma3teir-api .

# Run the container
docker run -p 3000:3000 --env-file .env bookerma3teir-api
```

### Using Docker Compose
```bash
docker-compose up -d
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **Khawla Al-Harthi** - *Initial work* - [Khawla-alharthi](https://github.com/Khawla-alharthi)

## 🙏 Acknowledgments

- Thanks to all contributors who have helped shape this project
- Inspired by modern API design principles and best practices

## 📞 Support

If you have any questions or need help, please:

1. Check the [documentation](docs/)
2. Search existing [issues](https://github.com/Khawla-alharthi/Bookerma3TeirAPI/issues)
3. Create a new issue if needed

## 📈 Roadmap

- [ ] Add email notifications for booking confirmations
- [ ] Implement recurring bookings
- [ ] Add calendar integration
- [ ] Implement booking approval workflow
- [ ] Add reporting and analytics features
- [ ] Mobile app integration support

---

**Happy Coding!** 🎉
