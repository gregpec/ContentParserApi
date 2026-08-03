# ContentParserApi

ContentParserApi is an ASP.NET Core Web API that accepts Base64 encoded CSV or INTERNAL_JSON data, parses it, and returns the result in a unified JSON format.

## Requirements

- .NET 8 SDK or newer

## Run the application

Clone the repository:

```bash
git clone https://github.com/gregpec/ContentParserApi.git
cd ContentParserApi
```

Restore NuGet packages:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run --project ContentParserApi
```

## Swagger

HTTP

```
http://localhost:5242/swagger
```

HTTPS

```
https://localhost:7097/swagger
```

---

## Endpoint

```
POST /api/v1/parse-content
```

**Content-Type**

```
application/json
```

Supported content types:

- `CSV`
- `INTERNAL_JSON`

---

## HTTP status codes

| Status Code | Description |
|--------------|-------------|
| **200 OK** | Request processed successfully. |
| **400 Bad Request** | Invalid request. Returned when the parser type is unsupported, the Base64 content is invalid, or the CSV/INTERNAL_JSON data cannot be parsed. |
| **500 Internal Server Error** | An unexpected server error occurred while processing the request. |

---

## Example CSV data

```csv
Id,Brand,Processor,RAM,SSD
1,Lenovo ThinkPad T14,Intel Core i5-1240P,16 GB,512 GB
2,Dell Latitude 7440,Intel Core i7-1365U,32 GB,1 TB
```

Example request:

```json
{
  "type": "CSV",
  "content": "<Base64 encoded CSV content>"
}
```

---

## Example INTERNAL_JSON data

```json
[
  {
    "Id": 1,
    "Brand": "Lenovo ThinkPad T14",
    "Processor": "Intel Core i5-1240P",
    "RAM": "16 GB",
    "SSD": "512 GB"
  },
  {
    "Id": 2,
    "Brand": "Dell Latitude 7440",
    "Processor": "Intel Core i7-1365U",
    "RAM": "32 GB",
    "SSD": "1 TB"
  }
]
```

Example request:

```json
{
  "type": "INTERNAL_JSON",
  "content": "<Base64 encoded JSON content>"
}
```

---

## Example PowerShell / curl request

```powershell
curl.exe -k -L `
  -X POST https://localhost:7097/api/v1/parse-content `
  -H "Content-Type: application/json" `
  --data-binary "@request.json"
```

Example `request.json`:

```json
{
  "type": "CSV",
  "content": "<Base64 encoded CSV content>"
}
```

---

## Successful response

```json
{
  "status": "success",
  "count": 2,
  "data": [
    {
      "fields": {
        "Id": "1",
        "Brand": "Lenovo ThinkPad T14",
        "Processor": "Intel Core i5-1240P",
        "RAM": "16 GB",
        "SSD": "512 GB"
      }
    },
    {
      "fields": {
        "Id": "2",
        "Brand": "Dell Latitude 7440",
        "Processor": "Intel Core i7-1365U",
        "RAM": "32 GB",
        "SSD": "1 TB"
      }
    }
  ]
}
```

---

## Example error responses

### Unsupported parser type

```json
{
  "status": "error",
  "message": "Unsupported parser type 'XML'."
}
```

### Invalid Base64 content

```json
{
  "status": "error",
  "message": "Invalid Base64 content."
}
```

### Invalid JSON format

```json
{
  "status": "error",
  "message": "Invalid JSON format."
}
```

### Invalid CSV

```json
{
  "status": "error",
  "message": "Liczba wartości nie zgadza się z liczbą nagłówków."
}
```