using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoLib.Models;

namespace ToDoLib.Controllers {
    public class CategoriesController {

        private readonly TodoDBContext _context = null;

        public async Task<IEnumerable<Category>> GetAll() {
           return await _context.categories.ToListAsync();
        }
        

        public CategoriesController() {
            _context = new TodoDBContext();
        }

    }
}
