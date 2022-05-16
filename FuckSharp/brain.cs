using System.Numerics;
public static class FuckSharp
{
    #region Console
    public static dynamic WL { set => Console.WriteLine(value.ToString()); }
    public static dynamic W { set => Console.Write(value.ToString()); }
    public static string RL { get => Console.ReadLine(); }
    public static char RC { get => Console.ReadLine()[0]; }
    public static ConsoleKeyInfo RK { get => Console.ReadKey(); }
    public static void BR() => Console.Write('\n');
    #endregion
    #region TypeConvert
        #region String
    public static string tS(this bool @bool) => @bool.ToString();
    public static string tS(this byte @byte) => @byte.ToString();
    public static string tS(this char @char) => @char.ToString();
    public static string tS(this decimal @decimal) => @decimal.ToString();
    public static string tS(this double @double) => @double.ToString();
    public static string tS(this float @float) => @float.ToString();
    public static string tS(this int @int) => @int.ToString();
    public static string tS(this long @long) => @long.ToString();
    public static string tS(this nint @nint) => @nint.ToString();
    public static string tS(this nuint @nuint) => @nuint.ToString();
    public static string tS(this sbyte @sbyte) => @sbyte.ToString();
    public static string tS(this short @short) => @short.ToString();
    public static string tS(this uint @uint) => @uint.ToString();
    public static string tS(this ulong @ulong) => @ulong.ToString();
    public static string tS(this ushort @ushort) => @ushort.ToString();
    #endregion
        #region Int32(int)
    public static int tI(this bool @bool) => @bool ? 1 : 0;
    public static int tI(this byte @byte) => @byte;
    public static int tI(this char @char) => @char;
    public static int tI(this decimal @decimal) => (int)@decimal;
    public static int tI(this double @double) => (int)@double;
    public static int tsI(this double @double) => (int)Math.Ceiling(@double);
    public static int thI(this double @double) => (int)Math.Floor(@double);
    public static int tI(this float @float) => (int)@float;
    public static int tsI(this float @float) => (int)Math.Ceiling(@float);
    public static int thI(this float @float) => (int)Math.Floor(@float);
    public static int tI(this long @long) => @long > int.MaxValue ? int.MaxValue : (@long < int.MinValue ? int.MinValue : (int)@long);
    public static int tI(this string @string) => int.Parse(@string);
    public static int tI(this nint @nint) => int.Parse(@nint.tS());
    public static int tI(this nuint @nuint) => (int)@nuint;
    public static int tI(this sbyte @sbyte) => @sbyte;
    public static int tI(this short @short) => @short;
    public static int tI(this uint @uint) => (int)@uint;
    public static int tI(this ulong @ulong) => (int)@ulong;
    public static int tI(this ushort @ushort) => @ushort;
        #endregion
    #endregion
    #region File
    public class F
    {
        private string path;
        public F(string path) => this.path = path;
        public string P { get => path; set => path = value; }

        public string W { set => File.WriteAllText(path, value); }
        public F mW(string text)
        {
            W = text;
            return this;
        }
        public string WL { set => File.WriteAllLines(path, new List<string> { value }); }
        public F mWL(string text)
        {
            WL = text;
            return this;
        }
        public List<string> WAL { set => File.WriteAllLines(path, value); }
        public F mWAL(List<string> lines)
        {
            WAL = lines;
            return this;
        }

        public string A { set => File.AppendAllText(path, value); }
        public F mA(string text)
        {
            A = text;
            return this;
        }
        public string AL { set => File.AppendAllLines(path, new List<string> { value }); }
        public F mAL(string text)
        {
            AL = text;
            return this;
        }
        public List<string> AAL { set => File.AppendAllLines(path, value); }
        public F mAAL(List<string> lines)
        {
            AAL = lines;
            return this;
        }

