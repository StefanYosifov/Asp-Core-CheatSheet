﻿namespace _Project_CheatSheet.Features.Course.Models
{
    using System.ComponentModel.DataAnnotations;

    using Constants.GlobalConstants.Course;

    public class CourseUpcomingModel
    {

        public string Id { get; set; } = null!;

        [Required]
        [StringLength(CourseConstants.TitleMaxLength, MinimumLength = CourseConstants.TitleMinLength)]
        public string Title { get; set; } = null!;

        public string StartDate { get; set; } = null!;

        public int WeeksDuration { get; set; }

        public string ImageUrl { get; set; } = null!;

        public bool HasPaid { get; set; }

    }
}
