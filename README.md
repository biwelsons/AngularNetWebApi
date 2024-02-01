<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>

<body>

  <header>
    <h1>App de cadastro de pacientes</h1>
    <div style="display: inline_block"><br>
    <img src="https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"
      alt=".NET" 
      height="30" >
    <img src="https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white"
      alt="Angular" 
      height="30" >
      <img src="https://img.shields.io/badge/TypeScript-007ACC?style=for-the-badge&logo=typescript&logoColor=white"
      alt="Typescript" 
      height="30" >
    </div>
  </header>

  <section>
    <p>This is a web application developed using Angular and .NET for patient registration, using components, SQL Server as the Database, Entity Framework and Migrations.</p>
    <p>The inspiration behind creating this application was my mother, who is a psychoanalyst and felt the need for a tool to register and monitor her patients.</p>
  </section>

  <section>
    <h2>API Endpoints</h2>
      <p>
      <strong>GET /pessoas:</strong> Lists patients<br>
      <strong>GET /pessoas/{id}:</strong> Lists detailed information of patients by ID<br>
      <strong>PUT /pessoas:</strong> Updates data such as name, observation note, consultation type, age, and recurrence day<br>
      <strong>DEL /pessoas/{id}:</strong> Deletes patients by ID<br>
      <strong>POST /pessoas:</strong> Registers a new patient<br>
    </p>
  </section>

  <section>
    <h2>Front-end</h2>
      <p> I used Angular as the Typescript framework for the front-end.
    </p>
  </section>

  <section>
    <h2>Database</h2>
    <p>The project utilizes SQL Server as the database. The necessary database migrations are managed using Entity Framework Migrations.<p/>
  </section>

</body>

</html>
