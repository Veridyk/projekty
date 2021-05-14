using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WebRipper
{
    class LPTMON
    {
        static int ES_COUNT = 19;
        static int MONSKILL_COUNT = 4;

        public short wMonID;
        public short wKind;
        public string strTITLE;
        public string strNAME;
        public float fLB;
        public float fLOST;
        public float fAB;
        public int dwOBJ;
        public short[] wItemID = new short[ES_COUNT];

        public short[] wSkillID = new short[MONSKILL_COUNT];

        public byte bNotNockBack;
        public byte bCanSelected;
        public byte bCanFly;

        public byte bCanAttack;
        public byte bDrawName;
        public byte bCanTame;
        public byte bVisible;
        public byte bApplyAI;
        public int dwMenuID;
        public float fSize;
        public float fScaleX;
        public float fScaleY;
        public float fScaleZ;
        public short wSpawnSFX;
        public short wDespawnSFX;
        public int dwSpawnSND;
        public short wFaceIcon;
        public byte bCanDetectHidingPC;
        public byte bSlidingWhenDie;
        public byte bDrawNameWhenDie;

        public LPTMON() { strTITLE = ""; strNAME = ""; }

        public LPTMON(BinaryReader br)
        {
            wMonID = br.ReadInt16();
            wKind = br.ReadInt16();
            byte count = br.ReadByte();
            strTITLE = Encoding.GetEncoding(1250).GetString(br.ReadBytes(count));
            count = br.ReadByte();
            strNAME = Encoding.GetEncoding(1250).GetString(br.ReadBytes(count));
            fLB = br.ReadSingle();
            fLOST = br.ReadSingle();
            fAB = br.ReadSingle();
            dwOBJ = br.ReadInt32();

            for (byte i = 0; i < ES_COUNT; i++)
                wItemID[i] = br.ReadInt16();

            for (byte i = 0; i < MONSKILL_COUNT; i++)
                wSkillID[i] = br.ReadInt16();

            bNotNockBack = br.ReadByte();
            bCanSelected = br.ReadByte();
            bCanFly = br.ReadByte();
            bCanAttack = br.ReadByte();
            bDrawName = br.ReadByte();
            bCanTame = br.ReadByte();
            bVisible = br.ReadByte();
            bApplyAI = br.ReadByte();
            dwMenuID = br.ReadInt32();
            fSize = br.ReadSingle();
            fScaleX = br.ReadSingle();
            fScaleY = br.ReadSingle();
            fScaleZ = br.ReadSingle();
            wSpawnSFX = br.ReadInt16();
            dwSpawnSND = br.ReadInt32();
            wFaceIcon = br.ReadInt16();
            bCanDetectHidingPC = br.ReadByte();
            bSlidingWhenDie = br.ReadByte();
            bDrawNameWhenDie = br.ReadByte();
        }
    }
}
