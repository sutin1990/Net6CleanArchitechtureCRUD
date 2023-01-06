using AutoMapper;
using CleanMovie.Application;
using CleanMovie.Domain.DBModels;
using CleanMovie.Domain.DBModels.MappingProfile;
using CleanMovie.Domain.ReponseModels;
using Microsoft.EntityFrameworkCore;

namespace CleanMovie.Infrastructure
{
    public class MovieRentalTransactionRepository : IMovieRentalTransactionRepository
    {
        private readonly MovieDbContext _context;
        private readonly IMapper _mapper;

        public MovieRentalTransactionRepository(MovieDbContext movieDbContext)
        {
            _context = movieDbContext;
        }

        public async Task<List<MoviesRentalTransaction>> GetAllMoviesRentalTransaction()
        {
            return await _context.MoviesRentalTransactions.ToListAsync();
        }

        public async Task<List<MoviesRentalTransaction>> GetMoviesRentalTransactionByCriteria(RequestDataConditionTransaction request)
        {
            var result = await (from t in _context.MoviesRentalTransactions
                                join u in _context.UserLoginDtos on t.StaffRentId equals u.Id into ps
                                from u in ps.DefaultIfEmpty()
                                join rt in _context.UserLoginDtos on t.StaffReturnId equals rt.Id into rt1
                                from rt in rt1.DefaultIfEmpty()
                                join c in _context.UserLoginDtos on t.CutomerId equals c.Id into c1
                                from c in c1.DefaultIfEmpty()
                                join m in _context.Movies on t.MovieId equals m.Id into ms
                                from m in ms.DefaultIfEmpty()
                                where (string.IsNullOrEmpty(request.UserNameStaffRent) || u.UserName.Contains(request.UserNameStaffRent))
                                    && (string.IsNullOrEmpty(request.UserNameStaffReturn) || rt.UserName.Contains(request.UserNameStaffReturn))
                                    && (string.IsNullOrEmpty(request.UserNameCustomer) || c.UserName.Contains(request.UserNameCustomer))
                                    && (string.IsNullOrEmpty(request.MovieName) || m.Name.Contains(request.MovieName))
                                    && (request.RentDate == DateTime.MinValue || t.RentDate.Date == request.RentDate.Date)
                                select new MoviesRentalTransaction
                                {
                                    Id = t.Id,
                                    RentDate = t.RentDate,
                                    ExpiryDate = t.ExpiryDate,
                                    ReturnDate = t.ReturnDate,
                                    LateFines = t.LateFines,
                                    UserLoginDtoStaffRent = u,
                                    UserLoginDtoStaffReturn = rt,
                                    UserLoginDtoCustomer = c,
                                    Movie = t.Movie
                                }).ToListAsync();


            return result;
        }

        public async Task<MoviesRentalTransaction> CreateMoviesRentalTransaction(MoviesRentalTransaction moviesRentalTransaction)
        {

            _context.MoviesRentalTransactions.Add(moviesRentalTransaction);
            await _context.SaveChangesAsync();
            return moviesRentalTransaction;
        }

        public async Task<MoviesRentalTransaction> UpdateMoviesRentalTransaction(MoviesRentalTransaction moviesRentalTransaction)
        {
            var dbTransaction = _context.MoviesRentalTransactions.FirstOrDefault(x => x.Id == moviesRentalTransaction.Id);
            if (dbTransaction != null)
            {
                //var dataMapped = MoviesRentalTransactionProfile.Mapper.Map<MoviesRentalTransaction>(moviesRentalTransaction);
                dbTransaction.RentDate = moviesRentalTransaction.RentDate;
                dbTransaction.ExpiryDate = moviesRentalTransaction.ExpiryDate;
                dbTransaction.ReturnDate = moviesRentalTransaction.ReturnDate;
                dbTransaction.LateFines = moviesRentalTransaction.LateFines;
                dbTransaction.MovieId = moviesRentalTransaction.MovieId;
                //dbTransaction.StaffRentId = moviesRentalTransaction.StaffRentId;
                dbTransaction.StaffReturnId = moviesRentalTransaction.StaffReturnId;
                dbTransaction.CutomerId = moviesRentalTransaction.CutomerId;
                //_context.Update(moviesRentalTransaction);
                await _context.SaveChangesAsync();
            }
            return dbTransaction;
        }
        public async Task<MoviesRentalTransaction> DeleteMoviesRentalTransaction(int id)
        {
            var dbTransaction = _context.MoviesRentalTransactions.FirstOrDefault(x => x.Id == id);
            if (dbTransaction != null)
            {
                _context.MoviesRentalTransactions.Remove(dbTransaction);
                await _context.SaveChangesAsync();
            }
            return dbTransaction;
        }

        public async Task<MoviesRentalTransaction> GetMoviesRentalTransactionById(int id)
        {
            var result = await (from t in _context.MoviesRentalTransactions
                                join u in _context.UserLoginDtos on t.StaffRentId equals u.Id into ps
                                from u in ps.DefaultIfEmpty()
                                join rt in _context.UserLoginDtos on t.StaffReturnId equals rt.Id into rt1
                                from rt in rt1.DefaultIfEmpty()
                                join c in _context.UserLoginDtos on t.CutomerId equals c.Id into c1
                                from c in c1.DefaultIfEmpty()
                                join m in _context.Movies on t.MovieId equals m.Id into ms
                                from m in ms.DefaultIfEmpty()
                                where t.Id == id
                                select new MoviesRentalTransaction
                                {
                                    Id = t.Id,
                                    RentDate = t.RentDate,
                                    ExpiryDate = t.ExpiryDate,
                                    ReturnDate = t.ReturnDate,
                                    LateFines = t.LateFines,
                                    UserLoginDtoStaffRent = u,
                                    UserLoginDtoStaffReturn = rt,
                                    UserLoginDtoCustomer = c ?? new UserLoginDto(),
                                    Movie = m ?? new Movie(),
                                    CutomerId = t.CutomerId,
                                    MovieId = t.MovieId,

                                }).FirstOrDefaultAsync();
            return result;
            //return await _context.MoviesRentalTransactions.FirstOrDefaultAsync(f=>f.Id == id);
        }
    }
}
