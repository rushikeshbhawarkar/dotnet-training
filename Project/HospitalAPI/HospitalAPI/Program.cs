using HospitalAPI.Data;
using HospitalAPI.Repositories;
using HospitalAPI.Services;
using HospitalAPI.GlobalException;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


// ==============================
// DATABASE
// ==============================

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString(
            "DefaultConnection"
        )
    )
);


// ==============================
// USER / AUTH
// ==============================

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();


// ==============================
// DOCTOR
// ==============================

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();

builder.Services.AddScoped<IDoctorService, DoctorService>();


// ==============================
// DEPARTMENT
// ==============================

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

builder.Services.AddScoped<IDepartmentService, DepartmentService>();


// ==============================
// APPOINTMENT
// ==============================

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();

builder.Services.AddScoped<IAppointmentService, AppointmentService>();


// ==============================
// PATIENT
// ==============================

builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddScoped<IPatientService, PatientService>();


// ==============================
// JWT AUTHENTICATION
// ==============================

builder.Services
    .AddAuthentication(
        JwtBearerDefaults.AuthenticationScheme
    )
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuer = true,

                ValidateAudience = true,

                ValidateLifetime = true,

                ValidateIssuerSigningKey = true,

                ValidIssuer =
                    builder.Configuration["Jwt:Issuer"],

                ValidAudience =
                    builder.Configuration["Jwt:Audience"],

                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            builder.Configuration["Jwt:Key"]!
                        )
                    )
            };
    });


// ==============================
// AUTHORIZATION
// ==============================

builder.Services.AddAuthorization();


// ==============================
// SWAGGER
// ==============================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",

            Type = SecuritySchemeType.Http,

            Scheme = "bearer",

            BearerFormat = "JWT",

            In = ParameterLocation.Header,

            Description = "Enter your JWT token"
        }
    );

    options.AddSecurityRequirement(document =>
        new OpenApiSecurityRequirement
        {
            [
                new OpenApiSecuritySchemeReference(
                    "Bearer",
                    document
                )
            ] = new List<string>()
        }
    );
});


var app = builder.Build();


// ==============================
// EXCEPTION MIDDLEWARE
// ==============================

app.UseMiddleware<ExceptionMiddleware>();


// ==============================
// SWAGGER
// ==============================

app.UseSwagger();

app.UseSwaggerUI();


// ==============================
// HTTPS
// ==============================

app.UseHttpsRedirection();


// ==============================
// AUTHENTICATION
// ==============================

app.UseAuthentication();


// ==============================
// AUTHORIZATION
// ==============================

app.UseAuthorization();


// ==============================
// CONTROLLERS
// ==============================

app.MapControllers();

app.Run();