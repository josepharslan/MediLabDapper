using MediLabDapper.Context;
using MediLabDapper.Repositories.AboutItemRepositories;
using MediLabDapper.Repositories.AboutRepositories;
using MediLabDapper.Repositories.AppointmentRepositories;
using MediLabDapper.Repositories.ContactRepositories;
using MediLabDapper.Repositories.DepartmentRepositories;
using MediLabDapper.Repositories.DoctorRepositories;
using MediLabDapper.Repositories.FeatureRepositories;
using MediLabDapper.Repositories.FileRepositories;
using MediLabDapper.Repositories.GalleryRepositories;
using MediLabDapper.Repositories.MessageRepositories;
using MediLabDapper.Repositories.ServiceRepositories;
using MediLabDapper.Repositories.TestimonialRepositories;

namespace MediLabDapper.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddRepositoriesExtension(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IFileStorage, LocalFileStorage>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IAboutItemRepository, AboutItemRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IGalleryRepository, GalleryRepository>();
            services.AddScoped<DapperContext>();

        }
    }
}
