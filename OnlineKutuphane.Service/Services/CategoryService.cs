using AutoMapper;
using OnlineKutuphane.Core;
using OnlineKutuphane.Core.Dtos;
using OnlineKutuphane.Core.Services;

namespace OnlineKutuphane.Service.Services
{
    //Kategori işlemlerini yönetir
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<BookDto> GetBooksByCategory(int categoryId)
        {
            var books = _unitOfWork.Books
                .GetAllWithInclude(b => b.Category)
                .Where(b => b.CategoryId == categoryId)
                .ToList();

            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
