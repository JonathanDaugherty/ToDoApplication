using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoLib.Models;

namespace ToDoLib.Controllers {
    public class TodoController {

        private readonly TodoDBContext _context = null;

        public async Task<IEnumerable<Todo>> GetAll() {
            return await _context.Todos
                                 .Include(x => x.Category)
                                 .ToListAsync();
        }

        public async Task<Todo> GetByPK(int id) {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<Todo> Create(Todo todo) {
            if(todo == null) {
                throw new Exception("Todo cannot be null");
            }
            if(todo.Id != 0) {
                throw new Exception("Tode.Id must be zero");
            }
            _context.Todos.Add(todo);
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected != 1) {
                throw new Exception("Create failed");
            }
            return todo;
        }

        public async Task<Todo> Change(Todo todo) {
            if(todo == null) {
                throw new Exception("Todo cannot be null");
            }
            if(todo.Id < 0) {
                throw new Exception("Todo.Id must be greater than zero");
            }
            _context.Entry(todo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected != 1) {
                throw new Exception("Change Failed");
            }
            return todo;
        }

        public async Task<Todo> Remove(int id) {
            var todo = _context.Todos.Find(id);
            if(todo == null) {
                return null;
            }
            _context.Todos.Remove(todo);
            var rowsAffected = await _context.SaveChangesAsync();
            if(rowsAffected != 1) {
                throw new Exception("Delete Failed");
            }
            return todo;
        }
        public TodoController() {
            _context = new TodoDBContext();
        }
    }
}
