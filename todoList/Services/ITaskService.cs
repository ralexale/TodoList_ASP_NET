using Microsoft.AspNetCore.Mvc;
using todoList.DTOs.Request;
using todoList.DTOs.Response;

namespace todoList.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskResponse>> GetAll();
        Task<TaskResponse?> GetById(int id);

        Task<bool> Delete(int id);

        Task<TaskResponse?> Update(int id);

        Task<TaskResponse> Create(TaskRequest taskRequest);
    }
}
