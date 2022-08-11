int[] ms = new int[2];
int[] ms1 = new int[] { 1, 2, 3, 4 };
int[] ms2 = { 3, 2, 3, 4 };

var element2 = ms2[2]; // => 3

string[] str = new string[2];
string[] str2 = new string[] { "satr", "soz", "gap" };
string[] str3 = { "satr", "soz", "gap" };

var satr = str2[3]; // => ???
var sat1r = str2[2]; // => gap
var s = str2[ms2[1]]; // => gap
var a = str2[ms1[ms2[1]]]; // =>
var b = str2[1]; // => soz

