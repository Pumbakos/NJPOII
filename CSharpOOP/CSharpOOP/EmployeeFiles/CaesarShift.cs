namespace CSharpOOP.EmployeeFiles
{
    public class CaesarShift
    {
        private static char Shift(char ch, int key)
        {
            if (!char.IsLetter(ch))
                return ch;

            var offset = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - offset) % 26) + offset);
        }

        public static string Encode(string input, int key)
        {
            var output = string.Empty;

            foreach (char ch in input)
                output += Shift(ch, key);

            return output;
        }

        public static string Decode(string input, int key)
        {
            return Encode(input, 26 - key);
        }
    }
}