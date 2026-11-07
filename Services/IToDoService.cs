using HomeControlBlazor.Models;

namespace HomeControlBlazor.Services
{
    public interface IToDoService
    {
        public Task<IEnumerable<TblToDo>> LoadRec();

        public Task<TblToDo> LoadRecByID(int ID);
    }
}
