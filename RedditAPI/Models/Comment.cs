﻿using System.ComponentModel.DataAnnotations;

namespace RedditAPI.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
        public ICollection<Vote> Votes { get; set; }
    }
}
