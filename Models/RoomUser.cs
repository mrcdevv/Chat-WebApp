using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.Models
{
    public class RoomUser
    {
        public Guid RoomId { get; set; }
        public int UserId { get; set; }
        public DateTime JoinedAt { get; set; }
        public DateTime LeftAt { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
    }
}