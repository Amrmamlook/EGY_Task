
using Task_Test.Endpoints.AuthEndpoints;
using Task_Test.Endpoints.CallsEndpoints;
using Task_Test.Endpoints.ClientsEndpoints;
using Task_Test.Service;
using Task_Test.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers().AddFluentValidation(x =>
    {
        x.ImplicitlyValidateChildProperties = true;

        x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
    });

     builder.Services.AddEndpointsApiExplorer();
     builder.Services.AddSwaggerGen(options => options.Configure());
     builder.Services.AddHttpContextAccessor();

    builder.Services.AddDbContextPool<StoreContext>(x =>
    {
        x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .EnableSensitiveDataLogging();
   });

   builder.Services.AddMediator(options => options.ServiceLifetime = ServiceLifetime.Transient);

    #region    Config of Identity

         //Getting Required Settings
       var authSettings = builder.Configuration.GetSection("AuthSettings").Get<AuthSettings>()
        ?? throw new Exception("Something wrong with appsettings");

        //Identity Data Store
        builder.Services.AddIdentity<AppUser, AppRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 8;
        }).AddEntityFrameworkStores<StoreContext>();

        //Authentication logic configuration
        var tokenValidationParamters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key)),
            ValidateLifetime = authSettings.ValidateLifetime,
            ValidAudience = authSettings.Audience,
            ValidIssuer = authSettings.Issuer,
            ValidateAudience = true,
            ValidateIssuer = true
        };

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = tokenValidationParamters;
            });

        builder.Services.AddSingleton(authSettings);
        builder.Services.AddSingleton(tokenValidationParamters);
        builder.Services.AddScoped<IAuthService, InitialAuthService>();
        builder.Services.AddAuthorizationBuilder()
            .AddPolicy("Admin", policy => policy.RequireRole("Admin"))
            .AddPolicy("user", policy => policy.RequireRole("user"));

#endregion

builder.Services.AddCors();
var app = builder.Build();


    

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapClientEndpoints();
app.MapAuthEnPoints();
app.MapCallsEndPoints();
app.UseCors(cp => cp.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseStaticFiles();
app.Run();
