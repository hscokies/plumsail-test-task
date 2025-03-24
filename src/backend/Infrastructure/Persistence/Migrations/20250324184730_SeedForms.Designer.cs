﻿// <auto-generated />
using System;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250324184730_SeedForms")]
    partial class SeedForms
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Answers.AnswerBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)")
                        .HasColumnName("discriminator");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer")
                        .HasColumnName("question_id");

                    b.Property<Guid>("SubmissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("submission_id");

                    b.HasKey("Id")
                        .HasName("pk_answers");

                    b.HasIndex("QuestionId")
                        .HasDatabaseName("ix_answers_question_id");

                    b.HasIndex("SubmissionId")
                        .HasDatabaseName("ix_answers_submission_id");

                    b.ToTable("answers", (string)null);

                    b.HasDiscriminator().HasValue("AnswerBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)")
                        .HasColumnName("color");

                    b.Property<string>("Subtitle")
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("subtitle");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_forms");

                    b.HasIndex("Title")
                        .HasDatabaseName("ix_forms_title");

                    b.ToTable("forms", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "#7A5CFA",
                            Subtitle = "Thu, Jun 5 at 07:00 PM EDT at The Amp Ballantyne",
                            Title = "RUN THE JEWELS"
                        });
                });

            modelBuilder.Entity("Domain.Entities.QuestionOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer")
                        .HasColumnName("question_id");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_question_options");

                    b.HasIndex("QuestionId")
                        .HasDatabaseName("ix_question_options_question_id");

                    b.ToTable("question_options", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuestionId = 3,
                            Value = "General Admission"
                        },
                        new
                        {
                            Id = 2,
                            QuestionId = 3,
                            Value = "VIP"
                        },
                        new
                        {
                            Id = 3,
                            QuestionId = 3,
                            Value = "Student"
                        },
                        new
                        {
                            Id = 4,
                            QuestionId = 4,
                            Value = "Front row"
                        },
                        new
                        {
                            Id = 5,
                            QuestionId = 4,
                            Value = "Middle row"
                        },
                        new
                        {
                            Id = 6,
                            QuestionId = 4,
                            Value = "Back row"
                        },
                        new
                        {
                            Id = 7,
                            QuestionId = 5,
                            Value = "Parking Pass"
                        },
                        new
                        {
                            Id = 8,
                            QuestionId = 5,
                            Value = "Afterpaty ticket"
                        },
                        new
                        {
                            Id = 9,
                            QuestionId = 5,
                            Value = "Backstage pass"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Questions.QuestionBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)")
                        .HasColumnName("discriminator");

                    b.Property<int>("FormId")
                        .HasColumnType("integer")
                        .HasColumnName("form_id");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("key");

                    b.Property<string>("Placeholder")
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("placeholder");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("title");

                    b.Property<string>("Validator")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("validator");

                    b.HasKey("Id")
                        .HasName("pk_questions");

                    b.HasIndex("FormId")
                        .HasDatabaseName("ix_questions_form_id");

                    b.ToTable("questions", (string)null);

                    b.HasDiscriminator().HasValue("QuestionBase");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Submission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("FormId")
                        .HasColumnType("integer")
                        .HasColumnName("form_id");

                    b.HasKey("Id")
                        .HasName("pk_submissions");

                    b.HasIndex("FormId")
                        .HasDatabaseName("ix_submissions_form_id");

                    b.ToTable("submissions", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Answers.OpenAnswer", b =>
                {
                    b.HasBaseType("Domain.Entities.Answers.AnswerBase");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.ToTable("answers", (string)null);

                    b.HasDiscriminator().HasValue("OpenAnswer");
                });

            modelBuilder.Entity("Domain.Entities.Answers.OptionAnswer", b =>
                {
                    b.HasBaseType("Domain.Entities.Answers.AnswerBase");

                    b.Property<int>("OptionId")
                        .HasColumnType("integer")
                        .HasColumnName("option_id");

                    b.HasIndex("OptionId")
                        .HasDatabaseName("ix_answers_option_id");

                    b.ToTable("answers", (string)null);

                    b.HasDiscriminator().HasValue("OptionAnswer");
                });

            modelBuilder.Entity("Domain.Entities.Questions.DateQuestion", b =>
                {
                    b.HasBaseType("Domain.Entities.Questions.QuestionBase");

                    b.ToTable("questions", (string)null);

                    b.HasDiscriminator().HasValue("DateQuestion");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            FormId = 1,
                            Key = "birthdate",
                            Title = "Date of birth",
                            Validator = "birthdate"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Questions.OpenQuestion", b =>
                {
                    b.HasBaseType("Domain.Entities.Questions.QuestionBase");

                    b.ToTable("questions", (string)null);

                    b.HasDiscriminator().HasValue("OpenQuestion");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FormId = 1,
                            Key = "email",
                            Placeholder = "Enter email address",
                            Title = "Email",
                            Validator = "email"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Questions.OptionsQuestionBase", b =>
                {
                    b.HasBaseType("Domain.Entities.Questions.QuestionBase");

                    b.ToTable("questions", (string)null);

                    b.HasDiscriminator().HasValue("OptionsQuestionBase");
                });

            modelBuilder.Entity("Domain.Entities.Questions.MultipleOptionsQuestion", b =>
                {
                    b.HasBaseType("Domain.Entities.Questions.OptionsQuestionBase");

                    b.ToTable("questions", (string)null);

                    b.HasDiscriminator().HasValue("MultipleOptionsQuestion");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            FormId = 1,
                            Key = "add-ons",
                            Title = "Add-ons",
                            Validator = "none"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Questions.SelectionQuestion", b =>
                {
                    b.HasBaseType("Domain.Entities.Questions.OptionsQuestionBase");

                    b.ToTable("questions", (string)null);

                    b.HasDiscriminator().HasValue("SelectionQuestion");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            FormId = 1,
                            Key = "ticket-type",
                            Title = "Ticket Type"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Questions.SingleOptionQuestion", b =>
                {
                    b.HasBaseType("Domain.Entities.Questions.OptionsQuestionBase");

                    b.ToTable("questions", (string)null);

                    b.HasDiscriminator().HasValue("SingleOptionQuestion");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            FormId = 1,
                            Key = "preferred-seating",
                            Title = "Preferred Seating"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Answers.AnswerBase", b =>
                {
                    b.HasOne("Domain.Entities.Questions.QuestionBase", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_answers_questions_question_id");

                    b.HasOne("Domain.Entities.Submission", "Submission")
                        .WithMany("Answers")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_answers_submissions_submission_id");

                    b.Navigation("Question");

                    b.Navigation("Submission");
                });

            modelBuilder.Entity("Domain.Entities.QuestionOption", b =>
                {
                    b.HasOne("Domain.Entities.Questions.OptionsQuestionBase", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_question_options_questions_question_id");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Domain.Entities.Questions.QuestionBase", b =>
                {
                    b.HasOne("Domain.Entities.Form", "Form")
                        .WithMany("Questions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_questions_forms_form_id");

                    b.Navigation("Form");
                });

            modelBuilder.Entity("Domain.Entities.Submission", b =>
                {
                    b.HasOne("Domain.Entities.Form", "Form")
                        .WithMany("Submissions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_submissions_forms_form_id");

                    b.Navigation("Form");
                });

            modelBuilder.Entity("Domain.Entities.Answers.OptionAnswer", b =>
                {
                    b.HasOne("Domain.Entities.QuestionOption", "Option")
                        .WithMany()
                        .HasForeignKey("OptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_answers_question_options_option_id");

                    b.Navigation("Option");
                });

            modelBuilder.Entity("Domain.Entities.Form", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Submissions");
                });

            modelBuilder.Entity("Domain.Entities.Submission", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Domain.Entities.Questions.OptionsQuestionBase", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
