using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_back.Models
{
    public class Clientes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]        
        public int Tel { get; set; }

        internal int Count()
        {
            throw new NotImplementedException();
        }
    }
}
