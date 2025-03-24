# 🛒 E-Commerce Microservices – Redis Caching + RabbitMQ Messaging

This project demonstrates a real-world microservices architecture using:
- ✅ .NET 8 Web APIs
- ✅ Redis for caching (ProductService)
- ✅ RabbitMQ for event-driven communication (Order → Inventory)
- ✅ Swagger for API testing

---

## 🔧 Technologies Used

- ASP.NET Core 8
- Redis (via StackExchange.Redis)
- RabbitMQ (via Docker + RabbitMQ.Client)
- Docker for running Redis & RabbitMQ
- Swagger UI for testing APIs

---

## 📦 Services

### 1. ProductService
- `GET /product`
- Returns product list, cached in Redis

### 2. OrderService
- `POST /order`
- Publishes product name to RabbitMQ (`order-placed` queue)

### 3. InventoryService
- Listens to `order-placed` queue
- Logs stock update for ordered product

---

## 🐳 Run Locally with Docker

### Start Redis
```bash
docker run -p 6379:6379 redis




