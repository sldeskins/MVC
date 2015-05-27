using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoTasksList.Models.Repository
{
    public interface ITaskRepository
    {
        List<ToDoTasksList.SQL.Models.Task1> ListAllTasks();
    }
}