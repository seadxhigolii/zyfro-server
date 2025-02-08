# Zyfro Pro

## Overview
Zyfro Pro is a Smart Document Management and Workflow Automation platform designed to streamline business operations for small and medium-sized businesses (SMBs), freelancers, and remote-first companies. Zyfro Pro helps users organize documents, automate workflows, and securely store and manage critical business files without relying on AI.

## Features
- **Customizable Workflow Automation** – Automate document processes to reduce manual work and improve efficiency.
- **Secure Cloud Storage** – Store and manage documents securely in the cloud.
- **E-Signature Integration** – Easily sign and manage documents electronically.
- **Advanced Search & Analytics** – Quickly find documents and analyze workflow efficiency.
- **Third-Party Integrations** – Seamlessly connect with tools like QuickBooks, Google Workspace, and Microsoft 365.

## Tech Stack
- **Backend:** .NET Core
- **Frontend:** Angular
- **Cloud Infrastructure:** AWS
- **Database:** PostgreSQL for structured data
- **Search Engine:** Elasticsearch for fast document retrieval

## Installation
### Prerequisites
Ensure you have the following installed:
- .NET 9.0 SDK
- Node.js
- Angular 19
- PostgreSQL
- Docker (optional, for containerized deployment)

### Setup Instructions
1. **Clone the repository:**
   ```sh
   git clone https://github.com/seadxhigolii/zyfro-server.git
   git clone https://github.com/seadxhigolii/zyfro-client.git
   ```
2. **Backend Setup:**
   ```sh
   cd zyfro-server
   dotnet restore
   dotnet run
   ```
3. **Frontend Setup:**
   ```sh
   cd zyfro-client
   npm install
   npm start
   ```
4. **Database Setup:**
   - Configure your PostgreSQL database and update the connection string in the backend.
   - Run database migrations:
     ```sh
     dotnet ef database update
     ```

## Deployment
### Docker Deployment
To deploy using Docker, run:
```sh
docker-compose up --build
```

## Contact
For support or inquiries, reach out to: [sead.xhigoli@proton.me]

