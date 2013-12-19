using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WordsISay_v1.Models
{
    public class Story
    {
        // Sets defaults where appropriate
        public Story()
        {
            ImageURL = "http://i.imgur.com/cUCdFHC.png";
            VoteScore = 0;
            DateCreated = DateTime.Now;
        }
        public int StoryId { get; set; }

        [Display(Name = "Title")]
        public string Name { get; set; }

        public string Plot { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Picture")]
        public string ImageURL { get; set; }

        [Display(Name = "Score")]
        public int VoteScore { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created")]
        public DateTime DateCreated { get; set; }
    }
}