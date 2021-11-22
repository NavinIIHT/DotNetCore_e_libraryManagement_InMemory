using e_library.BusinessLayer.Interfaces;
using e_library.BusinessLayer.Services.Repository;
using e_library.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace e_library.BusinessLayer.Services
{
    public class LibraryServices : ILibraryServices
    {
        /// <summary>
        /// Creating Referance variable of ILibraryRepository and injecting in LibraryServices constructor
        /// </summary>
        private readonly ILibraryRepository _libraryRepository;
        public LibraryServices(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }
        /// <summary>
        /// Add a new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<Book> AddBook(Book book)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// GEt list of by student streams
        /// </summary>
        /// <param name="streams"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> AllBooksByStream(Streams streams)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all book by Student Stream
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> AllBooksByStudentStream(int studentId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all book details with fine, if not return
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> AllBookWithFine()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all Issued book by Srudent Id.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> AllIssuedBookByStudentId(int studentId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Details of Issued book for Student
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> IssuedBook()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Issue a new book for student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<bool> IssueNewBook(int studentId, int bookId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register a new Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> Register(Student student)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Return issued book by student with fine if applicable.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<bool> ReturnBook(int studentId, int bookId)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
