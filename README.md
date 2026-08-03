# \# ContentParserApi

# 

# ASP.NET Core Web API for parsing different input formats into a standardized data structure.

# 

# \## Features

# 

# \- CSV parser

# \- Internal JSON parser (in progress)

# \- Dependency Injection

# \- Dynamic parser selection

# \- Swagger (OpenAPI)

# \- cURL support

# \- Base64 input support (planned)

# 

# \---

# 

# \## Technologies

# 

# \- .NET 8

# \- ASP.NET Core Web API

# \- C#

# \- Swagger / OpenAPI

# \- System.Text.Json

# 

# \---

# 

# \## Project Structure

# 

# ```

# ContentParserApi

# │

# ├── Controllers

# ├── Enums

# ├── Models

# ├── Parsers

# └── Program.cs

# ```

# 

# \---

# 

# \## Supported Content Types

# 

# | Type | Status |

# |------|--------|

# | CSV | ✅ |

# | INTERNAL\_JSON | 🚧 |

# 

# \---

# 

# \# Getting Started

# 

# \## Clone repository

# 

# ```bash

# git clone https://github.com/gregpec/ContentParserApi.git

# ```

# 

# \## Navigate to the project

# 

# ```powershell

# cd ContentParserApi

# ```

# 

# \## Run the application

# 

# ```powershell

# dotnet run

# ```

# 

# Example output:

# 

# ```text

# Now listening on: http://localhost:5242

# ```

# 

# \---

# 

# \# Swagger

# 

# Open:

# 

# ```

# http://localhost:5242/swagger

# ```

# 

# \---

# 

# \# API

# 

# \## Endpoint

# 

# ```

# POST /api/v1/parse-content

# ```

# 

# \---

# 

# \## Sample Request

# 

# ```json

# {

# &#x20; "type": "CSV",

# &#x20; "content": "Id,Name,Age\\n1,Jan,20\\n2,Anna,25"

# }

# ```

# 

# \---

# 

# \## Sample Response

# 

# ```json

# \[

# &#x20; {

# &#x20;   "fields": {

# &#x20;     "Id": "1",

# &#x20;     "Name": "Jan",

# &#x20;     "Age": "20"

# &#x20;   }

# &#x20; },

# &#x20; {

# &#x20;   "fields": {

# &#x20;     "Id": "2",

# &#x20;     "Name": "Anna",

# &#x20;     "Age": "25"

# &#x20;   }

# &#x20; }

# ]

# ```

# 

# \---

# 

# \# Testing with cURL

# 

# Create \*\*request.json\*\*

# 

# ```json

# {

# &#x20; "type": "CSV",

# &#x20; "content": "Id,Name,Age\\n1,Jan,20\\n2,Anna,25"

# }

# ```

# 

# Run:

# 

# ```powershell

# curl.exe -X POST http://localhost:5242/api/v1/parse-content `

# \-H "Content-Type: application/json" `

# \--data-binary "@request.json"

# ```

# 

# \---

# 

# \# Creating Base64 Content (PowerShell)

# 

# \## Create CSV file

# 

# ```powershell

# @"

# Id,Name,Age

# 1,Jan,20

# 2,Anna,25

# "@ | Set-Content .\\dane.csv

# ```

# 

# \## Encode to Base64

# 

# ```powershell

# $base64 = \[Convert]::ToBase64String(

# &#x20;   \[Text.Encoding]::UTF8.GetBytes(

# &#x20;       (Get-Content .\\dane.csv -Raw)

# &#x20;   )

# )

# ```

# 

# Display the encoded string:

# 

# ```powershell

# $base64

# ```

# 

# Example output:

# 

# ```text

# SWQsTmFtZSxBZ2UKMSxKYW4sMjAKMixBbm5hLDI1

# ```

# 

# Create \*\*request.json\*\*

# 

# ```powershell

# @"

# {

# &#x20; "type": "CSV",

# &#x20; "content": "$base64"

# }

# "@ | Set-Content .\\request.json

# ```

# 

# Send request:

# 

# ```powershell

# curl.exe -X POST http://localhost:5242/api/v1/parse-content `

# \-H "Content-Type: application/json" `

# \--data-binary "@request.json"

# ```

# 

# \---

# 

# \# Architecture

# 

# ```

# HTTP Request

# &#x20;     │

# &#x20;     ▼

# ParseContentController

# &#x20;     │

# &#x20;     ▼

# IEnumerable<IContentParser>

# &#x20;     │

# &#x20;     ▼

# CsvParser / InternalJsonParser

# &#x20;     │

# &#x20;     ▼

# List<ParsedRecord>

# &#x20;     │

# &#x20;     ▼

# JSON Response

# ```

# 

# \---

# 

# \# Current Status

# 

# \### Implemented

# 

# \- CSV parser

# \- Parser interface

# \- Dependency Injection

# \- Dynamic parser selection

# \- Swagger support

# \- cURL testing

# \- CSV validation

# \- Dynamic field mapping

# 

# \### Planned

# 

# \- Base64 decoding

# \- Internal JSON parser

# \- Unit tests

# \- Docker support

# \- CI/CD

# 

# \---

# 

# \# Future Improvements

# 

# \- Support for additional file formats

# \- File upload endpoint

# \- Logging

# \- Exception middleware

# \- Performance improvements

# 

# \---

# 

# \# Author

# 

# \*\*Grzegorz Pęksa\*\*

# 

# GitHub:

# 

# https://github.com/gregpec

