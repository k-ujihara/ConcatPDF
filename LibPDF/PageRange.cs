namespace Ujihara.PDF
{
    public struct PageRange
    {
        public int StartPage;
        public int EndPage;

        public PageRange(int startPage, int endPage)
        {
            StartPage = startPage;
            EndPage = endPage;
        }
    }
}
