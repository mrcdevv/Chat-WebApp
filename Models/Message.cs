using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public int UserId { get; set; }
        public Guid RoomId { get; set; }
        public User User { get; set; }
        public Room Room { get; set; }
    }
}