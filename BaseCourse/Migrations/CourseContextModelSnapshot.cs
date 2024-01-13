﻿// <auto-generated />
using System;
using BaseCourse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaseCourse.Migrations
{
    [DbContext(typeof(CourseContext))]
    partial class CourseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaseCourse.Models.CategoryCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Urlimage")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoryCourse", (string)null);
                });

            modelBuilder.Entity("BaseCourse.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CreateUserId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Knowledge")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Requirments")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Target")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CategoryId" }, "IX_Course_CategoryId");

                    b.HasIndex(new[] { "CreateUserId" }, "IX_Course_CreateUserId");

                    b.ToTable("Course", (string)null);
                });

            modelBuilder.Entity("BaseCourse.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NameFileAzure")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("Time")
                        .HasColumnType("time");

                    b.Property<string>("Url")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "SectionId" }, "IX_Lecture_SectionId");

                    b.ToTable("Lecture", (string)null);
                });

            modelBuilder.Entity("BaseCourse.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BaseCourse.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CourseId" }, "IX_Section_CourseId");

                    b.ToTable("Section", (string)null);
                });

            modelBuilder.Entity("BaseCourse.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AboutMe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Education")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Experiences")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("FullName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("OverView")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BaseCourse.Models.UserCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CourseId" }, "IX_UserCourse_CourseId");

                    b.HasIndex(new[] { "UserId" }, "IX_UserCourse_UserId");

                    b.ToTable("UserCourse", (string)null);
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex(new[] { "RoleId" }, "IX_UserRoles_RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("BaseCourse.Models.Course", b =>
                {
                    b.HasOne("BaseCourse.Models.CategoryCourse", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("Category");

                    b.HasOne("BaseCourse.Models.User", "CreateUser")
                        .WithMany("Courses")
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("creat");

                    b.Navigation("Category");

                    b.Navigation("CreateUser");
                });

            modelBuilder.Entity("BaseCourse.Models.Lecture", b =>
                {
                    b.HasOne("BaseCourse.Models.Section", "Section")
                        .WithMany("Lectures")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("VideoSection");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("BaseCourse.Models.Section", b =>
                {
                    b.HasOne("BaseCourse.Models.Course", "Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("SectionCourse");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("BaseCourse.Models.UserCourse", b =>
                {
                    b.HasOne("BaseCourse.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .IsRequired()
                        .HasConstraintName("courseId");

                    b.HasOne("BaseCourse.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("user");

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("BaseCourse.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseCourse.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BaseCourse.Models.CategoryCourse", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("BaseCourse.Models.Course", b =>
                {
                    b.Navigation("Sections");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("BaseCourse.Models.Section", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("BaseCourse.Models.User", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("UserCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
