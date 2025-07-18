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

## 🛠️ API Change Management in REST API

**API Change Management** refers to the practices and strategies used to handle modifications in your REST API **without breaking existing clients**. As APIs evolve over time, it's crucial to introduce changes in a controlled and backward-compatible way.

---

## 🔄 Types of API Changes

### ✅ **Non-Breaking Changes (Safe to Release)**

* Adding new fields to the response
* Adding new optional query parameters
* Adding new endpoints
* Deprecating features (with a warning)

### ❌ **Breaking Changes (Need Versioning or Coordination)**

* Removing or renaming existing fields
* Changing the data type of a field
* Modifying response structure
* Changing the endpoint path
* Making optional fields required

---

## 📋 Best Practices for API Change Management

### 1. **Use API Versioning**

Always version your API to safely manage breaking changes. For example:

```http
GET /api/v1/users
GET /api/v2/users
```

### 2. **Deprecate Gradually**

* Mark old endpoints or fields as deprecated.
* Provide a deprecation notice in the response headers or documentation.

```http
Warning: 299 - "Deprecated API. Please migrate to /api/v2/users"
```

### 3. **Communicate Clearly**

* Use changelogs and release notes.
* Notify clients (email, dashboards, etc.) before making major changes.

### 4. **Follow Semantic Versioning**

If applicable:

* `v1.0.0` → Initial release
* `v1.1.0` → Minor (non-breaking) additions
* `v2.0.0` → Major (breaking) changes

### 5. **Use Feature Flags**

Control feature rollout and test changes without affecting all users.

### 6. **Automated Testing & Monitoring**

* Ensure new changes don’t break existing functionality.
* Monitor API usage to identify which endpoints or fields are in use.

---

## 🚧 Example of Safe Change

Adding a new `email` field:

```json
// Old response
{
  "id": 1,
  "name": "John"
}

// New response
{
  "id": 1,
  "name": "John",
  "email": "john@example.com"  // Added non-breaking field
}
```

---

