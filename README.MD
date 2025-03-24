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
