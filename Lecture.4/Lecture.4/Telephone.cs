namespace Lecture._4
{
    internal class Telephone
    {
        private readonly string code;
        private readonly string number;

        public Telephone(string code, string number)
        {
            this.code = code;
            this.number = number;
        }

        public string Compare()
        {
            if (this.code != null || this.code != string.Empty)
            {
                return this.number;
            }

            return "(" + this.code + ")" + this.number;
        }
    }
}
