using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COIN_GAME_UNEU_
{
    public static class Class1
    {
        public static class USER
        {
            public static int 돈 { get; set; }
        }
        public static class 사용자코인
            {
            public static int 보유수 { get; set; }
            public static string 코인이름 { get; set; }
            public static int  현재가격 { get; set; }
            public static int 과거가격 { get; set; }

            public static int 변동률 { get; set; }
        }
        public static class 코드아트코인
        {
            public static int 보유수 { get; set; }
            public static string 코인이름 { get; set; }
            public static int 현재가격 { get; set; }
            public static int 과거가격 { get; set; }

            public static int 변동률 { get; set; }
        }
    }
}
