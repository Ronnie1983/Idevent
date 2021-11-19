# Idevent

### Setup
For the database functionalities to work, you need to setup a local database based on the SqlServerTemplate project.
After that you need to make a environment variable called "SQLCONNSTR_IdeventConnectionString", which should have the localdb connection string as value.

### Contribution Rules

#### Branch naming
TBA/feature-name

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
