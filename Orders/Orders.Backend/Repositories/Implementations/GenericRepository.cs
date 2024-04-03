using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Backend.Repositories.Interfaces;
using Orders.Shared.Responses;

namespace Orders.Backend.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(DataContext context)
        {
            this._context = context;
            _entity = _context.Set<T>();
        }

        public async Task<ActionsResponse<T>> AddAsync(T entity)
        {
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionsResponse<T>
                {
                    WasSuccess = true,
                    Result = entity,
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResult(exception);
            }
        }

        public async Task<ActionsResponse<T>> DeleteAsync(int id)
        {
            var row = await _context.FindAsync<T>(id);
            if (row == null)
            {
                return new ActionsResponse<T>
                {
                    WasSuccess = false,
                    Message = "Registro no encontrado."
                };
            }

            try
            {
                _entity.Remove(row);
                await _context.SaveChangesAsync();
                return new ActionsResponse<T>
                {
                    WasSuccess = true,
                    //Result = row
                };
            }
            catch
            {

                return new ActionsResponse<T>
                {
                    WasSuccess = false,
                    Message = "Sorry!. No se puede borrar, por que existen registros relacionados."
                };
            }
        }

        public async Task<ActionsResponse<T>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionsResponse<IEnumerable<T>>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionsResponse<T>> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        private ActionsResponse<T> DbUpdateExceptionActionResponse()
        {
            return new ActionsResponse<T>
            {
                WasSuccess = false,
                Message = "Sorry!. Ya existe el registro que estas creando."
            };
        }

        private ActionsResponse<T> ExceptionActionResult(Exception exception)
        {
            return new ActionsResponse<T>
            {
                WasSuccess = false,
                Message = "Sorry!. Ya existe el regidtro que estas Creando."
            };
        }
    }
}