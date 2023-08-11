namespace _Project_CheatSheet.Infrastructure.Data.SQL
{
    using Models;
    using Models.Base.Interfaces;
    using Seed;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CheatSheetDbContext : IdentityDbContext<User>
    {
        private readonly IHttpContextAccessor? httpContext;

        public CheatSheetDbContext()
        {

        }

        public CheatSheetDbContext(
            DbContextOptions<CheatSheetDbContext> options,
            IHttpContextAccessor httpContext)
            : base(options)
        {
            this.httpContext = httpContext;
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;
        public virtual DbSet<ResourceLike> ResourceLikes { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CommentLike> CommentLikes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<CategoryResource> CategoriesResources { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<UserCourses> UserCourses { get; set; } = null!;
        public virtual DbSet<Topic> Topics { get; set; } = null!;
        public virtual DbSet<Video> Videos { get; set; } = null!;
        public virtual DbSet<Issue> Issues { get; set; } = null!;
        public virtual DbSet<CategoryIssue> CategoriesIssues { get; set; } = null!;
        public virtual DbSet<CategoryCourse> CategoryCourses { get; set; } = null!;
        public virtual DbSet<CategoryCourseCourses> CategoryCourseCourses { get; set; } = null!;



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=CheatSheet;Integrated Security=true");
            }
        }


        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResourceLike>()
                .HasKey(r => new { r.UserId, r.ResourceId });

            modelBuilder.Entity<ResourceLike>()
                .HasOne(r => r.User)
                .WithMany(u => u.ResourceLikes)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ResourceLike>()
                .HasOne(r => r.Resource)
                .WithMany(p => p.ResourceLikes)
                .HasForeignKey(r => r.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommentLike>()
                .HasKey(c => new { c.UserId, c.CommentId });

            modelBuilder.Entity<CommentLike>()
                .HasOne(c => c.User)
                .WithMany(u => u.CommentLikes)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CommentLike>()
                .HasOne(c => c.Comment)
                .WithMany(c => c.CommentLikes)
                .HasForeignKey(c => c.CommentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Resource>()
                .HasQueryFilter(r => !r.IsDeleted)
                .HasOne(p => p.User)
                .WithMany(u => u.Resources)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasQueryFilter(c => !c.IsDeleted)
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasQueryFilter(c => !c.IsDeleted)
                .HasOne(c => c.Resource)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ResourceId);

            modelBuilder.Entity<CategoryResource>()
                .HasKey(k => new { k.CategoryId, k.ResourceId });

            modelBuilder.Entity<UserCourses>()
                .HasKey(uc => new { uc.CourseId, uc.UserId });

            modelBuilder.Entity<UserCourses>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCourses)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserCourses>()
                .HasOne(uc => uc.Course)
                .WithMany(c => c.UsersCourses)
                .HasForeignKey(uc => uc.CourseId);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Topic>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Course)
                .WithMany(c => c.Topics)
                .HasForeignKey(t => t.CourseId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            modelBuilder.Entity<Topic>()
                .HasOne(t => t.Video)
                .WithMany(v => v.Topics)
                .HasForeignKey(t => t.VideoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Video>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Video>()
                .HasMany(v => v.Topics)
                .WithOne(t => t.Video)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CategoryCourseCourses>()
                .HasKey(k => new
                {
                    k.CourseId,
                    k.CategoryCourseId
                });

            modelBuilder.Entity<Issue>()
                .HasQueryFilter(i => !i.IsDeleted);
            

            DataSeeder.SeedRoles(modelBuilder);
            DataSeeder.SeedDatabase(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            AuditSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            AuditSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        private void AuditSave()
        {
            var currentTime = DateTime.UtcNow;
            var userName = httpContext?.HttpContext?.User?.Identity?.Name;

            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = "admin";
            }

            foreach (var item in ChangeTracker.Entries().Where(e => e.Entity is IEntity))
            {
                if (item.Entity is IDeletableEntity deletable)
                {
                    if (item.State == EntityState.Deleted)
                    {
                        deletable.DeletedOn = currentTime;
                        deletable.DeletedBy = userName;
                        deletable.IsDeleted = true;

                        item.State = EntityState.Modified;
                    }
                }

                if (item.Entity is IEntity entity)
                {
                    if (item.State == EntityState.Added)
                    {
                        entity.CreatedOn = currentTime;
                        if (userName != null)
                        {
                            entity.CreatedBy = userName!;
                        }
                    }
                    else if (item.State == EntityState.Modified)
                    {
                        entity.UpdatedOn = currentTime;
                        entity.UpdatedBy = userName!;
                    }
                }
            }
        }
    }
}