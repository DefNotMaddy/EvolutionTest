DECLARE @ConnectionString NVARCHAR(MAX);

SELECT @ConnectionString =
    'Data Source=' + @@SERVERNAME + ',1433;' +
    'Initial Catalog=' + DB_NAME() + ';' +
    'User ID=' + CURRENT_USER + ';' +
    'Password=*sanitized*;' +
    'TrustServerCertificate=True;';

SELECT @ConnectionString AS ConnectionString;
