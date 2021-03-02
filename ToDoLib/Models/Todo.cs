using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoLib.Models {
    public class Todo {

        public int Id { get; set; }
        [StringLength(80), Required]
        public string Description { get; set; }
        public DateTime? Due { get; set; }
        [StringLength(80), Required]
        public string Note { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public override string ToString() {
            return $"{Id} | {Description} | {Due} | {Category.Name}";
        }


    }
}
