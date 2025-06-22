namespace Application.UseCases.Event.FindById;
    public interface IFindEventByIdUC
    {
        public Task<Domain.Entities.Event?> FindEventById(long id);
    }
