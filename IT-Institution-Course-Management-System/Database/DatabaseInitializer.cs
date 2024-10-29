using Microsoft.Data.Sqlite;

namespace IT_Institution_Course_Management_System.Database
{
    public class DatabaseInitializer
    {
        private readonly string _ConnectionString;

        public DatabaseInitializer(string connectionString)
        {
            _ConnectionString = connectionString;
        }


        public void Initialize()
        {
            using (var connection = new SqliteConnection(_ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"

                    CREATE TABLE IF NOT EXISTS  Students(
                        Nic NVARCHAR(15) PRIMARY KEY,
                        FullName NVARCHAR(25) NOT NULL,
                        Email NVARCHAR(25) NOT NULL,
                        Phone NVARCHAR(15) NOT NULL,
                        Password NVARCHAR(50) NOT NULL,
                        RegistrationFee INT NOT NULL,
                        CourseEnrollId INT NULL,
                        ImagePath NVARCHAR(100) NULL
                    );

                    CREATE TABLE IF NOT EXISTS  Courses(
                        Id NVARCHAR(50) PRIMARY KEY,
                        CourseName NVARCHAR(25) NOT NULL,
                        Level NVARCHAR(25) NOT NULL,
                        TotalFee INT NOT NULL
                    );

                    CREATE TABLE IF NOT EXISTS CourseEnrollDetails(
                        Id NVARCHAR(50) PRIMARY KEY,
                        Nic NVARCHAR(15) NOT NULL,
                        CourseId NVARCHAR(50) NOT NULL,
                        Duration NVARCHAR(5) NOT NULL,
                        InstallmentId NVARCHAR(50) NULL,
                        FullPaymentId NVARCHAR(50) NULL,
                        CourseEnrollDate Date NOT NULL,
                        Status NVARCHAR(10) NOT NULL,

                        FOREIGN KEY (CourseId) REFERENCES Courses(Id) ON DELETE CASCADE
                        FOREIGN KEY (Nic) REFERENCES Students(Nic) ON DELETE CASCADE
                    );
					

                    CREATE TABLE IF NOT EXISTS  FullPayments(
                        Id NVARCHAR(50) PRIMARY KEY,
                        Nic NVARCHAR(15) NOT NULL,
                        FullPayment INT NOT NULL,
                        PaymentDate Date NOT NULL,

                        FOREIGN KEY (Nic) REFERENCES Students(Nic) ON DELETE CASCADE
                    );

                    CREATE TABLE IF NOT EXISTS  Installments(
                        Id NVARCHAR(50) PRIMARY KEY,
                        Nic NVARCHAR(15) NOT NULL,
                        TotalAmount DECIMAL NOT NULL,
                        InstallmentAmount DECIMAL NOT NULL,
                        Installments NVARCHAR(5) NOT NULL,
                        PaymentDue DECIMAL NOT NULL,
                        PaymentPaid DECIMAL NOT NULL,
                        PaymentDate Date NOT NULL,

                        FOREIGN KEY (Nic) REFERENCES Students(Nic) ON DELETE CASCADE

                    );

                    CREATE TABLE IF NOT EXISTS Notifications(
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nic NVARCHAR(15) NOT NULL,
                        Type NVARCHAR(50) NOT NULL,
                        SourceId NVARCHAR(50) NOT NULL,
                        Date Date NOT NULL,
                        IsDeleted BOOLEAN,

                        FOREIGN KEY (Nic) REFERENCES Students(Nic) ON DELETE CASCADE

                    );

                    CREATE TABLE IF NOT EXISTS ContactUS(
                        Id INT PRIMARY KEY,
                        Name NVARCHAR(50) NOT NULL,
                        Email NVARCHAR(50) NOT NULL,
                        Message NVARCHAR(500) NOT NULL,
                        SubmitDate Date NOT NULL
                    );



                    INSERT OR IGNORE   INTO Courses (Id, CourseName, Level, TotalFee) VALUES
                    ('C001', 'Python', 'Beginner', 12000),
                    ('C002', 'Python', 'Intermediate', 18000),
                    ('C003', 'C#', 'Beginner', 24000),
                    ('C004', 'C#', 'Intermediate', 30000),
                    ('C005', 'JavaScript', 'Beginner', 12000),
                    ('C006', 'JavaScript', 'Intermediate', 18000),
                    ('C007', 'SQL', 'Beginner', 6000),
                    ('C008', 'SQL', 'Intermediate', 12000),
                    ('C009', 'Java', 'Beginner', 24000),
                    ('C010', 'Java', 'Intermediate', 36000),
                    ('C011', 'Angular', 'Beginner', 12000),
                    ('C012', 'Angular', 'Intermediate', 18000);

                    PRAGMA foreign_keys = ON;
                ";
                command.ExecuteNonQuery();
            }
        }
    }
}
