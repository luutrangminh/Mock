using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Professor.Models
{
    public class ProjectViewModel
    {
        [Required]
        [Display(Name = "Project name")]
        public string name { get; set; }
        [Display(Name = "Project code")]
        public string code { get; set; }
        [Display(Name = "Created At")]
        public DateTime createdAt { get; set; }

        [Display(Name = "Created By")]
        public string createdBy { get; set; }
        [Display(Name = "Start At")]
        public DateTime startAt { get; set; }
        [Display(Name = "Time")]
        public int time { get; set; }
    }

    public class QuestionViewModel
    {
        [Required]
        [Display(Name = "Question")]
        public string question { get; set; }
    }

    public class AnswerViewModel
    {
        [Required]
        [Display(Name = "Answer")]
        public string answer { get; set; }
        public bool status { get; set; }
    }
}