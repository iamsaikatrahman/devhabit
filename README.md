# 📘 HATEOAS and Change Management

## 📂 Topics Covered
- 🔗 **HATEOAS** (Hypermedia as the Engine of Application State)
- 🧩 **Implementing HATEOAS**
- 🔄 **Content Negotiation**
- 🧮 **API Versioning**
- 🛠️ **API Change Management**

---

## 🔄 Content Negotiation

**Content negotiation** in a REST API is the process where the **client and server agree on the format** of the data (like `JSON`, `XML`, etc.) to be used for the response.  
This allows the same API endpoint to deliver data in multiple formats, depending on what the client can handle or prefers.

### 🔍 Why it's useful:
- ✅ Supports different clients (browsers, mobile apps, legacy systems)
- 🔧 Improves flexibility and compatibility
- 📌 Enables easier versioning (e.g., custom media types like `application/vnd.myapi.v1+json`)

---
## 🧮 API Versioning

**API versioning** in a REST API is a strategy to manage changes and backward compatibility in your API over time. When your API evolves (e.g., `adding fields`, `changing formats`, or `removing features`), versioning helps you introduce those changes without breaking existing clients.

### 🧭 Why API Versioning is Important:
- ✅ Ensures backward compatibility for existing consumers.
- 🛠 Allows independent evolution of the API.
- 📅 Helps teams manage change over time in a structured way.
- 📉 Prevents sudden breaking changes in production.

### 🛣️ Common API Versioning Strategies

### 1. **URI Path Versioning** (Most Common)

Version is added in the URL path.

```http
GET /api/v1/products
```

✅ Simple and visible
🚫 Breaks URI structure if changed too often

---

### 2. **Query String Versioning**

Version is specified using a query parameter.

```http
GET /api/products?version=1
```

✅ Easy to test
🚫 Not always ideal for caching

---

### 3. **Header Versioning**

Version is sent as a custom request header.

```http
GET /api/products
Accept: application/vnd.myapi.v1+json
```

✅ Clean URLs
🚫 Harder to debug or use in browser

---

### 4. **Content Negotiation (Media Type Versioning)**

Version is embedded in the `Accept` header's media type.

```http
Accept: application/vnd.companyname.v1+json
```

✅ Works well with content negotiation
🚫 More complex to implement and document


## 🚦 Which Versioning Strategy Should You Use?

| Strategy            | Easy to Use | Browser-Friendly | Clean URLs | Supports Caching |
| ------------------- | ----------- | ---------------- | ---------- | ---------------- |
| URI Path            | ✅           | ✅                | ❌          | ✅                |
| Query String        | ✅           | ✅                | ✅          | ❌                |
| Header              | ❌           | ❌                | ✅          | ✅                |
| Media Type (Accept) | ❌           | ❌                | ✅          | ✅                |

---

