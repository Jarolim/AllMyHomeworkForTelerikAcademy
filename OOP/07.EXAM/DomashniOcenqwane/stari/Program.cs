﻿using System;
using System.Collections.Generic;
using System.Numerics;

class DecimalToHexa
{
    static void Main()
    {
        BigInteger N = BigInteger.Parse(Console.ReadLine());
        List<string> Hexa = new List<string>();
        int result = 0;
        string hex = "";
        do
        {
            result = (int)N % 256;
            switch (result)
            {
                case 0: hex = "A"; break;
                case 1: hex = "B"; break;
                case 2: hex = "C"; break;
                case 3: hex = "D"; break;
                case 4: hex = "E"; break;
                case 5: hex = "F"; break;
                case 6: hex = "G"; break;
                case 7: hex = "H"; break;
                case 8: hex = "I"; break;
                case 9: hex = "G"; break;
                case 10: hex = "K"; break;
                case 11: hex = "L"; break;
                case 12: hex = "M"; break;
                case 13: hex = "N"; break;
                case 14: hex = "O"; break;
                case 15: hex = "P"; break;
                case 16: hex = "Q"; break;
                case 17: hex = "R"; break;
                case 18: hex = "S"; break;
                case 19: hex = "T"; break;
                case 20: hex = "U"; break;
                case 21: hex = "V"; break;
                case 22: hex = "W"; break;
                case 23: hex = "X"; break;
                case 24: hex = "Y"; break;
                case 25: hex = "Z"; break;
                case 26: hex = "aA"; break;
                case 27: hex = "aB"; break;
                case 28: hex = "aC"; break;
                case 29: hex = "aD"; break;
                case 30: hex = "aE"; break;
                case 31: hex = "aF"; break;
                case 32: hex = "aG"; break;
                case 33: hex = "aH"; break;
                case 34: hex = "aI"; break;
                case 35: hex = "aG"; break;
                case 36: hex = "aK"; break;
                case 37: hex = "aL"; break;
                case 38: hex = "aM"; break;
                case 39: hex = "aN"; break;
                case 40: hex = "aO"; break;
                case 41: hex = "aP"; break;
                case 42: hex = "aQ"; break;
                case 43: hex = "aR"; break;
                case 44: hex = "aS"; break;
                case 45: hex = "aT"; break;
                case 46: hex = "aU"; break;
                case 47: hex = "aV"; break;
                case 48: hex = "aW"; break;
                case 49: hex = "aX"; break;
                case 50: hex = "aY"; break;
                case 51: hex = "aZ"; break;
                case 52: hex = "bA"; break;
                case 53: hex = "bB"; break;
                case 54: hex = "bC"; break;
                case 55: hex = "bD"; break;
                case 56: hex = "bE"; break;
                case 57: hex = "bF"; break;
                case 58: hex = "bG"; break;
                case 59: hex = "bH"; break;
                case 60: hex = "bI"; break;
                case 61: hex = "bG"; break;
                case 62: hex = "bK"; break;
                case 63: hex = "bL"; break;
                case 64: hex = "bM"; break;
                case 65: hex = "bN"; break;
                case 66: hex = "bO"; break;
                case 67: hex = "bP"; break;
                case 68: hex = "bQ"; break;
                case 69: hex = "bR"; break;
                case 70: hex = "bS"; break;
                case 71: hex = "bT"; break;
                case 72: hex = "bU"; break;
                case 73: hex = "bV"; break;
                case 74: hex = "bW"; break;
                case 75: hex = "bX"; break;
                case 76: hex = "bY"; break;
                case 77: hex = "bZ"; break;
                case 78: hex = "cA"; break;
                case 79: hex = "cB"; break;
                case 80: hex = "cC"; break;
                case 81: hex = "cD"; break;
                case 82: hex = "cE"; break;
                case 83: hex = "cF"; break;
                case 84: hex = "cG"; break;
                case 85: hex = "cH"; break;
                case 86: hex = "cI"; break;
                case 87: hex = "cG"; break;
                case 88: hex = "cK"; break;
                case 89: hex = "cL"; break;
                case 90: hex = "cM"; break;
                case 91: hex = "cN"; break;
                case 92: hex = "cO"; break;
                case 93: hex = "cP"; break;
                case 94: hex = "cQ"; break;
                case 95: hex = "cR"; break;
                case 96: hex = "cS"; break;
                case 97: hex = "cT"; break;
                case 98: hex = "cU"; break;
                case 99: hex = "cV"; break;
                case 100: hex = "cW"; break;
                case 101: hex = "cX"; break;
                case 102: hex = "cY"; break;
                case 103: hex = "cZ"; break;
                case 104: hex = "dA"; break;
                case 105: hex = "dB"; break;
                case 106: hex = "dC"; break;
                case 107: hex = "dD"; break;
                case 108: hex = "dE"; break;
                case 109: hex = "dF"; break;
                case 110: hex = "dG"; break;
                case 111: hex = "dH"; break;
                case 112: hex = "dI"; break;
                case 113: hex = "dG"; break;
                case 114: hex = "dK"; break;
                case 115: hex = "dL"; break;
                case 116: hex = "dM"; break;
                case 117: hex = "dN"; break;
                case 118: hex = "dO"; break;
                case 119: hex = "dP"; break;
                case 120: hex = "dQ"; break;
                case 121: hex = "dR"; break;
                case 122: hex = "dS"; break;
                case 123: hex = "dT"; break;
                case 124: hex = "dU"; break;
                case 125: hex = "dV"; break;
                case 126: hex = "dW"; break;
                case 127: hex = "dX"; break;
                case 128: hex = "dY"; break;
                case 129: hex = "dZ"; break;
                case 130: hex = "eA"; break;
                case 131: hex = "eB"; break;
                case 132: hex = "eC"; break;
                case 133: hex = "eD"; break;
                case 134: hex = "eE"; break;
                case 135: hex = "eF"; break;
                case 136: hex = "eG"; break;
                case 137: hex = "eH"; break;
                case 138: hex = "eI"; break;
                case 139: hex = "eG"; break;
                case 140: hex = "eK"; break;
                case 141: hex = "eL"; break;
                case 142: hex = "eM"; break;
                case 143: hex = "eN"; break;
                case 144: hex = "eO"; break;
                case 145: hex = "eP"; break;
                case 146: hex = "eQ"; break;
                case 147: hex = "eR"; break;
                case 148: hex = "eS"; break;
                case 149: hex = "eT"; break;
                case 150: hex = "eU"; break;
                case 151: hex = "eV"; break;
                case 152: hex = "eW"; break;
                case 153: hex = "eX"; break;
                case 154: hex = "eY"; break;
                case 155: hex = "eZ"; break;
                case 156: hex = "fA"; break;
                case 157: hex = "fB"; break;
                case 158: hex = "fC"; break;
                case 159: hex = "fD"; break;
                case 160: hex = "fE"; break;
                case 161: hex = "fF"; break;
                case 162: hex = "fG"; break;
                case 163: hex = "fH"; break;
                case 164: hex = "fI"; break;
                case 165: hex = "fG"; break;
                case 166: hex = "fK"; break;
                case 167: hex = "fL"; break;
                case 168: hex = "fM"; break;
                case 169: hex = "fN"; break;
                case 170: hex = "fO"; break;
                case 171: hex = "fP"; break;
                case 172: hex = "fQ"; break;
                case 173: hex = "fR"; break;
                case 174: hex = "fS"; break;
                case 175: hex = "fT"; break;
                case 176: hex = "fU"; break;
                case 177: hex = "fV"; break;
                case 178: hex = "fW"; break;
                case 179: hex = "fX"; break;
                case 180: hex = "fY"; break;
                case 181: hex = "fZ"; break;
                case 182: hex = "gA"; break;
                case 183: hex = "gB"; break;
                case 184: hex = "gC"; break;
                case 185: hex = "gD"; break;
                case 186: hex = "gE"; break;
                case 187: hex = "gF"; break;
                case 188: hex = "gG"; break;
                case 189: hex = "gH"; break;
                case 190: hex = "gI"; break;
                case 191: hex = "gG"; break;
                case 192: hex = "gK"; break;
                case 193: hex = "gL"; break;
                case 194: hex = "gM"; break;
                case 195: hex = "gN"; break;
                case 196: hex = "gO"; break;
                case 197: hex = "gP"; break;
                case 198: hex = "gQ"; break;
                case 199: hex = "gR"; break;
                case 200: hex = "gS"; break;
                case 201: hex = "gT"; break;
                case 202: hex = "gU"; break;
                case 203: hex = "gV"; break;
                case 204: hex = "gW"; break;
                case 205: hex = "gX"; break;
                case 206: hex = "gY"; break;
                case 207: hex = "gZ"; break;
                case 208: hex = "hA"; break;
                case 209: hex = "hB"; break;
                case 210: hex = "hC"; break;
                case 211: hex = "hD"; break;
                case 212: hex = "hE"; break;
                case 213: hex = "hF"; break;
                case 214: hex = "hG"; break;
                case 215: hex = "hH"; break;
                case 216: hex = "hI"; break;
                case 217: hex = "hG"; break;
                case 218: hex = "hK"; break;
                case 219: hex = "hL"; break;
                case 220: hex = "hM"; break;
                case 221: hex = "hN"; break;
                case 222: hex = "hO"; break;
                case 223: hex = "hP"; break;
                case 224: hex = "hQ"; break;
                case 225: hex = "hR"; break;
                case 226: hex = "hS"; break;
                case 227: hex = "hT"; break;
                case 228: hex = "hU"; break;
                case 229: hex = "hV"; break;
                case 230: hex = "hW"; break;
                case 231: hex = "hX"; break;
                case 232: hex = "hY"; break;
                case 233: hex = "hZ"; break;
                case 234: hex = "iA"; break;
                case 235: hex = "iB"; break;
                case 236: hex = "iC"; break;
                case 237: hex = "iD"; break;
                case 238: hex = "iE"; break;
                case 239: hex = "iF"; break;
                case 240: hex = "iG"; break;
                case 241: hex = "iH"; break;
                case 242: hex = "iI"; break;
                case 243: hex = "iG"; break;
                case 244: hex = "iK"; break;
                case 245: hex = "iL"; break;
                case 246: hex = "iM"; break;
                case 247: hex = "iN"; break;
                case 248: hex = "iO"; break;
                case 249: hex = "iP"; break;
                case 250: hex = "iQ"; break;
                case 251: hex = "iR"; break;
                case 252: hex = "iS"; break;
                case 253: hex = "iT"; break;
                case 254: hex = "iU"; break;
                case 255: hex = "iV"; break;
                default: hex = ""; break;
            }
            

            Hexa.Add(hex);
            N = N / 256;

        } while (N > 0);

        for (int i = Hexa.Count; i > 0; i--)
        {
            Console.Write(Hexa[i - 1]);
        }
        Console.WriteLine();
    }
}
