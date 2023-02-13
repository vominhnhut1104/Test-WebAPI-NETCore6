namespace Test_WebAPI_NETCore6.DataModel
{
    public class AuthorNumberBook
    {
        public string authorname { get; set; }
        public int sosach { get; set; }

        public AuthorNumberBook(string a,int sosach1)
        {
            authorname = a;
            sosach = sosach1;
        }
    }
}
