# Idevent

### Setup
####Step 1.
Download the project.

**Step 2.**
Publish the SQL Server Database Project (IdeventSQLServerTemplate) twice: One with a database name of "Idevent" another named "IdeventTestDB"
**Step 3.**
Take the connection string from each newly created database and put them into 2 environment variables
The Idevent database connectionstring should be in the environment variable called "SQLCONNSTR_IdeventConnectionString"
The IdeventTestDB connectionstring should be in the environment variable called "IdeventTestDBConn"
**Step 4.**
Run the InsertDataScript on the Idevent database (copy it from IdeventSQLServerTemplate and run it with a query to that database)
**Step 5.**
Insert data manually into StandFunctionalities

**Step 6. (optional)**
Insert data manually into ChipGroups and Chips

** Step 7.**
See if it works. You should be able to run tests and get data into the program.

### Contribution Rules

#### Branch naming
TBA/FeatureName or TBA/feature-name

#### Pull Requests
Before commiting to master: discuss the code with the others (code review).

#### Definition of Done
The issue/userstory needs to be approved by product owner.

### Naming conventions
**Class, Components, Methods, Properties:** PascalCase

**Private fields names:** _camelCaseWithPrefix

**Parameters, local variables:** camelCase

**Constants:** UPPERCASE_WORDS

**Interfaces:** IPascalCaseWithIPrefix

**Async Methods:** ThisIsAMethodAsync (ends with Async) 

**HTML id and class:** camelCase

**Stored Procedure:** spPascalCaseWithPrefix
