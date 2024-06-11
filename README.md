## Introduction

This project is a comprehensive ASP.NET MVC 8 web application that integrates with an ASP.NET API 8 for managing `ProjectType` entities. The API handles CRUD operations, while the MVC project provides a user interface to interact with the API seamlessly.

## Features

- **API Integration**: Perform CRUD operations on `ProjectType` entities via a dedicated API.
- **MVC Frontend**: Navigate and manage project types using a clean and responsive MVC frontend.
- **CRUD Operations**: Create, Read, Update, and Delete `ProjectType` entities.
- **Dynamic Navigation**: Links to different functionalities directly from the home page.

## API Endpoints

The API provides the following endpoints to manage ProjectType entities:

- **Get All Project Types**: `GET /api/ProjectType`
- **Get Project Type by ID**: `GET /api/ProjectType/{id}`
- **Create New Project Type**: `POST /api/ProjectType`
- **Update Project Type**: `PUT /api/ProjectType/{id}`
- **Delete Project Type**: `DELETE /api/ProjectType/{id}`
