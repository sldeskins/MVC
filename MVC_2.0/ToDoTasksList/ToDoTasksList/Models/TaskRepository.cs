using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoTasksList.Models.Repository
{

    public class TaskRepository : ITaskRepository
    {
        private ToDoTasksList.SQL.Models.TaskSQLDataContext _rep = null;
        public TaskRepository()
        {
            _rep = new SQL.Models.TaskSQLDataContext();
        }

        public List<SQL.Models.Task1> ListAllTasks()
        {
            return _rep.Task1s.ToList();
        }
    }
}