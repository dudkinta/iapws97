using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace iapws97
{
    public partial class fmMain : Form
    {
        const double R = 0.461526;
        const double Tc = 647.096;
        const double Pc = 22.064;
        const double Rc = 322;
        public struct TtableLine
        {
            public long l;
            public int e;
            public int m;
            public int i;
            public int j;
            public double n;
            public TtableLine(long l, int e, int m,  int i, int j, double n)
            {
                this.l = l;
                this.e = e;
                this.m = m;
                this.i = i;
                this.j = j;
                this.n = n;
            }
        }
        public struct TDataVater
        {
            public double p;
            public double t;
            public double h;
            public double s;
            public double v;
            public double u;
            public double Cp;
            public double Cv;
            public double w;
            public double Ps;
            public double Ts;
            public double Q;
            public double Hn;
            public double Hk;
            public double QT;
            public double HnT;
            public double HkT;

            public TDataVater(double x)
            {
                this.p = x;
                this.t = x;
                this.h = x;
                this.s = x;
                this.v = x;
                this.u = x;
                this.Cp = x;
                this.Cv = x;
                this.w = x;
                this.Ps = x;
                this.Ts = x;
                this.Q = x;
                this.Hn = x;
                this.Hk = x;
                this.QT = x;
                this.HnT = x;
                this.HkT = x;
            }
        }
        TtableLine[] Table1 =new TtableLine[6];
        TtableLine[] Table2 =new TtableLine[35];
        TtableLine[] Table8 =new TtableLine[21];
        TtableLine[] Table10 =new TtableLine[10];
        TtableLine[] Table11 =new TtableLine[44];
        TtableLine[] Table30 =new TtableLine[41];
        TtableLine[] Table34 =new TtableLine[11];
        TtableLine[] Table37 =new TtableLine[7];
        TtableLine[] Table38 =new TtableLine[7];
        public int Reg;
        public TDataVater DV;
        public string Sep = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;


        public TDataVater ClearDataVater()
        {
            TDataVater DV = new TDataVater(0);
            return DV;
        }
        public void TableInit()
        {
            Table1[1] = new TtableLine(34805185628969, 3, 1, 0, 0, 0);
            Table1[2] = new TtableLine(11671859879975, 1, -1, 0, 0, 0);
            Table1[3] = new TtableLine(10192970039326, -2, 1, 0, 0, 0);
            Table1[4] = new TtableLine(57254459862746, 3, 1, 0, 0, 0);
            Table1[5] = new TtableLine(13918839778870, 2, 1, 0, 0, 0);
            Table2[1] = new TtableLine(14632971213167, 0, 1, 0, -2, 0);
            Table2[2] = new TtableLine(84548187169114, 0, -1, 0, -1, 0);
            Table2[3] = new TtableLine(37563603672040, 1, -1, 0, 0, 0);
            Table2[4] = new TtableLine(33855169168385, 1, 1, 0, 1, 0);
            Table2[5] = new TtableLine(95791963387892, 0, -1, 0, 2, 0);
            Table2[6] = new TtableLine(15772038513228, 0, 1, 0, 3, 0);
            Table2[7] = new TtableLine(16616417199501, -1, -1, 0, 4, 0);
            Table2[8] = new TtableLine(81214629983568, -3, 1, 0, 5, 0);
            Table2[9] = new TtableLine(28319080123804, -3, 1, 1, -9, 0);
            Table2[10] = new TtableLine(60706301565874, -3, -1, 1, -7, 0);
            Table2[11] = new TtableLine(18990068218419, -1, -1, 1, -1, 0);
            Table2[12] = new TtableLine(32529748770505, -1, -1, 1, 0, 0);
            Table2[13] = new TtableLine(21841717175414, -1, -1, 1, 1, 0);
            Table2[14] = new TtableLine(52838357969930, -4, -1, 1, 3, 0);
            Table2[15] = new TtableLine(47184321073267, -3, -1, 2, -3, 0);
            Table2[16] = new TtableLine(30001780793026, -3, -1, 2, 0, 0);
            Table2[17] = new TtableLine(47661393906987, -4, 1, 2, 1, 0);
            Table2[18] = new TtableLine(44141845330846, -5, -1, 2, 3, 0);
            Table2[19] = new TtableLine(72694996297594, -15, -1, 2, 17, 0);
            Table2[20] = new TtableLine(31679644845054, -4, -1, 3, -4, 0);
            Table2[21] = new TtableLine(28270797985312, -5, -1, 3, 0, 0);
            Table2[22] = new TtableLine(85205128120103, -9, -1, 3, 6, 0);
            Table2[23] = new TtableLine(22425281908000, -5, -1, 4, -5, 0);
            Table2[24] = new TtableLine(65171222895601, -6, -1, 4, -2, 0);
            Table2[25] = new TtableLine(14341729937924, -12, -1, 4, 10, 0);
            Table2[26] = new TtableLine(40516996860117, -6, -1, 5, -8, 0);
            Table2[27] = new TtableLine(12734301741641, -8, -1, 8, -11, 0);
            Table2[28] = new TtableLine(17424871230634, -9, -1, 8, -6, 0);
            Table2[29] = new TtableLine(68762131295531, -18, -1, 21, -29, 0);
            Table2[30] = new TtableLine(14478307828521, -19, 1, 23, -31, 0);
            Table2[31] = new TtableLine(26335781662795, -22, 1, 29, -38, 0);
            Table2[32] = new TtableLine(11947622640071, -22, -1, 30, -39, 0);
            Table2[33] = new TtableLine(18228094581404, -23, 1, 31, -40, 0);
            Table2[34] = new TtableLine(93537087292458, -25, -1, 32, -41, 0);
            Table8[1] = new TtableLine(17478268058307, 3, 1, 0, 0, 0);
            Table8[2] = new TtableLine(34806930892873, 2, 1, 0, 1, 0);
            Table8[3] = new TtableLine(65292584978455, 1, 1, 0, 3, 0);
            Table8[4] = new TtableLine(33039981775489, 0, 1, 0, 3, 0);
            Table8[5] = new TtableLine(19281382923196, -6, -1, 0, 11, 0);
            Table8[6] = new TtableLine(24909197244573, -22, -1, 0, 31, 0);
            Table8[7] = new TtableLine(26107636489332, 0, -1, 1, 0, 0);
            Table8[8] = new TtableLine(22592965981586, 0, 1, 1, 1, 0);
            Table8[9] = new TtableLine(64256463395226, -1, -1, 1, 2, 0);
            Table8[10] = new TtableLine(78876289270526, -2, 1, 1, 3, 0);
            Table8[11] = new TtableLine(35372110607366, -9, 1, 1, 12, 0);
            Table8[12] = new TtableLine(17332496994895, -23, 1, 1, 31, 0);
            Table8[13] = new TtableLine(56608900654837, -3, 1, 2, 0, 0);
            Table8[14] = new TtableLine(32635483139717, -3, -1, 2, 1, 0);
            Table8[15] = new TtableLine(44778286690632, -4, 1, 2, 2, 0);
            Table8[16] = new TtableLine(51322156908507, -9, -1, 2, 9, 0);
            Table8[17] = new TtableLine(42522657042207, -25, -1, 2, 31, 0);
            Table8[18] = new TtableLine(26400441360689, -12, 1, 3, 10, 0);
            Table8[19] = new TtableLine(78124600459723, -28, 1, 3, 32, 0);
            Table8[20] = new TtableLine(30732199903668, -30, -1, 4, 32, 0);
            Table10[1] = new TtableLine(96927686500217, 1, -1, 0, 0, 0);
            Table10[2] = new TtableLine(10086655968018, 2, 1, 0, 1, 0);
            Table10[3] = new TtableLine(56087911283020, -2, -1, 0, -5, 0);
            Table10[4] = new TtableLine(71452738081455, -1, 1, 0, -4, 0);
            Table10[5] = new TtableLine(40710498223928, 0, -1, 0, -3, 0);
            Table10[6] = new TtableLine(14240819171444, 1, 1, 0, -2, 0);
            Table10[7] = new TtableLine(43839511319450, 1, -1, 0, -1, 0);
            Table10[8] = new TtableLine(28408632460772, 0, -1, 0, 2, 0);
            Table10[9] = new TtableLine(21268463753307, -1, 1, 0, 3, 0);
            Table11[1] = new TtableLine(17731742473213, -2, -1, 1, 0, 0);
            Table11[2] = new TtableLine(17834862292358, -1, -1, 1, 1, 0);
            Table11[3] = new TtableLine(45996013696365, -1, -1, 1, 2, 0);
            Table11[4] = new TtableLine(57581259083432, -1, -1, 1, 3, 0);
            Table11[5] = new TtableLine(50325278727930, -1, -1, 1, 6, 0);
            Table11[6] = new TtableLine(33032641670203, -4, -1, 2, 1, 0);
            Table11[7] = new TtableLine(18948987516315, -3, -1, 2, 2, 0);
            Table11[8] = new TtableLine(39392777243355, -2, -1, 2, 4, 0);
            Table11[9] = new TtableLine(43797295650573, -1, -1, 2, 7, 0);
            Table11[10] = new TtableLine(26674547914087, -4, -1, 2, 36, 0);
            Table11[11] = new TtableLine(20481737692309, -7, 1, 3, 0, 0);
            Table11[12] = new TtableLine(43870667284435, -6, 1, 3, 1, 0);
            Table11[13] = new TtableLine(32277677238570, -4, -1, 3, 3, 0);
            Table11[14] = new TtableLine(15033924542148, -2, -1, 3, 6, 0);
            Table11[15] = new TtableLine(40668253562649, -1, -1, 3, 35, 0);
            Table11[16] = new TtableLine(78847309559367, -9, -1, 4, 1, 0);
            Table11[17] = new TtableLine(12790717852285, -7, 1, 4, 2, 0);
            Table11[18] = new TtableLine(48225372718507, -6, 1, 4, 3, 0);
            Table11[19] = new TtableLine(22922076337661, -5, 1, 5, 7, 0);
            Table11[20] = new TtableLine(16714766451061, -10, -1, 6, 3, 0);
            Table11[21] = new TtableLine(21171472321355, -2, -1, 6, 16, 0);
            Table11[22] = new TtableLine(23895741934104, 2, -1, 6, 35, 0);
            Table11[23] = new TtableLine(59059564324270, -17, -1, 7, 0, 0);
            Table11[24] = new TtableLine(12621808899101, -5, -1, 7, 11, 0);
            Table11[25] = new TtableLine(38946842435739, -1, -1, 7, 25, 0);
            Table11[26] = new TtableLine(11256211360459, -10, 1, 8, 8, 0);
            Table11[27] = new TtableLine(82311340897998, 1, -1, 8, 36, 0);
            Table11[28] = new TtableLine(19809712802088, -7, 1, 9, 13, 0);
            Table11[29] = new TtableLine(10406965210174, -18, 1, 10, 4, 0);
            Table11[30] = new TtableLine(10234747095929, -12, -1, 10, 10, 0);
            Table11[31] = new TtableLine(10018179379511, -8, -1, 10, 14, 0);
            Table11[32] = new TtableLine(80882908646985, -10, -1, 16, 29, 0);
            Table11[33] = new TtableLine(10693031879409, 0, 1, 16, 50, 0);
            Table11[34] = new TtableLine(33662250574171, 0, -1, 18, 57, 0);
            Table11[35] = new TtableLine(89185845355421, -24, 1, 20, 20, 0);
            Table11[36] = new TtableLine(30629216876232, -12, 1, 20, 35, 0);
            Table11[37] = new TtableLine(42002467698208, -5, -1, 20, 48, 0);
            Table11[38] = new TtableLine(59056029685639, -25, -1, 21, 21, 0);
            Table11[39] = new TtableLine(37826947613457, -5, 1, 22, 53, 0);
            Table11[40] = new TtableLine(12768608934681, -14, -1, 23, 39, 0);
            Table11[41] = new TtableLine(73087610595061, -28, 1, 24, 26, 0);
            Table11[42] = new TtableLine(55414715350778, -16, 1, 24, 40, 0);
            Table11[43] = new TtableLine(94369707241210, -6, -1, 24, 58, 0);
            Table30[1] = new TtableLine(10658070028513, 1, 1, 0, 0, 0);
            Table30[2] = new TtableLine(15732845290239, 2, -1, 0, 0, 0);
            Table30[3] = new TtableLine(20944396974307, 2, 1, 0, 1, 0);
            Table30[4] = new TtableLine(76867707878716, 1, -1, 0, 2, 0);
            Table30[5] = new TtableLine(26185947787954, 1, 1, 0, 7, 0);
            Table30[6] = new TtableLine(28080781148620, 1, -1, 0, 10, 0);
            Table30[7] = new TtableLine(12053369696517, 1, 1, 0, 12, 0);
            Table30[8] = new TtableLine(84566812812502, -2, -1, 0, 23, 0);
            Table30[9] = new TtableLine(12654315477714, 1, -1, 1, 2, 0);
            Table30[10] = new TtableLine(11524407806681, 1, -1, 1, 6, 0);
            Table30[11] = new TtableLine(88521043984318, 0, 1, 1, 15, 0);
            Table30[12] = new TtableLine(64207765181607, 0, -1, 1, 17, 0);
            Table30[13] = new TtableLine(38493460186671, 0, 1, 2, 0, 0);
            Table30[14] = new TtableLine(85214708824206, 0, -1, 2, 2, 0);
            Table30[15] = new TtableLine(48972281541877, 1, 1, 2, 6, 0);
            Table30[16] = new TtableLine(30502617256965, 1, -1, 2, 7, 0);
            Table30[17] = new TtableLine(39420536879154, -1, 1, 2, 22, 0);
            Table30[18] = new TtableLine(12558408424308, 0, 1, 2, 26, 0);
            Table30[19] = new TtableLine(27999329698710, 0, -1, 3, 0, 0);
            Table30[20] = new TtableLine(13899799569460, 1, 1, 3, 2, 0);
            Table30[21] = new TtableLine(20189915023570, 1, -1, 3, 4, 0);
            Table30[22] = new TtableLine(82147637173963, -2, -1, 3, 16, 0);
            Table30[23] = new TtableLine(47596035734923, 0, -1, 3, 26, 0);
            Table30[24] = new TtableLine(43984074473500, -1, 1, 4, 0, 0);
            Table30[25] = new TtableLine(44476435428739, 0, -1, 4, 2, 0);
            Table30[26] = new TtableLine(90572070719733, 0, 1, 4, 4, 0);
            Table30[27] = new TtableLine(70522450087967, 0, 1, 4, 26, 0);
            Table30[28] = new TtableLine(10770512626332, 0, 1, 5, 1, 0);
            Table30[29] = new TtableLine(32913623258954, 0, -1, 5, 3, 0);
            Table30[30] = new TtableLine(50871062041158, 0, -1, 5, 26, 0);
            Table30[31] = new TtableLine(22175400873096, -1, -1, 6, 0, 0);
            Table30[32] = new TtableLine(94260751665092, -1, 1, 6, 2, 0);
            Table30[33] = new TtableLine(16436278447961, 0, 1, 6, 26, 0);
            Table30[34] = new TtableLine(13503372241348, -1, -1, 7, 2, 0);
            Table30[35] = new TtableLine(14834345352472, -1, -1, 8, 26, 0);
            Table30[36] = new TtableLine(57922953628084, -3, 1, 9, 2, 0);
            Table30[37] = new TtableLine(32308904703711, -2, 1, 9, 26, 0);
            Table30[38] = new TtableLine(80964802996215, -4, 1, 10, 0, 0);
            Table30[39] = new TtableLine(16557679795037, -3, -1, 10, 1, 0);
            Table30[40] = new TtableLine(44923899061815, -4, -1, 11, 26, 0);
            Table34[1] = new TtableLine(11670521452767, 4, 1, 0, 0, 0);
            Table34[2] = new TtableLine(72421316703206, 6, -1, 0, 0, 0);
            Table34[3] = new TtableLine(17073846940092, 2, -1, 0, 0, 0);
            Table34[4] = new TtableLine(12020824702470, 5, 1, 0, 0, 0);
            Table34[5] = new TtableLine(32325550322333, 7, -1, 0, 0, 0);
            Table34[6] = new TtableLine(14915108613530, 2, 1, 0, 0, 0);
            Table34[7] = new TtableLine(48232657361591, 4, -1, 0, 0, 0);
            Table34[8] = new TtableLine(40511340542057, 6, 1, 0, 0, 0);
            Table34[9] = new TtableLine(23855557567849, 0, -1, 0, 0, 0);
            Table34[10] = new TtableLine(65017534844798, 3, 1, 0, 0, 0);
            Table37[1] = new TtableLine(13179983674201, 2, -1, 0, 0, 0);
            Table37[2] = new TtableLine(68540841634434, 1, 1, 0, 1, 0);
            Table37[3] = new TtableLine(24805148933466, -1, -1, 0, -3, 0);
            Table37[4] = new TtableLine(36901534980333, 0, 1, 0, -2, 0);
            Table37[5] = new TtableLine(31161318213925, 1, -1, 0, -1, 0);
            Table37[6] = new TtableLine(32961626538917, 0, -1, 0, 2, 0);
            Table38[1] = new TtableLine(15736404855259, -2, 1, 1, 1, 0);
            Table38[2] = new TtableLine(90153761673944, -3, 1, 1, 2, 0);
            Table38[3] = new TtableLine(50270077677648, -2, -1, 1, 3, 0);
            Table38[4] = new TtableLine(22440037409485, -5, 1, 2, 3, 0);
            Table38[5] = new TtableLine(41163275453471, -5, -1, 2, 9, 0);
            Table38[6] = new TtableLine(37919454822955, -7, 1, 3, 7, 0);
            for (int i = 1; i <= 5;  i++) { Table1[i].n  = Table1[i].l /  Math.Pow(10, 14) *  Table1[i].m * Math.Pow(10,  Table1[i].e); }
            for (int i = 1; i <= 34; i++) { Table2[i].n  = Table2[i].l /  Math.Pow(10, 14) *  Table2[i].m * Math.Pow(10,  Table2[i].e); }
            for (int i = 1; i <= 20; i++) { Table8[i].n  = Table8[i].l /  Math.Pow(10, 14) *  Table8[i].m * Math.Pow(10,  Table8[i].e); }
            for (int i = 1; i <= 9;  i++) { Table10[i].n = Table10[i].l / Math.Pow(10, 14) * Table10[i].m * Math.Pow(10, Table10[i].e); }
            for (int i = 1; i <= 43; i++) { Table11[i].n = Table11[i].l / Math.Pow(10, 14) * Table11[i].m * Math.Pow(10, Table11[i].e); }
            for (int i = 1; i <= 40; i++) { Table30[i].n = Table30[i].l / Math.Pow(10, 14) * Table30[i].m * Math.Pow(10, Table30[i].e); }
            for (int i = 1; i <= 10; i++) { Table34[i].n = Table34[i].l / Math.Pow(10, 14) * Table34[i].m * Math.Pow(10, Table34[i].e); }
            for (int i = 1; i <= 6;  i++) { Table37[i].n = Table37[i].l / Math.Pow(10, 14) * Table37[i].m * Math.Pow(10, Table37[i].e); }
            for (int i = 1; i <= 6;  i++) { Table38[i].n = Table38[i].l / Math.Pow(10, 14) * Table38[i].m * Math.Pow(10, Table38[i].e); }
        }
        public double b23p(double T)
        {
            double tz =1;
            double sigma = T/tz;
            double result = Table1[1].n+(Table1[2].n*sigma)+(Table1[3].n*sigma*sigma);
            return result;
        }
        public double b23t(double P)
        {
            double pz =1;
            double tz = 1;
            double pi = P/pz;
            double result = (Table1[4].n + Math.Pow((pi - Table1[5].n) / Table1[3].n, 0.5))*tz;
            return result;
        }
        public double Ps(double T)
        {
            double pz =1;
            double tz =1;
            double sigma = T / tz + Table34[9].n / ((T / tz) - Table34[10].n);
            double A = Math.Pow(sigma, 2) + Table34[1].n * sigma + Table34[2].n;
            double B = Table34[3].n * Math.Pow(sigma, 2) + Table34[4].n * sigma + Table34[5].n;
            double C = Table34[6].n * Math.Pow(sigma, 2) + Table34[7].n * sigma + Table34[8].n;
            double result = Math.Pow((2*C)/(-B+Math.Sqrt(B*B-4*A*C)),4)*pz;
            return result;
        }
        public double Ts(double P)
        {
            double pz = 1;
            double tz = 1;
            double beta = Math.Pow(P / pz, 0.25);
            double E = Math.Pow(beta, 2) + Table34[3].n * beta + Table34[6].n;
            double F = Table34[1].n * Math.Pow(beta, 2) + Table34[4].n * beta + Table34[7].n;
            double G = Table34[2].n * Math.Pow(beta, 2) + Table34[5].n * beta + Table34[8].n;
            double D = (2 * G) / (-F - Math.Pow(Math.Pow(F, 2) - 4 * E * G, 0.5));
            double result = ((Table34[10].n + D - Math.Pow(Math.Pow(Table34[10].n + D, 2) - 4 * (Table34[9].n + Table34[10].n * D), 0.5)) / 2) * tz;
            return result;
        }
        public int GetRegion(double P, double T)
        {
            int Result = 0;
            if ((((P>0) && (P<=100)) && ((T>273.15)&&(T<=1073.15))) || (((P>0) && (P<=50)) && ((T>1073.15) && (T<=2273.15))))
            {
                if (((P>0) && (P<=50)) && ((T>1073.15)&& (T<=2273.15))) Result = 5;
                else 
                {
                    if ((T>273.15) && (T<647.096))
                    {
                        double fPs = Ps(T);
                        if (fPs == P) Result = 4;
                    }
                    if ((T>273.15) && (T<=623.15))
                    {
                        double fPs = Ps(T);
                        if (P>fPs) Result = 1;
                        else Result = 2;
                    } 
                    else
                    {
                        if ((T>623.15) && (T<=1073.15))
                        {
                            double b23press = b23p(T);
                            if (P<b23press) Result = 2;
                            else Result = 3;
                        }
                    }
                }
            } else Result = 0;
            return Result;
        }
        public void GetFormat()
        {
            if (cbbP.Text == "кгс/см2") DV.p = DV.p * 0.0980665;
            if ((cbbT.Text=="С")&&(DV.t>0)) DV.t = DV.t+273.15;
        }
        public void PutFormat()
        { 
            if (cbbH.Text=="ккал/кг") DV.h = DV.h*0.2388458966275;
            if (cbbQ.Text == "ккал/кг") DV.Q = DV.Q * 0.2388458966275;
            if (cbbHn.Text == "ккал/кг") DV.Hn = DV.Hn * 0.2388458966275;
            if (cbbHk.Text == "ккал/кг") DV.Hk = DV.Hk * 0.2388458966275;
            if (cbbQT.Text == "ккал/кг") DV.QT = DV.QT * 0.2388458966275;
            if (cbbHnT.Text == "ккал/кг") DV.HnT = DV.HnT * 0.2388458966275;
            if (cbbHkT.Text == "ккал/кг") DV.HkT = DV.HkT * 0.2388458966275;
            if (cbbS.Text=="ккал/кг К") DV.s = DV.s*0.2388458966275;
            if (cbbU.Text=="ккал/кг") DV.u = DV.u*0.2388458966275;
            if (cbbCp.Text=="ккал/кг К") DV.Cp = DV.Cp*0.2388458966275;
            if (cbbCv.Text=="ккал/кг К") DV.Cv = DV.Cv*0.2388458966275;
            if ((cbbTs.Text=="С")&&(DV.Ts>273.15)) DV.Ts = DV.Ts-273.15;
            if ((cbbPs.Text=="кгс/см2")&&(DV.Ps!=0)) DV.Ps = DV.Ps/0.0980665;
        }
        
        public void PrintDataVater()
        {
            if (DV.h != 0) edtH.Text = String.Format("{0:0.000000}", DV.h); else edtH.Text = "н/д";
            if (DV.s != 0) edtS.Text = String.Format("{0:0.000000}", DV.s); else edtS.Text = "н/д";
            if (DV.v != 0) edtV.Text = String.Format("{0:0.000000}", DV.v); else edtV.Text = "н/д";
            if (DV.Cp != 0) edtCp.Text = String.Format("{0:0.000000}", DV.Cp); else edtCp.Text = "н/д";
            if (DV.Cv != 0) edtCv.Text = String.Format("{0:0.000000}", DV.Cv); else edtCv.Text = "н/д";
            if (DV.w != 0) edtW.Text = String.Format("{0:0.000000}", DV.w); else edtW.Text = "н/д";
            if (DV.u != 0) edtU.Text = String.Format("{0:0.000000}", DV.u); else edtU.Text = "н/д";
            if (DV.Ts != 0) edtTs.Text = String.Format("{0:0.000000}", DV.Ts); else edtTs.Text = "н/д";
            if (DV.Ps != 0) edtPs.Text = String.Format("{0:0.000000}", DV.Ps); else edtPs.Text = "н/д";
            if (DV.Q != 0) edtQ.Text = String.Format("{0:0.000000}", DV.Q); else edtQ.Text = "н/д";
            if (DV.Hn != 0) edtHn.Text = String.Format("{0:0.000000}", DV.Hn); else edtHn.Text = "н/д";
            if (DV.Hk != 0) edtHk.Text = String.Format("{0:0.000000}", DV.Hk); else edtHk.Text = "н/д";
            if (DV.QT != 0) edtQT.Text = String.Format("{0:0.000000}", DV.QT); else edtQT.Text = "н/д";
            if (DV.HnT != 0) edtHnT.Text = String.Format("{0:0.000000}", DV.HnT); else edtHnT.Text = "н/д";
            if (DV.HkT != 0) edtHkT.Text = String.Format("{0:0.000000}", DV.HkT); else edtHkT.Text = "н/д";
        }
        public fmMain()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void fmMain_Load(object sender, EventArgs e)
        {
            TableInit();
            TDataVater DV = new TDataVater(0);
            cbbP.Text = cbbP.Items[0].ToString();
            cbbT.Text = cbbT.Items[0].ToString();
            cbbH.Text = cbbH.Items[0].ToString();
            cbbS.Text = cbbS.Items[0].ToString();
            cbbV.Text = cbbV.Items[0].ToString();
            cbbU.Text = cbbU.Items[0].ToString();
            cbbCv.Text = cbbCv.Items[0].ToString();
            cbbCp.Text = cbbCp.Items[0].ToString();
            cbbW.Text = cbbW.Items[0].ToString();
            cbbTs.Text = cbbTs.Items[0].ToString();
            cbbPs.Text = cbbPs.Items[0].ToString();
            cbbQ.Text = cbbQ.Items[0].ToString();
            cbbHn.Text = cbbHn.Items[0].ToString();
            cbbHk.Text = cbbHk.Items[0].ToString();
            cbbQT.Text = cbbQT.Items[0].ToString();
            cbbHnT.Text = cbbHnT.Items[0].ToString();
            cbbHkT.Text = cbbHkT.Items[0].ToString();
            PrintDataVater();
        }

        private void edtPress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) {return;}
            if ((e.KeyChar == '.') || (e.KeyChar == ',')) 
            {
                e.KeyChar = Sep[0];
                if (edtPress.Text.IndexOf(Sep[0]) != -1) {e.Handled = true;return;} else {return;}
            }
            if (Char.IsControl(e.KeyChar)) {return;}
            e.Handled = true;
        }
        private void edtTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9')) { return; }
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                e.KeyChar = Sep[0];
                if (edtTemp.Text.IndexOf(Sep[0]) != -1) { e.Handled = true; return; } else { return; }
            }
            if (Char.IsControl(e.KeyChar)) { return; }
            e.Handled = true;
        }
        private string ControlUser(string s)
        {
            if (string.IsNullOrEmpty(s))  s= "0";
            if (s == Sep) s = "0" + Sep[0];
            string result = s;
            return result;
        }
        public TDataVater Reg1PT(TDataVater DV)
        {
            double pz = 16.53;
            double tz = 1386;
            double pi = DV.p / pz;
            double tau = tz / DV.t;
            double Y =0;
            double Yp = 0;
            double Yt = 0;
            double Ypp = 0;
            double Ytt = 0;
            double Ypt = 0;
            for (int k = 1; k <= 34; k++)
            {
                double n = Table2[k].n;
                double i = Table2[k].i;
                double j = Table2[k].j;
                Y += n * Math.Pow(7.1 - pi, i) * Math.Pow(tau - 1.222, j);
                Yp += -n * i * Math.Pow(7.1 - pi, i - 1) * Math.Pow(tau - 1.222, j);
                Yt += n * Math.Pow(7.1 - pi, i) * j * Math.Pow(tau - 1.222, j - 1);
                Ypp += n * i * (i - 1) * Math.Pow(7.1 - pi, i - 2) * Math.Pow(tau - 1.222, j);
                Ytt += n * Math.Pow(7.1 - pi, i) * j * (j - 1) * Math.Pow(tau - 1.222, j - 2);
                Ypt += -n * i * Math.Pow(7.1 - pi, i - 1) * j * Math.Pow(tau - 1.222, j - 1);
            }
            DV.v = (pi*Yp*R*DV.t)/DV.p/1000;
            DV.u = (tau * Yt - pi * Yp) * R * DV.t;
            DV.s = (tau * Yt - Y) * R;
            DV.h = tau * Yt * R * DV.t;
            DV.Cp = -(Math.Pow(tau, 2) * Ytt * R);
            DV.Cv = -(Math.Pow(tau, 2) * Ytt) + Math.Pow(Yp - tau * Ypt, 2) / Ypp;
            DV.w = Math.Pow(((Yp * Yp) / ((((Yp - tau * Ypt) * (Yp - tau * Ypt)) / (tau * tau * Ytt)) - Ypp)) * R * DV.t * 1000,0.5);
            return DV;
        }
        public TDataVater Reg2PT(TDataVater DV)
        {
            double pz = 1;
            double tz = 540;
            double p = DV.p / pz;
            double t = tz / DV.t;
            double Y = 0;
            double Yp = 0;
            double Yt = 0;
            double Ypp = 0;
            double Ytt = 0;
            double Ypt = 0;
            double Y0 = 0;
            double Y0p = 1/p;
            double Y0t = 0;
            double Y0pp = -1/p*p;
            double Y0tt = 0;
            //double Y0pt = 0;
            for (int k = 1; k <= 9; k++)
            { 
                double n = Table10[k].n;
                double i = Table10[k].i;
                double j = Table10[k].j;
                Y0 +=n*Math.Pow(t,j);
                Y0t += n * j * Math.Pow(t, j - 1);
                Y0tt += n * j * (j - 1) * Math.Pow(t, j - 2);
            }
            Y0 += Math.Log(p);
            for (int k = 1; k <= 43; k++)
            {
                double n = Table11[k].n;
                double i = Table11[k].i;
                double j = Table11[k].j;
                Y += n * Math.Pow(p, i) * Math.Pow(t - 0.5, j);
                Yp += n * i * Math.Pow(p, i - 1) * Math.Pow(t - 0.5, j);
                Yt += n * Math.Pow(p, i) * j * Math.Pow(t - 0.5, j - 1);
                Ypp += n * i * (i - 1) * Math.Pow(p, i - 2) * Math.Pow(t - 0.5, j);
                Ytt += n * Math.Pow(p, i) * j * (j - 1) * Math.Pow(t - 0.5, j - 2);
                Ypt += n * i * Math.Pow(p, i - 1) * j * Math.Pow(t - 0.5, j - 1);
            }
            DV.v=(p*(Y0p+Yp)*R*DV.t)/(DV.p*1000);
            DV.u=(t*(Y0t+Yt)-p*(Y0p+Yp))*R*DV.t;
            DV.s=(t*(Y0t+Yt)-(Y0+Y))*R;
            DV.h=t*(Y0t+Yt)*R*DV.t;
            DV.Cp=(-(t*t*(Y0tt+Ytt)))*R;
            DV.Cv = (-(t * t * (Y0tt + Ytt) - Math.Pow(1 + p * Yp - t * p * Ypt, 2) / (1 - p * p * Ypp))) * R;
            DV.w = Math.Pow(((1 + 2 * p * Yp + p * p * Yp * Yp) / ((1 - p * p * Ypp) + (Math.Pow(1 + p * Yp - t * p * Ypt, 2) / (t * t * (Y0tt + Ytt))))) * R * DV.t * 1000,0.5);
            return DV;
        }
        public TDataVater Reg5PT(TDataVater DV)
        {
            double pz = 1;
            double tz = 1000;
            double pi = DV.p / pz;
            double tau = tz / DV.t;
            double Y = 0;
            double Yp = 0;
            double Yt = 0;
            double Ypp = 0;
            double Ytt = 0;
            double Ypt = 0;
            double Y0 = 0;
            double Y0p = 0;
            double Y0t = 0;
            double Y0pp = 0;
            double Y0tt = 0;
            //double Y0pt = 0;
            Y0p = 1 / pi;
            Y0pp=-1/Math.Pow(pi,2);
            for (int k= 1;k<=6;k++)
            {
                double n = Table37[k].n;
                double i = Table37[k].i;
                double j = Table37[k].j;
                Y0 =Y0 + n*Math.Pow(tau, j);
                Y0t = Y0t + n * j * Math.Pow(tau, j - 1);
                Y0tt = Y0tt + n * j * (j - 1) * Math.Pow(tau, j - 2);
                n = Table38[k].n;
                i = Table38[k].i;
                j = Table38[k].j;
                Y = Y + n * Math.Pow(pi, i) * Math.Pow(tau, j);
                Yp = Yp + n * i * Math.Pow(pi, i - 1) * Math.Pow(tau, j);
                Yt = Yt + n * Math.Pow(pi, i) * j * Math.Pow(tau, j - 1);
                Ypp = Ypp + n * i * (i - 1) * Math.Pow(pi, i - 2) * Math.Pow(tau, j);
                Ytt = Ytt + n * Math.Pow(pi, i) * j * (j - 1) * Math.Pow(tau, j - 2);
                Ypt = Ypt + n * i * Math.Pow(pi, i - 1) * j * Math.Pow(tau, j - 1);
            }
            Y0 += Math.Log(pi);
            DV.v = (pi*(Y0p+Yp)*R*DV.t)/DV.p/1000;
            DV.u = (tau*(Y0t+Yt)-pi*(Y0p+Yp))*R*DV.t;
            DV.s = (tau*(Y0t+Yt)-(Y0+Y))*R;
            DV.h = tau*(Y0t+Yt)*R*DV.t;
            DV.Cp= -Math.Pow(tau,2)*(Y0tt+Ytt)*R;
            DV.Cv = (-Math.Pow(tau, 2) * (Y0tt + Ytt) - Math.Pow(1 + pi * Yp - tau * pi * Ypt, 2) / (1 - pi * pi * Yp)) * R;
            DV.w = Math.Pow(((1 + 2 * pi * Yp + pi * pi * Yp * Yp) / ((1 - pi * pi * Ypp) + Math.Pow(1 + pi * Yp - tau * pi * Ypt, 2) / (tau * tau * (Y0tt + Ytt)))) * R * DV.t * 1000,0.5);
            return DV;
        }

        private void MathVater()
        { 
            if (Reg == 1) DV = Reg1PT(DV);
            if (Reg == 5) DV = Reg5PT(DV);
            if (Reg == 2) DV = Reg2PT(DV);
        }
            
        private void edtPress_TextChanged(object sender, EventArgs e)
        {
            Reg = 0;
            DV = ClearDataVater();
            DV.p = double.Parse(ControlUser(edtPress.Text));
            DV.t = double.Parse(ControlUser(edtTemp.Text));
            GetFormat();
            if ((this.DV.t > 273.15) && (this.DV.t < 647.096))
            {
                this.DV.Ps = Ps(this.DV.t);
                TDataVater DVts = DV;
                DVts.p = DV.Ps;
                DVts = Reg2PT(DVts);
                DV.HnT = DVts.h;
                TDataVater DVts2 = DV;
                DVts2.p = DV.Ps;
                DVts2 = Reg1PT(DVts2);
                DV.QT = DVts.h - DVts2.h;
                DV.HkT = DVts2.h;
            }
            else this.DV.Ps = 0;
            if ((this.DV.p > 0.000611213) && (this.DV.p < 22.064))
            {
                this.DV.Ts = this.Ts(DV.p);
                TDataVater DVts = DV;
                DVts.t = DV.Ts;
                DVts = Reg2PT(DVts);
                DV.Hn = DVts.h;
                TDataVater DVts2 = DV;
                DVts2.t = DV.Ts;
                DVts2 = Reg1PT(DVts2);
                DV.Q = DVts.h - DVts2.h;
                DV.Hk = DVts2.h;
            }
            else this.DV.Ts = 0;
            Reg = GetRegion(this.DV.p, this.DV.t);
            if (Reg == 0) edtRegion.Text = "Ошибка диапазона параметров";
            if (Reg == 1) edtRegion.Text = "Вода";
            if (Reg == 2) edtRegion.Text = "Перегретый пар";
            if (Reg == 3) edtRegion.Text = "Критическая смесь";
            if (Reg == 4) edtRegion.Text = "Насыщенный пар";
            if (Reg == 5) edtRegion.Text = "Сверхперегретый пар";
            if (Reg != 0) MathVater();

            PutFormat();
            PrintDataVater();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            fmAbout fmAbout = new fmAbout();
            fmAbout.ShowDialog();
        }


    }
}
