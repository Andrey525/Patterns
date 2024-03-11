namespace Patterns.Structural.Proxy
{
    class Page
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }
    class PageContext
    {
        public List<Page> Pages { get; set; }
        public PageContext()
        {
            Pages = new List<Page>();
            Pages.Add(new Page() { Id = 1, Number = 1, Text = "Text1" });
            Pages.Add(new Page() { Id = 2, Number = 2, Text = "Text2" });
            Pages.Add(new Page() { Id = 3, Number = 3, Text = "Text3" });
        }
    }

    interface IBook
    {
        Page GetPage(int number);
    }

    class BookStore : IBook
    {
        PageContext db;
        public BookStore()
        {
            db = new PageContext();
        }
        public Page GetPage(int number)
        {
            Thread.Sleep(2000);
            return db.Pages.FirstOrDefault(p => p.Number == number);
        }
    }

    class BookStoreProxy : IBook
    {
        List<Page> pages;
        BookStore bookStore;
        public BookStoreProxy()
        {
            pages = new List<Page>();
        }
        public Page GetPage(int number)
        {
            Page page = pages.FirstOrDefault(p => p.Number == number);
            if (page == null)
            {
                if (bookStore == null)
                    bookStore = new BookStore();
                page = bookStore.GetPage(number);
                pages.Add(page);
            }
            return page;
        }
    }
}
