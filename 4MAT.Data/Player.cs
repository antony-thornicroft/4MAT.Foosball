using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace _4MAT.Data
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }


    }
}