using assignment_aug_02.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//------------------------
//one instance is created per HTTP Request


//---------------------------------------------
//---------------------------------------------
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
//---------------------------------------------
//---------------------------------------------

builder.Services.AddScoped<IDepartmentService, DepartmentService>();


//-------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.CustomSchemaIds(type => type.FullName);
//});
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

