using HomeControlBlazor.Models;

namespace HomeControlBlazor.Services
{
    public interface IOTEService
    {
     
            public Task<List<TblOte>> Get();
        //Task<ToDo> Get(int id);
        //Task<ToDo> Add(ToDo toDo);
        //Task<ToDo> Update(ToDo toDo);
        //Task<ToDo> Delete(int id);
        public  Task<IEnumerable<TblOte>> LoadRec();

        public Task<IEnumerable<TblOte>> LoadRecByDate(DateTime date);

        public Task<IEnumerable<OTEPricing>> LoadOTEByDate(DateTime date);
    }
}
