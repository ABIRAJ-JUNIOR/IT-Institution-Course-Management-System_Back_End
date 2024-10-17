using IT_Institution_Course_Management_System.Database;
using IT_Institution_Course_Management_System.IRepository;
using IT_Institution_Course_Management_System.Repository;

namespace IT_Institution_Course_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseWebRoot("wwwroot");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var connectionString = builder.Configuration.GetConnectionString("DBConnection");

            builder.Services.AddSingleton<IStudentRepository>(provider => new StudentRepository(connectionString));
            builder.Services.AddSingleton<ICourseRepository>(provider => new CourseRepository(connectionString));
            builder.Services.AddSingleton<IContactUsRepository>(provider => new ContactUsRepository(connectionString));


            //Initialize The Database
            var Initialize = new DatabaseInitializer(connectionString);
            Initialize.Initialize();
            
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors();

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
