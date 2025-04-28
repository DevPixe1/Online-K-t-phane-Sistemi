using OnlineKutuphane.Core.Dtos;

namespace OnlineKutuphane.Core.Services
{
    //Kategori işlemlerini yönetmek için interface
    public interface ICategoryService
    {
        IEnumerable<BookDto> GetBooksByCategory(int categoryId);
    }
}
