using static FuckSharp;
byte[,,] bytes = new byte[16, 32, 64];
FA3(0, 16, 0, 32, 0, 64, (q, w, e) => bytes[q, w, e] = (byte)(q ^ w | e & 0xFF));
var _ = () => { };