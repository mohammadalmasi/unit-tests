namespace GenericRepository.Test
{
    public interface IGenericRepository
    {
        Guid Add<T>(T argument);
    }

    public class GenericRepository : IGenericRepository
    {
        public Guid Add<T>(T argument)
        {
            //After add record to database
            return Guid.NewGuid();
        }
    }
}
