using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace _13MoonDiary.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        //以2021/01/01為基準, 當天為Friday, KIN18, 超頻(5)白世界橋(18)
        private static DateTime baseDate = DateTime.Parse("Jan 1, 2021");
        private static int baseKIN = 18;
        private static int baseOrace = 18;
        private static int baseTone = 5;

        [BindProperty]
        public static List<MayanOracle> MayanOracles { get; set; }

        [BindProperty]
        public static List<Tone> MayanTones { get; set; }

        [BindProperty]
        public static List<CardInfo> WeekCardInfos { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            InitOracle();
            InitTone();

            var todayOracle = GetMayanOracleByDate(DateTime.Now.Date);
            var todayTone = GetToneByDate(DateTime.Now.Date);
            string todayKIN = GetKINByDate(DateTime.Now.Date);

            //從本週的第一天起取得連續七天的CardInfo
            DateTime dt = DateTime.Now.StartOfWeek(DayOfWeek.Monday);

            WeekCardInfos = GetWeekCardInfos(dt);
        }

        /// <summary>
        /// 初始化波符料
        /// </summary>
        public void InitOracle()
        {
            List<MayanOracle> oracles = new List<MayanOracle>
            {
                new MayanOracle
                {
                    id=1,
                    oracleEName="Dragon",
                    oracleName="紅龍",
                    oracleColor="Red",
                    oracleImgSrc="01-mayankin-marielamaya-bridgingworlds-tzolkin-red-dragon-glyph.png"
                },
                new MayanOracle
                {
                    id=2,
                    oracleEName="Wind",
                    oracleName="白風",
                    oracleColor="White",
                    oracleImgSrc="02-mayankin-marielamaya-bridgingworlds-tzolkin-white-wind-glyph.png"
                },
                new MayanOracle
                {
                    id=3,
                    oracleEName="Night",
                    oracleName="藍夜",
                    oracleColor="Blue",
                    oracleImgSrc="03-mayankin-marielamaya-bridgingworlds-tzolkin-blue-night-glyph.png"
                },
                new MayanOracle
                {
                    id=4,
                    oracleEName="Seed",
                    oracleName="黃種子",
                    oracleColor="Yellow",
                    oracleImgSrc="04-mayankin-marielamaya-bridgingworlds-tzolkin-yellow-seed-glyph.png"
                },
                new MayanOracle
                {
                    id=5,
                    oracleEName="Serpent",
                    oracleName="紅蛇",
                    oracleColor="Red",
                    oracleImgSrc="05-mayankin-marielamaya-bridgingworlds-tzolkin-red-serpent-glyph.png"
                },
                new MayanOracle
                {
                    id=6,
                    oracleEName="WorldBridger",
                    oracleName="白世界橋",
                    oracleColor="White",
                    oracleImgSrc="06-mayankin-marielamaya-bridgingworlds-tzolkin-white-world-bridger-glyph.png"
                },
                new MayanOracle
                {
                    id=7,
                    oracleEName="Hand",
                    oracleName="藍手",
                    oracleColor="Blue",
                    oracleImgSrc="07-mayankin-marielamaya-bridgingworlds-tzolkin-blue-hand-glyph.png"
                },
                new MayanOracle
                {
                    id=8,
                    oracleEName="Star",
                    oracleName="黃星星",
                    oracleColor="Yellow",
                    oracleImgSrc="08-mayankin-marielamaya-bridgingworlds-tzolkin-yellow-star-glyph.png"
                },
                new MayanOracle
                {
                    id=9,
                    oracleEName="Moon",
                    oracleName="紅月",
                    oracleColor="Red",
                    oracleImgSrc="09-mayankin-marielamaya-bridgingworlds-tzolkin-red-moon-glyph.png"
                },
                new MayanOracle
                {
                    id=10,
                    oracleEName="Dog",
                    oracleName="白狗",
                    oracleColor="White",
                    oracleImgSrc="10-mayankin-marielamaya-bridgingworlds-tzolkin-white-dog-glyph.png"
                },
                new MayanOracle
                {
                    id=11,
                    oracleEName="Monkey",
                    oracleName="藍猴",
                    oracleColor="Blue",
                    oracleImgSrc="11-mayankin-marielamaya-bridgingworlds-tzolkin-blue-monkey-glyph.png"
                },
                new MayanOracle
                {
                    id=12,
                    oracleEName="Human",
                    oracleName="黃人",
                    oracleColor="Yellow",
                    oracleImgSrc="12-mayankin-marielamaya-bridgingworlds-tzolkin-yellow-human-glyph.png"
                },
                new MayanOracle
                {
                    id=13,
                    oracleEName="SkyWalker",
                    oracleName="紅天行者",
                    oracleColor="Red",
                    oracleImgSrc="13-mayankin-marielamaya-bridgingworlds-tzolkin-red-skywalker-glyph.png"
                },
                new MayanOracle
                {
                    id=14,
                    oracleEName="Wizard",
                    oracleName="白巫師",
                    oracleColor="White",
                    oracleImgSrc="14-mayankin-marielamaya-bridgingworlds-tzolkin-white-wizard-glyph.png"
                },
                new MayanOracle
                {
                    id=15,
                    oracleEName="Eagle",
                    oracleName="藍鷹",
                    oracleColor="Blue",
                    oracleImgSrc="15-mayankin-marielamaya-bridgingworlds-tzolkin-blue-eagle-glyph.png"
                },
                new MayanOracle
                {
                    id=16,
                    oracleEName="Warrior",
                    oracleName="黃戰士",
                    oracleColor="Yellow",
                    oracleImgSrc="16-mayankin-marielamaya-bridgingworlds-tzolkin-yellow-warrior-glyph.png"
                },
                new MayanOracle
                {
                    id=17,
                    oracleEName="Earth",
                    oracleName="紅地球",
                    oracleColor="Red",
                    oracleImgSrc="17-mayankin-marielamaya-bridgingworlds-tzolkin-red-earth-glyph.png"
                },
                new MayanOracle
                {
                    id=18,
                    oracleEName="Mirror",
                    oracleName="白鏡",
                    oracleColor="White",
                    oracleImgSrc="18-mayankin-marielamaya-bridgingworlds-tzolkin-white-mirror-glyph.png"
                },
                new MayanOracle
                {
                    id=19,
                    oracleEName="Storm",
                    oracleName="藍風暴",
                    oracleColor="Blue",
                    oracleImgSrc="19-mayankin-marielamaya-bridgingworlds-tzolkin-blue-storm-glyph.png"
                },
                new MayanOracle
                {
                    id=20,
                    oracleEName="Sun",
                    oracleName="黃太陽",
                    oracleColor="Yellow",
                    oracleImgSrc="20-mayankin-marielamaya-bridgingworlds-tzolkin-yellow-sun-glyph.png"
                }

            };

            MayanOracles = oracles;
        }

        /// <summary>
        /// 初始化調性資料
        /// </summary>
        public void InitTone()
        {
            List<Tone> tones = new List<Tone>
            {
                new Tone
                {
                    id=1,
                    toneEName = "Magnetic",
                    toneName = "磁性",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-magnetic.png"
                },
                new Tone
                {
                    id=2,
                    toneEName = "Lunar",
                    toneName = "月亮",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-lunar.png"
                },
                new Tone
                {
                    id=3,
                    toneEName = "Electric",
                    toneName = "電力",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-electric.png"
                },
                new Tone
                {
                    id=4,
                    toneEName = "Self Existing",
                    toneName = "自我存在",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-self-existing.png"
                },
                new Tone
                {
                    id=5,
                    toneEName = "Overtone",
                    toneName = "超頻",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-overtone.png"
                },
                new Tone
                {
                    id=6,
                    toneEName = "Rhythmic",
                    toneName = "韻律",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-rhythmic.png"
                },
                new Tone
                {
                    id=7,
                    toneEName = "Resonant",
                    toneName = "共振",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-resonant.png"
                },
                new Tone
                {
                    id=8,
                    toneEName = "Galactic",
                    toneName = "銀河星系",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-galactic.png"
                },
                new Tone
                {
                    id=9,
                    toneEName = "Solar",
                    toneName = "太陽",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-solar.png"
                },
                new Tone
                {
                    id=10,
                    toneEName = "Planetary",
                    toneName = "行星",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-planetary.png"
                },
                new Tone
                {
                    id=11,
                    toneEName = "Spectral",
                    toneName = "光譜",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-spectral.png"
                },
                new Tone
                {
                    id=12,
                    toneEName = "Crystal",
                    toneName = "水晶",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-crystal.png"
                },
                new Tone
                {
                    id=13,
                    toneEName = "Cosmic",
                    toneName = "宇宙",
                    toneImgSrc = "mayankin-marielamaya-bridgingworlds-tzolkin-lunar-tone-cosmic.png"
                }
            };

            MayanTones = tones;
        }

        public MayanOracle GetMayanOracleByDate(DateTime dDate)
        {
            //波符為20天一個週期            
            int dateDiff = Convert.ToInt32((dDate - baseDate).TotalDays);
            int oracleIndex = dateDiff % 20;
            if(oracleIndex > 2)
            {
                oracleIndex = oracleIndex - 2;
            }
            else
            {
                oracleIndex = oracleIndex + baseOrace;
            }

            return MayanOracles[oracleIndex-1];
        }

        public Tone GetToneByDate(DateTime dDate)
        {
            //調性為13天一個週期            
            int dateDiff = Convert.ToInt32((dDate - baseDate).TotalDays);
            int toneIndex = dateDiff % 13;
            if (toneIndex > 8)
            {
                toneIndex = toneIndex - 8;
            }
            else
            {
                toneIndex = toneIndex + baseTone;
            }

            return MayanTones[toneIndex - 1];
        }

        public string GetKINByDate(DateTime dDate)
        {
            //KIN為260天一個週期
            int dateDiff = Convert.ToInt32((dDate - baseDate).TotalDays);
            int kinIndex = dateDiff % 260;
            if (kinIndex > 242)
            {
                kinIndex = kinIndex - 242;
            }
            else
            {
                kinIndex = kinIndex + baseKIN;
            }

            return string.Format("KIN{0}", kinIndex);
        }

        public List<CardInfo> GetWeekCardInfos(DateTime weekStartDate)
        {
            List<CardInfo> cards = new List<CardInfo>();

            for(int i=0; i<7; i++)
            {
                var dDate = weekStartDate.AddDays(i);
                var weekDayName = weekStartDate.AddDays(i).ToString("ddd");
                var oracle = GetMayanOracleByDate(weekStartDate.AddDays(i));
                var tone = GetToneByDate(weekStartDate.AddDays(i));
                var kin = GetKINByDate(weekStartDate.AddDays(i));

                var card = new CardInfo
                {
                    date = dDate,
                    weekDay = weekDayName,
                    mainOracle = oracle,
                    mainToen = tone,
                    mainKIN = kin
                };

                cards.Add(card);
            }

            return cards;
        }
    }

    public class MayanOracle
    {
        public int id;
        public string oracleEName;
        public string oracleName;
        public string oracleColor;
        public string oracleImgSrc;

        public MayanOracle()
        {
        }

        public MayanOracle(int id,  string oracleEName, string oracleName, string oracleColor, string oracleImgSrc)
        {
            this.id = id;
            this.oracleEName = oracleEName;
            this.oracleName = oracleName;
            this.oracleColor = oracleColor;
            this.oracleImgSrc = oracleImgSrc;
        }
    }

    public class Tone
    {
        public int id;
        public string toneEName;
        public string toneName;
        public string toneImgSrc;

        public Tone()
        {
        }

        public Tone(int id, string toneEName, string toneName, string toneImgSrc)
        {
            this.id = id;
            this.toneEName = toneEName;
            this.toneName = toneName;
            this.toneImgSrc = toneImgSrc;
        }
    }

    /// <summary>
    /// 每天顯示的資訊卡片內容
    /// </summary>
    public class CardInfo
    {
        public DateTime date;
        public string weekDay;
        public MayanOracle mainOracle;
        public Tone mainToen;
        public string mainKIN;

    }

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }

}
