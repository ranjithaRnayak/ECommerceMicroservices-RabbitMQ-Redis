# 🛒 E-Commerce Microservices – Event-driven Architecture & Redis Caching

This project demonstrates a scalable, decoupled **microservices architecture** built with **.NET 8**, featuring:
- 🔁 **Event-driven communication** via **RabbitMQ**
- ⚡ **In-memory caching** via **Redis**
- 🧠 Clean separation of concerns across services
- 🐳 Docker-based message broker setup for local dev
- 🔍 Swagger API documentation for testing endpoints

---

## 📦 Services Overview

### 🧾 1. ProductService
- Endpoint: `GET /product`
- Returns a hardcoded product list
- On first call, saves response in **Redis**
- On next calls, fetches data from Redis cache for faster performance

### 📤 2. OrderService
- Endpoint: `POST /order`
- Accepts a product name as plain string in request body
- Publishes the event (`OrderPlaced`) to RabbitMQ queue named `order-placed`

### 📥 3. InventoryService
- Subscribes to `order-placed` RabbitMQ queue
- Logs each product order received
- Simulates real-time stock update

---

## 🧠 Architecture Diagram


All services are decoupled and communicate through **asynchronous messaging** using RabbitMQ.

---

## 🛠️ Tech Stack

- ✅ ASP.NET Core 8 Web API
- ✅ RabbitMQ (Dockerized with Management UI)
- ✅ Redis (Dockerized)
- ✅ Docker (for running message brokers)
- ✅ RabbitMQ.Client NuGet package
- ✅ StackExchange.Redis NuGet package
- ✅ Swagger / Swashbuckle for API testing

---

## 🚀 Run Locally

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

---

### 🐳 Start Redis (caching)
```bash
docker run -p 6379:6379 redis
docker run -d --hostname rabbit-dev --name rabbitmq-dev \
  -p 5672:5672 -p 15672:15672 rabbitmq:3-management
 http://localhost:15672
Login: guest / guest
