using e_library.BusinessLayer.Services.UserException;
using e_library.DataLayer;
using e_library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_library.BusinessLayer.Services.Repository
{
    public class LibraryRepository : ILibraryRepository
    {
        /// <summary>
        /// Creating referance Variable of DbContext
        /// </summary>
        private readonly LibraryDbContext _libraryDbContext;
        public LibraryRepository(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        /// <summary>
        /// Add new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public async Task<Book> AddBook(Book book)
        {
            try
            {
                await _libraryDbContext.books.AddAsync(book);
                await _libraryDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return book;
        }
        /// <summary>
        /// List all book based on book stream.
        /// </summary>
        /// <param name="streams"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> AllBooksByStream(Streams streams)
        {
            try
            {
                return await _libraryDbContext.books.Where(x => x.Streams == streams)
                    .Take(10).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all book by student Id with book stream.
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> AllBooksByStudentStream(int studentId)
        {
            try
            {
                var studentStream = await _libraryDbContext.students.FirstOrDefaultAsync(x => x.Id == studentId);
                return await _libraryDbContext.books.Where(x => x.Streams == studentStream.streams).Take(10).ToListAsync();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all book details with fine, If not return by stuent within duration
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> AllBookWithFine()
        {
            try
            {
                List<int> bookid = new List<int>();
                List<Book> findbooks = new List<Book>();
                var issueDetail = await _libraryDbContext.book_Issues.
                    Where(x => x.Returned == false && x.Fine > 0).ToListAsync();
                if(issueDetail != null)
                {
                    foreach(var book in issueDetail)
                    {
                        bookid.Add(book.BookId);
                    }
                    for (int i = 0; i < bookid.Count; i++)
                    {
                        findbooks = await _libraryDbContext.books.Where(x => x.Id == bookid[i]).ToListAsync();
                    }
                }
                return findbooks;
            }
            catch(Exception ex)
            {
                throw new BookNotFoundException("Book Not Found..", ex);
            }
        }
        /// <summary>
        /// show thoese books whos issued to student
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> AllIssuedBookByStudentId(int studentId)
        {
            try
            {
                List<int> bookid = new List<int>();
                List<Book> findbooks = new List<Book>();
                var issuedBook = await _libraryDbContext.book_Issues.Where(x => x.StudentId == studentId && x.Returned == false).ToListAsync();
                if (issuedBook != null)
                {
                    foreach (var books in issuedBook)
                    {
                       bookid.Add(books.BookId);
                    }
                    for(int i = 0; i < bookid.Count; i++ )
                    {
                        findbooks = await _libraryDbContext.books.Where(x => x.Id == bookid[i]).ToListAsync();
                    }
                }
                return findbooks;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// List all book that is allready issued to student.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> IssuedBook()
        {
            try
            {
                return await _libraryDbContext.books.Where(x => x.Issued == true)
                    .Take(10).ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Issue a new book by student.
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<bool> IssueNewBook(int studentId, int bookId)
        {
            try
            {
                var res = false;
                if(studentId > 0 && bookId > 0)
                {
                    var bookStatus = await _libraryDbContext.books.FirstOrDefaultAsync(x => x.Id == bookId);
                    if (bookStatus.Issued == false)
                    {
                        var issuedNew = new Book_Issue()
                        {
                            BookId = bookId,
                            StudentId = studentId,
                            Issue_Date = DateTime.Now,
                            Return_Date = DateTime.Now.AddDays(7),
                            ActualReturn_Date = DateTime.Now.AddDays(7),
                            Fine = 0,
                            Returned = false
                        };
                        await _libraryDbContext.AddAsync(issuedNew);
                        //await _libraryDbContext.SaveChangesAsync();
                        if(bookStatus.Issued == false)
                        {
                            bookStatus.Issued = true;
                        }
                        await _libraryDbContext.SaveChangesAsync();
                    }
                    res = true;
                }
                else
                {
                    return false;
                }
                return res;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Register new Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<Student> Register(Student student)
        {
            try
            {
                if (student == null)
                {
                    throw new ArgumentNullException(typeof(Student).Name + "Object is Null");
                }
                await _libraryDbContext.students.AddAsync(student);
                await _libraryDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return student;
        }
        /// <summary>
        /// Return a book
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public async Task<bool> ReturnBook(int studentId, int bookId)
        {
            try
            {
                var res = false;
                if(studentId > 0 && bookId > 0)
                {
                    var bookStatus = await _libraryDbContext.book_Issues.FirstOrDefaultAsync(x => x.BookId == bookId && x.StudentId == studentId);
                    // calculate fine and update table.
                    var issueDate = bookStatus.Issue_Date;
                    var returnDate = bookStatus.Return_Date;
                    var actualDate = DateTime.Now;
                    var fine = bookStatus.Fine;
                    var finedays = (actualDate - issueDate).TotalDays;
                    fine = finedays * 5;
                    if (bookStatus.Returned == false)
                    {
                        bookStatus.ActualReturn_Date = actualDate;
                        bookStatus.Fine = fine;
                        bookStatus.Returned = true;
                        res = true;
                        await _libraryDbContext.SaveChangesAsync();
                    }
                    var bookStatu = await _libraryDbContext.books.FirstOrDefaultAsync(x => x.Id == bookId);
                    if (bookStatu.Issued == false)
                    {
                        bookStatu.Issued = true;
                    }
                    await _libraryDbContext.SaveChangesAsync();
                }
                else{
                    return false;
                }
                return res;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
