namespace Lecture._4
{
    public class TelephoneDZ2
    {
        private readonly string code;
        private readonly string number;

        public TelephoneDZ2(string code, string number)
        {
            this.code = code;
            this.number = number;
        }

        public string Compare
        {
            get
            {
                if (this.code != null || this.code != string.Empty)
                {
                    return this.number;
                }

                return "(" + this.code + ")" + this.number;
            }
        }
    }
}
