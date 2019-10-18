using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DESApp.DES
{
    class DES
    {
        private const int sizeOfBlock = 64;
        private const int sizeOfChar = 16;
        private const int sizeOfByte = 8;
        private const int quantityOfRounds = 16;

        private BitArray[] Blocks;
        private string StringToRightLength(string input)
        {
            while (((input.Length * sizeOfChar) % sizeOfBlock) != 0)
                input += "#";

            return input;
        }

        private byte[] GetBytesFromString(string input)
        {
            return Encoding.Unicode.GetBytes(input);
        }

        private string GetStringFromBytes(byte[] arrayOfBytes)
        {
            return Encoding.Unicode.GetString(arrayOfBytes);
        }

        private BitArray GetBitsFromBytes(byte[] arrayOfBytes)
        {
            return new BitArray(arrayOfBytes);
        }

        private byte[] GetBytesFromBits(BitArray arrayOfBits)
        {
            byte[] ret = new byte[(arrayOfBits.Length - 1) / 8 + 1];
            arrayOfBits.CopyTo(ret, 0);
            return ret;
        }

        private void CutStringIntoBlocks(string input)
        {
            Blocks = new BitArray[(input.Length * sizeOfChar) / sizeOfBlock];

            string[] strBlocks = new string[(input.Length * sizeOfChar) / sizeOfBlock];
            int lengthOfBlock = input.Length / strBlocks.Length;

            for (int i = 0; i < strBlocks.Length; i++)
            {
                strBlocks[i] = input.Substring(i * lengthOfBlock, lengthOfBlock);
                Blocks[i] = GetBitsFromBytes(GetBytesFromString(strBlocks[i]));
            }  
        }

        private void CutBytesIntoBlocks(byte[] input)
        {
            Blocks = new BitArray[(input.Length * sizeOfByte) / sizeOfBlock];
            byte[][] strBlocks = new byte[(input.Length * sizeOfByte) / sizeOfBlock][];

            for (int i = 0; i < Blocks.Length; i++)
            {
                strBlocks[i] = new byte[sizeOfByte];
                for (int j = 0; j < sizeOfByte; j++)
                {  
                    strBlocks[i][j] = input[i * sizeOfByte + j]; 
                }
            }

            for (int i = 0; i < Blocks.Length; i++)
            {
                Blocks[i] = GetBitsFromBytes(strBlocks[i]);
            }
        }

        private BitArray GetBitArrayCopy(BitArray bitArray)
        {
            BitArray copyBitArray = new BitArray(bitArray.Length);
            for (int i = 0; i < bitArray.Length; i++)
            {
                copyBitArray[i] = bitArray[i];
            }
            return copyBitArray;
        }

        public byte[] Encode(string plainText, string key, out string outText)
        {
            int halfBlock = sizeOfBlock / 2;
            CutStringIntoBlocks(StringToRightLength(plainText));
            string text = "";
            BitArray ipBitArray = null;

            BitArray bitKey = GetBitsFromBytes(GetBytesFromString(CorrectKeyWord(key, 3)));

            for (int curBlock = 0; curBlock < Blocks.Length; curBlock++)
            {
                // Начальная перестановка
                ipBitArray = GetBitArrayCopy(Blocks[curBlock]);
                string textcheck = GetStringFromBytes(GetBytesFromBits(Blocks[curBlock]));
                for (int ipMember = 0; ipMember < 64; ipMember++)
                {
                    Blocks[curBlock][ipMember] = ipBitArray[DESData.matrixIP[ipMember] - 1];
                }

                BitArray L = new BitArray(halfBlock);
                BitArray R = new BitArray(halfBlock);
                for (int i = 0; i < halfBlock; i++)
                {
                    L[i] = Blocks[curBlock][i];
                    R[i] = Blocks[curBlock][i + halfBlock];
                }

                for (int i = 0; i < quantityOfRounds; i++)
                {
                    EncodeDES_One_Round(ref L, ref R, bitKey);
                }

                for (int i = 0; i < halfBlock; i++)
                {
                    Blocks[curBlock][i] = L[i];
                    Blocks[curBlock][i + halfBlock] = R[i];
                }

                ipBitArray = GetBitArrayCopy(Blocks[curBlock]);
                for (int ipMember = 0; ipMember < 64; ipMember++)
                {
                    Blocks[curBlock][ipMember] = ipBitArray[DESData.matrixIP_1[ipMember] - 1];
                }

                text += GetStringFromBytes(GetBytesFromBits(Blocks[curBlock]));
            }
            outText = text;

            BitArray combinedArray = new BitArray(Blocks.Length * sizeOfBlock);
            for (int i = 0; i < Blocks.Length; i++)
            {
                for (int j = 0; j < sizeOfBlock; j++)
                {
                    combinedArray[i * sizeOfBlock + j] = Blocks[i][j];
                }
            }
            return GetBytesFromBits(combinedArray); ;
        }

        public string Decode(byte[] byteText, string key)
        {
            int halfBlock = sizeOfBlock / 2;
            CutBytesIntoBlocks(byteText);
            string text = "";
            BitArray ipBitArray = null;

            BitArray bitKey = GetBitsFromBytes(GetBytesFromString(CorrectKeyWord(key, 3)));

            for (int curBlock = 0; curBlock < Blocks.Length; curBlock++)
            {
                // Начальная перестановка
                ipBitArray = GetBitArrayCopy(Blocks[curBlock]);
                for (int ipMember = 0; ipMember < 64; ipMember++)
                {
                    Blocks[curBlock][ipMember] = ipBitArray[DESData.matrixIP[ipMember] - 1];
                }

                BitArray L = new BitArray(halfBlock);
                BitArray R = new BitArray(halfBlock);
                for (int i = 0; i < halfBlock; i++)
                {
                    L[i] = Blocks[curBlock][i];
                    R[i] = Blocks[curBlock][i + halfBlock];
                }

                for (int i = 0; i < quantityOfRounds; i++)
                {
                    DecodeDES_One_Round(ref L, ref R, bitKey);
                }

                for (int i = 0; i < halfBlock; i++)
                {
                    Blocks[curBlock][i] = L[i];
                    Blocks[curBlock][i + halfBlock] = R[i];
                }

                ipBitArray = GetBitArrayCopy(Blocks[curBlock]);
                for (int ipMember = 0; ipMember < 64; ipMember++)
                {
                    Blocks[curBlock][ipMember] = ipBitArray[DESData.matrixIP_1[ipMember] - 1];
                }

                text += GetStringFromBytes(GetBytesFromBits(Blocks[curBlock]));
            }
            return text;
        }
        private void EncodeDES_One_Round(ref BitArray L, ref BitArray R, BitArray key)
        {
            BitArray bufR = GetBitArrayCopy(R);

            R = XOR(L, FunctionF(R, key));
            L = bufR;    
        }

        private void DecodeDES_One_Round(ref BitArray L, ref BitArray R, BitArray key)
        {
            BitArray bufL = GetBitArrayCopy(L);

            L = XOR(R, FunctionF(L, key));
            R = bufL;
        }

        private BitArray XOR(BitArray bitL, BitArray bitF)
        {
            BitArray bitXOR = GetBitArrayCopy(bitL);
            return bitXOR.Xor(bitF);
        }
        private BitArray FunctionF(BitArray bitR, BitArray key)
        {
            BitArray bufR = FuntionExtension(bitR);

            const int blockCount = 8;
            const int bitInBlock = 6;
            const int bitInBlocka = 4;

            BitArray[] bBlocks = new BitArray[blockCount];
            BitArray[] baBlocks = new BitArray[blockCount];

            bufR = XOR(bufR, key);
            for (int i = 0; i < blockCount; i++)
            {
                bBlocks[i] = new BitArray(bitInBlock);
                for (int j = 0; j < bitInBlock; j++)
                {
                    bBlocks[i][j] = bufR[i * bitInBlock + j];
                }
            }

            for (int i = 0; i < blockCount; i++)
            {
                baBlocks[i] = new BitArray(bitInBlocka);
                BitArray row = new BitArray(2);
                BitArray col = new BitArray(4);
                row[0] = bBlocks[i][0];
                row[1] = bBlocks[i][5];

                for (int j = 1; j < bitInBlock - 1; j++)
                {
                    col[j - 1] = bBlocks[i][j];
                }

                byte irow = GetBytesFromBits(row)[0];
                byte icol = GetBytesFromBits(col)[0];
                
                switch (i)
                {
                    case 0:
                        {
                            byte[] b = new byte[1];
                            b[0] = Convert.ToByte(DESData.s1[irow, icol]);
                            baBlocks[i] = GetBitsFromBytes(b);
                            break;
                        };
                    case 1:
                        {
                            byte[] b = new byte[1];
                            b[0] = Convert.ToByte(DESData.s2[irow, icol]);
                            baBlocks[i] = GetBitsFromBytes(b);
                            break;
                        }
                    case 2:
                        {
                            byte[] b = new byte[1];
                            b[0] = Convert.ToByte(DESData.s3[irow, icol]);
                            baBlocks[i] = GetBitsFromBytes(b);
                            break;
                        };
                    case 3:
                        {
                            byte[] b = new byte[1];
                            b[0] = Convert.ToByte(DESData.s4[irow, icol]);
                            baBlocks[i] = GetBitsFromBytes(b);
                            break;
                        }
                    case 4:
                        {
                            byte[] b = new byte[1];
                            b[0] = Convert.ToByte(DESData.s5[irow, icol]);
                            baBlocks[i] = GetBitsFromBytes(b);
                            break;
                        };
                    case 5:
                        {
                            byte[] b = new byte[1];
                            b[0] = Convert.ToByte(DESData.s6[irow, icol]);
                            baBlocks[i] = GetBitsFromBytes(b);
                            break;
                        }
                    case 6:
                        {
                            byte[] b = new byte[1];
                            b[0] = Convert.ToByte(DESData.s7[irow, icol]);
                            baBlocks[i] = GetBitsFromBytes(b);
                            break;
                        };
                    case 7:
                        {
                            byte[] b = new byte[1];
                            b[0] = Convert.ToByte(DESData.s8[irow, icol]);
                            baBlocks[i] = GetBitsFromBytes(b);
                            break;
                        }
                }
            }

            BitArray[] baaBlocks = new BitArray[blockCount];
            for (int i = 0; i < blockCount; i++)
            {
                baaBlocks[i] = new BitArray(4);
                for (int j = 0; j < 4; j++)
                {
                    baaBlocks[i][j] = baBlocks[i][j];
                }
            }

            BitArray P = new BitArray(32);
            for (int i = 0; i < blockCount; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    P[i * 4 + j] = baaBlocks[i][j];
                }
            }

            return P;
        }

        private BitArray FuntionExtension(BitArray R)
        {
            const int N = 48;
            BitArray bufR = new BitArray(N);
            for (int i = 0; i < N; i++)
            {
                bufR[i] = R[DESData.matrixE[i] - 1];
            }
            return bufR;
        }
        private string CorrectKeyWord(string input, int lengthKey)
        {
            if (input.Length > lengthKey)
            {
                input = input.Substring(0, lengthKey);
            }
            else
            {
                while (input.Length < lengthKey)
                {
                    input = "0" + input;
                }
            }
            return input;
        }
    }
}
