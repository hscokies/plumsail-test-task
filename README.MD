# Plumsail test task

## Build from source

To build and run this project from source, follow these steps:

### Prerequisites

Ensure you have the following installed on your system:

- Node.js
- .NET 9

### Setup and Build the Frontend (Vite + Vue)

```
cd /src/frontend # Navigate to frontend source directory
npm i  # Install dependencies
npm run build  # Build
```

### Setup and Build the Backend (ASP.NET Core)

```
cd /src/backend  # Navigate to backend directory
dotnet restore  # Restore dependencies
dotnet build -c Release  # Build
```

## Running the Application

Run the Backend

```
cd /src/backend/Web.Api/bin/Release/net9.0 # Navigate to build directory
dotnet Web.Api.dll
```

By default, the backend runs on following urls:

- https://localhost:5001
- http://localhost:5000

Run the Frontend

```
cd /src/frontend
npm run preview
```

By default, the frontend runs on http://localhost:3000.

## Task
1. Create an arbitrary form with CSS and Vue as a JavaScript framework. Say, a contact or order form with at least five
   fields of different types:
    - text
    - drop-down
    - date
    - radio
    - checkbox
2. Add validation for the form fields.
3. Implement a REST-service using C# and ASP.NET Core:
   The service should provide all necessary methods for your frontend.
    - It should allow receiving and storing submissions without hard coded models. Imagine there is another frontend
      application with different form fields that uses the same backend. Backend should know nothing about the data
      structure
    - For storing your data, use either In-Memory database or any other storage that won’t require us to set up database
      servers or register in any online services. It is easier for us to review your task this way.

4. Add UI for listing and searching the submitted objects from different forms on one page.
5. Pack all JS- and CSS-files of the project into a single file with the help of a build system of your choice (Vite or
   Webpack).

## API Declarations

### Forms

#### Creating new form

POST: _/api/forms_

\- request

```json
{
   "title": "string",
   "subtitle": "string",
   "color": "string",
   "questions": [
      {
         "$type": "OpenQuestion",
         "Title": "string",
         "Placeholder": "string",
         "Validator": "string" // see src/frontend/src/shared/lib/validators/common-validators.js
      },
      {
         "$type": "DateQuestion",
         "Title": "string",
         "Validator": "string"
      },
      {
         "$type": "SelectionQuestion",
         "Title": "string",
         "Placeholder": "string",
         "Validator": "string",
         "options": [
            "string",
            "string"
         ]
      },
      {
         "$type": "SingleOptionQuestion",
         "Title": "string",
         "Validator": "string",
         "options": [
            "string",
            "string"
         ]
      },
      {
         "$type": "MultipleOptionsQuestion",
         "Title": "What features do you like?",
         "Validator": "checkbox",
         "options": [
            "string",
            "string"
         ]
      }
   ]
}
```

\- response

```json
1
```

#### Get available forms

GET: _/api/forms?Search={string?}_

*Response of this method is cached for 5 minutes.

\- request
\<empty\>

\- response

```json
[
   {
      "formId": 1,
      "title": "User Feedback Form",
      "subtitle": "Help us improve our services",
      "color": "#3498db"
   }
]
```

#### Get form

GET: _/api/forms/{id:int}_

\- request
\<empty\>

\- response

```json
{
   "id": 1,
   "title": "User Feedback Form",
   "subtitle": "Help us improve our services",
   "color": "#3498db",
   "questions": [
      {
         "$type": "DateQuestion",
         "id": 2,
         "title": "What is your birthdate?",
         "validator": "birthdate"
      },
      {
         "$type": "OpenQuestion",
         "placeholder": "Enter your email",
         "id": 1,
         "title": "What is your email?",
         "validator": "email"
      },
      {
         "$type": "MultipleOptionsQuestion",
         "options": [
            {
               "id": 6,
               "label": "Speed"
            },
            {
               "id": 7,
               "label": "Customer support"
            },
            {
               "id": 8,
               "label": "Ease of use"
            }
         ],
         "id": 5,
         "title": "What features do you like?",
         "validator": "checkbox"
      },
      {
         "$type": "SelectionQuestion",
         "options": [
            {
               "id": 1,
               "label": "Email"
            },
            {
               "id": 2,
               "label": "Phone"
            },
            {
               "id": 3,
               "label": "In-person"
            }
         ],
         "id": 3,
         "title": "Select your preferred contact method",
         "validator": "none"
      },
      {
         "$type": "SingleOptionQuestion",
         "options": [
            {
               "id": 4,
               "label": "Delivery"
            },
            {
               "id": 5,
               "label": "In-store purchase"
            }
         ],
         "id": 4,
         "title": "Which service did you use?",
         "validator": "none"
      }
   ]
}
```

### Submissions

#### Submitting the form

POST: _/submissions_

\- request

```json
{
   "formId": 1,
   "answers": [
      {
         "$type": "DateQuestion",
         "questionId": 2,
         "value": "2000-01-02"
      },
      {
         "$type": "MultipleOptionsQuestion",
         "questionId": 5,
         "value": [
            8,
            6,
            8
         ]
      },
      {
         "$type": "OpenQuestion",
         "questionId": 1,
         "value": "email@example.com"
      },
      {
         "$type": "SelectionQuestion",
         "questionId": 3,
         "value": 3
      },
      {
         "$type": "SingleOptionQuestion",
         "questionId": 4,
         "value": 5
      }
   ]
}
```

\- response

```json
"8863aeba-ad84-4613-9a2f-a595beafd769"
```

#### Get submissions (all forms)

GET: _/api/submissions?Search={string?}_

*Response of this method is cached for 5 minutes.

\- request
\<empty\>

\- response

```json
[
   {
      "id": "8863aeba-ad84-4613-9a2f-a595beafd769",
      "formId": 1,
      "title": "User Feedback Form",
      "subtitle": "Help us improve our services",
      "color": "#3498db",
      "answers": [
         {
            "$type": "DateAnswerModel",
            "value": "2000-01-02",
            "question": "What is your birthdate?"
         },
         {
            "$type": "OpenAnswerModel",
            "value": "email@example.com",
            "question": "What is your email?"
         },
         {
            "$type": "SingleOptionAnswerModel",
            "value": "In-person",
            "question": "Select your preferred contact method"
         },
         {
            "$type": "SingleOptionAnswerModel",
            "value": "In-store purchase",
            "question": "Which service did you use?"
         },
         {
            "$type": "MultipleOptionsAnswerModel",
            "value": [
               "Ease of use",
               "Speed"
            ],
            "question": "What features do you like?"
         }
      ]
   }
]
```