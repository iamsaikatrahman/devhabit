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
