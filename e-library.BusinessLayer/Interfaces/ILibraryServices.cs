using e_library.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace e_library.BusinessLayer.Interfaces
{
    public interface ILibraryServices
    {
        Task<Book> AddBook(Book book);
        Task<IEnumerable<Book>> IssuedBook();
        Task<IEnumerable<Book>> AllBooksByStream(Streams streams);
        Task<IEnumerable<Book>> AllBooksByStudentStream(int studentId);
        Task<Student> Register(Student student);
        Task<bool> IssueNewBook(int studentId, int bookId);
        Task<IEnumerable<Book>> AllIssuedBookByStudentId(int studentId);
        Task<IEnumerable<Book>> AllBookWithFine();
        Task<bool> ReturnBook(int studentId, int bookId);
    }
}
