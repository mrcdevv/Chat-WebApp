using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        public string RoomName { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<RoomUser> RoomUsers { get; set; }
    }
}