﻿// <auto-generated />
using System;
using BaseCourse.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BaseCourse.Migrations
{
    [DbContext(typeof(CourseContext))]
    [Migration("20240117101218_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BaseCourse.Models.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsRight")
                        .HasColumnType("bit");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("BaseCourse.Models.CategoryCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Urlimage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoryCourses");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Knowledge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Requirments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Target")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreateUserId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("BaseCourse.Models.CourseExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseExam");
                });

            modelBuilder.Entity("BaseCourse.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("LectureId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAzure")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("BaseCourse.Models.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFileAzure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.Property<int?>("Sort")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("Time")
                        .HasColumnType("time");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("BaseCourse.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseExamId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseExamId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("BaseCourse.Models.ResultExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AnswerId")
                        .HasColumnType("int");

                    b.Property<int?>("QuestionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TakeAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserExamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserExamId");

                    b.ToTable("ResultExam");
                });

            modelBuilder.Entity("BaseCourse.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Sort")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("BaseCourse.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AboutMe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Experiences")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OverView")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

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

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourses");
                });

            modelBuilder.Entity("BaseCourse.Models.UserExam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AnswerAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CourseExamId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseExamId");

                    b.HasIndex("UserId");

                    b.ToTable("UserExam");
                });

            modelBuilder.Entity("BaseCourse.Models.Answer", b =>
                {
                    b.HasOne("BaseCourse.Models.Question", null)
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("BaseCourse.Models.Course", b =>
                {
                    b.HasOne("BaseCourse.Models.CategoryCourse", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId");

                    b.HasOne("BaseCourse.Models.User", "CreateUser")
                        .WithMany("Courses")
                        .HasForeignKey("CreateUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("CreateUser");
                });

            modelBuilder.Entity("BaseCourse.Models.CourseExam", b =>
                {
                    b.HasOne("BaseCourse.Models.Course", null)
                        .WithMany("CourseExams")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("BaseCourse.Models.Document", b =>
                {
                    b.HasOne("BaseCourse.Models.Lecture", null)
                        .WithMany("Documents")
                        .HasForeignKey("LectureId");
                });

            modelBuilder.Entity("BaseCourse.Models.Lecture", b =>
                {
                    b.HasOne("BaseCourse.Models.Section", "Section")
                        .WithMany("Lectures")
                        .HasForeignKey("SectionId");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("BaseCourse.Models.Question", b =>
                {
                    b.HasOne("BaseCourse.Models.CourseExam", null)
                        .WithMany("Questions")
                        .HasForeignKey("CourseExamId");
                });

            modelBuilder.Entity("BaseCourse.Models.ResultExam", b =>
                {
                    b.HasOne("BaseCourse.Models.Answer", "Answer")
                        .WithMany("ResultExams")
                        .HasForeignKey("AnswerId");

                    b.HasOne("BaseCourse.Models.Question", null)
                        .WithMany("ResultExams")
                        .HasForeignKey("QuestionId");

                    b.HasOne("BaseCourse.Models.UserExam", null)
                        .WithMany("ResultExams")
                        .HasForeignKey("UserExamId");

                    b.Navigation("Answer");
                });

            modelBuilder.Entity("BaseCourse.Models.Section", b =>
                {
                    b.HasOne("BaseCourse.Models.Course", "Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("BaseCourse.Models.User", b =>
                {
                    b.HasOne("BaseCourse.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BaseCourse.Models.UserCourse", b =>
                {
                    b.HasOne("BaseCourse.Models.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BaseCourse.Models.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BaseCourse.Models.UserExam", b =>
                {
                    b.HasOne("BaseCourse.Models.CourseExam", null)
                        .WithMany("UserExams")
                        .HasForeignKey("CourseExamId");

                    b.HasOne("BaseCourse.Models.User", null)
                        .WithMany("UserExams")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BaseCourse.Models.Answer", b =>
                {
                    b.Navigation("ResultExams");
                });

            modelBuilder.Entity("BaseCourse.Models.CategoryCourse", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("BaseCourse.Models.Course", b =>
                {
                    b.Navigation("CourseExams");

                    b.Navigation("Sections");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("BaseCourse.Models.CourseExam", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("UserExams");
                });

            modelBuilder.Entity("BaseCourse.Models.Lecture", b =>
                {
                    b.Navigation("Documents");
                });

            modelBuilder.Entity("BaseCourse.Models.Question", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("ResultExams");
                });

            modelBuilder.Entity("BaseCourse.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BaseCourse.Models.Section", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("BaseCourse.Models.User", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("UserCourses");

                    b.Navigation("UserExams");
                });

            modelBuilder.Entity("BaseCourse.Models.UserExam", b =>
                {
                    b.Navigation("ResultExams");
                });
#pragma warning restore 612, 618
        }
    }
}