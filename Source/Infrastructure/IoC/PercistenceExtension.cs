using FluentMigrator.Runner;
using DAO.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Contracts.Data.Services;
using DAO.Repositories;
using Domain.Contracts.Data.Repositories.User;
using Application.UseCases.User.Register;
using Application.Services;
using Application.UseCases.User.Delete;
using Application.UseCases.User.Update;
using Application.UseCases.User.Login;
using Domain.Contracts.Data.Repositories.Event;
using Application.UseCases.Event.Register;
using Application.UseCases.Event.Delete;
using Application.UseCases.Event.Update;
using Domain.Contracts.Data.Repositories.Activity;
using Application.UseCases.Activity.Register;
using Application.UseCases.Activity.Update;
using Application.UseCases.Activity.Delete;
using Domain.Contracts.Data.Repositories.Inscription;
using Application.UseCases.Inscription.Register;
using Application.UseCases.Inscription.Delete;
using Domain.Contracts.Data.Repositories.Attendance;
using Application.UseCases.Attendance.Register;
using Application.UseCases.Attendance.Delete;
using Domain.Contracts.Data.Repositories.Certificate;

namespace IoC;
    public static class PercistenceExtension
    {
    public static void ConfigurePercisteceApp(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddFluentMigratorCore()
           .ConfigureRunner(rb => rb
               .AddPostgres()
               .WithGlobalConnectionString(connectionString)
               .ScanIn(typeof(AppDbContext).Assembly).For.Migrations())
           .AddLogging(lb => lb.AddFluentMigratorConsole());

        services.AddDbContext<AppDbContext>(opt =>
            opt.UseNpgsql(connectionString));

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // User Repositories and Use Cases
        services.AddScoped<IUserReadRepository, UserRepository>();
        services.AddScoped<IUserWriteRepository, UserRepository>();
        services.AddScoped<IRegisterUserUC, RegisterUserUC>();
        var encryptionKey = configuration.GetValue<string>("EncryptionKey");
        services.AddScoped(_ => new PasswordEncryptionService(encryptionKey!));
        services.AddScoped<IDeleteUserUC, DeleteUserUC>();
        services.AddScoped<IUpdateUserUC, UpdateUserUC>();
        services.AddScoped<ILoginUserUC, LoginUserUC>();

        // Event Repositories and Use Cases
        services.AddScoped<IEventReadRepository, EventRepository>();
        services.AddScoped<IEventWriteRepository, EventRepository>();
        services.AddScoped<IRegisterEventUC, RegisterEventUC>();
        services.AddScoped<IDeleteEventUC, DeleteEventUC>();
        services.AddScoped<IUpdateEventUC, UpdateEventUC>();
        services.AddHttpContextAccessor();

        // Activity Repositories and Use Cases
        services.AddScoped<IActivityReadRepository, ActivityRepository>();
        services.AddScoped<IActivityWriteRepository, ActivityRepository>();
        services.AddScoped<IRegisterActivityUC, RegisterActivityUC>();
        services.AddScoped<IUpdateActivityUC, UpdateActivityUC>();
        services.AddScoped<IDeleteActivityUC, DeleteActivityUC>();


        // Inscription Repositories and Use Cases
        services.AddScoped<IInscriptionReadRepository, InscriptionRepository>();
        services.AddScoped<IInscriptionWriteRepository, InscriptionRepository>();
        services.AddScoped<IRegisterInscriptionUC, RegisterInscriptionUC>();
        services.AddScoped<IDeleteInscriptionUC, DeleteInscriptionUC>();


        // Attendance Repositories and Use Cases
        services.AddScoped<IAttendanceReadRepository, AttendanceRepository>();
        services.AddScoped<IAttendanceWriteRepository, AttendanceRepository>();
        services.AddScoped<IRegisterAttendanceUC, RegisterAttendanceUC>();
        services.AddScoped<IDeleteAttendanceUC, DeleteAttendanceUC>();

        // Certificate Repositories and Use Cases       
        services.AddScoped<ICertificateReadRepository, CertificateRepository>();
        services.AddScoped<ICertificateWriteRepository, CertificateRepository>();
        

    }
    }
