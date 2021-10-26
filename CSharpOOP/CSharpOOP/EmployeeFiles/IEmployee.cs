namespace CSharpOOP.EmployeeFiles
{
    public interface IEmployee
    {
        public void Show();
        public bool IsMatch(IEmployee employee);
        public bool Validate();
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmployeeType Type { get; set; }
        public string Born { get; set; }
        public int Age { get; set; }

        protected internal static bool IsValid(IEmployee t)
        {
            if (t == null)
            {
                return false;
            }

            if (t.Age <= 0 || string.IsNullOrEmpty(t.FirstName) || string.IsNullOrEmpty(t.LastName)
                || string.IsNullOrEmpty(t.Born) || string.IsNullOrEmpty(t.IdNumber) ||
                string.IsNullOrEmpty(t.Type.ToString()))
            {
                return false;
            }

            return true;
        }
    }
}