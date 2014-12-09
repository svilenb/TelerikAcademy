namespace _02.TradeCompany
{
    using System;

    public class Article : IComparable<Article>
    {
        public Article(int barcode, string vendor, string title)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
        }

        public int Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return string.Format("Article: {0}, Barcode: {1}, Vendor: {2}", this.Title, this.Barcode, this.Vendor);
        }

        public int CompareTo(Article other)
        {
            if (other == null)
            {
                throw new ArgumentNullException();
            }

            if(this.Title != other.Title)
            {
                return this.Title.CompareTo(other.Title);
            }
            else if (this.Barcode != other.Barcode)
            {
                return this.Barcode.CompareTo(other.Barcode);
            }
            else
            {
                return this.Vendor.CompareTo(other.Vendor);
            }
        }
    }
}
