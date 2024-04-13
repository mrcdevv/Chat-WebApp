using System;
using System.Collections.Generic;
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
        public int RoomId { get; set; }
        public User User { get; set; }
        public Room Room { get; set; }
    }
}