        public string R { get => File.ReadAllText(path); }
    }
    #endregion
    #region Math
    public static class M
    {
        public static dynamic Cut(dynamic num, dynamic sector)
        {
            BigInteger bigNum = BigInteger.Parse(num.ToString());
            BigInteger bigSector = BigInteger.Parse(sector.ToString());            
            if(bigNum <= bigSector) return num;
            return sector;
        }
    }
    #endregion
    #region Linq
    public static string sW(this string str, Func<char, bool> predicate) => new string(str.Where(predicate).ToArray());
    public static string sW(this string str, char predicate) => new string(str.Where(z => z == predicate).ToArray());
    public static string sW(this string str, string predicate) => new string(str.Where(z => predicate.Contains(z)).ToArray());
    public static int sC(this string str, Func<char, bool> predicate) => str.Count(predicate);
    public static int sC(this string str, char predicate) => str.Count(z => z == predicate);
    public static int sC(this string str, string predicate) => str.Count(z => predicate.Contains(z));
    #endregion
    #region String
    public static string R(this string @string, char oldChar, char newChar) => @string.Replace(oldChar, newChar);
    public static string R(this string @string, string oldChar, char newChar) => @string.Replace(oldChar, newChar.tS());
    public static string R(this string @string, char oldChar, string newChar) => @string.Replace(oldChar.tS(), newChar);
    public static string R(this string @string, string oldChar, string newChar) => @string.Replace(oldChar, newChar);
    public static string bTS(this byte[] bytes) => new string(bytes.Select(z => (char)z).ToArray());
    #endregion
    #region BrainFuck
    public class BF
    {
        private int pos = 0;
        private int allocSize;
        private MemoryStream stream;
        public BF(int allocSize)
        {
            this.allocSize = allocSize;
            stream = new MemoryStream(allocSize);
        }
        public BF(int allocSize, MemoryStream memoryStream, int pos = 0)
        {
            this.allocSize = allocSize;
            this.pos = pos;
            stream = memoryStream;
        }
        public Stream GS()
        {
            stream.Position = 0;
            return stream;
        }
        public string GSUTF8() => GB().bTS();
        public byte[] GB()
        {
            stream.Position = 0;
            byte[] bytes = new byte[allocSize];
            stream.Read(bytes, 0, bytes.Length);
            return bytes;
            stream.Position = pos;
        }
        public BF p { get
        {
            W = stream.ReadByte();
            stream.Position = pos;  
            return this;
        }}
        public BF w{ get
        {
            stream.WriteByte((byte)RC);
            stream.Position = pos;
            return this;
        }}
        public static BF operator /(BF bf, short rem)
        {
            byte newByte = (byte)(bf.stream.ReadByte() - rem);
            bf.stream.Position = bf.pos;
            bf.stream.WriteByte(newByte);
            bf.stream.Position = bf.pos;
            return new(bf.allocSize, bf.stream, bf.pos);
        }
        public static BF operator *(BF bf, short add)
        {
            byte newByte = (byte)(bf.stream.ReadByte() + add);
            bf.stream.Position = bf.pos;
            bf.stream.WriteByte(newByte);
            bf.stream.Position = bf.pos;
            return new(bf.allocSize, bf.stream, bf.pos);
        }
        public static BF operator %(BF bf, int length)
        {
            bf.stream.Position = bf.pos = bf.pos + length;
            return new(bf.allocSize, bf.stream, bf.pos);
        }
    }
    #endregion
    #region StandardBrainFuck
    public class SBF
    {
        public byte[] Excute(string code, int allocSize = 30000)
        {
            byte[] bytes = new byte[allocSize];
            short pos = 0;
            Dictionary<char, Action> types = new(){
                {'>', new(() => pos++)}, {'<', new(() => pos--)},
                {'+', new(() => bytes[pos]++)}, {'-', new(() => bytes[pos]--)},
                {'.', new(() => Console.Write(bytes[pos]))}, {',', new(() => bytes[pos] = (byte)Console.ReadLine()[0])}
            };
            foreach (string z in code.Replace("[", "[|").Split('[').Select(z => z.Split(']').Aggregate((z, v) => new(z.Concat(v.ToArray()).ToArray()))).ToList())
                if (z[0] == '|')
                    while (bytes[pos] != 0)
                        for (int i = 1; i < z.Length; i++)
                            types[z[i]]();
                else
                    for (int i = 0; i < z.Length; i++)
                        types[z[i]]();
            return bytes;
        }
    }
    #endregion
}