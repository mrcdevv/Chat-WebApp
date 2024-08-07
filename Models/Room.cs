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
        public IEnumerable<Message> Messages { get; set; }
        public IEnumerable<RoomUser> RoomUsers { get; set; }
    }
}